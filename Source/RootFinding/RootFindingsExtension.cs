using Beryl.NumericalDerivation;
using Beryl.Utilities.Structures;

namespace Beryl.RootFinding
{

    public static class RootFindingsExtension
    {

        #region NewtonSolver

        public static NewtonSolverFunction NewtonSolver(this Function function,Function derivative,IStoppingCriteria stoppingCriteria,int maxIterations)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivative, stoppingCriteria, maxIterations);
        }

        public static NewtonSolverFunction NewtonSolver(this Function function, Function derivative, IStoppingCriteria stoppingCriteria)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivative, stoppingCriteria);
        }

        public static NewtonSolverFunction NewtonSolver(this Function function, DerivativeGenerator derivativeGenerator, IStoppingCriteria stoppingCriteria, int maxIterations)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivativeGenerator, stoppingCriteria, maxIterations);
        }

        public static NewtonSolverFunction NewtonSolver(this Function function, DerivativeGenerator derivativeGenerator, IStoppingCriteria stoppingCriteria)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivativeGenerator, stoppingCriteria);
        }

        public static NewtonSolverFunction NewtonSolver(this Function function,IStoppingCriteria stoppingCriteria,int maxIterations)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, stoppingCriteria, maxIterations);
        }

        public static NewtonSolverFunction NewtonSolver(this Function function, IStoppingCriteria stoppingCriteria)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, stoppingCriteria);
        }

        public static NewtonSolverFunction NewtonSolver(this Function function,int maxIterations)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, maxIterations);
        }

        public static NewtonSolverFunction NewtonSolver(this Function function)
        {
            return RootFinding.NewtonSolver.MakeSolver(function);
        }

        public static NewtonSolverFunction NewtonSolver(this Function function,Function derivative,int maxIterations)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivative, maxIterations);
        }

        public static NewtonSolverFunction NewtonSolver(this Function function, Function derivative)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivative);
        }

        public static NewtonSolverFunction NewtonSolver(this Function function, DerivativeGenerator derivativeGenerator, int maxIterations)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivativeGenerator, maxIterations);
        }

        public static NewtonSolverFunction NewtonSolver(this Function function, DerivativeGenerator derivativeGenerator)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivativeGenerator);
        }

        public static Vector2D NewtonSolve(this Function function, double x0, int multiplicity,Function derivative, IStoppingCriteria stoppingCriteria, int maxIterations)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivative, stoppingCriteria, maxIterations)(x0, multiplicity);
        }

        public static Vector2D NewtonSolve(this Function function, double x0, int multiplicity, Function derivative, IStoppingCriteria stoppingCriteria)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivative, stoppingCriteria)(x0, multiplicity);
        }

        public static Vector2D NewtonSolve(this Function function, double x0, int multiplicity, DerivativeGenerator derivativeGenerator, IStoppingCriteria stoppingCriteria, int maxIterations)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivativeGenerator, stoppingCriteria, maxIterations)(x0, multiplicity);
        }

        public static Vector2D NewtonSolve(this Function function, double x0, int multiplicity, DerivativeGenerator derivativeGenerator, IStoppingCriteria stoppingCriteria)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivativeGenerator, stoppingCriteria)(x0, multiplicity);
        }

        public static Vector2D NewtonSolve(this Function function, double x0, Function derivative, IStoppingCriteria stoppingCriteria, int maxIterations)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivative, stoppingCriteria, maxIterations)(x0);
        }

        public static Vector2D NewtonSolve(this Function function, double x0, Function derivative, IStoppingCriteria stoppingCriteria)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivative, stoppingCriteria)(x0);
        }

        public static Vector2D NewtonSolve(this Function function, double x0, DerivativeGenerator derivativeGenerator, IStoppingCriteria stoppingCriteria, int maxIterations)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivativeGenerator, stoppingCriteria, maxIterations)(x0);
        }

        public static Vector2D NewtonSolve(this Function function, double x0, DerivativeGenerator derivativeGenerator, IStoppingCriteria stoppingCriteria)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivativeGenerator, stoppingCriteria)(x0);
        }

        public static Vector2D NewtonSolve(this Function function, double x0, int multiplicity, IStoppingCriteria stoppingCriteria, int maxIterations)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, stoppingCriteria, maxIterations)(x0, multiplicity);
        }

        public static Vector2D NewtonSolve(this Function function, double x0, int multiplicity, IStoppingCriteria stoppingCriteria)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, stoppingCriteria)(x0, multiplicity);
        }

        public static Vector2D NewtonSolve(this Function function, double x0, IStoppingCriteria stoppingCriteria, int maxIterations)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, stoppingCriteria, maxIterations)(x0);
        }

        public static Vector2D NewtonSolve(this Function function, double x0, IStoppingCriteria stoppingCriteria)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, stoppingCriteria)(x0);
        }

        public static Vector2D NewtonSolve(this Function function, double x0,int multiplicity, Function derivative, int maxIterations)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivative, maxIterations)(x0,multiplicity);
        }

        public static Vector2D NewtonSolve(this Function function, double x0, int multiplicity, Function derivative)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivative)(x0, multiplicity);
        }

        public static Vector2D NewtonSolve(this Function function, double x0, int multiplicity, DerivativeGenerator derivativeGenerator, int maxIterations)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivativeGenerator, maxIterations)(x0, multiplicity);
        }

        public static Vector2D NewtonSolve(this Function function, double x0, int multiplicity, DerivativeGenerator derivativeGenerator)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivativeGenerator)(x0, multiplicity);
        }

        public static Vector2D NewtonSolve(this Function function, double x0, Function derivative, int maxIterations)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivative, maxIterations)(x0);
        }

        public static Vector2D NewtonSolve(this Function function, double x0, Function derivative)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivative)(x0);
        }

        public static Vector2D NewtonSolve(this Function function, double x0, DerivativeGenerator derivativeGenerator, int maxIterations)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivativeGenerator, maxIterations)(x0);
        }

        public static Vector2D NewtonSolve(this Function function, double x0, DerivativeGenerator derivativeGenerator)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivativeGenerator)(x0);
        }

        public static Vector2D NewtonSolve(this Function function, double x0, int multiplicity, int maxIterations)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, maxIterations)(x0,multiplicity);
        }

        public static Vector2D NewtonSolve(this Function function, double x0, int multiplicity)
        {
            return RootFinding.NewtonSolver.MakeSolver(function)(x0, multiplicity);
        }

        public static Vector2D NewtonSolve(this Function function, double x0)
        {
            return RootFinding.NewtonSolver.MakeSolver(function)(x0);
        }

        #endregion

        #region BiscetionSolver

        public static BisectionSolverFunction BisectionSolver(this Function function,IStoppingCriteria stoppingCriteria,int maxIterations)
        {
            return RootFinding.BisectionSolver.MakeSolver(function, stoppingCriteria, maxIterations);
        }

        public static BisectionSolverFunction BisectionSolver(this Function function, IStoppingCriteria stoppingCriteria)
        {
            return RootFinding.BisectionSolver.MakeSolver(function, stoppingCriteria);
        }

        public static BisectionSolverFunction BisectionSolver(this Function function,int maxIterations)
        {
            return RootFinding.BisectionSolver.MakeSolver(function, maxIterations);
        }

        public static BisectionSolverFunction BisectionSolver(this Function function)
        {
            return RootFinding.BisectionSolver.MakeSolver(function);
        }

        public static Vector2D BisectionSolve(this Function function, double inf,double sup,IStoppingCriteria stoppingCriteria,int maxIterations)
        {
            return RootFinding.BisectionSolver.MakeSolver(function, stoppingCriteria, maxIterations)(inf, sup);
        }

        public static Vector2D BisectionSolve(this Function function, double inf, double sup, IStoppingCriteria stoppingCriteria)
        {
            return RootFinding.BisectionSolver.MakeSolver(function, stoppingCriteria)(inf, sup);
        }

        public static Vector2D BisectionSolve(this Function function,double inf,double sup,int maxIterations)
        {
            return RootFinding.BisectionSolver.MakeSolver(function, maxIterations)(inf, sup);
        }

        public static Vector2D BisectionSolve(this Function function, double inf, double sup)
        {
            return RootFinding.BisectionSolver.MakeSolver(function)(inf, sup);
        }

        #endregion

        #region SecantSolver

        public static SecantSolverFunction SecantSolver(this Function function,IStoppingCriteria stoppingCrieria,int maxIterations)
        {
            return RootFinding.SecantSolver.MakeSolver(function, stoppingCrieria, maxIterations);
        }

        public static SecantSolverFunction SecantSolver(this Function function, IStoppingCriteria stoppingCrieria)
        {
            return RootFinding.SecantSolver.MakeSolver(function, stoppingCrieria);
        }

        public static SecantSolverFunction SecantSolver(this Function function, int maxIterations)
        {
            return RootFinding.SecantSolver.MakeSolver(function, maxIterations);
        }

        public static SecantSolverFunction SecantSolver(this Function function)
        {
            return RootFinding.SecantSolver.MakeSolver(function);
        }

        public static Vector2D SecantSolve(this Function function,double x0,double x1,IStoppingCriteria stoppingCriteria,int maxIterations)
        {
            return RootFinding.SecantSolver.MakeSolver(function, stoppingCriteria, maxIterations)(x0, x1);
        }

        public static Vector2D SecantSolve(this Function function, double x0, double x1, IStoppingCriteria stoppingCriteria)
        {
            return RootFinding.SecantSolver.MakeSolver(function, stoppingCriteria)(x0, x1);
        }

        public static Vector2D SecantSolve(this Function function,double x0,double x1,int maxIterations)
        {
            return RootFinding.SecantSolver.MakeSolver(function, maxIterations)(x0, x1);
        }

        public static Vector2D SecantSolve(this Function function, double x0, double x1)
        {
            return RootFinding.SecantSolver.MakeSolver(function)(x0, x1);
        }

        #endregion

    }

}
