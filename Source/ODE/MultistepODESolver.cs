using System;
using System.Collections.Generic;
using Beryl.Utilities.Extension;
using Beryl.Utilities.NodeSelection.PointSelection;
using Beryl.Utilities.Structures;


namespace Beryl.ODE
{
    public abstract class MultistepODESolver
    {
        private enum SolverDirection
        {
            Unknown,Left,Right
        }

        private struct OrderedX
        {
            public double X
            {
                get;
            }
            public int Position
            {
                get;
            }

            public OrderedX(double x, int position)
            {
                if (!x.IsFinite())
                    throw new ArgumentOutOfRangeException("x", "non-finite abscissa");
                X = x;
                if (position < 0)
                    throw new ArgumentOutOfRangeException("position", "negative position");
                Position = position;
            }
        }

        protected readonly ODEFunction function;

        protected readonly int order;

        private Point2D _startingCoordinates;
        protected Point2D StartingCoordinates { get { return _startingCoordinates; } }
        private readonly StepPoint[] _leftInitialPoints;
        protected StepPoint[] LeftInitialPoints
        {
            get
            {
                return (StepPoint[])_leftInitialPoints.Clone();
            }
        }
        private readonly StepPoint[] _rightInitialPoints;
        protected StepPoint[] RightInitialPoints
        {
            get
            {
                return (StepPoint[])_rightInitialPoints.Clone();
            }
        }


        protected readonly SingleStepIteration auxiliaryIterator;

        protected readonly IDiscretizer discretizer;
        protected readonly PointSelector nodeSelector;

        private readonly int maxIterations;

        protected MultistepODESolver(ODEFunction function, int order, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer, int maxIterations)
        {
            if (discretizer == null)
                throw new ArgumentNullException("discretizer", "Null discretizer passed");
            this.discretizer = discretizer;

            if (function == null)
                throw new ArgumentNullException("function", "Null function passed");
            this.function = function;

            if (maxIterations <= 0)
                throw new ArgumentOutOfRangeException("maxIterations", "The number of maximum iterations must be positive");
            this.maxIterations = maxIterations;

            if (auxiliaryIterator == null)
                throw new ArgumentNullException("auxiliaryIterator","Null auxiliary single step method iterator passed");
            this.auxiliaryIterator = auxiliaryIterator;

            if (order <= 0)
                throw new ArgumentOutOfRangeException("order", "The order of the solver must be positive");
            this.order = order;

            if (!initialConditions.CheckOrder(order))
                throw new ArgumentOutOfRangeException("initalContions", "the initial conditions are not compatible with the oreder of the method");

            _startingCoordinates = initialConditions.StartingPoint;

            _leftInitialPoints = new StepPoint[order];
            _rightInitialPoints = new StepPoint[order];
            GenerateIntialPoints(initialConditions);
        }

        protected MultistepODESolver(ODEFunction function, int order, ODEInitialConditions initialCondition, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer, IODEOptimizer optimizer, int maxIterations) :
            this(function, order, initialCondition, auxiliaryIterator, discretizer, maxIterations)
        {
            nodeSelector = GenerateSelector(optimizer);
        }

        private void GenerateIntialPoints(ODEInitialConditions initialCondition)
        {
            int i = order-1;
            if (initialCondition.LeftPoints.Length > 0)
            {
                _leftInitialPoints[i] = new StepPoint(initialCondition.StartingPoint, initialCondition.LeftPoints[0].x - initialCondition.StartingPoint.x);
                i--;
                int j = 1;
                for (; i >= 0 && j < initialCondition.LeftPoints.Length; j++)
                {
                    _leftInitialPoints[i] = new StepPoint(initialCondition.LeftPoints[j - 1], initialCondition.LeftPoints[j].x - initialCondition.LeftPoints[j - 1].x);
                    i--;
                }
                if (i >= 0)
                {
                    _leftInitialPoints[i] = new StepPoint(initialCondition.LeftPoints[j-1],discretizer.CalculateLeftStep(initialCondition.LeftPoints[j-1]));
                    i--;
                }
            }
            else
            {
                _leftInitialPoints[i] = new StepPoint(initialCondition.StartingPoint, discretizer.CalculateLeftStep(initialCondition.StartingPoint));
                i--;
            }
        

            while (i >= 0)
            {
                Point2D newPoint = auxiliaryIterator(function,_leftInitialPoints[i + 1]);
                _leftInitialPoints[i] = new StepPoint(newPoint, discretizer.CalculateLeftStep(newPoint));
                i--;
            }

            i = order - 1;
            if (initialCondition.RightPoints.Length > 0)
            {
                _rightInitialPoints[i] = new StepPoint(initialCondition.StartingPoint, initialCondition.RightPoints[0].x - initialCondition.StartingPoint.x);
                i--;
                int j = 1;
                for (; i >= 0 && j < initialCondition.RightPoints.Length; j++)
                {
                    _rightInitialPoints[i] = new StepPoint(initialCondition.RightPoints[j - 1], initialCondition.RightPoints[j].x - initialCondition.RightPoints[j - 1].x);
                    i--;
                }
                if (i >= 0)
                {
                    _rightInitialPoints[i] = new StepPoint(initialCondition.RightPoints[j - 1], discretizer.CalculateRightStep(initialCondition.RightPoints[j - 1]));
                    i--;
                }
            }
            else
            {
                _rightInitialPoints[i] = new StepPoint(initialCondition.StartingPoint, discretizer.CalculateRightStep(initialCondition.StartingPoint));
                i--;
            }

            while (i >= 0)
            {
                Point2D newPoint = auxiliaryIterator(function, _rightInitialPoints[i + 1]);
                _rightInitialPoints[i] = new StepPoint(newPoint, discretizer.CalculateRightStep(newPoint));
                i--;
            }
        }

        private PointSelector GenerateSelector(IODEOptimizer optimizer)
        {

            LeftPointNode[] leftNodes = GenerateLeftNodes(optimizer.LeftPointDistribution());
            RightPointNode[] rightNodes = GenerateRightNodes(optimizer.RightPointDistribution());

            double rightCentralInterval = rightNodes.Length > 0 ? Math.Abs(rightNodes[0].Coordinates.x - _startingCoordinates.x) : double.PositiveInfinity;
            double leftCentralInterval = leftNodes.Length > 0 ? Math.Abs(leftNodes[0].Coordinates.x - _startingCoordinates.x) : double.PositiveInfinity;
            double rightStep = discretizer.CalculateRightStep(_startingCoordinates);
            double leftStep = discretizer.CalculateLeftStep(_startingCoordinates);
            CentralPointNode centralNode = new CentralPointNode(_startingCoordinates, RightInitialPoints, LeftInitialPoints, rightCentralInterval, leftCentralInterval);

            return optimizer.SelectorGenerator(leftNodes, centralNode, rightNodes);
        }

        private RightPointNode[] GenerateRightNodes(int[] nodeDistribution)
        {

            if (nodeDistribution.Length == 0)
                return new RightPointNode[0];

            RightPointNode[] rightNodes = new RightPointNode[nodeDistribution.Length];

            LinkedList<StepPoint> previousPoints = new LinkedList<StepPoint>(_rightInitialPoints);
            int i = 0;
            int currentNodeIndex = 0;
            Point2D currentPoint = previousPoints.First.Value.Coordinates;


            for (; i < nodeDistribution[0]; i++)
            {
                currentPoint = IterateRight(previousPoints).Coordinates;
            }
            i = 0;
            StepPoint currentNodePoint = previousPoints.First.Value;
            StepPoint[] currentNodePreviousPoints = previousPoints.ToArray().SubSegment(1, order-1);
            for (; currentNodeIndex < nodeDistribution.Length - 1; currentNodeIndex++)
            {
                for (; i < nodeDistribution[currentNodeIndex + 1]; i++)
                {
                    currentPoint = IterateRight(previousPoints).Coordinates;
                }
                i = 0;
                rightNodes[currentNodeIndex] = new RightPointNode(currentNodePoint, Math.Abs(currentNodePoint.Coordinates.x - previousPoints.First.Value.Coordinates.x), currentNodePreviousPoints);
                currentNodePoint = previousPoints.First.Value;
                currentNodePreviousPoints = previousPoints.ToArray().SubSegment(1, order-1);
            }

            rightNodes[rightNodes.Length - 1] = new RightPointNode(currentNodePoint, Double.PositiveInfinity, currentNodePreviousPoints);

            return rightNodes;
        }

        private LeftPointNode[] GenerateLeftNodes(int[] nodeDistribution)
        {

            if (nodeDistribution.Length == 0)
                return new LeftPointNode[0];

            LeftPointNode[] leftNodes = new LeftPointNode[nodeDistribution.Length];

            LinkedList<StepPoint> previousPoints = new LinkedList<StepPoint>(_leftInitialPoints);
            int i = 0;
            int currentNodeIndex = 0;
            Point2D currentPoint = previousPoints.First.Value.Coordinates;
            
            
            for(;i<nodeDistribution[0];i++)
            {
                currentPoint = IterateLeft(previousPoints).Coordinates;
            }
            i = 0;
            StepPoint currentNodePoint = previousPoints.First.Value;
            StepPoint[] currentNodePreviousPoints = previousPoints.ToArray().SubSegment(1, order-1);
            for(;currentNodeIndex<nodeDistribution.Length-1;currentNodeIndex++)
            {
                for(;i<nodeDistribution[currentNodeIndex+1];i++)
                {
                    currentPoint = IterateLeft(previousPoints).Coordinates;
                }
                i = 0;
                leftNodes[currentNodeIndex] = new LeftPointNode(currentNodePoint, Math.Abs(currentNodePoint.Coordinates.x - previousPoints.First.Value.Coordinates.x), currentNodePreviousPoints);
                currentNodePoint = previousPoints.First.Value;
                currentNodePreviousPoints = previousPoints.ToArray().SubSegment(1, order-1);
            }

            leftNodes[leftNodes.Length - 1] = new LeftPointNode(currentNodePoint, Double.PositiveInfinity, currentNodePreviousPoints);

            return leftNodes;
        }

        protected double Solve(double x)
        {
            if (!x.IsFinite())
                throw new ArgumentOutOfRangeException("x", "the input point is not finited");

            SolverDirection direction = SolverDirection.Unknown;

            if (x == _startingCoordinates.x)//if the searched point is the initial one returns directly it
                return _startingCoordinates.y;
            else if (x > _startingCoordinates.x)
                direction = SolverDirection.Right;
            else
                direction = SolverDirection.Left;

            LinkedList<StepPoint> previousPoints = null;

            if(nodeSelector!=null)
            {
                previousPoints=new LinkedList<StepPoint>(nodeSelector(x));
                if (previousPoints.First.Value.Coordinates.x < _startingCoordinates.x)
                    direction = SolverDirection.Left;
                else
                    direction = SolverDirection.Right;
            }
            else
            {
                if (direction == SolverDirection.Left)
                    previousPoints = new LinkedList<StepPoint>(_leftInitialPoints);
                else
                    previousPoints = new LinkedList<StepPoint>(_rightInitialPoints);
            }

            if (direction == SolverDirection.Left)
                return SolveLeft(x,previousPoints);
            else
                return SolveRight(x,previousPoints);

        }

        private double SolveLeft(double x, LinkedList<StepPoint> previousPoints)
        {
            double solution = 0;
            bool success = false;
            if (x <= previousPoints.Last.Value.Coordinates.x && x > previousPoints.First.Value.Coordinates.x)
            {
                for(var point=previousPoints.Last;point!=previousPoints.First;point=point.Previous)
                {
                    if (x == point.Value.Coordinates.x)
                    {
                        solution = point.Value.Coordinates.y;
                        success = true;
                    }
                    else if (x > point.Value.Coordinates.x + point.Value.Step && point.Value.Coordinates.x > x)
                    {
                        solution = auxiliaryIterator(function, new StepPoint(point.Value.Coordinates, discretizer.IntermediateStep(x, point.Value.Coordinates, point.Previous.Value.Coordinates))).y;
                        success = true;
                    }
                }
            }
            for (int i = 0; i < maxIterations && !success; i++)
            {
                if (x > previousPoints.First.Value.Coordinates.x)
                {
                    StepPoint secondPoint = previousPoints.First.Next.Value;
                    double intermediateStep = discretizer.IntermediateStep(x, secondPoint.Coordinates, previousPoints.First.Value.Coordinates);
                    solution = auxiliaryIterator(function, new StepPoint(secondPoint.Coordinates, intermediateStep)).y;
                    success = true;
                }
                else if (x == previousPoints.First.Value.Coordinates.x)
                {
                    solution = previousPoints.First.Value.Coordinates.y;
                    success = true;
                }
                else
                {
                    IterateLeft(previousPoints);
                }
            }

            if (!success)
                throw new ODECalculationException("No convergence to the solution (exceded the maximum number of iterations)", function);

            return solution;
        }

        private double SolveRight(double x, LinkedList<StepPoint> previousPoints)
        {
            double solution = 0;
            bool success = false;
            if (x >= previousPoints.Last.Value.Coordinates.x && x < previousPoints.First.Value.Coordinates.x)
            {
                for (var point = previousPoints.Last; point != previousPoints.First; point = point.Previous)
                {
                    if (x == point.Value.Coordinates.x)
                    {
                        solution = point.Value.Coordinates.y;
                        success = true;
                    }
                    else if (x < point.Value.Coordinates.x + point.Value.Step && point.Value.Coordinates.x < x)
                    {
                        solution = auxiliaryIterator(function, new StepPoint(point.Value.Coordinates, discretizer.IntermediateStep(x, point.Value.Coordinates, point.Previous.Value.Coordinates))).y;
                        success = true;
                    }
                }
            }
            for (int i = 0; i < maxIterations && !success; i++)
            {
                if (x < previousPoints.First.Value.Coordinates.x)
                {
                    StepPoint secondPoint = previousPoints.First.Next.Value;
                    double intermediateStep = discretizer.IntermediateStep(x, secondPoint.Coordinates, previousPoints.First.Value.Coordinates);
                    solution = auxiliaryIterator(function, new StepPoint(secondPoint.Coordinates, intermediateStep)).y;
                    success = true;
                }
                else if (x == previousPoints.First.Value.Coordinates.x)
                {
                    solution = previousPoints.First.Value.Coordinates.y;
                    success = true;
                }
                else
                {
                    IterateRight(previousPoints);
                }
            }

            if (!success)
                throw new ODECalculationException("No convergence to the solution (exceded the maximum number of iterations)", function);

            return solution;
        }
        
        protected double[] ArraySolve(double[] x)
        {
            if (x.IsFinite())
                throw new ArgumentOutOfRangeException("x", "the input point is not finited");
            double[] solutions = new double[x.Length];
            OrderedX[] orderedX = new OrderedX[x.Length];
            for(int i=0;i<x.Length;i++)
            {
                orderedX[i] = new OrderedX(x[i], i);
            }
            Array.Sort(orderedX,(OrderedX a, OrderedX b) =>
            {
                if (a.X > b.X)
                    return 1;
                else if (a.X == b.X)
                    return 0;
                else
                    return -1;
            });
            
            List<OrderedX> leftOrderedX= new List<OrderedX>();
            List<OrderedX> rightOrderedX = new List<OrderedX>();
            for(int i=0;i<orderedX.Length;i++)
            {
                if (orderedX[i].X < _startingCoordinates.x)
                {
                    leftOrderedX.Add(orderedX[i]);
                }
                else
                {
                    rightOrderedX.Add(orderedX[i]);
                }

            }

            LinkedList<StepPoint> previousPoints = new LinkedList<StepPoint>(_leftInitialPoints);
            for(int i=leftOrderedX.Count-1;i>=0;i--)
            {
                double newSolution = SolveLeft(leftOrderedX[i].X, previousPoints);
                solutions[leftOrderedX[i].Position] = newSolution;
            }

            previousPoints = new LinkedList<StepPoint>(_rightInitialPoints);
            for (int i = 0; i < rightOrderedX.Count; i++)
            {
                double newSolution = SolveRight(rightOrderedX[i].X, previousPoints);
                solutions[rightOrderedX[i].Position] = newSolution;
            }


            return solutions;
        }

        private StepPoint IterateRight(LinkedList<StepPoint> previousPoints)
        {
            Point2D currentPoint = Iteration(previousPoints);
            StepPoint newPoint = new StepPoint(currentPoint, discretizer.CalculateRightStep(currentPoint));
            previousPoints.RemoveLast();
            previousPoints.AddFirst(newPoint);
            return newPoint;
        }

        private StepPoint IterateLeft(LinkedList<StepPoint> previousPoints)
        {
            Point2D currentPoint = Iteration(previousPoints);
            StepPoint newPoint = new StepPoint(currentPoint, discretizer.CalculateLeftStep(currentPoint));
            previousPoints.RemoveLast();
            previousPoints.AddFirst(newPoint);
            return newPoint;
        }

        protected abstract Point2D Iteration(LinkedList<StepPoint> points);
        
    }
}
