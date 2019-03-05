using System;
using Beryl.Structures;
using Beryl.Utilities;

namespace Beryl.RootFinding
{

    public delegate Vector2D SecantSolverFunction(double x0, double x1);

    class SecantSolver
    {

        public static SecantSolverFunction MakeSolver(Function function, IStoppingCriteria stoppingCriteria, int maxIterations = 50)
        {
            return new SecantSolver(function, stoppingCriteria, maxIterations).Solve;
        }

        public static SecantSolverFunction MakeSolver(Function function, int maxIterations=50)
        {
            return new SecantSolver(function, new AbsoluteCriteria(0.000001), maxIterations).Solve;
        }

        private readonly int maxIterations;

        //the stopping criteria
        private readonly IStoppingCriteria stoppingCriteria;

        private readonly Function function;
        //the function wrapped for detecting non-finite returned values
        private readonly Function wrappedFunction;

        private SecantSolver(Function function, IStoppingCriteria stoppingCriteria, int maxIterations)
        {

            if (maxIterations < 0)
                throw new ArgumentOutOfRangeException("MaxIterations", "The number of iteractions must be non-negative");
            this.maxIterations = maxIterations;

            this.function = function;
            wrappedFunction = FunctionWrapper.MakeWrapper(function);

            this.stoppingCriteria = stoppingCriteria;
        }

        public Vector2D Solve(double x0, double x1)
        {

            double xn1 = x1,xn0=x0,x=0;
            double fn1 = wrappedFunction(xn1),fn0=wrappedFunction(xn0);
            bool success = false;

            stoppingCriteria.SetCriteria(new Vector2D(xn1, wrappedFunction(fn1)));

            for (int k = 0; k < maxIterations; k++)
            {
                double d = (fn1 - fn0)/ (xn1 - xn0);
                x = xn1 - fn1/ d ;
                if (!x.IsFinite())
                    throw new CalculationException("Found a non finite point in the succession to the root", function);

                fn0 = fn1;
                xn0 = xn1;
                fn1 = wrappedFunction(x);
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
