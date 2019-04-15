using Beryl.Utilities.Structures;

namespace Beryl.ODE
{
    //an ODE solver based on the 4-th order explicit Runge-Kutta method
    public class RungeKuttaSolver : StandardODESolver
    {

        public static ArraySolver MakeArraySolver(ODEFunction argument, Vector2D initialCondition, IDiscretizer discretizer, int maxIterations = DEFAULT_MAX_ITERATIONS)
        {
            return new RungeKuttaSolver(argument, initialCondition, discretizer, maxIterations).Solve;
        }

        public static ArraySolver MakeArraySolver(ODEFunction argument, Vector2D initialCondition, int maxIterations = DEFAULT_MAX_ITERATIONS)
        {
            return new RungeKuttaSolver(argument, initialCondition, new UniformDiscretizer(DEFAULT_DISCRETIZER_STEP), maxIterations).Solve;
        }

        public static Function MakeSolution(ODEFunction argument, Vector2D initialCondition, IDiscretizer discretizer, OptimizationOptions options, int maxIterations = DEFAULT_MAX_ITERATIONS)
        {
            return new RungeKuttaSolver(argument, initialCondition, discretizer, options, maxIterations).Solve;
        }

        public static Function MakeSolution(ODEFunction argument, Vector2D initialCondition, OptimizationOptions options, int maxIterations = DEFAULT_MAX_ITERATIONS)
        {
            return new RungeKuttaSolver(argument, initialCondition, new UniformDiscretizer(DEFAULT_DISCRETIZER_STEP), options, maxIterations).Solve;
        }

        public static Function MakeSolution(ODEFunction argument, Vector2D initialCondition, IDiscretizer discretizer, int maxIterations = DEFAULT_MAX_ITERATIONS)
        {
            return new RungeKuttaSolver(argument, initialCondition, discretizer, DEFAULT_MAX_ITERATIONS).Solve;
        }

        public static Function MakeSolution(ODEFunction argument, Vector2D initialCondition, int maxIterations)
        {
            return new RungeKuttaSolver(argument, initialCondition, new UniformDiscretizer(DEFAULT_DISCRETIZER_STEP), maxIterations).Solve;
        }

        private RungeKuttaSolver(ODEFunction function, Vector2D initialCondition, IDiscretizer discretizer, OptimizationOptions options, int maxIterations = DEFAULT_MAX_ITERATIONS) :
            base(function, initialCondition, discretizer, options, maxIterations)
        { }

        private RungeKuttaSolver(ODEFunction function, Vector2D initialCondition, IDiscretizer discretizer, int maxIterations = DEFAULT_MAX_ITERATIONS) :
            base(function, initialCondition, discretizer, maxIterations)
        { }

        //calculates an Runge-Kutta iteration
        protected override Vector2D Iteration(Vector2D previousNode, double step)
        {
            double K1 = function(previousNode.x, previousNode.y);
            double K2 = function(previousNode.x + step / 2, previousNode.y + step / 2 * K1);
            double K3 = function(previousNode.x + step / 2, previousNode.y + step / 2 * K2);
            double K4 = function(previousNode.x + step, previousNode.y + step * K3);
            return new Vector2D(previousNode.x + step, previousNode.y + step / 6 * (K1 + 2 * K2 + 2 * K3 + K4)); ;
        }
    }
}
