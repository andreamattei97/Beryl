using System;
using Beryl.Utilities.Structures;
using Beryl.Utilities.Extension;

namespace Beryl.RootFinding
{

    public class SecantSolver
    {

        public static SecantSolverFunction MakeSolver(Function function, IStoppingCriteria stoppingCriteria, int maxIterations)
        {
            return new SecantSolver(function, stoppingCriteria, maxIterations).Solve;
        }

        public static SecantSolverFunction MakeSolver(Function function, IStoppingCriteria stoppingCriteria)
        {
            return new SecantSolver(function, stoppingCriteria, DefaultRootFindingParameters.DefaultMaxIterations).Solve;
        }

        public static SecantSolverFunction MakeSolver(Function function, int maxIterations)
        {
            return new SecantSolver(function, DefaultRootFindingParameters.DefaultStoppingCriteria, maxIterations).Solve;
        }

        public static SecantSolverFunction MakeSolver(Function function)
        {
            return new SecantSolver(function, DefaultRootFindingParameters.DefaultStoppingCriteria, DefaultRootFindingParameters.DefaultMaxIterations).Solve;
        }

        private readonly int maxIterations;

        //the stopping criteria
        private readonly IStoppingCriteria stoppingCriteria;

        private readonly Function function;

        private SecantSolver(Function function, IStoppingCriteria stoppingCriteria, int maxIterations)
        {

            if (maxIterations < 0)
                throw new ArgumentOutOfRangeException("MaxIterations", "The number of iteractions must be non-negative");
            this.maxIterations = maxIterations;
            this.function = function;
            this.stoppingCriteria = stoppingCriteria;
        }

        public Vector2D Solve(double x0, double x1)
        {

            double xn1 = x1,xn0=x0,x=0;
            double fn1 = function(xn1),fn0=function(xn0);
            bool success = false;

            stoppingCriteria.SetCriteria(new Vector2D(xn1, function(fn1)));

            for (int k = 0; k < maxIterations; k++)
            {
                double d = (fn1 - fn0)/ (xn1 - xn0);
                x = xn1 - fn1/ d ;
                if (!x.IsFinite())
                    throw new CalculationException("Found a non finite point in the succession to the root", function);

                fn0 = fn1;
                xn0 = xn1;
                fn1 = function(x);
                xn1 = x;

                if (stoppingCriteria.FullfilCriteria(new Vector2D(xn1, fn1)))
                {
                    success = true;
                    break;
                }
            }

            if (!success)
                throw new CalculationException("No convergence to the solution (exceded the maximum number of iterations)", function);

            return new Vector2D(xn1, fn1);
        }
    }
}
