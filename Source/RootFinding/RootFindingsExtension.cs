using Beryl.Utilities.Structures;

namespace Beryl.RootFinding
{

    public static class RootFindingsExtension
    {

        #region NewtonSolver

        public static NewtonSolverFunction NewtonSolver(this Function function,Function derivative,IStoppingCriteria stoppingCriteria,int maxIterations=50)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivative, stoppingCriteria, maxIterations);
        }

        public static NewtonSolverFunction NewtonSolver(this Function function,IStoppingCriteria stoppingCriteria,int maxIterations=50)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, stoppingCriteria, maxIterations);
        }

        public static NewtonSolverFunction NewtonSolver(this Function function,int maxIterations=50)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, maxIterations);
        }

        public static NewtonSolverFunction NewtonSolver(this Function function,Function derivative,int maxIterations=50)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivative, maxIterations);
        }

        public static Vector2D NewtonSolve(this Function function, double x0, int multiplicity,Function derivative, IStoppingCriteria stoppingCriteria,int maxIterations=50)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivative, stoppingCriteria, maxIterations)(x0, multiplicity);
        }

        public static Vector2D NewtonSolve(this Function function, double x0, Function derivative, IStoppingCriteria stoppingCriteria, int maxIterations = 50)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivative, stoppingCriteria, maxIterations)(x0);
        }

        public static Vector2D NewtonSolve(this Function function, double x0, int multiplicity, IStoppingCriteria stoppingCriteria, int maxIterations = 50)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, stoppingCriteria, maxIterations)(x0, multiplicity);
        }

        public static Vector2D NewtonSolve(this Function function, double x0, IStoppingCriteria stoppingCriteria, int maxIterations = 50)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, stoppingCriteria, maxIterations)(x0);
        }

        public static Vector2D NewtonSolve(this Function function, double x0,int multiplicity, Function derivative, int maxIterations = 50)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivative, maxIterations)(x0,multiplicity);
        }

        public static Vector2D NewtonSolve(this Function function, double x0, Function derivative, int maxIterations = 50)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivative, maxIterations)(x0);
        }

        public static Vector2D NewtonSolve(this Function function, double x0, int multiplicity, int maxIterations = 50)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, maxIterations)(x0,multiplicity);
        }

        public static Vector2D NewtonSolve(this Function function, double x0, int maxIterations = 50)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, maxIterations)(x0);
        }

        #endregion

        #region BiscetionSolver

        public static BisectionSolverFunction BisectionSolver(this Function function,IStoppingCriteria stoppingCriteria,int maxIterations=50)
        {
            return RootFinding.BisectionSolver.MakeSolver(function, stoppingCriteria, maxIterations);
        }

        public static BisectionSolverFunction BisectionSolver(this Function function,int maxIterations=50)
        {
            return RootFinding.BisectionSolver.MakeSolver(function, maxIterations);
        }

        public static Vector2D BisectionSolve(this Function function, double inf,double sup,IStoppingCriteria stoppingCriteria,int maxIterations=50)
        {
            return RootFinding.BisectionSolver.MakeSolver(function, stoppingCriteria, maxIterations)(inf, sup);
        }

        public static Vector2D BisectionSolve(this Function function,double inf,double sup,int maxIterations=50)
        {
            return RootFinding.BisectionSolver.MakeSolver(function, maxIterations)(inf, sup);
        }

        #endregion

        #region SecantSolver

        public static SecantSolverFunction SecantSolver(this Function function,IStoppingCriteria stoppingCrieria,int maxIterations=50)
        {
            return RootFinding.SecantSolver.MakeSolver(function, stoppingCrieria, maxIterations);
        }

        public static SecantSolverFunction SecantSolver(this Function function, int maxIterations=50)
        {
            return RootFinding.SecantSolver.MakeSolver(function, maxIterations);
        }

        public static Vector2D SecantSolve(this Function function,double x0,double x1,IStoppingCriteria stoppingCriteria,int maxIterations=50)
        {
            return RootFinding.SecantSolver.MakeSolver(function, stoppingCriteria, maxIterations)(x0, x1);
        }

        public static Vector2D SecantSolve(this Function function,double x0,double x1,int maxIterations=50)
        {
            return RootFinding.SecantSolver.MakeSolver(function, maxIterations)(x0, x1);
        }

        #endregion

    }

}
