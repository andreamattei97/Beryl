using Beryl.Utilities.Structures;
using Experimental.Beryl.Utilities.Structures;

namespace Beryl.ODE
{
    public static partial class ODEExtension
    {

        #region EulerSolver

        //solvers

        //no optimizer - ODEInitialConditions initial condition
        public static Function EulerSolve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, int maxIterations)
        {
            return EulerSolver.MakeSolution(function, initialConditions, discretizer, maxIterations);
        }

        //no optimizer - Vector2D initial condition
        public static Function EulerSolve(this ODEFunction function, Vector2D initialPoint, IDiscretizer discretizer, int maxIterations)
        {
            return EulerSolver.MakeSolution(function, initialPoint, discretizer, maxIterations);
        }

        //all parameters - ODEInitialConditions initial condition
        public static Function EulerSolve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, IODEOptimizer optimizer, int maxIterations)
        {
            return EulerSolver.MakeSolution(function, initialConditions, discretizer, optimizer, maxIterations);
        }

        //all parameters - Vector2D initial condition
        public static Function EulerSolve(this ODEFunction function, Vector2D initialConditions, IDiscretizer discretizer, IODEOptimizer optimizer, int maxIterations)
        {
            return EulerSolver.MakeSolution(function, initialConditions, discretizer, optimizer, maxIterations);
        }

        //no optimizer, no max iterations - ODEInitialConditions initial condition
        public static Function EulerSolve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer)
        {
            return EulerSolver.MakeSolution(function, initialConditions, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no optimizer, no max iterations - Vector2D initial condition
        public static Function EulerSolve(this ODEFunction function, Vector2D initialPoint, IDiscretizer discretizer)
        {
            return EulerSolver.MakeSolution(function, initialPoint, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no max iterations - ODEInitialConditions initial condition
        public static Function EulerSolve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, IODEOptimizer optimizer)
        {
            return EulerSolver.MakeSolution(function, initialConditions, discretizer, optimizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no max iterations - Vector2D initial condition
        public static Function EulerSolve(this ODEFunction function, Vector2D initialPoint, IDiscretizer discretizer, IODEOptimizer optimizer)
        {
            return EulerSolver.MakeSolution(function, initialPoint, discretizer, optimizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer, no optimizer - ODEInitialConditions initial condition
        public static Function EulerSolve(this ODEFunction function, ODEInitialConditions initialConditions, int maxIterations)
        {
            return EulerSolver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no discretizer, no optimizer - Vector2D initial condition
        public static Function EulerSolve(this ODEFunction function, Vector2D initialPoint, int maxIterations)
        {
            return EulerSolver.MakeSolution(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no discretizer - ODEInitialConditions initial condition
        public static Function EulerSolve(this ODEFunction function, ODEInitialConditions initialConditions, IODEOptimizer optimizer, int maxIterations)
        {
            return EulerSolver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, optimizer, maxIterations);
        }

        //no discretizer - Vector2D initial condition
        public static Function EulerSolve(this ODEFunction function, Vector2D initialPoint, IODEOptimizer optimizer, int maxIterations)
        {
            return EulerSolver.MakeSolution(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, optimizer, maxIterations);
        }

        //no discretizer, no max iterations, no optimizer - ODEInitialConditions initial condition
        public static Function EulerSolve(this ODEFunction function, ODEInitialConditions initialConditions)
        {
            return EulerSolver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer, no max iterations, no optimizer - Vector2D initial condition
        public static Function EulerSolve(this ODEFunction function, Vector2D initialPoint)
        {
            return EulerSolver.MakeSolution(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer, no max iterations - ODEInitialConditions initial condition
        public static Function EulerSolve(this ODEFunction function, ODEInitialConditions initialConditions, IODEOptimizer optimizer)
        {
            return EulerSolver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, optimizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer, no max iterations - Vector2D initial condition
        public static Function EulerSolve(this ODEFunction function, Vector2D initialPoint, IODEOptimizer optimizer)
        {
            return EulerSolver.MakeSolution(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, optimizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //array solver

        //all parameters - ODEInitialConditions initial condition
        public static ArrayFunction EulerArraySolve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, int maxIterations)
        {
            return EulerSolver.MakeArraySolution(function, initialConditions, discretizer, maxIterations);
        }

        //all parameters - Vector2D initial condition
        public static ArrayFunction EulerArraySolve(this ODEFunction function, Vector2D initialPoint, IDiscretizer discretizer, int maxIterations)
        {
            return EulerSolver.MakeArraySolution(function, initialPoint, discretizer, maxIterations);
        }

        //no max iterations - ODEInitialConditions initial condition
        public static ArrayFunction EulerArraySolve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer)
        {
            return EulerSolver.MakeArraySolution(function, initialConditions, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no max iterations - Vector2D initial condition
        public static ArrayFunction EulerArraySolve(this ODEFunction function, Vector2D initialPoint, IDiscretizer discretizer)
        {
            return EulerSolver.MakeArraySolution(function, initialPoint, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer - ODEInitialConditions initial condition
        public static ArrayFunction EulerArraySolve(this ODEFunction function, ODEInitialConditions initialConditions, int maxIterations)
        {
            return EulerSolver.MakeArraySolution(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no discretizer - Vector2D initial condition
        public static ArrayFunction EulerArraySolve(this ODEFunction function, Vector2D initialPoint, int maxIterations)
        {
            return EulerSolver.MakeArraySolution(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no discretizer, no max iterations - ODEInitialConditions initial condition
        public static ArrayFunction EulerArraySolve(this ODEFunction function, ODEInitialConditions initialConditions)
        {
            return EulerSolver.MakeArraySolution(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer, no max iterations - Vector2D initial condition
        public static ArrayFunction EulerArraySolve(this ODEFunction function, Vector2D initialPoint)
        {
            return EulerSolver.MakeArraySolution(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //MapSolver

        //all parameters - ODEInitialConditions initial condition
        public static MapFunction<T> EulerMapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, int maxIterations) where T:IMap<T>
        {
            return EulerSolver.MakeMapSolution<T>(function, initialConditions, discretizer, maxIterations);
        }

        //all parameters - Vector2D initial condition
        public static MapFunction<T> EulerMapSolve<T>(this ODEFunction function, Vector2D initialPoint, IDiscretizer discretizer, int maxIterations) where T : IMap<T>
        {
            return EulerSolver.MakeMapSolution<T>(function, initialPoint, discretizer, maxIterations);
        }

        //no max iterations - ODEInitialConditions initial condition
        public static MapFunction<T> EulerMapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer) where T : IMap<T>
        {
            return EulerSolver.MakeMapSolution<T>(function, initialConditions, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no max iterations - Vector2D initial condition
        public static MapFunction<T> EulerMapSolve<T>(this ODEFunction function, Vector2D initialPoint, IDiscretizer discretizer) where T : IMap<T>
        {
            return EulerSolver.MakeMapSolution<T>(function, initialPoint, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer - ODEInitialConditions initial condition
        public static MapFunction<T> EulerMapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions, int maxIterations) where T : IMap<T>
        {
            return EulerSolver.MakeMapSolution<T>(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no discretizer - Vector2D initial condition
        public static MapFunction<T> EulerMapSolve<T>(this ODEFunction function, Vector2D initialPoint, int maxIterations) where T : IMap<T>
        {
            return EulerSolver.MakeMapSolution<T>(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no discretizer, no max iterations - ODEInitialConditions initial condition
        public static MapFunction<T> EulerMapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions) where T : IMap<T>
        {
            return EulerSolver.MakeMapSolution<T>(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer, no max iterations - Vector2D initial condition
        public static MapFunction<T> EulerMapSolve<T>(this ODEFunction function, Vector2D initialPoint) where T : IMap<T>
        {
            return EulerSolver.MakeMapSolution<T>(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        #endregion

        #region HeunSolver

        //solvers

        //no optimizer - ODEInitialConditions initial condition
        public static Function HeunSolve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, int maxIterations)
        {
            return HeunSolver.MakeSolution(function, initialConditions, discretizer, maxIterations);
        }

        //no optimizer - Vector2D initial condition
        public static Function HeunSolve(this ODEFunction function, Vector2D initialPoint, IDiscretizer discretizer, int maxIterations)
        {
            return EulerSolver.MakeSolution(function, initialPoint, discretizer, maxIterations);
        }

        //all parameters - ODEInitialConditions initial condition
        public static Function HeunSolve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, IODEOptimizer optimizer, int maxIterations)
        {
            return EulerSolver.MakeSolution(function, initialConditions, discretizer, optimizer, maxIterations);
        }

        //all parameters - Vector2D initial condition
        public static Function HeunSolve(this ODEFunction function, Vector2D initialConditions, IDiscretizer discretizer, IODEOptimizer optimizer, int maxIterations)
        {
            return HeunSolver.MakeSolution(function, initialConditions, discretizer, optimizer, maxIterations);
        }

        //no optimizer, no max iterations - ODEInitialConditions initial condition
        public static Function HeunSolve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer)
        {
            return HeunSolver.MakeSolution(function, initialConditions, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no optimizer, no max iterations - Vector2D initial condition
        public static Function HeunSolve(this ODEFunction function, Vector2D initialPoint, IDiscretizer discretizer)
        {
            return HeunSolver.MakeSolution(function, initialPoint, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no max iterations - ODEInitialConditions initial condition
        public static Function HeunSolve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, IODEOptimizer optimizer)
        {
            return HeunSolver.MakeSolution(function, initialConditions, discretizer, optimizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no max iterations - Vector2D initial condition
        public static Function HeunSolve(this ODEFunction function, Vector2D initialPoint, IDiscretizer discretizer, IODEOptimizer optimizer)
        {
            return HeunSolver.MakeSolution(function, initialPoint, discretizer, optimizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer, no optimizer - ODEInitialConditions initial condition
        public static Function HeunSolve(this ODEFunction function, ODEInitialConditions initialConditions, int maxIterations)
        {
            return HeunSolver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no discretizer, no optimizer - Vector2D initial condition
        public static Function HeunSolve(this ODEFunction function, Vector2D initialPoint, int maxIterations)
        {
            return HeunSolver.MakeSolution(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no discretizer - ODEInitialConditions initial condition
        public static Function HeunSolve(this ODEFunction function, ODEInitialConditions initialConditions, IODEOptimizer optimizer, int maxIterations)
        {
            return HeunSolver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, optimizer, maxIterations);
        }

        //no discretizer - Vector2D initial condition
        public static Function HeunSolve(this ODEFunction function, Vector2D initialPoint, IODEOptimizer optimizer, int maxIterations)
        {
            return HeunSolver.MakeSolution(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, optimizer, maxIterations);
        }

        //no discretizer, no max iterations, no optimizer - ODEInitialConditions initial condition
        public static Function HeunSolve(this ODEFunction function, ODEInitialConditions initialConditions)
        {
            return HeunSolver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer, no max iterations, no optimizer - Vector2D initial condition
        public static Function HeunSolve(this ODEFunction function, Vector2D initialPoint)
        {
            return HeunSolver.MakeSolution(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer, no max iterations - ODEInitialConditions initial condition
        public static Function HeunSolve(this ODEFunction function, ODEInitialConditions initialConditions, IODEOptimizer optimizer)
        {
            return HeunSolver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, optimizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer, no max iterations - Vector2D initial condition
        public static Function HeunSolve(this ODEFunction function, Vector2D initialPoint, IODEOptimizer optimizer)
        {
            return HeunSolver.MakeSolution(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, optimizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //array solver

        //all parameters - ODEInitialConditions initial condition
        public static ArrayFunction HeunArraySolve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, int maxIterations)
        {
            return HeunSolver.MakeArraySolution(function, initialConditions, discretizer, maxIterations);
        }

        //all parameters - Vector2D initial condition
        public static ArrayFunction HeunArraySolve(this ODEFunction function, Vector2D initialPoint, IDiscretizer discretizer, int maxIterations)
        {
            return HeunSolver.MakeArraySolution(function, initialPoint, discretizer, maxIterations);
        }

        //no max iterations - ODEInitialConditions initial condition
        public static ArrayFunction HeunArraySolve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer)
        {
            return HeunSolver.MakeArraySolution(function, initialConditions, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no max iterations - Vector2D initial condition
        public static ArrayFunction HeunArraySolve(this ODEFunction function, Vector2D initialPoint, IDiscretizer discretizer)
        {
            return HeunSolver.MakeArraySolution(function, initialPoint, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer - ODEInitialConditions initial condition
        public static ArrayFunction HeunArraySolve(this ODEFunction function, ODEInitialConditions initialConditions, int maxIterations)
        {
            return HeunSolver.MakeArraySolution(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no discretizer - Vector2D initial condition
        public static ArrayFunction HeunArraySolve(this ODEFunction function, Vector2D initialPoint, int maxIterations)
        {
            return HeunSolver.MakeArraySolution(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no discretizer, no max iterations - ODEInitialConditions initial condition
        public static ArrayFunction HeunArraySolve(this ODEFunction function, ODEInitialConditions initialConditions)
        {
            return HeunSolver.MakeArraySolution(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer, no max iterations - Vector2D initial condition
        public static ArrayFunction HeunArraySolve(this ODEFunction function, Vector2D initialPoint)
        {
            return HeunSolver.MakeArraySolution(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //MapSolver

        //all parameters - ODEInitialConditions initial condition
        public static MapFunction<T> HeunMapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, int maxIterations) where T : IMap<T>
        {
            return HeunSolver.MakeMapSolution<T>(function, initialConditions, discretizer, maxIterations);
        }

        //all parameters - Vector2D initial condition
        public static MapFunction<T> HeunMapSolve<T>(this ODEFunction function, Vector2D initialPoint, IDiscretizer discretizer, int maxIterations) where T : IMap<T>
        {
            return HeunSolver.MakeMapSolution<T>(function, initialPoint, discretizer, maxIterations);
        }

        //no max iterations - ODEInitialConditions initial condition
        public static MapFunction<T> HeunMapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer) where T : IMap<T>
        {
            return HeunSolver.MakeMapSolution<T>(function, initialConditions, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no max iterations - Vector2D initial condition
        public static MapFunction<T> HeunMapSolve<T>(this ODEFunction function, Vector2D initialPoint, IDiscretizer discretizer) where T : IMap<T>
        {
            return HeunSolver.MakeMapSolution<T>(function, initialPoint, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer - ODEInitialConditions initial condition
        public static MapFunction<T> HeunMapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions, int maxIterations) where T : IMap<T>
        {
            return HeunSolver.MakeMapSolution<T>(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no discretizer - Vector2D initial condition
        public static MapFunction<T> HeunMapSolve<T>(this ODEFunction function, Vector2D initialPoint, int maxIterations) where T : IMap<T>
        {
            return HeunSolver.MakeMapSolution<T>(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no discretizer, no max iterations - ODEInitialConditions initial condition
        public static MapFunction<T> HeunMapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions) where T : IMap<T>
        {
            return HeunSolver.MakeMapSolution<T>(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer, no max iterations - Vector2D initial condition
        public static MapFunction<T> HeunMapSolve<T>(this ODEFunction function, Vector2D initialPoint) where T : IMap<T>
        {
            return HeunSolver.MakeMapSolution<T>(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        #endregion

        #region RungeKuttaSolver

        //solvers

        //no optimizer - ODEInitialConditions initial condition
        public static Function RungeKuttaSolve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, int maxIterations)
        {
            return RungeKuttaSolver.MakeSolution(function, initialConditions, discretizer, maxIterations);
        }

        //no optimizer - Vector2D initial condition
        public static Function RungeKuttaSolve(this ODEFunction function, Vector2D initialPoint, IDiscretizer discretizer, int maxIterations)
        {
            return RungeKuttaSolver.MakeSolution(function, initialPoint, discretizer, maxIterations);
        }

        //all parameters - ODEInitialConditions initial condition
        public static Function RungeKuttaSolve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, IODEOptimizer optimizer, int maxIterations)
        {
            return RungeKuttaSolver.MakeSolution(function, initialConditions, discretizer, optimizer, maxIterations);
        }

        //all parameters - Vector2D initial condition
        public static Function RungeKuttaSolve(this ODEFunction function, Vector2D initialConditions, IDiscretizer discretizer, IODEOptimizer optimizer, int maxIterations)
        {
            return RungeKuttaSolver.MakeSolution(function, initialConditions, discretizer, optimizer, maxIterations);
        }

        //no optimizer, no max iterations - ODEInitialConditions initial condition
        public static Function RungeKuttaSolve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer)
        {
            return RungeKuttaSolver.MakeSolution(function, initialConditions, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no optimizer, no max iterations - Vector2D initial condition
        public static Function RungeKuttaSolve(this ODEFunction function, Vector2D initialPoint, IDiscretizer discretizer)
        {
            return RungeKuttaSolver.MakeSolution(function, initialPoint, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no max iterations - ODEInitialConditions initial condition
        public static Function RungeKuttaSolve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, IODEOptimizer optimizer)
        {
            return RungeKuttaSolver.MakeSolution(function, initialConditions, discretizer, optimizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no max iterations - Vector2D initial condition
        public static Function RungeKuttaSolve(this ODEFunction function, Vector2D initialPoint, IDiscretizer discretizer, IODEOptimizer optimizer)
        {
            return RungeKuttaSolver.MakeSolution(function, initialPoint, discretizer, optimizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer, no optimizer - ODEInitialConditions initial condition
        public static Function RungeKuttaSolve(this ODEFunction function, ODEInitialConditions initialConditions, int maxIterations)
        {
            return RungeKuttaSolver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no discretizer, no optimizer - Vector2D initial condition
        public static Function RungeKuttaSolve(this ODEFunction function, Vector2D initialPoint, int maxIterations)
        {
            return RungeKuttaSolver.MakeSolution(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no discretizer - ODEInitialConditions initial condition
        public static Function RungeKuttaSolve(this ODEFunction function, ODEInitialConditions initialConditions, IODEOptimizer optimizer, int maxIterations)
        {
            return RungeKuttaSolver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, optimizer, maxIterations);
        }

        //no discretizer - Vector2D initial condition
        public static Function RungeKuttaSolve(this ODEFunction function, Vector2D initialPoint, IODEOptimizer optimizer, int maxIterations)
        {
            return RungeKuttaSolver.MakeSolution(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, optimizer, maxIterations);
        }

        //no discretizer, no max iterations, no optimizer - ODEInitialConditions initial condition
        public static Function RungeKuttaSolve(this ODEFunction function, ODEInitialConditions initialConditions)
        {
            return RungeKuttaSolver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer, no max iterations, no optimizer - Vector2D initial condition
        public static Function RungeKuttaSolve(this ODEFunction function, Vector2D initialPoint)
        {
            return RungeKuttaSolver.MakeSolution(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer, no max iterations - ODEInitialConditions initial condition
        public static Function RungeKuttaSolve(this ODEFunction function, ODEInitialConditions initialConditions, IODEOptimizer optimizer)
        {
            return RungeKuttaSolver.MakeSolution(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, optimizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer, no max iterations - Vector2D initial condition
        public static Function RungeKuttaSolve(this ODEFunction function, Vector2D initialPoint, IODEOptimizer optimizer)
        {
            return RungeKuttaSolver.MakeSolution(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, optimizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //array solver

        //all parameters - ODEInitialConditions initial condition
        public static ArrayFunction RungeKuttaArraySolve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, int maxIterations)
        {
            return RungeKuttaSolver.MakeArraySolution(function, initialConditions, discretizer, maxIterations);
        }

        //all parameters - Vector2D initial condition
        public static ArrayFunction RungeKuttaArraySolve(this ODEFunction function, Vector2D initialPoint, IDiscretizer discretizer, int maxIterations)
        {
            return RungeKuttaSolver.MakeArraySolution(function, initialPoint, discretizer, maxIterations);
        }

        //no max iterations - ODEInitialConditions initial condition
        public static ArrayFunction RungeKuttaArraySolve(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer)
        {
            return RungeKuttaSolver.MakeArraySolution(function, initialConditions, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no max iterations - Vector2D initial condition
        public static ArrayFunction RungeKuttaArraySolve(this ODEFunction function, Vector2D initialPoint, IDiscretizer discretizer)
        {
            return RungeKuttaSolver.MakeArraySolution(function, initialPoint, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer - ODEInitialConditions initial condition
        public static ArrayFunction RungeKuttaArraySolve(this ODEFunction function, ODEInitialConditions initialConditions, int maxIterations)
        {
            return RungeKuttaSolver.MakeArraySolution(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no discretizer - Vector2D initial condition
        public static ArrayFunction RungeKuttaArraySolve(this ODEFunction function, Vector2D initialPoint, int maxIterations)
        {
            return RungeKuttaSolver.MakeArraySolution(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no discretizer, no max iterations - ODEInitialConditions initial condition
        public static ArrayFunction RungeKuttaArraySolve(this ODEFunction function, ODEInitialConditions initialConditions)
        {
            return RungeKuttaSolver.MakeArraySolution(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer, no max iterations - Vector2D initial condition
        public static ArrayFunction RungeKuttaArraySolve(this ODEFunction function, Vector2D initialPoint)
        {
            return RungeKuttaSolver.MakeArraySolution(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //MapSolver

        //all parameters - ODEInitialConditions initial condition
        public static MapFunction<T> RungeKuttaMapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, int maxIterations) where T : IMap<T>
        {
            return RungeKuttaSolver.MakeMapSolution<T>(function, initialConditions, discretizer, maxIterations);
        }

        //all parameters - Vector2D initial condition
        public static MapFunction<T> RungeKuttaMapSolve<T>(this ODEFunction function, Vector2D initialPoint, IDiscretizer discretizer, int maxIterations) where T : IMap<T>
        {
            return RungeKuttaSolver.MakeMapSolution<T>(function, initialPoint, discretizer, maxIterations);
        }

        //no max iterations - ODEInitialConditions initial condition
        public static MapFunction<T> RungeKuttaMapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer) where T : IMap<T>
        {
            return RungeKuttaSolver.MakeMapSolution<T>(function, initialConditions, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no max iterations - Vector2D initial condition
        public static MapFunction<T> RungeKuttaMapSolve<T>(this ODEFunction function, Vector2D initialPoint, IDiscretizer discretizer) where T : IMap<T>
        {
            return RungeKuttaSolver.MakeMapSolution<T>(function, initialPoint, discretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer - ODEInitialConditions initial condition
        public static MapFunction<T> RungeKuttaMapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions, int maxIterations) where T : IMap<T>
        {
            return RungeKuttaSolver.MakeMapSolution<T>(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no discretizer - Vector2D initial condition
        public static MapFunction<T> RungeKuttaMapSolve<T>(this ODEFunction function, Vector2D initialPoint, int maxIterations) where T : IMap<T>
        {
            return RungeKuttaSolver.MakeMapSolution<T>(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, maxIterations);
        }

        //no discretizer, no max iterations - ODEInitialConditions initial condition
        public static MapFunction<T> RungeKuttaMapSolve<T>(this ODEFunction function, ODEInitialConditions initialConditions) where T : IMap<T>
        {
            return RungeKuttaSolver.MakeMapSolution<T>(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        //no discretizer, no max iterations - Vector2D initial condition
        public static MapFunction<T> RungeKuttaMapSolve<T>(this ODEFunction function, Vector2D initialPoint) where T : IMap<T>
        {
            return RungeKuttaSolver.MakeMapSolution<T>(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations);
        }

        #endregion

    }
}
