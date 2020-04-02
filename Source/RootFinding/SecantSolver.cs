using System;
using Beryl.Utilities.Structures;
using Beryl.Utilities.Extension;

namespace Beryl.RootFinding
{

    public class SecantSolver
    {

        /// <summary>
        /// Generates Secant method-based solver for the given function that has the given stopping criteria. The maximum number of iterations of the solver is set to the given number
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="stoppingCriteria">The stopping criteria of the solver</param>
        /// <param name="maxIterations">The maximum number of iterations of the solver</param>
        /// <returns>The solver of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed stopping criteria is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed number of maximum iterations is negative</exception>
        public static SecantSolverFunction MakeSolver(Function function, IStoppingCriteria stoppingCriteria, int maxIterations)
        {
            return new SecantSolver(function, stoppingCriteria, maxIterations).Solve;
        }

        /// <summary>
        /// Generates Secant method-based solver for the given function that has the given stopping criteria. The maximum number of iterations of the solver is set to the default number
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="stoppingCriteria">The stopping criteria of the solver</param>
        /// <returns>The solver of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed stopping criteria is null</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static SecantSolverFunction MakeSolver(Function function, IStoppingCriteria stoppingCriteria)
        {
            return new SecantSolver(function, stoppingCriteria, DefaultRootFindingParameters.DefaultMaxIterations).Solve;
        }

        /// <summary>
        /// Generates Secant method-based solver for the given function that has the default stopping criteria. The maximum number of iterations of the solver is set to the given number
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="maxIterations">The maximum number of iterations of the solver</param>
        /// <returns>The solver of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed number of maximum iterations is negative</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static SecantSolverFunction MakeSolver(Function function, int maxIterations)
        {
            return new SecantSolver(function, DefaultRootFindingParameters.DefaultStoppingCriteria, maxIterations).Solve;
        }

        /// <summary>
        /// Generates Secant method-based solver for the given function that has the default stopping criteria. The maximum number of iterations of the solver is set to the default number
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <returns>The solver of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
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

        public double Solve(double x0, double x1)
        {

            if (!x0.IsFinite())
                throw new ArgumentOutOfRangeException("x0", "the first initial estimation of the root must be finite");
            if (!x1.IsFinite())
                throw new ArgumentOutOfRangeException("x1", "the second initial estiamtion of the root must be finite");

            double xn1 = x1,xn0=x0,x=0;
            double fn1 = function(xn1),fn0=function(xn0);
            bool success = false;

            //set the reference estimation 
            if (stoppingCriteria is IReferenceStoppingCriteria)
            {
                ((IReferenceStoppingCriteria)stoppingCriteria).SetReference(new Vector2D(xn1, function(fn1)));
            }

            for (int k = 0; k < maxIterations; k++)
            {
                double d = (fn1 - fn0)/ (xn1 - xn0);
                x = xn1 - fn1/ d ;
               
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

            return xn1;
        }
    }
}
