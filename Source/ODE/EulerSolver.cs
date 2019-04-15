using Beryl.Utilities.Structures;

namespace Beryl.ODE
{
    public class EulerSolver:StandardODESolver
    {
        
        public static ArraySolver MakeArraySolver(ODEFunction argument,Vector2D initialCondition,IDiscretizer discretizer,int maxIterations=DEFAULT_MAX_ITERATIONS)
        {
            return new EulerSolver(argument,initialCondition, discretizer, maxIterations).Solve;
        }

        public static ArraySolver MakeArraySolver(ODEFunction argument, Vector2D initialCondition,int maxIterations=DEFAULT_MAX_ITERATIONS)
        {
            return new EulerSolver(argument,initialCondition, new UniformDiscretizer(DEFAULT_DISCRETIZER_STEP), maxIterations).Solve;
        }

        public static Function MakeSolution(ODEFunction argument, Vector2D initialCondition, IDiscretizer discretizer, OptimizationOptions options, int maxIterations = DEFAULT_MAX_ITERATIONS)
        {
            return new EulerSolver(argument, initialCondition, discretizer, options, maxIterations).Solve;
        }

        public static Function MakeSolution(ODEFunction argument, Vector2D initialCondition, OptimizationOptions options, int maxIterations = DEFAULT_MAX_ITERATIONS)
        {
            return new EulerSolver(argument, initialCondition, new UniformDiscretizer(DEFAULT_DISCRETIZER_STEP), options, maxIterations).Solve;
        }

        public static Function MakeSolution(ODEFunction argument, Vector2D initialCondition, IDiscretizer discretizer, int maxIterations=DEFAULT_MAX_ITERATIONS)
        {
            return new EulerSolver(argument, initialCondition, discretizer, DEFAULT_MAX_ITERATIONS).Solve;
        }

        public static Function MakeSolution(ODEFunction argument, Vector2D initialCondition, int maxIterations)
        {
            return new EulerSolver(argument, initialCondition, new UniformDiscretizer(DEFAULT_DISCRETIZER_STEP), maxIterations).Solve;
        }

        private EulerSolver (ODEFunction function, Vector2D initialCondition, IDiscretizer discretizer,OptimizationOptions options, int maxIterations = DEFAULT_MAX_ITERATIONS):
            base(function,initialCondition,discretizer,options,maxIterations)
        { }

        private EulerSolver(ODEFunction function, Vector2D initialCondition, IDiscretizer discretizer, int maxIterations = DEFAULT_MAX_ITERATIONS) :
            base(function, initialCondition, discretizer, maxIterations)
        { }

        protected override Vector2D Iteration(Vector2D previousNode,double step)
        {
            return new Vector2D(previousNode.x + step, previousNode.y + step * function(previousNode.x, previousNode.y));
        }
    }
}