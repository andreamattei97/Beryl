using Beryl.Utilities.Structures;

namespace Beryl.ODE
{

    public static class ODEExtension
    {
        //Euler solver extension
        public static ArraySolver EulerArraySolver(this ODEFunction argument, Vector2D initialCondition, IDiscretizer discretizer,int maxIterations= StandardODESolver.DEFAULT_MAX_ITERATIONS)
        {
            return EulerSolver.MakeArraySolver(argument, initialCondition, discretizer, maxIterations);
        }

        public static ArraySolver EulerArraySolver(this ODEFunction argument,Vector2D initialCondition, int maxIterations= StandardODESolver.DEFAULT_MAX_ITERATIONS)
        {
            return EulerSolver.MakeArraySolver(argument, initialCondition, maxIterations);
        }

        public static Function EulerSolve(this ODEFunction argument,Vector2D initialCondition,IDiscretizer discretizer,OptimizationOptions options,int maxIterations= StandardODESolver.DEFAULT_MAX_ITERATIONS)
        {
            return EulerSolver.MakeSolution(argument, initialCondition, discretizer, options, maxIterations);
        }

        public static Function EulerSolve(this ODEFunction argument, Vector2D initialCondition, IDiscretizer discretizer, int maxIterations = StandardODESolver.DEFAULT_MAX_ITERATIONS)
        {
            return EulerSolver.MakeSolution(argument, initialCondition, discretizer, maxIterations);
        }

        public static Function EulerSolve(this ODEFunction argument, Vector2D initialCondition, OptimizationOptions options, int maxIterations = StandardODESolver.DEFAULT_MAX_ITERATIONS)
        {
            return EulerSolver.MakeSolution(argument, initialCondition, options, maxIterations);
        }

        public static Function EulerSolve(this ODEFunction argument, Vector2D initialCondition, int maxIterations=StandardODESolver.DEFAULT_MAX_ITERATIONS)
        {
            return EulerSolver.MakeSolution(argument, initialCondition, maxIterations);
        }

        //Heun solver extension
        public static ArraySolver HeunArraySolver(this ODEFunction argument, Vector2D initialCondition, IDiscretizer discretizer, int maxIterations = StandardODESolver.DEFAULT_MAX_ITERATIONS)
        {
            return HeunSolver.MakeArraySolver(argument, initialCondition, discretizer, maxIterations);
        }

        public static ArraySolver HeunArraySolver(this ODEFunction argument, Vector2D initialCondition, int maxIterations = StandardODESolver.DEFAULT_MAX_ITERATIONS)
        {
            return HeunSolver.MakeArraySolver(argument, initialCondition, maxIterations);
        }

        public static Function HeunSolve(this ODEFunction argument, Vector2D initialCondition, IDiscretizer discretizer, OptimizationOptions options, int maxIterations = StandardODESolver.DEFAULT_MAX_ITERATIONS)
        {
            return HeunSolver.MakeSolution(argument, initialCondition, discretizer, options, maxIterations);
        }

        public static Function HeunSolve(this ODEFunction argument, Vector2D initialCondition, IDiscretizer discretizer, int maxIterations = StandardODESolver.DEFAULT_MAX_ITERATIONS)
        {
            return HeunSolver.MakeSolution(argument, initialCondition, discretizer, maxIterations);
        }

        public static Function HeunSolve(this ODEFunction argument, Vector2D initialCondition, OptimizationOptions options, int maxIterations = StandardODESolver.DEFAULT_MAX_ITERATIONS)
        {
            return HeunSolver.MakeSolution(argument, initialCondition, options, maxIterations);
        }

        public static Function HeunSolve(this ODEFunction argument, Vector2D initialCondition, int maxIterations = StandardODESolver.DEFAULT_MAX_ITERATIONS)
        {
            return HeunSolver.MakeSolution(argument, initialCondition, maxIterations);
        }

        //Runge-Kutta solver extension
        public static ArraySolver RungeKuttaArraySolver(this ODEFunction argument, Vector2D initialCondition, IDiscretizer discretizer, int maxIterations = StandardODESolver.DEFAULT_MAX_ITERATIONS)
        {
            return RungeKuttaSolver.MakeArraySolver(argument, initialCondition, discretizer, maxIterations);
        }

        public static ArraySolver RungeKuttaArraySolver(this ODEFunction argument, Vector2D initialCondition, int maxIterations = StandardODESolver.DEFAULT_MAX_ITERATIONS)
        {
            return RungeKuttaSolver.MakeArraySolver(argument, initialCondition, maxIterations);
        }

        public static Function RungeKuttaSolve(this ODEFunction argument, Vector2D initialCondition, IDiscretizer discretizer, OptimizationOptions options, int maxIterations = StandardODESolver.DEFAULT_MAX_ITERATIONS)
        {
            return RungeKuttaSolver.MakeSolution(argument, initialCondition, discretizer, options, maxIterations);
        }

        public static Function RungeKuttaSolve(this ODEFunction argument, Vector2D initialCondition, IDiscretizer discretizer, int maxIterations = StandardODESolver.DEFAULT_MAX_ITERATIONS)
        {
            return RungeKuttaSolver.MakeSolution(argument, initialCondition, discretizer, maxIterations);
        }

        public static Function RungeKuttaSolve(this ODEFunction argument, Vector2D initialCondition, OptimizationOptions options, int maxIterations = StandardODESolver.DEFAULT_MAX_ITERATIONS)
        {
            return RungeKuttaSolver.MakeSolution(argument, initialCondition, options, maxIterations);
        }

        public static Function RungeKuttaSolve(this ODEFunction argument, Vector2D initialCondition, int maxIterations = StandardODESolver.DEFAULT_MAX_ITERATIONS)
        {
            return RungeKuttaSolver.MakeSolution(argument, initialCondition, maxIterations);
        }

    }
}
