using System;
using Beryl.Utilities.Extension;
using Beryl.Utilities.Structures;

namespace Beryl.RootFinding
{
    /// <summary>
    /// A solver that implements the Bisection method
    /// </summary>
    /// <remarks>    
    /// <para>This class serves for estimating the root of a function using the Bisection method.</para>
    /// <para>The solver uses a stopping criteria (<see cref="IStoppingCriteria"/>) for checking if
    /// the current approximated root has reached the desired precision.
    /// If the number of iterations of the solver exceeds the maximum set then the solver aborts and throws an <see cref="CalculationException"/>.
    /// Both the stopping criteria and the maximum iteration are optional parameters, see <see cref="DefaultRootFindingParameters"/> for default values of optional parameters.
    /// </para>
    /// <para>For more info on how the method works check the related <a href="https://en.wikipedia.org/wiki/Bisection_method">Wikipedia page</a> 
    /// </para>
    /// </remarks>
    public class BisectionSolver
    {
        /// <summary>
        /// Generates a Bisection method-based solver for the given function with the given stopping criteria (capped to the given maximum number of iterations)
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="stoppingCriteria">The stopping criteria of the solver</param>
        /// <param name="maxIterations">The maximum number of iterations of the solver</param>
        /// <returns>The solver of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception>        
        /// <exception cref="ArgumentNullException">Thrown when the passed stopping criteria is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed number of maximum iterations is negative</exception>
        public static BisectionSolverFunction MakeSolver(Function function, IStoppingCriteria stoppingCriteria, int maxIterations)
        {
            return new BisectionSolver(function, stoppingCriteria, maxIterations).Solve;
        }

        /// <summary>
        /// <para>Generates a Bisection method-based solver for the given function with the given stopping criteria (capped to the default maximum number of iterations)</para>
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="stoppingCriteria">The stopping criteria of the solver</param>
        /// <returns>The solver of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception>        
        /// <exception cref="ArgumentNullException">Thrown when the passed stopping criteria is null</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static BisectionSolverFunction MakeSolver(Function function, IStoppingCriteria stoppingCriteria)
        {
            return new BisectionSolver(function, stoppingCriteria, DefaultRootFindingParameters.DefaultMaxIterations).Solve;
        }

        /// <summary>
        /// <para>Generates a Bisection method-based solver for the given function with the default stopping criteria (capped to the given maximum number of iterations)</para>
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="maxIterations">The maximum number of iterations before the solver aborts</param>
        /// <returns>The solver of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception>        
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed number of maximum iterations is negative</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static BisectionSolverFunction MakeSolver(Function function,int maxIterations)
        {
            return new BisectionSolver(function, DefaultRootFindingParameters.DefaultStoppingCriteria, maxIterations).Solve;
        }

        /// <summary>
        /// <para>Generates a Bisection method-based solver for the given function with the default stopping criteria (capped to the default maximum number of iterations)</para>
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <returns>The solver of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception>   
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>      
        public static BisectionSolverFunction MakeSolver(Function function)
        {
            return new BisectionSolver(function, DefaultRootFindingParameters.DefaultStoppingCriteria, DefaultRootFindingParameters.DefaultMaxIterations).Solve;
        }

        private readonly int maxIterations;

        //the stopping criteria
        private readonly IStoppingCriteria stoppingCriteria;

        private readonly Function function;

        private BisectionSolver(Function function, IStoppingCriteria stoppingCriteria,int maxIterations)
        {
            if (function == null)
                throw new ArgumentNullException("function");
            if (maxIterations < 0)
                throw new ArgumentOutOfRangeException("MaxIterations", "The number of iteractions must be non-negative");
            if (stoppingCriteria == null)
                throw new ArgumentNullException("stoppingCriteria");

            this.maxIterations = maxIterations;
            this.stoppingCriteria = stoppingCriteria;
            this.function = function;

        }

        //returns the point which axproximates the zero inside the interval
        private double Solve(double inf,double sup)
        {

            if (!inf.IsFinite())
                throw new ArgumentOutOfRangeException("inf", "the infimum of the range must be finite");
            if (!sup.IsFinite())
                throw new ArgumentOutOfRangeException("sup", "the supremum of the range must be finite");

            double a=inf, b=sup, x=0;
            double fa=function(a), fb=function(b),fx=0;
            
            bool success = false;

            //check if the interval is valid
            if(fa*fb>0)
            {
                throw new CalculationException("Not valid interval",function);
            }

            //first iteration can be used for providing a reference estimation
            x = (a + b) / 2;
            fx = function(x);
            if (fx * fa < 0)
            {
                b = x;
                fb = fx;
            }
            else if (fx * fb < 0)
            {
                a = x;
                fa = fx;
            }

            //set the initial reference estimation if needed 
            if(stoppingCriteria is IReferenceStoppingCriteria)
            {
                ((IReferenceStoppingCriteria)stoppingCriteria).SetReference(new Vector2D(x, fx));
            }

            for(int k=0; k<maxIterations;k++)
            {
                x = (a + b) / 2;
                fx = function(x);

                if(stoppingCriteria.FullfilCriteria(new Vector2D(x,fx)))
                {
                    success = true;
                    break;
                }

                if(fx*fa<0)
                {
                    b = x;
                    fb = fx;
                }
                else if(fx*fb<0)
                {
                    a = x;
                    fa = fx;
                }
            }

            if (!success)
                throw new CalculationException("No convergence to the solution (exceded the maximum number of iterations)", function);

            return x;
        }
    }
}
