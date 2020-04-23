using Beryl.Utilities.NodeSelection.PointSelection;
using Beryl.Utilities.Structures;

namespace Beryl.ODE
{
    public class EulerSolver:SinglestepODESolver
    {
        #region Solver-ODEInitialConditions

        //no optimizer
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, int maxIterations)
        {
            return new EulerSolver(function, initialConditions, discretizer, maxIterations).Solve;
        }

        //all parameters
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, IODEOptimizer optimizer, int maxIterations)
        {
            return new EulerSolver(function, initialConditions, discretizer, optimizer, maxIterations).Solve;
        }

        //no optimizer, no max iterations
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer)
        {
            return new EulerSolver(function, initialConditions, discretizer, DefaultODEParameters.DefaultMaxIterations).Solve;
        }

        //no max iterations
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, IODEOptimizer optimizer)
        {
            return new EulerSolver(function, initialConditions, discretizer, optimizer, DefaultODEParameters.DefaultMaxIterations).Solve;
        }

        //no discretizer, no optimizer
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, int maxIterations)
        {
            return new EulerSolver(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, maxIterations).Solve;
        }

        //no discretizer
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, IODEOptimizer optimizer, int maxIterations)
        {
            return new EulerSolver(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, optimizer, maxIterations).Solve;
        }

        //no discretizer, no max iterations, no optimizer
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions)
        {
            return new EulerSolver(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations).Solve;
        }

        //no discretizer, no max iterations
        public static Function MakeSolution(ODEFunction function, ODEInitialConditions initialConditions, IODEOptimizer optimizer)
        {
            return new EulerSolver(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, optimizer, DefaultODEParameters.DefaultMaxIterations).Solve;
        }

        #endregion

        #region Solver-InitialPoint

        //no optimizer
        public static Function MakeSolution(ODEFunction function, Point2D initialPoint, IDiscretizer discretizer, int maxIterations)
        {
            return new EulerSolver(function, initialPoint, discretizer, maxIterations).Solve;
        }

        //all parameters
        public static Function MakeSolution(ODEFunction function, Point2D initialPoint, IDiscretizer discretizer, IODEOptimizer optimizer, int maxIterations)
        {
            return new EulerSolver(function, initialPoint, discretizer, optimizer, maxIterations).Solve;
        }

        //no optimizer, no max iterations
        public static Function MakeSolution(ODEFunction function, Point2D initialPoint, IDiscretizer discretizer)
        {
            return new EulerSolver(function, initialPoint, discretizer, DefaultODEParameters.DefaultMaxIterations).Solve;
        }

        //no max iterations
        public static Function MakeSolution(ODEFunction function, Point2D initialPoint, IDiscretizer discretizer, IODEOptimizer optimizer)
        {
            return new EulerSolver(function, initialPoint, discretizer, optimizer, DefaultODEParameters.DefaultMaxIterations).Solve;
        }

        //no discretizer, no optimizer
        public static Function MakeSolution(ODEFunction function, Point2D initialPoint, int maxIterations)
        {
            return new EulerSolver(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, maxIterations).Solve;
        }

        //no discretizer
        public static Function MakeSolution(ODEFunction function, Point2D initialPoint, IODEOptimizer optimizer, int maxIterations)
        {
            return new EulerSolver(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, optimizer, maxIterations).Solve;
        }

        //no discretizer, no max iterations, no optimizer
        public static Function MakeSolution(ODEFunction function, Point2D initialPoint)
        {
            return new EulerSolver(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations).Solve;
        }

        //no discretizer, no max iterations
        public static Function MakeSolution(ODEFunction function, Point2D initialPoint, IODEOptimizer optimizer)
        {
            return new EulerSolver(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, optimizer, DefaultODEParameters.DefaultMaxIterations).Solve;
        }

        #endregion

        #region ArraySolver-ODEInitialCondtions

        //all parameters
        public static ArrayFunction MakeArraySolution(ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, int maxIterations)
        {
            return new EulerSolver(function, initialConditions, discretizer, maxIterations).ArraySolve;
        }

        //no max iterations
        public static ArrayFunction MakeArraySolution(ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer)
        {
            return new EulerSolver(function, initialConditions, discretizer, DefaultODEParameters.DefaultMaxIterations).ArraySolve;
        }

        //no discretizer
        public static ArrayFunction MakeArraySolution(ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, int maxIterations)
        {
            return new EulerSolver(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, maxIterations).ArraySolve;
        }

        //no discretizer, no max iterations
        public static ArrayFunction MakeArraySolution(ODEFunction function, ODEInitialConditions initialConditions)
        {
            return new EulerSolver(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations).ArraySolve;
        }

        #endregion

        #region ArraySolver-InitialPoint

        //all parameters
        public static ArrayFunction MakeArraySolution(ODEFunction function, Point2D initialPoint, IDiscretizer discretizer, int maxIterations)
        {
            return new EulerSolver(function, initialPoint, discretizer, maxIterations).ArraySolve;
        }

        //no max iterations
        public static ArrayFunction MakeArraySolution(ODEFunction function, Point2D initialPoint, IDiscretizer discretizer)
        {
            return new EulerSolver(function, initialPoint, discretizer, DefaultODEParameters.DefaultMaxIterations).ArraySolve;
        }

        //no discretizer
        public static ArrayFunction MakeArraySolution(ODEFunction function, Point2D initialPoint, SingleStepIteration auxiliaryIterator, int maxIterations)
        {
            return new EulerSolver(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, maxIterations).ArraySolve;
        }

        //no discretizer, no max iterations
        public static ArrayFunction MakeArraySolution(ODEFunction function, Point2D initialPoint)
        {
            return new EulerSolver(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations).ArraySolve;
        }

        #endregion

        #region MapSolver-ODEInitialConditions

        //all parameters
        public static MapFunction<T> MakeMapSolution<T>(ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, int maxIterations) where T : IMap<T>
        {
            return new EulerSolver(function, initialConditions, discretizer, maxIterations).MapSolve;
        }

        //no max iterations
        public static MapFunction<T> MakeMapSolution<T>(ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer) where T : IMap<T>
        {
            return new EulerSolver(function, initialConditions, discretizer, DefaultODEParameters.DefaultMaxIterations).MapSolve;
        }

        //no discretizer
        public static MapFunction<T> MakeMapSolution<T>(ODEFunction function, ODEInitialConditions initialConditions, SingleStepIteration auxiliaryIterator, int maxIterations) where T : IMap<T>
        {
            return new EulerSolver(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, maxIterations).MapSolve;
        }

        //no discretizer, no max iterations
        public static MapFunction<T> MakeMapSolution<T>(ODEFunction function, ODEInitialConditions initialConditions) where T : IMap<T>
        {
            return new EulerSolver(function, initialConditions, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations).MapSolve;
        }

        #endregion

        #region MapSolver-InitialPoint

        //all parameters
        public static MapFunction<T> MakeMapSolution<T>(ODEFunction function, Point2D initialPoint, IDiscretizer discretizer, int maxIterations) where T : IMap<T>
        {
            return new EulerSolver(function, initialPoint, discretizer, maxIterations).MapSolve;
        }

        //no max iterations
        public static MapFunction<T> MakeMapSolution<T>(ODEFunction function, Point2D initialPoint, IDiscretizer discretizer) where T : IMap<T>
        {
            return new EulerSolver(function, initialPoint, discretizer, DefaultODEParameters.DefaultMaxIterations).MapSolve;
        }

        //no discretizer
        public static MapFunction<T> MakeMapSolution<T>(ODEFunction function, Point2D initialPoint, SingleStepIteration auxiliaryIterator, int maxIterations) where T : IMap<T>
        {
            return new EulerSolver(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, maxIterations).MapSolve;
        }

        //no discretizer, no max iterations
        public static MapFunction<T> MakeMapSolution<T>(ODEFunction function, Point2D initialPoint) where T : IMap<T>
        {
            return new EulerSolver(function, initialPoint, DefaultODEParameters.DefaultDiscretizer, DefaultODEParameters.DefaultMaxIterations).MapSolve;
        }

        #endregion

        private EulerSolver(ODEFunction function, ODEInitialConditions initialConditions, IDiscretizer discretizer, int maxIterations) : base(function, initialConditions, discretizer, maxIterations)
        {
        }

        private EulerSolver(ODEFunction function, Point2D initialPoint, IDiscretizer discretizer, int maxIterations): base(function,initialPoint,discretizer,maxIterations)
        {
        }

        private EulerSolver(ODEFunction function, ODEInitialConditions initialCondition, IDiscretizer discretizer, IODEOptimizer optimizer, int maxIterations) : base(function, initialCondition, discretizer, optimizer, maxIterations)
        {
        }

        private EulerSolver(ODEFunction function, Point2D initialPoint, IDiscretizer discretizer, IODEOptimizer optimizer, int maxIterations) : base(function, initialPoint, discretizer, optimizer, maxIterations)
        {
        }

        protected override Point2D Iteration(StepPoint previousPoint)
        {
            return new Point2D(previousPoint.Coordinates.x + previousPoint.Step, previousPoint.Coordinates.y + previousPoint.Step * function(previousPoint.Coordinates.x,previousPoint.Coordinates.y));
        }

        public static Point2D Iteration(ODEFunction function, StepPoint previousPoint)
        {
            return new Point2D(previousPoint.Coordinates.x + previousPoint.Step, previousPoint.Coordinates.y + previousPoint.Step * function(previousPoint.Coordinates.x, previousPoint.Coordinates.y));
        }
    }
}