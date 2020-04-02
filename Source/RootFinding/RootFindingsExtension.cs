using System;

using Beryl.NumericalDerivation;
using Beryl.Utilities.Structures;

namespace Beryl.RootFinding
{

    public static class RootFindingsExtension
    {

        #region NewtonSolver

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
        public static NewtonSolverFunction NewtonSolver(this Function function,Function derivative,IStoppingCriteria stoppingCriteria,int maxIterations)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivative, stoppingCriteria, maxIterations);
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
        public static NewtonSolverFunction NewtonSolver(this Function function, Function derivative, IStoppingCriteria stoppingCriteria)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivative, stoppingCriteria);
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
        public static NewtonSolverFunction NewtonSolver(this Function function, DerivativeGenerator derivativeGenerator, IStoppingCriteria stoppingCriteria, int maxIterations)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivativeGenerator, stoppingCriteria, maxIterations);
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
        public static NewtonSolverFunction NewtonSolver(this Function function, DerivativeGenerator derivativeGenerator, IStoppingCriteria stoppingCriteria)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivativeGenerator, stoppingCriteria);
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
        public static NewtonSolverFunction NewtonSolver(this Function function,IStoppingCriteria stoppingCriteria,int maxIterations)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, stoppingCriteria, maxIterations);
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
        public static NewtonSolverFunction NewtonSolver(this Function function, IStoppingCriteria stoppingCriteria)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, stoppingCriteria);
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
        public static NewtonSolverFunction NewtonSolver(this Function function,int maxIterations)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, maxIterations);
        }

        /// <summary>
        /// Generates a Newton method-based solver for the given function using the default numerical derivative generator to estimate its derivative and the default stopping criteria. 
        /// The maximum number of iterations of the solver is set to the default value
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <returns>The solver of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static NewtonSolverFunction NewtonSolver(this Function function)
        {
            return RootFinding.NewtonSolver.MakeSolver(function);
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
        public static NewtonSolverFunction NewtonSolver(this Function function,Function derivative,int maxIterations)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivative, maxIterations);
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
        public static NewtonSolverFunction NewtonSolver(this Function function, Function derivative)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivative);
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
        public static NewtonSolverFunction NewtonSolver(this Function function, DerivativeGenerator derivativeGenerator, int maxIterations)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivativeGenerator, maxIterations);
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
        public static NewtonSolverFunction NewtonSolver(this Function function, DerivativeGenerator derivativeGenerator)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivativeGenerator);
        }

        #endregion

        #region NewtonSolve

        /// <summary>
        /// Solves the function by the Newton method looking for a root of the given multiplicity and using its exact derivative and the given initial estimation.
        /// The solver iterates until the approximation satisfies the given criteria or the number of itarations reaches the given limit.
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="x0">The initial estimation of the root</param>
        /// <param name="multiplicity">The multiplicity of the searched root</param>
        /// <param name="derivative">The exact derivative of the function</param>
        /// <param name="stoppingCriteria">The stopping criteria of the solver</param>
        /// <param name="maxIterations">The maximum number of iterations of the solver</param>
        /// <returns>The approximated root of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed initial estimation of the root is non-finite</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passsed multiplicity of the root is negative or zero</exception>
        /// <exception cref="ArgumentNullException">Thrown when the passed derivative is null</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed stopping criteria is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed number of maximum iterations is negative</exception>
        /// <exception cref="CalculationException">Thrown when the maximum of iterations is reached</exception>
        /// <exception cref="CalculationException">Thrown when the solver encounters a point with zero derivative</exception>
        public static double NewtonSolve(this Function function, double x0, int multiplicity, Function derivative, IStoppingCriteria stoppingCriteria, int maxIterations)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivative, stoppingCriteria, maxIterations)(x0, multiplicity);
        }

        /// <summary>
        /// Solves the function by the Newton method looking for a root of the given multiplicity and using its exact derivative and the given initial estimation.
        /// The solver iterates until the approximation satisfies the given criteria or the number of itarations reaches the default limit.
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="x0">The initial estimation of the root</param>
        /// <param name="multiplicity">The multiplicity of the searched root</param>
        /// <param name="derivative">The exact derivative of the function</param>
        /// <param name="stoppingCriteria">The stopping criteria of the solver</param>
        /// <returns>The approximated root of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed initial estimation of the root is non-finite</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passsed multiplicity of the root is negative or zero</exception>
        /// <exception cref="ArgumentNullException">Thrown when the passed derivative is null</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed stopping criteria is null</exception>
        /// <exception cref="CalculationException">Thrown when the maximum of iterations is reached</exception>
        /// <exception cref="CalculationException">Thrown when the solver encounters a point with zero derivative</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static double NewtonSolve(this Function function, double x0, int multiplicity, Function derivative, IStoppingCriteria stoppingCriteria)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivative, stoppingCriteria)(x0, multiplicity);
        }

        /// <summary>
        /// Solves the function by the Newton method looking for a root of the given multiplicity and using a numerical derivative generator to estimate its derivative and the given initial estimation.
        /// The solver iterates until the approximation satisfies the given criteria or the number of itarations reaches the given limit.
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="x0">The initial estimation of the root</param>
        /// <param name="multiplicity">The multiplicity of the searched root</param>
        /// <param name="derivativeGenerator">The derivative generator used for estimating the derivative of the function</param>
        /// <param name="stoppingCriteria">The stopping criteria of the solver</param>
        /// <param name="maxIterations">The maximum number of iterations of the solver</param>
        /// <returns>The approximated root of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed initial estimation of the root is non-finite</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passsed multiplicity of the root is negative or zero</exception>
        /// <exception cref="ArgumentNullException">Thrown when the passed derivative generator is null</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed stopping criteria is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed number of maximum iterations is negative</exception>
        /// <exception cref="CalculationException">Thrown when the maximum of iterations is reached</exception>
        /// <exception cref="CalculationException">Thrown when the solver encounters a point with zero derivative</exception>
        public static double NewtonSolve(this Function function, double x0, int multiplicity, DerivativeGenerator derivativeGenerator, IStoppingCriteria stoppingCriteria, int maxIterations)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivativeGenerator, stoppingCriteria, maxIterations)(x0, multiplicity);
        }

        /// <summary>
        /// Solves the function by the Newton method looking for a root of the given multiplicity and using a numerical derivative generator to estimate its derivative and the given initial estimation.
        /// The solver iterates until the approximation satisfies the given criteria or the number of itarations reaches the given limit.
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="x0">The initial estimation of the root</param>
        /// <param name="multiplicity">The multiplicity of the searched root</param>
        /// <param name="derivativeGenerator">The derivative generator used for estimating the derivative of the function</param>
        /// <param name="stoppingCriteria">The stopping criteria of the solver</param>
        /// <returns>The approximated root of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed initial estimation of the root is non-finite</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passsed multiplicity of the root is negative or zero</exception>
        /// <exception cref="ArgumentNullException">Thrown when the passed derivative generator is null</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed stopping criteria is null</exception>
        /// <exception cref="CalculationException">Thrown when the maximum of iterations is reached</exception>
        /// <exception cref="CalculationException">Thrown when the solver encounters a point with zero derivative</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static double NewtonSolve(this Function function, double x0, int multiplicity, DerivativeGenerator derivativeGenerator, IStoppingCriteria stoppingCriteria)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivativeGenerator, stoppingCriteria)(x0, multiplicity);
        }

        /// <summary>
        /// Solves the function by the Newton method looking for a root of multiplicity 1 and using its exact derivative and the given initial estimation.
        /// The solver iterates until the approximation satisfies the given criteria or the number of itarations reaches the given limit.
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="x0">The initial estimation of the root</param>
        /// <param name="derivative">The exact derivative of the function</param>
        /// <param name="stoppingCriteria">The stopping criteria of the solver</param>
        /// <param name="maxIterations">The maximum number of iterations of the solver</param>
        /// <returns>The approximated root of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed initial estimation of the root is non-finite</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed derivative is null</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed stopping criteria is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed number of maximum iterations is negative</exception>
        /// <exception cref="CalculationException">Thrown when the maximum of iterations is reached</exception>
        /// <exception cref="CalculationException">Thrown when the solver encounters a point with zero derivative</exception>
        public static double NewtonSolve(this Function function, double x0, Function derivative, IStoppingCriteria stoppingCriteria, int maxIterations)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivative, stoppingCriteria, maxIterations)(x0, 1);
        }

        /// <summary>
        /// Solves the function by the Newton method looking for a root of multiplicity 1 and using its exact derivative and the given initial estimation.
        /// The solver iterates until the approximation satisfies the given criteria or the number of itarations reaches the default limit.
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="x0">The initial estimation of the root</param>
        /// <param name="derivative">The exact derivative of the function</param>
        /// <param name="stoppingCriteria">The stopping criteria of the solver</param>
        /// <returns>The approximated root of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed initial estimation of the root is non-finite</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed derivative is null</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed stopping criteria is null</exception>
        /// <exception cref="CalculationException">Thrown when the maximum of iterations is reached</exception>
        /// <exception cref="CalculationException">Thrown when the solver encounters a point with zero derivative</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static double NewtonSolve(this Function function, double x0, Function derivative, IStoppingCriteria stoppingCriteria)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivative, stoppingCriteria)(x0, 1);
        }

        /// <summary>
        /// Solves the function by the Newton method looking for a root of multiplicity 1 and using a numerical derivative generator to estimate its derivative and the given initial estimation.
        /// The solver iterates until the approximation satisfies the given criteria or the number of itarations reaches the given limit.
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="x0">The initial estimation of the root</param>
        /// <param name="derivativeGenerator">The derivative generator used for estimating the derivative of the function</param>
        /// <param name="stoppingCriteria">The stopping criteria of the solver</param>
        /// <param name="maxIterations">The maximum number of iterations of the solver</param>
        /// <returns>The approximated root of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed initial estimation of the root is non-finite</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed derivative generator is null</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed stopping criteria is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed number of maximum iterations is negative</exception>
        /// <exception cref="CalculationException">Thrown when the maximum of iterations is reached</exception>
        /// <exception cref="CalculationException">Thrown when the solver encounters a point with zero derivative</exception>
        public static double NewtonSolve(this Function function, double x0, DerivativeGenerator derivativeGenerator, IStoppingCriteria stoppingCriteria, int maxIterations)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivativeGenerator, stoppingCriteria, maxIterations)(x0, 1);
        }

        /// <summary>
        /// Solves the function by the Newton method looking for a root of multiplicity 1 and using a numerical derivative generator to estimate its derivative and the given initial estimation.
        /// The solver iterates until the approximation satisfies the given criteria or the number of itarations reaches the default limit.
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="x0">The initial estimation of the root</param>
        /// <param name="derivativeGenerator">The derivative generator used for estimating the derivative of the function</param>
        /// <param name="stoppingCriteria">The stopping criteria of the solver</param>
        /// <returns>The approximated root of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed initial estimation of the root is non-finite</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed derivative generator is null</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed stopping criteria is null</exception>
        /// <exception cref="CalculationException">Thrown when the maximum of iterations is reached</exception>
        /// <exception cref="CalculationException">Thrown when the solver encounters a point with zero derivative</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static double NewtonSolve(this Function function, double x0, DerivativeGenerator derivativeGenerator, IStoppingCriteria stoppingCriteria)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivativeGenerator, stoppingCriteria)(x0, 1);
        }

        /// <summary>
        /// Solves the function by the Newton method looking for a root of the given multiplicity and using the default numerical derivative generator to estimate its derivative and the given initial estimation.
        /// The solver iterates until the approximation satisfies the given criteria or the number of itarations reaches the given limit.
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="x0">The initial estimation of the root</param>
        /// <param name="multiplicity">The multiplicity of the searched root</param>
        /// <param name="stoppingCriteria">The stopping criteria of the solver</param>
        /// <param name="maxIterations">The maximum number of iterations of the solver</param>
        /// <returns>The approximated root of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed initial estimation of the root is non-finite</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passsed multiplicity of the root is negative or zero</exception>
        /// <exception cref="ArgumentNullException">Thrown when the passed stopping criteria is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed number of maximum iterations is negative</exception>
        /// <exception cref="CalculationException">Thrown when the maximum of iterations is reached</exception>
        /// <exception cref="CalculationException">Thrown when the solver encounters a point with zero derivative</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static double NewtonSolve(this Function function, double x0, int multiplicity, IStoppingCriteria stoppingCriteria, int maxIterations)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, stoppingCriteria, maxIterations)(x0, multiplicity);
        }

        /// <summary>
        /// Solves the function by the Newton method looking for a root of the given multiplicity and using the default numerical derivative generator to estimate its derivative and the given initial estimation.
        /// The solver iterates until the approximation satisfies the given criteria or the number of itarations reaches the default limit.
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="x0">The initial estimation of the root</param>
        /// <param name="multiplicity">The multiplicity of the searched root</param>
        /// <param name="stoppingCriteria">The stopping criteria of the solver</param>
        /// <returns>The approximated root of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed initial estimation of the root is non-finite</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passsed multiplicity of the root is negative or zero</exception>
        /// <exception cref="ArgumentNullException">Thrown when the passed stopping criteria is null</exception>
        /// <exception cref="CalculationException">Thrown when the maximum of iterations is reached</exception>
        /// <exception cref="CalculationException">Thrown when the solver encounters a point with zero derivative</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static double NewtonSolve(this Function function, double x0, int multiplicity, IStoppingCriteria stoppingCriteria)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, stoppingCriteria)(x0, multiplicity);
        }

        /// <summary>
        /// Solves the function by the Newton method looking for a root of multiplicity 1 and using the default numerical derivative generator to estimate its derivative and the given initial estimation.
        /// The solver iterates until the approximation satisfies the given criteria or the number of itarations reaches the given limit.
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="x0">The initial estimation of the root</param>
        /// <param name="stoppingCriteria">The stopping criteria of the solver</param>
        /// <param name="maxIterations">The maximum number of iterations of the solver</param>
        /// <returns>The approximated root of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed initial estimation of the root is non-finite</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed stopping criteria is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed number of maximum iterations is negative</exception>
        /// <exception cref="CalculationException">Thrown when the maximum of iterations is reached</exception>
        /// <exception cref="CalculationException">Thrown when the solver encounters a point with zero derivative</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static double NewtonSolve(this Function function, double x0, IStoppingCriteria stoppingCriteria, int maxIterations)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, stoppingCriteria, maxIterations)(x0, 1);
        }

        /// <summary>
        /// Solves the function by the Newton method looking for a root of multiplicity 1 and using the default numerical derivative generator to estimate its derivative and the given initial estimation.
        /// The solver iterates until the approximation satisfies the given criteria or the number of itarations reaches the default limit.
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="x0">The initial estimation of the root</param>
        /// <param name="stoppingCriteria">The stopping criteria of the solver</param>
        /// <returns>The approximated root of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed initial estimation of the root is non-finite</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed stopping criteria is null</exception>
        /// <exception cref="CalculationException">Thrown when the maximum of iterations is reached</exception>
        /// <exception cref="CalculationException">Thrown when the solver encounters a point with zero derivative</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static double NewtonSolve(this Function function, double x0, IStoppingCriteria stoppingCriteria)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, stoppingCriteria)(x0, 1);
        }

        /// <summary>
        /// Solves the function by the Newton method looking for a root of the given multiplicity and using its exact derivative and the given initial estimation.
        /// The solver iterates until the approximation satisfies the default criteria or the number of itarations reaches the given limit.
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="x0">The initial estimation of the root</param>
        /// <param name="multiplicity">The multiplicity of the searched root</param>
        /// <param name="derivative">The exact derivative of the function</param>
        /// <param name="maxIterations">The maximum number of iterations of the solver</param>
        /// <returns>The approximated root of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed initial estimation of the root is non-finite</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passsed multiplicity of the root is negative or zero</exception>
        /// <exception cref="ArgumentNullException">Thrown when the passed derivative is null</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed number of maximum iterations is negative</exception>
        /// <exception cref="CalculationException">Thrown when the maximum of iterations is reached</exception>
        /// <exception cref="CalculationException">Thrown when the solver encounters a point with zero derivative</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static double NewtonSolve(this Function function, double x0,int multiplicity, Function derivative, int maxIterations)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivative, maxIterations)(x0,multiplicity);
        }

        /// <summary>
        /// Solves the function by the Newton method looking for a root of the given multiplicity and using its exact derivative and the given initial estimation.
        /// The solver iterates until the approximation satisfies the default criteria or the number of itarations reaches the default limit.
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="x0">The initial estimation of the root</param>
        /// <param name="multiplicity">The multiplicity of the searched root</param>
        /// <param name="derivative">The exact derivative of the function</param>
        /// <returns>The approximated root of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed initial estimation of the root is non-finite</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passsed multiplicity of the root is negative or zero</exception>
        /// <exception cref="ArgumentNullException">Thrown when the passed derivative is null</exception> 
        /// <exception cref="CalculationException">Thrown when the maximum of iterations is reached</exception>
        /// <exception cref="CalculationException">Thrown when the solver encounters a point with zero derivative</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static double NewtonSolve(this Function function, double x0, int multiplicity, Function derivative)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivative)(x0, multiplicity);
        }

        /// <summary>
        /// Solves the function by the Newton method looking for a root of the given multiplicity and using a numerical derivative generator to estimate its derivative and the given initial estimation.
        /// The solver iterates until the approximation satisfies the default criteria or the number of itarations reaches the given limit.
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="x0">The initial estimation of the root</param>
        /// <param name="multiplicity">The multiplicity of the searched root</param>
        /// <param name="derivativeGenerator">The derivative generator used for estimating the derivative of the function</param>
        /// <param name="maxIterations">The maximum number of iterations of the solver</param>
        /// <returns>The approximated root of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed initial estimation of the root is non-finite</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passsed multiplicity of the root is negative or zero</exception>
        /// <exception cref="ArgumentNullException">Thrown when the passed derivative generator is null</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed number of maximum iterations is negative</exception>
        /// <exception cref="CalculationException">Thrown when the maximum of iterations is reached</exception>
        /// <exception cref="CalculationException">Thrown when the solver encounters a point with zero derivative</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static double NewtonSolve(this Function function, double x0, int multiplicity, DerivativeGenerator derivativeGenerator, int maxIterations)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivativeGenerator, maxIterations)(x0, multiplicity);
        }

        /// <summary>
        /// Solves the function by the Newton method looking for a root of the given multiplicity and using a numerical derivative generator to estimate its derivative and the given initial estimation.
        /// The solver iterates until the approximation satisfies the default criteria or the number of itarations reaches the default limit.
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="x0">The initial estimation of the root</param>
        /// <param name="multiplicity">The multiplicity of the searched root</param>
        /// <param name="derivativeGenerator">The derivative generator used for estimating the derivative of the function</param>
        /// <returns>The approximated root of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed initial estimation of the root is non-finite</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passsed multiplicity of the root is negative or zero</exception>
        /// <exception cref="ArgumentNullException">Thrown when the passed derivative generator is null</exception> 
        /// <exception cref="CalculationException">Thrown when the maximum of iterations is reached</exception>
        /// <exception cref="CalculationException">Thrown when the solver encounters a point with zero derivative</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static double NewtonSolve(this Function function, double x0, int multiplicity, DerivativeGenerator derivativeGenerator)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivativeGenerator)(x0, multiplicity);
        }

        /// <summary>
        /// Solves the function by the Newton method looking for a root of multiplicity 1 and using its exact derivative and the given initial estimation.
        /// The solver iterates until the approximation satisfies the default criteria or the number of itarations reaches the given limit.
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="x0">The initial estimation of the root</param>
        /// <param name="derivative">The exact derivative of the function</param>
        /// <param name="maxIterations">The maximum number of iterations of the solver</param>
        /// <returns>The approximated root of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed initial estimation of the root is non-finite</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed derivative is null</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed number of maximum iterations is negative</exception>
        /// <exception cref="CalculationException">Thrown when the maximum of iterations is reached</exception>
        /// <exception cref="CalculationException">Thrown when the solver encounters a point with zero derivative</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static double NewtonSolve(this Function function, double x0, Function derivative, int maxIterations)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivative, maxIterations)(x0, 1);
        }

        /// <summary>
        /// Solves the function by the Newton method looking for a root of multiplicity 1 and using its exact derivative and the given initial estimation.
        /// The solver iterates until the approximation satisfies the default criteria or the number of itarations reaches the default limit.
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="x0">The initial estimation of the root</param>
        /// <param name="derivative">The exact derivative of the function</param>
        /// <returns>The approximated root of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed initial estimation of the root is non-finite</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed derivative is null</exception> 
        /// <exception cref="CalculationException">Thrown when the maximum of iterations is reached</exception>
        /// <exception cref="CalculationException">Thrown when the solver encounters a point with zero derivative</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static double NewtonSolve(this Function function, double x0, Function derivative)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivative)(x0, 1);
        }

        /// <summary>
        /// Solves the function by the Newton method looking for a root of multiplicity 1 and using a numerical derivative generator to estimate its derivative and the given initial estimation.
        /// The solver iterates until the approximation satisfies the default criteria or the number of itarations reaches the given limit.
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="x0">The initial estimation of the root</param>
        /// <param name="derivativeGenerator">The derivative generator used for estimating the derivative of the function</param>
        /// <param name="maxIterations">The maximum number of iterations of the solver</param>
        /// <returns>The approximated root of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed initial estimation of the root is non-finite</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed derivative generator is null</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed number of maximum iterations is negative</exception>
        /// <exception cref="CalculationException">Thrown when the maximum of iterations is reached</exception>
        /// <exception cref="CalculationException">Thrown when the solver encounters a point with zero derivative</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static double NewtonSolve(this Function function, double x0, DerivativeGenerator derivativeGenerator, int maxIterations)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivativeGenerator, maxIterations)(x0, 1);
        }

        /// <summary>
        /// Solves the function by the Newton method looking for a root of multiplicity 1 and using a numerical derivative generator to estimate its derivative and the given initial estimation.
        /// The solver iterates until the approximation satisfies the default criteria or the number of itarations reaches the default limit.
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="x0">The initial estimation of the root</param>
        /// <param name="derivativeGenerator">The derivative generator used for estimating the derivative of the function</param>
        /// <returns>The approximated root of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed initial estimation of the root is non-finite</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed derivative generator is null</exception> 
        /// <exception cref="CalculationException">Thrown when the maximum of iterations is reached</exception>
        /// <exception cref="CalculationException">Thrown when the solver encounters a point with zero derivative</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static double NewtonSolve(this Function function, double x0, DerivativeGenerator derivativeGenerator)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, derivativeGenerator)(x0, 1);
        }

        /// <summary>
        /// Solves the function by the Newton method looking for a root of the given multiplicity and using the default numerical derivative generator to estimate its derivative and the given initial estimation.
        /// The solver iterates until the approximation satisfies the default criteria or the number of itarations reaches the given limit.
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="x0">The initial estimation of the root</param>
        /// <param name="multiplicity">The multiplicity of the searched root</param>
        /// <param name="maxIterations">The maximum number of iterations of the solver</param>
        /// <returns>The approximated root of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed initial estimation of the root is non-finite</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passsed multiplicity of the root is negative or zero</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed number of maximum iterations is negative</exception>
        /// <exception cref="CalculationException">Thrown when the maximum of iterations is reached</exception>
        /// <exception cref="CalculationException">Thrown when the solver encounters a point with zero derivative</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static double NewtonSolve(this Function function, double x0, int multiplicity, int maxIterations)
        {
            return RootFinding.NewtonSolver.MakeSolver(function, maxIterations)(x0,multiplicity);
        }

        /// <summary>
        /// Solves the function by the Newton method looking for a root of the given multiplicity and using the default numerical derivative generator to estimate its derivative and the given initial estimation.
        /// The solver iterates until the approximation satisfies the default criteria or the number of itarations reaches the default limit.
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="x0">The initial estimation of the root</param>
        /// <param name="multiplicity">The multiplicity of the searched root</param>
        /// <returns>The approximated root of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed initial estimation of the root is non-finite</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passsed multiplicity of the root is negative or zero</exception>
        /// <exception cref="CalculationException">Thrown when the maximum of iterations is reached</exception>
        /// <exception cref="CalculationException">Thrown when the solver encounters a point with zero derivative</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static double NewtonSolve(this Function function, double x0, int multiplicity)
        {
            return RootFinding.NewtonSolver.MakeSolver(function)(x0, multiplicity);
        }

        /// <summary>
        /// Solves the function by the Newton method looking for a root of multiplicity 1 and using the default numerical derivative generator to estimate its derivative and the given initial estimation.
        /// The solver iterates until the approximation satisfies the default criteria or the number of itarations reaches the default limit.
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="x0">The initial estimation of the root</param>
        /// <returns>The approximated root of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed initial estimation of the root is non-finite</exception> 
        /// <exception cref="CalculationException">Thrown when the maximum of iterations is reached</exception>
        /// <exception cref="CalculationException">Thrown when the solver encounters a point with zero derivative</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static double NewtonSolve(this Function function, double x0)
        {
            return RootFinding.NewtonSolver.MakeSolver(function)(x0, 1);
        }

        #endregion

        #region BiscetionSolver

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
        public static BisectionSolverFunction BisectionSolver(this Function function,IStoppingCriteria stoppingCriteria,int maxIterations)
        {
            return RootFinding.BisectionSolver.MakeSolver(function, stoppingCriteria, maxIterations);
        }

        /// <summary>
        /// Generates a Bisection method-based solver for the given function with the given stopping criteria (capped to the default maximum number of iterations)
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="stoppingCriteria">The stopping criteria of the solver</param>
        /// <returns>The solver of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception>        
        /// <exception cref="ArgumentNullException">Thrown when the passed stopping criteria is null</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static BisectionSolverFunction BisectionSolver(this Function function, IStoppingCriteria stoppingCriteria)
        {
            return RootFinding.BisectionSolver.MakeSolver(function, stoppingCriteria);
        }

        /// <summary>
        /// Generates a Bisection method-based solver for the given function with the default stopping criteria (capped to the given maximum number of iterations)
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="maxIterations">The maximum number of iterations of the solver</param>
        /// <returns>The solver of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception>        
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed number of maximum iterations is negative</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static BisectionSolverFunction BisectionSolver(this Function function,int maxIterations)
        {
            return RootFinding.BisectionSolver.MakeSolver(function, maxIterations);
        }

        /// <summary>
        /// Generates a Bisection method-based solver for the given function with the default stopping criteria (capped to the default maximum number of iterations)
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <returns>The solver of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception>        
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static BisectionSolverFunction BisectionSolver(this Function function)
        {
            return RootFinding.BisectionSolver.MakeSolver(function);
        }

        #endregion

        #region BisectionSolve

        /// <summary>
        /// Solves the function in the range provided through its supremum and its infimum using the bisection method.
        /// The solver iterates until the approximation satisfies the given criteria or the number of itarations reaches the given limit.
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="inf">The infimum of the range where to search the root</param>
        /// <param name="sup">The supremum of the range where to search the root</param>
        /// <param name="stoppingCriteria">The stopping criteria of the solver</param>
        /// <param name="maxIterations">The maximum number of iterations of the solver</param>
        /// <returns>The approximated root of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception>        
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the infimum or the supremum of the range are not finite</exception>
        /// <exception cref="ArgumentNullException">Thrown when the passed stopping criteria is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed number of maximum iterations is negative</exception>
        /// <exception cref="CalculationException">Thrown when the passed interval is not valid (i.e. f(inf)*f(sup)>0)</exception>
        /// <exception cref="CalculationException">Thrown when the maximum of iterations is reached</exception>
        public static double BisectionSolve(this Function function, double inf,double sup,IStoppingCriteria stoppingCriteria,int maxIterations)
        {
            return RootFinding.BisectionSolver.MakeSolver(function, stoppingCriteria, maxIterations)(inf, sup);
        }

        /// <summary>
        /// Solves the function in the range provided through its supremum and its infimum using the bisection method.
        /// The solver iterates until the approximation satisfies the given criteria or the number of itarations reaches the default limit.
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="inf">The infimum of the range where to search the root</param>
        /// <param name="sup">The supremum of the range where to search the root</param>
        /// <param name="stoppingCriteria">The stopping criteria of the solver</param>
        /// <returns>The approximated root of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception>        
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the infimum or the supremum of the range are not finite</exception>
        /// <exception cref="ArgumentNullException">Thrown when the passed stopping criteria is null</exception>
        /// <exception cref="CalculationException">Thrown when the passed interval is not valid (i.e. f(inf)*f(sup)>0)</exception>
        /// <exception cref="CalculationException">Thrown when the maximum of iterations is reached</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static double BisectionSolve(this Function function, double inf, double sup, IStoppingCriteria stoppingCriteria)
        {
            return RootFinding.BisectionSolver.MakeSolver(function, stoppingCriteria)(inf, sup);
        }

        /// <summary>
        /// Solves the function in the range provided through its supremum and its infimum using the bisection method.
        /// The solver iterates until the approximation satisfies the default criteria or the number of itarations reaches the given limit.
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="inf">The infimum of the range where to search the root</param>
        /// <param name="sup">The supremum of the range where to search the root</param>
        /// <param name="maxIterations">The maximum number of iterations of the solver</param>
        /// <returns>The approximated root of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception>        
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the infimum or the supremum of the range are not finite</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed number of maximum iterations is negative</exception>
        /// <exception cref="CalculationException">Thrown when the passed interval is not valid (i.e. f(inf)*f(sup)>0)</exception>
        /// <exception cref="CalculationException">Thrown when the maximum of iterations is reached</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static double BisectionSolve(this Function function,double inf,double sup,int maxIterations)
        {
            return RootFinding.BisectionSolver.MakeSolver(function, maxIterations)(inf, sup);
        }

        /// <summary>
        /// Solves the function in the range provided through its supremum and its infimum using the bisection method.
        /// The solver iterates until the approximation satisfies the default criteria or the number of itarations reaches the default limit.
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="inf">The infimum of the range where to search the root</param>
        /// <param name="sup">The supremum of the range where to search the root</param>
        /// <returns>The approximated root of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception>        
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the infimum or the supremum of the range are not finite</exception>
        /// <exception cref="CalculationException">Thrown when the passed interval is not valid (i.e. f(inf)*f(sup)>0)</exception>
        /// <exception cref="CalculationException">Thrown when the maximum of iterations is reached</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static double BisectionSolve(this Function function, double inf, double sup)
        {
            return RootFinding.BisectionSolver.MakeSolver(function)(inf, sup);
        }

        #endregion

        #region SecantSolver

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
        public static SecantSolverFunction SecantSolver(this Function function,IStoppingCriteria stoppingCrieria,int maxIterations)
        {
            return RootFinding.SecantSolver.MakeSolver(function, stoppingCrieria, maxIterations);
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
        public static SecantSolverFunction SecantSolver(this Function function, IStoppingCriteria stoppingCrieria)
        {
            return RootFinding.SecantSolver.MakeSolver(function, stoppingCrieria);
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
        public static SecantSolverFunction SecantSolver(this Function function, int maxIterations)
        {
            return RootFinding.SecantSolver.MakeSolver(function, maxIterations);
        }

        /// <summary>
        /// Generates Secant method-based solver for the given function that has the default stopping criteria. The maximum number of iterations of the solver is set to the default number
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <returns>The solver of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception> 
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static SecantSolverFunction SecantSolver(this Function function)
        {
            return RootFinding.SecantSolver.MakeSolver(function);
        }

        #endregion

        #region SecantSolve

        /// <summary>
        /// Solve the given function by the secant method using the two initial estimations.
        /// The solver iterates until the approximation satisfies the given criteria or the number of itarations reaches the given limit.
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="x0">The first initial estimation of the root</param>
        /// <param name="x1">The second initial estimation of the root</param>
        /// <param name="stoppingCriteria">The stopping criteria of the solver</param>
        /// <param name="maxIterations">The maximum number of iterations of the solver</param>
        /// <returns>The approximated root of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception>        
        /// <exception cref="ArgumentOutOfRangeException">Thrown when either the first or the second passed initial estimations of the root is non-finite</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed stopping criteria is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed number of maximum iterations is negative</exception>
        /// <exception cref="CalculationException">Thrown when the maximum of iterations is reached</exception>
        public static double SecantSolve(this Function function,double x0,double x1,IStoppingCriteria stoppingCriteria,int maxIterations)
        {
            return RootFinding.SecantSolver.MakeSolver(function, stoppingCriteria, maxIterations)(x0, x1);
        }

        /// <summary>
        /// Solve the given function by the secant method using the two initial estimations.
        /// The solver iterates until the approximation satisfies the given criteria or the number of itarations reaches the default limit.
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="x0">The first initial estimation of the root</param>
        /// <param name="x1">The second initial estimation of the root</param>
        /// <param name="stoppingCriteria">The stopping criteria of the solver</param>
        /// <returns>The approximated root of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception>        
        /// <exception cref="ArgumentOutOfRangeException">Thrown when either the first or the second passed initial estimations of the root is non-finite</exception> 
        /// <exception cref="ArgumentNullException">Thrown when the passed stopping criteria is null</exception>
        /// <exception cref="CalculationException">Thrown when the maximum of iterations is reached</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static double SecantSolve(this Function function, double x0, double x1, IStoppingCriteria stoppingCriteria)
        {
            return RootFinding.SecantSolver.MakeSolver(function, stoppingCriteria)(x0, x1);
        }

        /// <summary>
        /// Solve the given function by the secant method using the two initial estimations.
        /// The solver iterates until the approximation satisfies the default criteria or the number of itarations reaches the given limit.
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="x0">The first initial estimation of the root</param>
        /// <param name="x1">The second initial estimation of the root</param>
        /// <param name="maxIterations">The maximum number of iterations of the solver</param>
        /// <returns>The approximated root of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception>        
        /// <exception cref="ArgumentOutOfRangeException">Thrown when either the first or the second passed initial estimations of the root is non-finite</exception> 
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the passed number of maximum iterations is negative</exception>
        /// <exception cref="CalculationException">Thrown when the maximum of iterations is reached</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static double SecantSolve(this Function function,double x0,double x1,int maxIterations)
        {
            return RootFinding.SecantSolver.MakeSolver(function, maxIterations)(x0, x1);
        }

        /// <summary>
        /// Solve the given function by the secant method using the two initial estimations.
        /// The solver iterates until the approximation satisfies the default criteria or the number of itarations reaches the default limit.
        /// </summary>
        /// <param name="function">The function to solve</param>
        /// <param name="x0">The first initial estimation of the root</param>
        /// <param name="x1">The second initial estimation of the root</param>
        /// <returns>The approximated root of the function</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed function is null</exception>        
        /// <exception cref="ArgumentOutOfRangeException">Thrown when either the first or the second passed initial estimations of the root is non-finite</exception> 
        /// <exception cref="CalculationException">Thrown when the maximum of iterations is reached</exception>
        /// <remarks><para>For the default parameters check <see cref="DefaultRootFindingParameters"/></para></remarks>
        public static double SecantSolve(this Function function, double x0, double x1)
        {
            return RootFinding.SecantSolver.MakeSolver(function)(x0, x1);
        }

        #endregion

    }

}
