﻿using Beryl.Utilities.NodeSelection.PointSelection;
using Beryl.Utilities.Structures;
using Experimental.Beryl.Utilities.Structures;
using System.Collections.Generic;

namespace Beryl.ODE
{
    public class Adams2Solver:MultistepODESolver
    {
        #region Solver

        //no optimizer
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer, int maxIterations)
        {
            return new Adams2Solver(function, initialConditions, auxiliaryIterator, discretizer, maxIterations).Solve;
        }

        //all parameters
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer, IODEOptimizer optimizer, int maxIterations)
        {
            return new Adams2Solver(function, initialConditions, auxiliaryIterator, discretizer, optimizer, maxIterations).Solve;
        }

        //no optimizer, no max iterations
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer)
        {
            return new Adams2Solver(function, initialConditions, auxiliaryIterator, discretizer, DefaultODEParameters.DefaultMaxIterations).Solve;
        }

        //no max iterations
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer, IODEOptimizer optimizer)
        {
            return new Adams2Solver(function, initialConditions, auxiliaryIterator, discretizer, optimizer, DefaultODEParameters.DefaultMaxIterations).Solve;
        }

        //no discretizer, no optimizer
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, int maxIterations)
        {
            return new Adams2Solver(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, maxIterations).Solve;
        }

        //no discretizer
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IODEOptimizer optimizer, int maxIterations)
        {
            return new Adams2Solver(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, optimizer, maxIterations).Solve;
        }

        //no auxiliary iterator, no optimizer
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, int maxIterations)
        {
            return new Adams2Solver(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, maxIterations).Solve;
        }

        //no auxiliary iterator
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, IODEOptimizer optimizer, int maxIterations)
        {
            return new Adams2Solver(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, optimizer, maxIterations).Solve;
        }

        //no discretizer, no max iterations, no optimizer
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator)
        {
            return new Adams2Solver(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations).Solve;
        }

        //no discretizer, no max iterations
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IODEOptimizer optimizer)
        {
            return new Adams2Solver(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, optimizer, DefaultODEParameters.DefaultMaxIterations).Solve;
        }

        //no auxiliary iterator,no optimizer ,no max iterations
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer)
        {
            return new Adams2Solver(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, DefaultODEParameters.DefaultMaxIterations).Solve;
        }

        //no auxiliary iterator ,no max iterations
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, IODEOptimizer optimizer)
        {
            return new Adams2Solver(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, optimizer, DefaultODEParameters.DefaultMaxIterations).Solve;
        }

        //no auxiliary iterator, no discretizer, no optimizer
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, int maxIterations)
        {
            return new Adams2Solver(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, maxIterations).Solve;
        }

        //no auxiliary iterator, no discretizer
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, IODEOptimizer optimizer, int maxIterations)
        {
            return new Adams2Solver(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, optimizer, maxIterations).Solve;
        }

        //no auxiliary iterator, no discretizer, no optimizer, no max iterations
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions)
        {
            return new Adams2Solver(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations).Solve;
        }

        //no auxiliary iterator, no discretizer, no max iterations
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, IODEOptimizer optimizer)
        {
            return new Adams2Solver(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, optimizer, DefaultODEParameters.DefaultMaxIterations).Solve;
        }

        #endregion

        #region ArraySolver

        //all parameters
        public static ArrayFunction MakeArraySolution(ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer, int maxIterations)
        {
            return new Adams2Solver(function, initialConditions, auxiliaryIterator, discretizer, maxIterations).ArraySolve;
        }

        //no max iterations
        public static ArrayFunction MakeArraySolution(ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer)
        {
            return new Adams2Solver(function, initialConditions, auxiliaryIterator, discretizer, DefaultODEParameters.DefaultMaxIterations).ArraySolve;
        }

        //no discretizer
        public static ArrayFunction MakeArraySolution(ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, int maxIterations)
        {
            return new Adams2Solver(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, maxIterations).ArraySolve;
        }

        //no auxiliary iterator
        public static ArrayFunction MakeArraySolution(ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, int maxIterations)
        {
            return new Adams2Solver(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, maxIterations).ArraySolve;
        }

        //no discretizer, no max iterations
        public static ArrayFunction MakeArraySolution(ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator)
        {
            return new Adams2Solver(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations).ArraySolve;
        }

        //no auxiliary iterator, no max iterations
        public static ArrayFunction MakeArraySolution(ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer)
        {
            return new Adams2Solver(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, DefaultODEParameters.DefaultMaxIterations).ArraySolve;
        }

        //no auxiliary iterator, no discretizer
        public static ArrayFunction MakeArraySolution(ODEFunction function, ODEInitialConditions initialConditions, int maxIterations)
        {
            return new Adams2Solver(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, maxIterations).ArraySolve;
        }

        //no auxiliary iterator, no discretizer, no max iterations
        public static ArrayFunction MakeArraySolution(ODEFunction function, ODEInitialConditions initialConditions)
        {
            return new Adams2Solver(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations).ArraySolve;
        }

        #endregion

        #region MapSolver

        //all parameters
        public static MapFunction<T> MakeMapSolution<T>(ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer, int maxIterations) where T : IMap<T>
        {
            return new Adams2Solver(function, initialConditions, auxiliaryIterator, discretizer, maxIterations).MapSolve<T>;
        }

        //no max iterations
        public static MapFunction<T> MakeMapSolution<T>(ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer) where T : IMap<T>
        {
            return new Adams2Solver(function, initialConditions, auxiliaryIterator, discretizer, DefaultODEParameters.DefaultMaxIterations).MapSolve<T>;
        }

        //no discretizer
        public static MapFunction<T> MakeMapSolution<T>(ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, int maxIterations) where T : IMap<T>
        {
            return new Adams2Solver(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, maxIterations).MapSolve<T>;
        }

        //no auxiliary iterator
        public static MapFunction<T> MakeMapSolution<T>(ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, int maxIterations) where T : IMap<T>
        {
            return new Adams2Solver(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, maxIterations).MapSolve<T>;
        }

        //no discretizer, no max iterations
        public static MapFunction<T> MakeMapSolution<T>(ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator) where T : IMap<T>
        {
            return new Adams2Solver(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations).MapSolve<T>;
        }

        //no auxiliary iterator, no max iterations
        public static MapFunction<T> MakeMapSolution<T>(ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer) where T : IMap<T>
        {
            return new Adams2Solver(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, DefaultODEParameters.DefaultMaxIterations).MapSolve<T>;
        }

        //no auxiliary iterator, no discretizer
        public static MapFunction<T> MakeMapSolution<T>(ODEFunction function, ODEInitialConditions initialConditions, int maxIterations) where T : IMap<T>
        {
            return new Adams2Solver(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, maxIterations).MapSolve<T>;
        }

        //no auxiliary iterator, no discretizer, no max iterations
        public static MapFunction<T> MakeMapSolution<T>(ODEFunction function, ODEInitialConditions initialConditions) where T : IMap<T>
        {
            return new Adams2Solver(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations).MapSolve<T>;
        }

        #endregion

        private Adams2Solver(ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer, int maxIterations) : base(function, 2, initialConditions, auxiliaryIterator, discretizer, maxIterations)
        {
        }

        private Adams2Solver(ODEFunction function, ODEInitialConditions initialCondition, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer, IODEOptimizer optimizer, int maxIterations) : base(function, 2, initialCondition, auxiliaryIterator, discretizer, optimizer, maxIterations)
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


            double y = ((y1 - y2) * h1 * h1) / (2 * h2) + y1 * h1 + y1;
            return new Vector2D(x, y);
        }
    }
}
