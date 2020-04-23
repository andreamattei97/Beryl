using System;
using System.Collections.Generic;
using Beryl.Utilities.Extension;
using Beryl.Utilities.NodeSelection.PointSelection;
using Beryl.Utilities.Structures;

namespace Beryl.ODE
{
    public abstract class SinglestepODESolver
    {
        private enum SolverDirection
        {
            Unknown, Left, Right
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

        private Point2D _startingCoordinates;
        protected Point2D StartingCoordinates { get { return _startingCoordinates; } }

        protected readonly IDiscretizer discretizer;
        protected readonly PointSelector nodeSelector;

        private readonly int maxIterations;

        protected SinglestepODESolver(ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, int maxIterations)
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

            if (!initialConditions.CheckOrder(1))
                throw new ArgumentOutOfRangeException("initalContions", "the initial conditions are not compatible with the oreder of the method");

            _startingCoordinates = initialConditions.StartingPoint;
        }

        protected SinglestepODESolver(ODEFunction function, Point2D initialPoint, IDiscretizer discretizer, int maxIterations) : this(function, new ODEInitialConditions(initialPoint, new Point2D[0], new Point2D[0]), discretizer, maxIterations)
        { }

        protected SinglestepODESolver(ODEFunction function, ODEInitialConditions initialCondition, IDiscretizer discretizer, IODEOptimizer optimizer, int maxIterations) :
            this(function, initialCondition, discretizer, maxIterations)
        {
            nodeSelector = GenerateSelector(optimizer);
        }

        protected SinglestepODESolver(ODEFunction function, Point2D initialPoint, IDiscretizer discretizer, IODEOptimizer optimizer, int maxIterations) : this(function, new ODEInitialConditions(initialPoint, new Point2D[0], new Point2D[0]), discretizer, optimizer, maxIterations)
        { }

        private PointSelector GenerateSelector(IODEOptimizer optimizer)
        {

            LeftPointNode[] leftNodes = GenerateLeftNodes(optimizer.LeftPointDistribution());
            RightPointNode[] rightNodes = GenerateRightNodes(optimizer.RightPointDistribution());

            double rightCentralInterval = rightNodes.Length > 0 ? Math.Abs(rightNodes[0].Coordinates.x - _startingCoordinates.x) : double.PositiveInfinity;
            double leftCentralInterval = leftNodes.Length > 0 ? Math.Abs(leftNodes[0].Coordinates.x - _startingCoordinates.x) : double.PositiveInfinity;
            double rightStep = discretizer.CalculateRightStep(_startingCoordinates);
            double leftStep = discretizer.CalculateLeftStep(_startingCoordinates);
            CentralPointNode centralNode = new CentralPointNode(_startingCoordinates, rightStep, leftStep, rightCentralInterval, leftCentralInterval);

            return optimizer.SelectorGenerator(leftNodes, centralNode, rightNodes);
        }

        private RightPointNode[] GenerateRightNodes(int[] nodeDistribution)
        {

            if (nodeDistribution.Length == 0)
                return new RightPointNode[0];

            RightPointNode[] rightNodes = new RightPointNode[nodeDistribution.Length];
            Point2D previousNodeCoordinates = _startingCoordinates;
            Point2D currentNodeCoordinates = _startingCoordinates;
            
            for (int j = 0; j < nodeDistribution[0]; j++)
            {
                currentNodeCoordinates = Iteration(new StepPoint(currentNodeCoordinates, discretizer.CalculateRightStep(currentNodeCoordinates)));
            }
            previousNodeCoordinates = currentNodeCoordinates;

            for (int i = 0; i < nodeDistribution.Length - 1; i++)
            {
                for (int j = 0; j < nodeDistribution[i]; j++)
                {
                    currentNodeCoordinates = Iteration(new StepPoint(currentNodeCoordinates, discretizer.CalculateRightStep(currentNodeCoordinates)));
                }
                StepPoint newPoint = new StepPoint(previousNodeCoordinates, discretizer.CalculateRightStep(previousNodeCoordinates));
                rightNodes[i] = new RightPointNode(newPoint, Math.Abs(currentNodeCoordinates.x - previousNodeCoordinates.x));
                previousNodeCoordinates = currentNodeCoordinates;
            }

            rightNodes[nodeDistribution.Length - 1] = new RightPointNode(new StepPoint(currentNodeCoordinates, discretizer.CalculateRightStep(currentNodeCoordinates)), Double.PositiveInfinity);

            return rightNodes;
        }

        private LeftPointNode[] GenerateLeftNodes(int[] nodeDistribution)
        {

            if (nodeDistribution.Length == 0)
                return new LeftPointNode[0];

            LeftPointNode[] leftNodes = new LeftPointNode[nodeDistribution.Length];

            Point2D previousNodeCoordinates = _startingCoordinates;
            Point2D currentNodeCoordinates = _startingCoordinates;
            for(int j=0;j<nodeDistribution[0];j++)
            {
                currentNodeCoordinates = Iteration(new StepPoint(currentNodeCoordinates, discretizer.CalculateLeftStep(currentNodeCoordinates)));
            }
            previousNodeCoordinates = currentNodeCoordinates;
            for (int i = 0; i < nodeDistribution.Length - 1; i++)
            {
                for (int j = 0; j < nodeDistribution[i]; j++)
                {
                    currentNodeCoordinates = Iteration(new StepPoint(currentNodeCoordinates, discretizer.CalculateLeftStep(currentNodeCoordinates)));
                }
                StepPoint newPoint = new StepPoint(previousNodeCoordinates, discretizer.CalculateLeftStep(previousNodeCoordinates));
                leftNodes[i] = new LeftPointNode(newPoint, Math.Abs(previousNodeCoordinates.x - currentNodeCoordinates.x));
                previousNodeCoordinates = currentNodeCoordinates;
            }
            leftNodes[nodeDistribution.Length - 1] = new LeftPointNode(new StepPoint(currentNodeCoordinates, discretizer.CalculateLeftStep(currentNodeCoordinates)), Double.PositiveInfinity);
            
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

            StepPoint previousPoint;

            if (nodeSelector != null)
            {
                previousPoint = nodeSelector(x)[0];
                if (previousPoint.Coordinates.x < _startingCoordinates.x)
                    direction = SolverDirection.Left;
                else
                    direction = SolverDirection.Right;
            }
            else
            {
                if (direction == SolverDirection.Left)
                    previousPoint = new StepPoint(_startingCoordinates, discretizer.CalculateLeftStep(_startingCoordinates));
                else
                    previousPoint = new StepPoint(_startingCoordinates,discretizer.CalculateRightStep(_startingCoordinates));
            }

            if (direction == SolverDirection.Left)
                return SolveLeft(x, previousPoint);
            else
                return SolveRight(x, previousPoint);

        }

        private double SolveLeft(double x, StepPoint previousPoint)
        {
            double solution = 0;
            bool success = false;

            StepPoint currentPoint = previousPoint;

            for (int i = 0; i < maxIterations && !success; i++)
            {
                if (x > previousPoint.Coordinates.x)
                {
                    double intermediateStep = discretizer.IntermediateStep(x, previousPoint.Coordinates, currentPoint.Coordinates);
                    solution = Iteration(new StepPoint(previousPoint.Coordinates, intermediateStep)).y;
                    success = true;
                }
                else if (x == currentPoint.Coordinates.x)
                {
                    solution = currentPoint.Coordinates.y;
                    success = true;
                }
                else
                {
                    previousPoint = currentPoint;
                    Point2D newCoordinates=Iteration(currentPoint);
                    currentPoint = new StepPoint(newCoordinates, discretizer.CalculateLeftStep(newCoordinates));
                }
            }

            if (!success)
                throw new ODECalculationException("No convergence to the solution (exceded the maximum number of iterations)", function);

            return solution;
        }

        private double SolveRight(double x, StepPoint previousPoint)
        {
            double solution = 0;
            bool success = false;

            StepPoint currentPoint = previousPoint;

            for (int i = 0; i < maxIterations && !success; i++)
            {
                if (x < previousPoint.Coordinates.x)
                {
                    double intermediateStep = discretizer.IntermediateStep(x, previousPoint.Coordinates, currentPoint.Coordinates);
                    solution = Iteration(new StepPoint(previousPoint.Coordinates, intermediateStep)).y;
                    success = true;
                }
                else if (x == currentPoint.Coordinates.x)
                {
                    solution = currentPoint.Coordinates.y;
                    success = true;
                }
                else
                {
                    previousPoint = currentPoint;
                    Point2D newCoordinates = Iteration(currentPoint);
                    currentPoint = new StepPoint(newCoordinates, discretizer.CalculateRightStep(newCoordinates));
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
            for (int i = 0; i < x.Length; i++)
            {
                orderedX[i] = new OrderedX(x[i], i);
            }
            Array.Sort(orderedX, (OrderedX a, OrderedX b) =>
            {
                if (a.X > b.X)
                    return 1;
                else if (a.X == b.X)
                    return 0;
                else
                    return -1;
            });

            List<OrderedX> leftOrderedX = new List<OrderedX>();
            List<OrderedX> rightOrderedX = new List<OrderedX>();
            for (int i = 0; i < orderedX.Length; i++)
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

            StepPoint previousPoint = new StepPoint(_startingCoordinates,discretizer.CalculateLeftStep(_startingCoordinates));
            for (int i = leftOrderedX.Count - 1; i >= 0; i--)
            {
                double newSolution = SolveLeft(leftOrderedX[i].X, previousPoint);
                solutions[leftOrderedX[i].Position] = newSolution;
            }

            previousPoint = new StepPoint(_startingCoordinates,discretizer.CalculateRightStep(_startingCoordinates));
            for (int i = 0; i < rightOrderedX.Count; i++)
            {
                double newSolution = SolveRight(rightOrderedX[i].X, previousPoint);
                solutions[rightOrderedX[i].Position] = newSolution;
            }


            return solutions;
        }

        protected T MapSolve<T>(T map) where T : Beryl.Utilities.Structures.IMap<T>
        {
            return map.ApplyFunction(ArraySolve);
        }

        protected abstract Point2D Iteration(StepPoint previousPoint);

    }
}
