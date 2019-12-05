using Beryl.Utilities.NodeSelection.PointSelection;
using Beryl.Utilities.Structures;

namespace Beryl.ODE
{
    //an ODE solver based on the 4-th order explicit Runge-Kutta method
    public class RungeKuttaSolver : SinglestepODESolver
    {
        #region Solver-ODEInitialConditions

        //no optimizer
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, int maxIterations)
        {
            return new RungeKuttaSolver(function, initialConditions, discretizer, maxIterations).Solve;
        }

        //all parameters
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, IODEOptimizer optimizer, int maxIterations)
        {
            return new RungeKuttaSolver(function, initialConditions, discretizer, optimizer, maxIterations).Solve;
        }

        //no optimizer, no max iterations
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer)
        {
            return new RungeKuttaSolver(function, initialConditions, discretizer, DefaultODEParameters.DefaultMaxIterations).Solve;
        }

        //no max iterations
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, IODEOptimizer optimizer)
        {
            return new RungeKuttaSolver(function, initialConditions, discretizer, optimizer, DefaultODEParameters.DefaultMaxIterations).Solve;
        }

        //no discretizer, no optimizer
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, int maxIterations)
        {
            return new RungeKuttaSolver(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, maxIterations).Solve;
        }

        //no discretizer
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, IODEOptimizer optimizer, int maxIterations)
        {
            return new RungeKuttaSolver(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, optimizer, maxIterations).Solve;
        }

        //no discretizer, no max iterations, no optimizer
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions)
        {
            return new RungeKuttaSolver(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations).Solve;
        }

        //no discretizer, no max iterations
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, IODEOptimizer optimizer)
        {
            return new RungeKuttaSolver(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, optimizer, DefaultODEParameters.DefaultMaxIterations).Solve;
        }

        #endregion

        #region Solver-InitialPoint

        //no optimizer
        public static Function MakeSolution(ODEFunction function, Vector2D initialPoint, IDiscretizer discretizer, int maxIterations)
        {
            return new RungeKuttaSolver(function, initialPoint, discretizer, maxIterations).Solve;
        }

        //all parameters
        public static Function MakeSolution(ODEFunction function, Vector2D initialPoint, IDiscretizer discretizer, IODEOptimizer optimizer, int maxIterations)
        {
            return new RungeKuttaSolver(function, initialPoint, discretizer, optimizer, maxIterations).Solve;
        }

        //no optimizer, no max iterations
        public static Function MakeSolution(ODEFunction function, Vector2D initialPoint, IDiscretizer discretizer)
        {
            return new RungeKuttaSolver(function, initialPoint, discretizer, DefaultODEParameters.DefaultMaxIterations).Solve;
        }

        //no max iterations
        public static Function MakeSolution(ODEFunction function, Vector2D initialPoint, IDiscretizer discretizer, IODEOptimizer optimizer)
        {
            return new RungeKuttaSolver(function, initialPoint, discretizer, optimizer, DefaultODEParameters.DefaultMaxIterations).Solve;
        }

        //no discretizer, no optimizer
        public static Function MakeSolution(ODEFunction function, Vector2D initialPoint, int maxIterations)
        {
            return new RungeKuttaSolver(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, maxIterations).Solve;
        }

        //no discretizer
        public static Function MakeSolution(ODEFunction function, Vector2D initialPoint, IODEOptimizer optimizer, int maxIterations)
        {
            return new RungeKuttaSolver(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, optimizer, maxIterations).Solve;
        }

        //no discretizer, no max iterations, no optimizer
        public static Function MakeSolution(ODEFunction function, Vector2D initialPoint)
        {
            return new RungeKuttaSolver(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations).Solve;
        }

        //no discretizer, no max iterations
        public static Function MakeSolution(ODEFunction function, Vector2D initialPoint, IODEOptimizer optimizer)
        {
            return new RungeKuttaSolver(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, optimizer, DefaultODEParameters.DefaultMaxIterations).Solve;
        }

        #endregion

        #region ArraySolver-ODEInitialCondtions

        //all parameters
        public static ArrayFunction MakeArraySolution(ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, int maxIterations)
        {
            return new RungeKuttaSolver(function, initialConditions, discretizer, maxIterations).ArraySolve;
        }

        //no max iterations
        public static ArrayFunction MakeArraySolution(ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer)
        {
            return new RungeKuttaSolver(function, initialConditions, discretizer, DefaultODEParameters.DefaultMaxIterations).ArraySolve;
        }

        //no discretizer
        public static ArrayFunction MakeArraySolution(ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, int maxIterations)
        {
            return new RungeKuttaSolver(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, maxIterations).ArraySolve;
        }

        //no discretizer, no max iterations
        public static ArrayFunction MakeArraySolution(ODEFunction function, ODEInitialConditions initialConditions)
        {
            return new RungeKuttaSolver(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations).ArraySolve;
        }

        #endregion

        #region ArraySolver-InitialPoint

        //all parameters
        public static ArrayFunction MakeArraySolution(ODEFunction function, Vector2D initialPoint, IDiscretizer discretizer, int maxIterations)
        {
            return new RungeKuttaSolver(function, initialPoint, discretizer, maxIterations).ArraySolve;
        }

        //no max iterations
        public static ArrayFunction MakeArraySolution(ODEFunction function, Vector2D initialPoint, IDiscretizer discretizer)
        {
            return new RungeKuttaSolver(function, initialPoint, discretizer, DefaultODEParameters.DefaultMaxIterations).ArraySolve;
        }

        //no discretizer
        public static ArrayFunction MakeArraySolution(ODEFunction function, Vector2D initialPoint, SingleStepIteration auxiliaryIterator, int maxIterations)
        {
            return new RungeKuttaSolver(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, maxIterations).ArraySolve;
        }

        //no discretizer, no max iterations
        public static ArrayFunction MakeArraySolution(ODEFunction function, Vector2D initialPoint)
        {
            return new RungeKuttaSolver(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations).ArraySolve;
        }

        #endregion

        private RungeKuttaSolver(ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, int maxIterations) : base(function, initialConditions, discretizer, maxIterations)
        {
        }

        private RungeKuttaSolver(ODEFunction function, Vector2D initialPoint, IDiscretizer discretizer, int maxIterations) : base(function, initialPoint, discretizer, maxIterations)
        {
        }

        private RungeKuttaSolver(ODEFunction function, ODEInitialConditions initialCondition, IDiscretizer discretizer, IODEOptimizer optimizer, int maxIterations) : base(function, initialCondition, discretizer, optimizer, maxIterations)
        {
        }

        private RungeKuttaSolver(ODEFunction function, Vector2D initialPoint, IDiscretizer discretizer, IODEOptimizer optimizer, int maxIterations) : base(function, initialPoint, discretizer, optimizer, maxIterations)
        {
        }

        //calculates an Runge-Kutta iteration
        protected override Vector2D Iteration(StepPoint point)
        {
            double K1 = function(point.Coordinates.x, point.Coordinates.y);
            double K2 = function(point.Coordinates.x + point.Step / 2, point.Coordinates.y + point.Step / 2 * K1);
            double K3 = function(point.Coordinates.x + point.Step / 2, point.Coordinates.y + point.Step / 2 * K2);
            double K4 = function(point.Coordinates.x + point.Step, point.Coordinates.y + point.Step * K3);
            return new Vector2D(point.Coordinates.x + point.Step, point.Coordinates.y + point.Step / 6 * (K1 + 2 * K2 + 2 * K3 + K4)); 
        }

        public static Vector2D Iteration(ODEFunction function, StepPoint point)
        {
            double K1 = function(point.Coordinates.x, point.Coordinates.y);
            double K2 = function(point.Coordinates.x + point.Step / 2, point.Coordinates.y + point.Step / 2 * K1);
            double K3 = function(point.Coordinates.x + point.Step / 2, point.Coordinates.y + point.Step / 2 * K2);
            double K4 = function(point.Coordinates.x + point.Step, point.Coordinates.y + point.Step * K3);
            return new Vector2D(point.Coordinates.x + point.Step, point.Coordinates.y + point.Step / 6 * (K1 + 2 * K2 + 2 * K3 + K4));
        }
    }
}
