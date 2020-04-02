using Experimental.Beryl.Utilities.Structures;

namespace Beryl.ODE
{
    public static partial class ODEExtension
    {
        #region Adams2Solver

        //solvers

        //no optimizer
        public static Function Adams2Solve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer, int maxIterations)
        {
            return Adams2Solver.MakeSolution(function, initialConditions, auxiliaryIterator, discretizer, maxIterations);
        }

        //all parameters
        public static Function Adams2Solve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer, IODEOptimizer optimizer, int maxIterations)
        {
            return Adams2Solver.MakeSolution(function, initialConditions, auxiliaryIterator, discretizer, optimizer, maxIterations);
        }

        //no optimizer, no max iterations
        public static Function Adams2Solve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer)
        {
            return Adams2Solver.MakeSolution(function, initialConditions, auxiliaryIterator, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no max iterations
        public static Function Adams2Solve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer, IODEOptimizer optimizer)
        {
            return Adams2Solver.MakeSolution(function, initialConditions, auxiliaryIterator, discretizer, optimizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer, no optimizer
        public static Function Adams2Solve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, int maxIterations)
        {
            return Adams2Solver.MakeSolution(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no discretizer
        public static Function Adams2Solve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IODEOptimizer optimizer, int maxIterations)
        {
            return Adams2Solver.MakeSolution(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, optimizer, maxIterations);
        }

        //no auxiliary iterator, no optimizer
        public static Function Adams2Solve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, int maxIterations)
        {
            return Adams2Solver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, maxIterations);
        }

        //no auxiliary iterator
        public static Function Adams2Solve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, IODEOptimizer optimizer, int maxIterations)
        {
            return Adams2Solver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, optimizer, maxIterations);
        }

        //no discretizer, no max iterations, no optimizer
        public static Function Adams2Solve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator)
        {
            return Adams2Solver.MakeSolution(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer, no max iterations
        public static Function Adams2Solve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IODEOptimizer optimizer)
        {
            return Adams2Solver.MakeSolution(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, optimizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no auxiliary iterator,no optimizer ,no max iterations
        public static Function Adams2Solve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer)
        {
            return Adams2Solver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no auxiliary iterator ,no max iterations
        public static Function Adams2Solve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, IODEOptimizer optimizer)
        {
            return Adams2Solver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, optimizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no auxiliary iterator, no discretizer, no optimizer
        public static Function Adams2Solve(this ODEFunction function, ODEInitialConditions initialConditions, int maxIterations)
        {
            return Adams2Solver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no auxiliary iterator, no discretizer
        public static Function Adams2Solve(this ODEFunction function, ODEInitialConditions initialConditions, IODEOptimizer optimizer, int maxIterations)
        {
            return Adams2Solver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, optimizer, maxIterations);
        }

        //no auxiliary iterator, no discretizer, no optimizer, no max iterations
        public static Function Adams2Solve(this ODEFunction function, ODEInitialConditions initialConditions)
        {
            return Adams2Solver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no auxiliary iterator, no discretizer, no max iterations
        public static Function Adams2Solve(this ODEFunction function, ODEInitialConditions initialConditions, IODEOptimizer optimizer)
        {
            return Adams2Solver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, optimizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //array solver

        //all parameters
        public static ArrayFunction Adams2ArraySolve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer, int maxIterations)
        {
            return Adams2Solver.MakeArraySolution(function, initialConditions, auxiliaryIterator, discretizer, maxIterations);
        }

        //no max iterations
        public static ArrayFunction Adams2ArraySolve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer)
        {
            return Adams2Solver.MakeArraySolution(function, initialConditions, auxiliaryIterator, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer
        public static ArrayFunction Adams2ArraySolve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, int maxIterations)
        {
            return Adams2Solver.MakeArraySolution(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no auxiliary iterator
        public static ArrayFunction Adams2ArraySolve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, int maxIterations)
        {
            return Adams2Solver.MakeArraySolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, maxIterations);
        }

        //no discretizer, no max iterations
        public static ArrayFunction Adams2ArraySolve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator)
        {
            return Adams2Solver.MakeArraySolution(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no auxiliary iterator, no max iterations
        public static ArrayFunction Adams2ArraySolve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer)
        {
            return Adams2Solver.MakeArraySolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no auxiliary iterator, no discretizer
        public static ArrayFunction Adams2ArraySolve(this ODEFunction function, ODEInitialConditions initialConditions, int maxIterations)
        {
            return Adams2Solver.MakeArraySolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no auxiliary iterator, no discretizer, no max iterations
        public static ArrayFunction Adams2ArraySolve(this ODEFunction function, ODEInitialConditions initialConditions)
        {
            return Adams2Solver.MakeArraySolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //map solvers

        //all parameters
        public static MapFunction<T> Adams2MapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer, int maxIterations) where T:IMap<T>
        {
            return Adams2Solver.MakeMapSolution<T>(function, initialConditions, auxiliaryIterator, discretizer, maxIterations);
        }


        //no max iterations
        public static MapFunction<T> Adams2MapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer) where T : IMap<T>
        {
            return Adams2Solver.MakeMapSolution<T>(function, initialConditions, auxiliaryIterator, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer
        public static MapFunction<T> Adams2MapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, int maxIterations) where T : IMap<T>
        {
            return Adams2Solver.MakeMapSolution<T>(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no auxiliary iterator
        public static MapFunction<T> Adams2MapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, int maxIterations) where T : IMap<T>
        {
            return Adams2Solver.MakeMapSolution<T>(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, maxIterations);
        }

        //no discretizer, no max iterations
        public static MapFunction<T> Adams2MapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator) where T : IMap<T>
        {
            return Adams2Solver.MakeMapSolution<T>(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no auxiliary iterator, no max iterations
        public static MapFunction<T> Adams2MapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer) where T : IMap<T>
        {
            return Adams2Solver.MakeMapSolution<T>(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no auxiliary iterator, no discretizer
        public static MapFunction<T> Adams2MapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions, int maxIterations) where T : IMap<T>
        {
            return Adams2Solver.MakeMapSolution<T>(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no auxiliary iterator, no discretizer, no max iterations
        public static MapFunction<T> Adams2MapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions) where T : IMap<T>
        {
            return Adams2Solver.MakeMapSolution<T>(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        #endregion

        #region Adams3Solver

        //solvers

        //no optimizer
        public static Function Adams3Solve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer, int maxIterations)
        {
            return Adams3Solver.MakeSolution(function, initialConditions, auxiliaryIterator, discretizer, maxIterations);
        }

        //all parameters
        public static Function Adams3Solve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer, IODEOptimizer optimizer, int maxIterations)
        {
            return Adams3Solver.MakeSolution(function, initialConditions, auxiliaryIterator, discretizer, optimizer, maxIterations);
        }

        //no optimizer, no max iterations
        public static Function Adams3Solve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer)
        {
            return Adams3Solver.MakeSolution(function, initialConditions, auxiliaryIterator, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no max iterations
        public static Function Adams3Solve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer, IODEOptimizer optimizer)
        {
            return Adams3Solver.MakeSolution(function, initialConditions, auxiliaryIterator, discretizer, optimizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer, no optimizer
        public static Function Adams3Solve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, int maxIterations)
        {
            return Adams3Solver.MakeSolution(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no discretizer
        public static Function Adams3Solve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IODEOptimizer optimizer, int maxIterations)
        {
            return Adams3Solver.MakeSolution(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, optimizer, maxIterations);
        }

        //no auxiliary iterator, no optimizer
        public static Function Adams3Solve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, int maxIterations)
        {
            return Adams3Solver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, maxIterations);
        }

        //no auxiliary iterator
        public static Function Adams3Solve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, IODEOptimizer optimizer, int maxIterations)
        {
            return Adams3Solver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, optimizer, maxIterations);
        }

        //no discretizer, no max iterations, no optimizer
        public static Function Adams3Solve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator)
        {
            return Adams3Solver.MakeSolution(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer, no max iterations
        public static Function Adams3Solve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IODEOptimizer optimizer)
        {
            return Adams3Solver.MakeSolution(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, optimizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no auxiliary iterator,no optimizer ,no max iterations
        public static Function Adams3Solve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer)
        {
            return Adams3Solver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no auxiliary iterator ,no max iterations
        public static Function Adams3Solve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, IODEOptimizer optimizer)
        {
            return Adams3Solver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, optimizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no auxiliary iterator, no discretizer, no optimizer
        public static Function Adams3Solve(this ODEFunction function, ODEInitialConditions initialConditions, int maxIterations)
        {
            return Adams3Solver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no auxiliary iterator, no discretizer
        public static Function Adams3Solve(this ODEFunction function, ODEInitialConditions initialConditions, IODEOptimizer optimizer, int maxIterations)
        {
            return Adams3Solver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, optimizer, maxIterations);
        }

        //no auxiliary iterator, no discretizer, no optimizer, no max iterations
        public static Function Adams3Solve(this ODEFunction function, ODEInitialConditions initialConditions)
        {
            return Adams3Solver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no auxiliary iterator, no discretizer, no max iterations
        public static Function Adams3Solve(this ODEFunction function, ODEInitialConditions initialConditions, IODEOptimizer optimizer)
        {
            return Adams3Solver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, optimizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //array solver

        //all parameters
        public static ArrayFunction Adams3ArraySolve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer, int maxIterations)
        {
            return Adams3Solver.MakeArraySolution(function, initialConditions, auxiliaryIterator, discretizer, maxIterations);
        }

        //no max iterations
        public static ArrayFunction Adams3ArraySolve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer)
        {
            return Adams3Solver.MakeArraySolution(function, initialConditions, auxiliaryIterator, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer
        public static ArrayFunction Adams3ArraySolve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, int maxIterations)
        {
            return Adams3Solver.MakeArraySolution(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no auxiliary iterator
        public static ArrayFunction Adams3ArraySolve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, int maxIterations)
        {
            return Adams3Solver.MakeArraySolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, maxIterations);
        }

        //no discretizer, no max iterations
        public static ArrayFunction Adams3ArraySolve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator)
        {
            return Adams3Solver.MakeArraySolution(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no auxiliary iterator, no max iterations
        public static ArrayFunction Adams3ArraySolve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer)
        {
            return Adams3Solver.MakeArraySolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no auxiliary iterator, no discretizer
        public static ArrayFunction Adams3ArraySolve(this ODEFunction function, ODEInitialConditions initialConditions, int maxIterations)
        {
            return Adams3Solver.MakeArraySolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no auxiliary iterator, no discretizer, no max iterations
        public static ArrayFunction Adams3ArraySolve(this ODEFunction function, ODEInitialConditions initialConditions)
        {
            return Adams3Solver.MakeArraySolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //map solvers

        //all parameters
        public static MapFunction<T> Adams3MapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer, int maxIterations) where T : IMap<T>
        {
            return Adams3Solver.MakeMapSolution<T>(function, initialConditions, auxiliaryIterator, discretizer, maxIterations);
        }

        //no max iterations
        public static MapFunction<T> Adams3MapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer) where T : IMap<T>
        {
            return Adams3Solver.MakeMapSolution<T>(function, initialConditions, auxiliaryIterator, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer
        public static MapFunction<T> Adams3MapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, int maxIterations) where T : IMap<T>
        {
            return Adams3Solver.MakeMapSolution<T>(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no auxiliary iterator
        public static MapFunction<T> Adams3MapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, int maxIterations) where T : IMap<T>
        {
            return Adams3Solver.MakeMapSolution<T>(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, maxIterations);
        }

        //no discretizer, no max iterations
        public static MapFunction<T> Adams3MapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator) where T : IMap<T>
        {
            return Adams3Solver.MakeMapSolution<T>(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no auxiliary iterator, no max iterations
        public static MapFunction<T> Adams3MapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer) where T : IMap<T>
        {
            return Adams3Solver.MakeMapSolution<T>(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no auxiliary iterator, no discretizer
        public static MapFunction<T> Adams3MapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions, int maxIterations) where T : IMap<T>
        {
            return Adams3Solver.MakeMapSolution<T>(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no auxiliary iterator, no discretizer, no max iterations
        public static MapFunction<T> Adams3MapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions) where T : IMap<T>
        {
            return Adams3Solver.MakeMapSolution<T>(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        #endregion

        #region Adams4Solver

        //solvers

        //no optimizer
        public static Function Adams4Solve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer, int maxIterations)
        {
            return Adams4Solver.MakeSolution(function, initialConditions, auxiliaryIterator, discretizer, maxIterations);
        }

        //all parameters
        public static Function Adams4Solve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer, IODEOptimizer optimizer, int maxIterations)
        {
            return Adams4Solver.MakeSolution(function, initialConditions, auxiliaryIterator, discretizer, optimizer, maxIterations);
        }

        //no optimizer, no max iterations
        public static Function Adams4Solve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer)
        {
            return Adams4Solver.MakeSolution(function, initialConditions, auxiliaryIterator, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no max iterations
        public static Function Adams4Solve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer, IODEOptimizer optimizer)
        {
            return Adams4Solver.MakeSolution(function, initialConditions, auxiliaryIterator, discretizer, optimizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer, no optimizer
        public static Function Adams4Solve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, int maxIterations)
        {
            return Adams4Solver.MakeSolution(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no discretizer
        public static Function Adams4Solve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IODEOptimizer optimizer, int maxIterations)
        {
            return Adams4Solver.MakeSolution(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, optimizer, maxIterations);
        }

        //no auxiliary iterator, no optimizer
        public static Function Adams4Solve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, int maxIterations)
        {
            return Adams4Solver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, maxIterations);
        }

        //no auxiliary iterator
        public static Function Adams4Solve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, IODEOptimizer optimizer, int maxIterations)
        {
            return Adams4Solver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, optimizer, maxIterations);
        }

        //no discretizer, no max iterations, no optimizer
        public static Function Adams4Solve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator)
        {
            return Adams4Solver.MakeSolution(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer, no max iterations
        public static Function Adams4Solve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IODEOptimizer optimizer)
        {
            return Adams4Solver.MakeSolution(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, optimizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no auxiliary iterator,no optimizer ,no max iterations
        public static Function Adams4Solve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer)
        {
            return Adams4Solver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no auxiliary iterator ,no max iterations
        public static Function Adams4Solve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, IODEOptimizer optimizer)
        {
            return Adams4Solver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, optimizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no auxiliary iterator, no discretizer, no optimizer
        public static Function Adams4Solve(this ODEFunction function, ODEInitialConditions initialConditions, int maxIterations)
        {
            return Adams4Solver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no auxiliary iterator, no discretizer
        public static Function Adams4Solve(this ODEFunction function, ODEInitialConditions initialConditions, IODEOptimizer optimizer, int maxIterations)
        {
            return Adams4Solver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, optimizer, maxIterations);
        }

        //no auxiliary iterator, no discretizer, no optimizer, no max iterations
        public static Function Adams4Solve(this ODEFunction function, ODEInitialConditions initialConditions)
        {
            return Adams4Solver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no auxiliary iterator, no discretizer, no max iterations
        public static Function Adams4Solve(this ODEFunction function, ODEInitialConditions initialConditions, IODEOptimizer optimizer)
        {
            return Adams4Solver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, optimizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //array solver

        //all parameters
        public static ArrayFunction Adams4ArraySolve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer, int maxIterations)
        {
            return Adams4Solver.MakeArraySolution(function, initialConditions, auxiliaryIterator, discretizer, maxIterations);
        }

        //no max iterations
        public static ArrayFunction Adams4ArraySolve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer)
        {
            return Adams4Solver.MakeArraySolution(function, initialConditions, auxiliaryIterator, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer
        public static ArrayFunction Adams4ArraySolve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, int maxIterations)
        {
            return Adams4Solver.MakeArraySolution(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no auxiliary iterator
        public static ArrayFunction Adams4ArraySolve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, int maxIterations)
        {
            return Adams4Solver.MakeArraySolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, maxIterations);
        }

        //no discretizer, no max iterations
        public static ArrayFunction Adams4ArraySolve(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator)
        {
            return Adams4Solver.MakeArraySolution(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no auxiliary iterator, no max iterations
        public static ArrayFunction Adams4ArraySolve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer)
        {
            return Adams4Solver.MakeArraySolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no auxiliary iterator, no discretizer
        public static ArrayFunction Adams4ArraySolve(this ODEFunction function, ODEInitialConditions initialConditions, int maxIterations)
        {
            return Adams4Solver.MakeArraySolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no auxiliary iterator, no discretizer, no max iterations
        public static ArrayFunction Adams4ArraySolve(this ODEFunction function, ODEInitialConditions initialConditions)
        {
            return Adams4Solver.MakeArraySolution(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //map solvers

        //all parameters
        public static MapFunction<T> Adams4MapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer, int maxIterations) where T : IMap<T>
        {
            return Adams4Solver.MakeMapSolution<T>(function, initialConditions, auxiliaryIterator, discretizer, maxIterations);
        }

        //no max iterations
        public static MapFunction<T> Adams4MapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, IDiscretizer discretizer) where T : IMap<T>
        {
            return Adams4Solver.MakeMapSolution<T>(function, initialConditions, auxiliaryIterator, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer
        public static MapFunction<T> Adams4MapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, int maxIterations) where T : IMap<T>
        {
            return Adams4Solver.MakeMapSolution<T>(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no auxiliary iterator
        public static MapFunction<T> Adams4MapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, int maxIterations) where T : IMap<T>
        {
            return Adams4Solver.MakeMapSolution<T>(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, maxIterations);
        }

        //no discretizer, no max iterations
        public static MapFunction<T> Adams4MapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator) where T : IMap<T>
        {
            return Adams4Solver.MakeMapSolution<T>(function, initialConditions, auxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no auxiliary iterator, no max iterations
        public static MapFunction<T> Adams4MapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer) where T : IMap<T>
        {
            return Adams4Solver.MakeMapSolution<T>(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no auxiliary iterator, no discretizer
        public static MapFunction<T> Adams4MapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions, int maxIterations) where T : IMap<T>
        {
            return Adams4Solver.MakeMapSolution<T>(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no auxiliary iterator, no discretizer, no max iterations
        public static MapFunction<T> Adams4MapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions) where T : IMap<T>
        {
            return Adams4Solver.MakeMapSolution<T>(function, initialConditions, DefaultODEParameters.DefaultauxiliaryIterator, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        #endregion
    }
}