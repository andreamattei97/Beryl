using System;
using System.Collections.Generic;
using Beryl.Utilities.NodeSelection;
using Beryl.Utilities.Structures;
/*
namespace Beryl.ODE
{
    public abstract class StandardODESolver
    {
        public const int DEFAULT_MAX_ITERATIONS = 10000;
        public const double DEFAULT_DISCRETIZER_STEP = 0.001;

        private readonly int maxIterations;
        private readonly IDiscretizer discretizer;
        private readonly Point2D initialCondition;
        private readonly NodeSelector nodeSelector;
        protected readonly ODEFunction function;

        protected StandardODESolver(ODEFunction function, Point2D initialCondition, IDiscretizer discretizer, int maxIterations = DEFAULT_MAX_ITERATIONS)
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
            if (!initialCondition.IsFinite())
                throw new ArgumentOutOfRangeException("initialCondition", "Non-finite initial condition");
            this.initialCondition = initialCondition;
        }

        protected StandardODESolver(ODEFunction function, Point2D initialCondition, IDiscretizer discretizer, OptimizationOptions options, int maxIterations = DEFAULT_MAX_ITERATIONS):
            this(function,initialCondition,discretizer,maxIterations)
        {
            nodeSelector = GenerateSelector(options);
        }

        //calculates the optimization nodes and generates the related node selector
        private NodeSelector GenerateSelector(OptimizationOptions options)
        {
            List<Point2D> rightNodes = new List<Point2D>(options.RightIntervals);
            Point2D currentNode = initialCondition;
            for (int i = 0; i < options.RightIntervals; i++)
            {
                for (int j = 0; j < options.RightIntervalsSpan; j++)
                {
                    currentNode = Iteration(currentNode, discretizer.CalculateRightStep(currentNode));
                }
                rightNodes.Add(currentNode);
            }

            List<Point2D> leftNodes = new List<Point2D>(options.LeftIntervals);
            currentNode = initialCondition;
            for (int i = 0; i < options.LeftIntervals; i++)
            {
                for (int j = 0; j < options.LeftIntervalsSpan; j++)
                {
                    currentNode = Iteration(currentNode, discretizer.CalculateLeftStep(currentNode));
                }
                leftNodes.Add(currentNode);
            }

            return options.SelectorGenerator(initialCondition, rightNodes, leftNodes);
        }

        //calculates the value of the solution in the given point
        public double Solve(double x)
        {
            if (!x.IsFinite())
                throw new ArgumentOutOfRangeException("x", "the input point is not finited");

            if (x == initialCondition.x)//if the searched point is the initial one returns directly it
                return initialCondition.y;

            Point2D solution = new Point2D();
            Point2D previousNode, nextNode;
            if (nodeSelector != null)
            {
                previousNode = nodeSelector(x);
                nextNode = previousNode;
            }
            else
            {
                previousNode = initialCondition;
                nextNode = previousNode;
            }
            if (x > initialCondition.x)
            {
                for (int i = 0; i < maxIterations; i++)
                {
                    if (x < nextNode.x)
                    {
                        double intermediateStep = discretizer.IntermediateStep(x, previousNode, nextNode);
                        solution = Iteration(previousNode, intermediateStep);
                        break;
                    }
                    else if (x == nextNode.x)
                    {
                        solution = nextNode;
                        break;
                    }
                    else
                    {
                        previousNode = nextNode;
                        nextNode = Iteration(nextNode, discretizer.CalculateRightStep(nextNode));
                    }
                }
            }
            else
            {
                for (int i = 0; i < maxIterations; i++)
                {
                    if (x > nextNode.x)
                    {
                        double intermediateStep = discretizer.IntermediateStep(x, previousNode, nextNode);
                        solution = Iteration(previousNode, intermediateStep);
                        break;
                    }
                    else if (x == nextNode.x)
                    {
                        solution = nextNode;
                        break;
                    }
                    else
                    {
                        previousNode = nextNode;
                        nextNode = Iteration(nextNode, discretizer.CalculateLeftStep(nextNode));
                    }
                }
            }
            return solution.y;
        }

        //calculates the value of the solution in the given points
        public Point2D[] Solve(double[] x)
        {
            //the linked list used for constructing the ordered vector
            LinkedList<Point2D> solutionsList = new LinkedList<Point2D>();

            List<double> leftPoints = new List<double>(); //all points less than the initial point
            List<double> rightPoints = new List<double>(); //all points greater than the inital point

            //divides the points in left and right ones
            foreach (double point in x)
            {
                if (point > initialCondition.x)
                    rightPoints.Add(point);
                else if (point < initialCondition.x)
                    leftPoints.Add(point);
                else //if the point is the starting one no need to calculate it
                    solutionsList.AddFirst(initialCondition);
            }

            leftPoints.Sort((double n1, double n2) => -n1.CompareTo(n2));
            rightPoints.Sort();

            List<Point2D> rightSolutions = SolveRight(rightPoints);
            for (int i = 0; i < rightSolutions.Count; i++)
            {
                solutionsList.AddLast(rightSolutions[i]);
            }

            List<Point2D> leftSolutions = SolveLeft(leftPoints);
            for (int i = 0; i < leftSolutions.Count; i++)
            {
                solutionsList.AddFirst(leftSolutions[i]);
            }

            Point2D[] array = new Point2D[solutionsList.Count];
            solutionsList.CopyTo(array, 0);
            return array;
        }

        //calculates the value of the solution of points greater than the initial one
        private List<Point2D> SolveRight(List<double> rightPoints)
        {

            List<Point2D> solutions = new List<Point2D>(rightPoints.Count);

            Point2D previousNode = initialCondition; //the second-last calculated node
            Point2D nextNode = initialCondition; //the last calculated node

            int iterations = 0; //number of iterations (an iteration is the calculation of a node)
            for (int i = 0; i < rightPoints.Count && iterations < maxIterations; i++)
            {
                double currentPoint = rightPoints[i];
                while (iterations < maxIterations)
                {
                    if (nextNode.x < currentPoint)
                    {
                        double step = discretizer.CalculateRightStep(nextNode);

                        previousNode = nextNode;
                        nextNode = Iteration(nextNode, step);
                        iterations++;
                    }
                    if (nextNode.x == currentPoint)
                    {
                        solutions.Add(nextNode);
                        break;
                    }
                    else if (currentPoint < nextNode.x)
                    {
                        double intermediateStep = discretizer.IntermediateStep(currentPoint, previousNode, nextNode);
                        solutions.Add(Iteration(previousNode, intermediateStep));
                        break;
                    }
                }
            }
            return solutions;
        }

        //calculates the value of the solution of points less than the initial one
        private List<Point2D> SolveLeft(List<double> leftPoints)
        {

            List<Point2D> solutions = new List<Point2D>(leftPoints.Count);

            Point2D previousNode = initialCondition; //the second-last calculated node
            Point2D nextNode = initialCondition; //the last calculated node

            int iterations = 0; //number of iterations (an iteration is the calculation of a node)
            for (int i = 0; i < leftPoints.Count && iterations < maxIterations; i++)
            {
                double currentPoint = leftPoints[i];
                while (iterations < maxIterations)
                {
                    if (nextNode.x > currentPoint)
                    {
                        double step = discretizer.CalculateLeftStep(nextNode);

                        previousNode = nextNode;
                        nextNode = Iteration(nextNode, step);
                        iterations++;
                    }
                    if (nextNode.x == currentPoint)
                    {
                        solutions.Add(nextNode);
                        break;
                    }
                    else if (currentPoint > nextNode.x)
                    {
                        double intermediateStep = discretizer.IntermediateStep(currentPoint, previousNode, nextNode);
                        solutions.Add(Iteration(previousNode, intermediateStep));
                        break;
                    }
                }
            }
            return solutions;
        }

        //calculates the next iteration of the method
        protected abstract Point2D Iteration(StepPoint point);
    }
}
*/