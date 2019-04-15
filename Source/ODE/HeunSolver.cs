using Beryl.Utilities.Structures;

namespace Beryl.ODE
{
    //an ODE solver based on Heun method
    public class HeunSolver : StandardODESolver
    {

        public static ArraySolver MakeArraySolver(ODEFunction argument, Vector2D initialCondition, IDiscretizer discretizer, int maxIterations = DEFAULT_MAX_ITERATIONS)
        {
            return new HeunSolver(argument, initialCondition, discretizer, maxIterations).Solve;
        }

        public static ArraySolver MakeArraySolver(ODEFunction argument, Vector2D initialCondition, int maxIterations = DEFAULT_MAX_ITERATIONS)
        {
            return new HeunSolver(argument, initialCondition, new UniformDiscretizer(DEFAULT_DISCRETIZER_STEP), maxIterations).Solve;
        }

        public static Function MakeSolution(ODEFunction argument, Vector2D initialCondition, IDiscretizer discretizer, OptimizationOptions options, int maxIterations = DEFAULT_MAX_ITERATIONS)
        {
            return new HeunSolver(argument, initialCondition, discretizer, options, maxIterations).Solve;
        }

        public static Function MakeSolution(ODEFunction argument, Vector2D initialCondition, OptimizationOptions options, int maxIterations = DEFAULT_MAX_ITERATIONS)
        {
            return new HeunSolver(argument, initialCondition, new UniformDiscretizer(DEFAULT_DISCRETIZER_STEP), options, maxIterations).Solve;
        }

        public static Function MakeSolution(ODEFunction argument, Vector2D initialCondition, IDiscretizer discretizer, int maxIterations = DEFAULT_MAX_ITERATIONS)
        {
            return new HeunSolver(argument, initialCondition, discretizer, DEFAULT_MAX_ITERATIONS).Solve;
        }

        public static Function MakeSolution(ODEFunction argument, Vector2D initialCondition, int maxIterations)
        {
            return new HeunSolver(argument, initialCondition, new UniformDiscretizer(DEFAULT_DISCRETIZER_STEP), maxIterations).Solve;
        }

        private HeunSolver(ODEFunction function, Vector2D initialCondition, IDiscretizer discretizer, OptimizationOptions options, int maxIterations = DEFAULT_MAX_ITERATIONS) :
            base(function, initialCondition, discretizer, options, maxIterations)
        { }

        private HeunSolver(ODEFunction function, Vector2D initialCondition, IDiscretizer discretizer, int maxIterations = DEFAULT_MAX_ITERATIONS) :
            base(function, initialCondition, discretizer, maxIterations)
        { }

        //calculates an Heun iteration
        protected override Vector2D Iteration(Vector2D previousNode, double step)
        {
            double K1 = function(previousNode.x, previousNode.y);
            double K2 = function(previousNode.x + step, previousNode.y + step * K1);
            return new Vector2D(previousNode.x + step, previousNode.y + step / 2 * (K1 + K2)); ;
        }
    }
}
