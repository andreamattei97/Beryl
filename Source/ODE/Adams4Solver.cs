﻿using System.Collections.Generic;
using Beryl.Utilities.Structures;
using Beryl.Utilities.NodeSelection.PointSelection;

namespace Beryl.ODE
{
    public class Adams4Solver : MultistepODESolver
    {
        //no optimizer
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer, int maxIterations)
        {
            return new Adams4Solver(function, initialConditions, auxiliaryIterator, discretizer, maxIterations).Solve;
        }

        //all parameters
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer, IODEOptimizer optimizer, int maxIterations)
        {
            return new Adams4Solver(function, initialConditions, auxiliaryIterator, discretizer, optimizer, maxIterations).Solve;
        }

        //no optimizer, no max iterations
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer)
        {
            return new Adams4Solver(function, initialConditions, auxiliaryIterator, discretizer, DefaultODEParameters.DefaultMaxIterations).Solve;
        }

        //no max iterations
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer, IODEOptimizer optimizer)
        {
            return new Adams4Solver(function, initialConditions, auxiliaryIterator, discretizer, optimizer, DefaultODEParameters.DefaultMaxIterations).Solve;
        }

        //no discretizer, no optimizer
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, int maxIterations)
        {
            return new Adams4Solver(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, maxIterations).Solve;
        }

        //no discretizer
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IODEOptimizer optimizer, int maxIterations)
        {
            return new Adams4Solver(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, optimizer, maxIterations).Solve;
        }

        //no auxiliary iterator, no optimizer
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, int maxIterations)
        {
            return new Adams4Solver(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, maxIterations).Solve;
        }

        //no auxiliary iterator
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, IODEOptimizer optimizer, int maxIterations)
        {
            return new Adams4Solver(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, optimizer, maxIterations).Solve;
        }

        //no discretizer, no max iterations, no optimizer
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator)
        {
            return new Adams4Solver(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations).Solve;
        }

        //no discretizer, no max iterations
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IODEOptimizer optimizer)
        {
            return new Adams4Solver(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, optimizer, DefaultODEParameters.DefaultMaxIterations).Solve;
        }

        //no auxiliary iterator,no optimizer ,no max iterations
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer)
        {
            return new Adams4Solver(function, initialConditions,DefaultODEParameters.DefaultauxiliaryIterator, discretizer, DefaultODEParameters.DefaultMaxIterations).Solve;
        }

        //no auxiliary iterator ,no max iterations
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, IODEOptimizer optimizer)
        {
            return new Adams4Solver(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, optimizer, DefaultODEParameters.DefaultMaxIterations).Solve;
        }

        //no auxiliary iterator, no discretizer, no optimizer
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, int maxIterations)
        {
            return new Adams4Solver(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, maxIterations).Solve;
        }

        //no auxiliary iterator, no discretizer
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, IODEOptimizer optimizer, int maxIterations)
        {
            return new Adams4Solver(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, optimizer, maxIterations).Solve;
        }

        //no auxiliary iterator, no discretizer, no optimizer, no max iterations
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions)
        {
            return new Adams4Solver(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations).Solve;
        }

        //no auxiliary iterator, no discretizer, no max iterations
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, IODEOptimizer optimizer)
        {
            return new Adams4Solver(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, optimizer, DefaultODEParameters.DefaultMaxIterations).Solve;
        }

        //all parameters
        public static ArrayFunction MakeArraySolution(ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer, int maxIterations)
        {
            return new Adams4Solver(function, initialConditions, auxiliaryIterator, discretizer, maxIterations).ArraySolve;
        }

        //no max iterations
        public static ArrayFunction MakeArraySolution(ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer)
        {
            return new Adams4Solver(function, initialConditions, auxiliaryIterator, discretizer, DefaultODEParameters.DefaultMaxIterations).ArraySolve;
        }

        //no discretizer
        public static ArrayFunction MakeArraySolution(ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, int maxIterations)
        {
            return new Adams4Solver(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, maxIterations).ArraySolve;
        }

        //no auxiliary iterator
        public static ArrayFunction MakeArraySolution(ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, int maxIterations)
        {
            return new Adams4Solver(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, maxIterations).ArraySolve;
        }

        //no discretizer, no max iterations
        public static ArrayFunction MakeArraySolution(ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator)
        {
            return new Adams4Solver(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations).ArraySolve;
        }

        //no auxiliary iterator, no max iterations
        public static ArrayFunction MakeArraySolution(ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer)
        {
            return new Adams4Solver(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, DefaultODEParameters.DefaultMaxIterations).ArraySolve;
        }

        //no auxiliary iterator, no discretizer
        public static ArrayFunction MakeArraySolution(ODEFunction function, ODEInitialConditions initialConditions, int maxIterations)
        {
            return new Adams4Solver(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, maxIterations).ArraySolve;
        }

        //no auxiliary iterator, no discretizer, no max iterations
        public static ArrayFunction MakeArraySolution(ODEFunction function, ODEInitialConditions initialConditions)
        {
            return new Adams4Solver(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations).ArraySolve;
        }

        private Adams4Solver(ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer, int maxIterations) : base(function, 4, initialConditions, auxiliaryIterator, discretizer, maxIterations)
        {
        }

        private Adams4Solver(ODEFunction function, ODEInitialConditions initialCondition, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer, IODEOptimizer optimizer, int maxIterations) : base(function, 4, initialCondition, auxiliaryIterator, discretizer, optimizer, maxIterations)
        {
        }

        protected override Vector2D Iteration(LinkedList<StepPoint> points)
        {
            LinkedListNode<StepPoint> currentNode = points.First;
            double x = currentNode.Value.Coordinates.x + currentNode.Value.Step;
            double h1 = currentNode.Value.Step;
            double y1 = currentNode.Value.Coordinates.y;
            currentNode = currentNode.Next;
            double h2 = currentNode.Value.Step;
            double y2 = currentNode.Value.Coordinates.y;
            currentNode = currentNode.Next;
            double h3 = currentNode.Value.Step;
            double y3 = currentNode.Value.Coordinates.y;
            currentNode = currentNode.Next;
            double h4 = currentNode.Value.Step;
            double y4 = currentNode.Value.Coordinates.y;


            double y= (6 * (h1 * h1) * (h2 * h2) * (h3 * h3 * h3) * y3 - 6 * (h1 * h1) * (h2 * h2) * (h4 * h4 * h4) * y2 + 12 * (h1 * h1) * (h2 * h2 * h2) * (h3 * h3) * y3 - 12 * (h1 * h1) * (h2 * h2 * h2) * (h4 * h4) * y2 + 6 * (h1 * h1) * (h3 * h3) * (h4 * h4 * h4) * y1 + 12 * (h1 * h1) * (h3 * h3 * h3) * (h4 * h4) * y1 + 12 * (h1 * h1 * h1) * (h2 * h2) * (h3 * h3) * y3 - 12 * (h1 * h1 * h1) * (h2 * h2) * (h4 * h4) * y2 + 12 * (h1 * h1 * h1) * (h3 * h3) * (h4 * h4) * y1 + 36 * (h2 * h2) * (h3 * h3) * (h4 * h4) * y1 - 6 * (h1 * h1) * (h2 * h2) * (h3 * h3 * h3) * y4 + 6 * (h1 * h1) * (h2 * h2) * (h4 * h4 * h4) * y3 - 12 * (h1 * h1) * (h2 * h2 * h2) * (h3 * h3) * y4 + 12 * (h1 * h1) * (h2 * h2 * h2) * (h4 * h4) * y3 - 6 * (h1 * h1) * (h3 * h3) * (h4 * h4 * h4) * y2 - 12 * (h1 * h1) * (h3 * h3 * h3) * (h4 * h4) * y2 - 12 * (h1 * h1 * h1) * (h2*h2) * (h3*h3) * y4 + 12 * (h1*h1*h1) * (h2*h2) * (h4*h4) * y3 - 12 * (h1*h1*h1) * (h3*h3) * (h4*h4) * y2 + 12 * h2 * (h3*h3*h3*h3) * h4 * y1 + 12 * h2 * (h3*h3) * (h4*h4*h4) * y1 + 24 * h2 * (h3*h3*h3) * (h4*h4) * y1 + 6 * (h1*h1) * (h2*h2*h2*h2) * h3 * y3 - 6 * (h1*h1) * (h2*h2*h2*h2) * h4 * y2 + 6 * (h1*h1) * (h3*h3*h3*h3) * h4 * y1 + 4 * (h1*h1*h1) * h2 * (h3*h3*h3) * y3 - 4 * (h1*h1*h1) * h2 * (h4*h4*h4) * y2 + 4 * (h1*h1*h1) * h3 * (h4*h4*h4) * y1 + 8 * (h1*h1*h1) * (h2*h2*h2) * h3 * y3 - 8 * (h1*h1*h1) * (h2*h2*h2) * h4 * y2 + 8 * (h1*h1*h1) * (h3*h3*h3) * h4 * y1 + 12 * (h2*h2) * h3 * (h4*h4*h4) * y1 + 24 * (h2*h2) * (h3*h3*h3) * h4 * y1 + 3 * (h1*h1*h1*h1) * h2 * (h3*h3) * y3 - 3 * (h1*h1*h1*h1) * h2 * (h4*h4) * y2 + 3 * (h1*h1*h1*h1) * h3 * (h4*h4) * y1 + 3 * (h1*h1*h1*h1) * (h2*h2) * h3 * y3 - 3 * (h1*h1*h1*h1) * (h2*h2) * h4 * y2 + 3 * (h1*h1*h1*h1) * (h3*h3) * h4 * y1 + 12 * (h2*h2*h2) * h3 * (h4*h4) * y1 + 12 * (h2*h2*h2) * (h3*h3) * h4 * y1 - 6 * (h1*h1) * (h2*h2*h2*h2) * h3 * y4 + 6 * (h1*h1) * (h2*h2*h2*h2) * h4 * y3 - 6 * (h1*h1) * (h3*h3*h3*h3) * h4 * y2 - 4 * (h1*h1*h1) * h2 * (h3*h3*h3) * y4 + 4 * (h1*h1*h1) * h2 * (h4*h4*h4) * y3 - 4 * (h1*h1*h1) * h3 * (h4*h4*h4) * y2 - 8 * (h1*h1*h1) * (h2*h2*h2) * h3 * y4 + 8 * (h1*h1*h1) * (h2*h2*h2) * h4 * y3 - 8 * (h1*h1*h1) * (h3*h3*h3) * h4 * y2 - 3 * (h1*h1*h1*h1) * h2 * (h3*h3) * y4 + 3 * (h1*h1*h1*h1) * h2 * (h4*h4) * y3 - 3 * (h1*h1*h1*h1) * h3 * (h4*h4) * y2 - 3 * (h1*h1*h1*h1) * (h2*h2) * h3 * y4 + 3 * (h1*h1*h1*h1) * (h2*h2) * h4 * y3 - 3 * (h1*h1*h1*h1) * (h3*h3) * h4 * y2 + 12 * h1 * h2 * (h3*h3) * (h4*h4*h4) * y1 + 24 * h1 * h2 * (h3*h3*h3) * (h4*h4) * y1 + 12 * h1 * (h2*h2) * h3 * (h4*h4*h4) * y1 + 24 * h1 * (h2*h2) * (h3*h3*h3) * h4 * y1 + 12 * h1 * (h2*h2*h2) * h3 * (h4*h4) * y1 + 12 * h1 * (h2*h2*h2) * (h3*h3) * h4 * y1 + 12 * (h1*h1) * h2 * h3 * (h4*h4*h4) * y1 + 24 * (h1*h1) * h2 * (h3*h3*h3) * h4 * y1 + 12 * (h1*h1*h1) * h2 * h3 * (h4*h4) * y1 + 12 * (h1*h1*h1) * h2 * (h3*h3) * h4 * y1 - 12 * (h1*h1) * h2 * h3 * (h4*h4*h4) * y2 - 24 * (h1*h1) * h2 * (h3*h3*h3) * h4 * y2 - 24 * (h1*h1) * (h2*h2*h2) * h3 * h4 * y2 - 24 * (h1*h1*h1) * h2 * h3 * (h4*h4) * y2 - 24 * (h1*h1*h1) * h2 * (h3*h3) * h4 * y2 - 24 * (h1*h1*h1) * (h2*h2) * h3 * h4 * y2 + 24 * (h1*h1) * (h2*h2*h2) * h3 * h4 * y3 + 12 * (h1*h1*h1) * h2 * h3 * (h4*h4) * y3 + 12 * (h1*h1*h1) * h2 * (h3*h3) * h4 * y3 + 24 * (h1*h1*h1) * (h2*h2) * h3 * h4 * y3 + 36 * h1 * (h2*h2) * (h3*h3) * (h4*h4) * y1 + 36 * (h1*h1) * h2 * (h3*h3) * (h4*h4) * y1 + 18 * (h1*h1) * (h2*h2) * h3 * (h4*h4) * y1 + 18 * (h1*h1) * (h2*h2) * (h3*h3) * h4 * y1 - 36 * (h1*h1) * h2 * (h3*h3) * (h4*h4) * y2 - 36 * (h1*h1) * (h2*h2) * h3 * (h4*h4) * y2 - 36 * (h1*h1) * (h2*h2) * (h3*h3) * h4 * y2 + 18 * (h1*h1) * (h2*h2) * h3 * (h4*h4) * y3 + 18 * (h1*h1) * (h2*h2) * (h3*h3) * h4 * y3 + 12 * h1 * h2 * (h3*h3*h3*h3) * h4 * y1 - 6 * (h1*h1*h1*h1) * h2 * h3 * h4 * y2 + 6 * (h1*h1*h1*h1) * h2 * h3 * h4 * y3) / (12 * h2 * h3 * h4 * (h2 + h3) * (h3 + h4) * (h2 + h3 + h4));
            return new Vector2D(x, y);
        }
    }
}