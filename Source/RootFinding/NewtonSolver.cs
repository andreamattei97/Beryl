using System;
using Beryl.NumericalDerivation;
using Beryl.Utilities.Extension;
using Beryl.Utilities.Structures;

namespace Beryl.RootFinding
{
    /// <summary>
    /// A solver that implements the Newton method
    /// </summary>
    /// <remarks>    
    /// <para>This class serves for estimating the root of a function using the Newton method.</para>
    /// <para>The solver can be generated using either the exact derivative (passed as <see cref="Function"/>) or a <see cref="DerivativeGenerator"/> for estimating the derivative of the function.</para>
    /// <para>The solver uses a stopping criteria (<see cref="IStoppingCriteria"/>) for checking if
    /// the current approximated root has reached the desired precision.</para>
    /// <para>If the number of iterations of the solver exceeds the maximum set then the solver aborts and throws an <see cref="CalculationException"/>.</para>
    /// <para>See <see cref="DefaultRootFindingParameters"/> for default values of optional parameters.</para>
    /// <para>For more info on how the method works check the related <a href="https://en.wikipedia.org/wiki/Bisection_method">Wikipedia page</a> 
    /// </para>
    /// </remarks>
    public class NewtonSolver
    {
        /// <summary>
        /// Generates a Newton method-based solver for the given function using its exact derivative and the given stopping criteria. 
        /// The maximum number of iterations of the solver is set to the given value
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="derivative">The exact derivative of the function</param>
        /// <param name="stoppingCriteria">The stopping criteria of the solver</param>
        /// <param name="maxIterations">The maximum number of iterations of the solver</param>
        /// <returns>The solver of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed derivative is null</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed stopping criteria is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed number of maximum iterations is negative</exception>
        public static NewtonSolverFunction  MakeSolver(Function function, Function derivative, IStoppingCriteria stoppingCriteria, int maxIterations)
        {
            return new NewtonSolver(function, derivative, stoppingCriteria, maxIterations).Solve;
        }

        /// <summary>
        /// Generates a Newton method-based solver for the given function using its exact derivative and the given stopping criteria. 
        /// The maximum number of iterations of the solver is set to the default value
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="derivative">The exact derivative of the function</param>
        /// <param name="stoppingCriteria">The stopping criteria of the solver</param>
        /// <returns>The solver of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed derivative is null</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed stopping criteria is null</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static NewtonSolverFunction MakeSolver(Function function, Function derivative, IStoppingCriteria stoppingCriteria)
        {
            return new NewtonSolver(function, derivative, stoppingCriteria, DefaultRootFindingParameters.DefaultMaxIterations).Solve;
        }

        /// <summary>
        /// Generates a Newton method-based solver for the given function using a numerical derivative generator to estimate its derivative and the given stopping criteria. 
        /// The maximum number of iterations of the solver is set to the given value
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="derivativeGenerator">The derivative generator used for estimating the derivative of the function</param>
        /// <param name="stoppingCriteria">The stopping criteria of the solver</param>
        /// <param name="maxIterations">The maximum number of iterations of the solver</param>
        /// <returns>The solver of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed derivative generator is null</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed stopping criteria is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed number of maximum iterations is negative</exception>
        public static NewtonSolverFunction MakeSolver(Function function, DerivativeGenerator derivativeGenerator, IStoppingCriteria stoppingCriteria, int maxIterations)
        {
            return new NewtonSolver(function, derivativeGenerator(function), stoppingCriteria, maxIterations).Solve;
        }

        /// <summary>
        /// Generates a Newton method-based solver for the given function using a numerical derivative generator to estimate its derivative and the given stopping criteria. 
        /// The maximum number of iterations of the solver is set to the default value
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="derivativeGenerator">The derivative generator used for estimating the derivative of the function</param>
        /// <param name="stoppingCriteria">The stopping criteria of the solver</param>
        /// <returns>The solver of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed derivative generator is null</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed stopping criteria is null</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static NewtonSolverFunction MakeSolver(Function function, DerivativeGenerator derivativeGenerator, IStoppingCriteria stoppingCriteria)
        {
            return new NewtonSolver(function, derivativeGenerator(function), stoppingCriteria, DefaultRootFindingParameters.DefaultMaxIterations).Solve;
        }

        /// <summary>
        /// Generates a Newton method-based solver for the given function using the default numerical derivative generator to estimate its derivative and the given stopping criteria. 
        /// The maximum number of iterations of the solver is set to the given value
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="stoppingCriteria">The stopping criteria of the solver</param>
        /// <param name="maxIterations">The maximum number of iterations of the solver</param>
        /// <returns>The solver of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed stopping criteria is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed number of maximum iterations is negative</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static NewtonSolverFunction MakeSolver(Function function,IStoppingCriteria stoppingCriteria,int maxIterations)
        {
            return new NewtonSolver(function, DefaultRootFindingParameters.DefaultDerivativeGenerator(function), stoppingCriteria, maxIterations).Solve;
        }

        /// <summary>
        /// Generates a Newton method-based solver for the given function using the default numerical derivative generator to estimate its derivative and the given stopping criteria. 
        /// The maximum number of iterations of the solver is set to the default value
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="stoppingCriteria">The stopping criteria of the solver</param>
        /// <returns>The solver of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed stopping criteria is null</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static NewtonSolverFunction MakeSolver(Function function, IStoppingCriteria stoppingCriteria)
        {
            return new NewtonSolver(function, DefaultRootFindingParameters.DefaultDerivativeGenerator(function), stoppingCriteria, DefaultRootFindingParameters.DefaultMaxIterations).Solve;
        }

        /// <summary>
        /// Generates a Newton method-based solver for the given function using its exact derivative and the default stopping criteria. 
        /// The maximum number of iterations of the solver is set to the given value
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="derivative">The exact derivative of the function</param>
        /// <param name="maxIterations">The maximum number of iterations of the solver</param>
        /// <returns>The solver of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed derivative is null</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed number of maximum iterations is negative</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static NewtonSolverFunction MakeSolver(Function function,Function derivative,int maxIterations)
        {
            return new NewtonSolver(function, derivative, DefaultRootFindingParameters.DefaultStoppingCriteria, maxIterations).Solve;
        }

        /// <summary>
        /// Generates a Newton method-based solver for the given function using its exact derivative and the default stopping criteria. 
        /// The maximum number of iterations of the solver is set to the default value
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="derivative">The exact derivative of the function</param>
        /// <returns>The solver of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed derivative is null</exception> 
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static NewtonSolverFunction MakeSolver(Function function, Function derivative)
        {
            return new NewtonSolver(function, derivative, DefaultRootFindingParameters.DefaultStoppingCriteria, DefaultRootFindingParameters.DefaultMaxIterations).Solve;
        }

        /// <summary>
        /// Generates a Newton method-based solver for the given function using a numerical derivative generator to estimate its derivative and the default stopping criteria. 
        /// The maximum number of iterations of the solver is set to the given value
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="derivativeGenerator">The derivative generator used for estimating the derivative of the function</param>
        /// <param name="maxIterations">The maximum number of iterations of the solver</param>
        /// <returns>The solver of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed derivative generator is null</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed number of maximum iterations is negative</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static NewtonSolverFunction MakeSolver(Function function, DerivativeGenerator derivativeGenerator, int maxIterations)
        {
            return new NewtonSolver(function, derivativeGenerator(function), DefaultRootFindingParameters.DefaultStoppingCriteria, maxIterations).Solve;
        }

        /// <summary>
        /// Generates a Newton method-based solver for the given function using a numerical derivative generator to estimate its derivative and the default stopping criteria. 
        /// The maximum number of iterations of the solver is set to the default value
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="derivativeGenerator">The derivative generator used for estimating the derivative of the function</param>
        /// <returns>The solver of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed derivative generator is null</exception> 
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static NewtonSolverFunction MakeSolver(Function function, DerivativeGenerator derivativeGenerator)
        {
            return new NewtonSolver(function, derivativeGenerator(function), DefaultRootFindingParameters.DefaultStoppingCriteria, DefaultRootFindingParameters.DefaultMaxIterations).Solve;
        }

        /// <summary>
        /// Generates a Newton method-based solver for the given function using the default numerical derivative generator to estimate its derivative and the default stopping criteria. 
        /// The maximum number of iterations of the solver is set to the given value
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="maxIterations">The maximum number of iterations of the solver</param>
        /// <returns>The solver of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed number of maximum iterations is negative</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static NewtonSolverFunction MakeSolver(Function function,int maxIterations)
        {
            return new NewtonSolver(function, DefaultRootFindingParameters.DefaultDerivativeGenerator(function), DefaultRootFindingParameters.DefaultStoppingCriteria, maxIterations).Solve;
        }

        /// <summary>
        /// Generates a Newton method-based solver for the given function using the default numerical derivative generator to estimate its derivative and the default stopping criteria. 
        /// The maximum number of iterations of the solver is set to the default value
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <returns>The solver of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static NewtonSolverFunction MakeSolver(Function function)
        {
            return new NewtonSolver(function, DefaultRootFindingParameters.DefaultDerivativeGenerator(function), DefaultRootFindingParameters.DefaultStoppingCriteria, DefaultRootFindingParameters.DefaultMaxIterations).Solve;
        }

        private readonly int maxIterations;

        //the stopping criteria
        private readonly IStoppingCriteria stoppingCriteria;

        private readonly Function function;

        //the function derivative
        private readonly Function derivative;

        private NewtonSolver(Function function,Function derivative,IStoppingCriteria stoppingCriteria,int maxIterations)
        {
            this.function = function;

            this.derivative = derivative;

            this.stoppingCriteria = stoppingCriteria;

            this.maxIterations = maxIterations;
        }

        private double Solve(double initialEstimation,int multiplicity=DefaultRootFindingParameters.DEFAULT_NEWTON_METHOD_MULTIPLICITY)
        {
            if (!initialEstimation.IsFinite())
                throw new ArgumentOutOfRangeException("initialEstimation", "the initial estimation of the root must be finite");

            if (multiplicity < 1)
                throw new ArgumentOutOfRangeException("multiplicity", "the multiplicity of the root must be equal or greater than 1");

            double xn = initialEstimation;
            double fn = 0;
            double dfn = 0;
            bool success = false;

            //set the reference estimation 
            if (stoppingCriteria is IReferenceStoppingCriteria)
            {
                ((IReferenceStoppingCriteria)stoppingCriteria).SetReference(new Vector2D(xn, function(xn)));
            }

            for(int k=0;k<maxIterations;k++)
            {
                fn = function(xn);
                dfn = derivative(xn);

                if (dfn == 0 && fn != 0)
                    throw new CalculationException("Cannot continue calculation, the function derivative is 0 in " + xn, function);

                if(stoppingCriteria.FullfilCriteria(new Vector2D(xn,fn)))
                {
                    success = true;
                    break;
                }

                xn = xn -multiplicity * fn / dfn;
            }

            if (!success)
                throw new CalculationException("No convergence to the solution (exceded the maximum number of iterations)", function);

            return xn;
        }
        

    }
}
