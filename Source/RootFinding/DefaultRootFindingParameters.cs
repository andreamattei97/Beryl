using System;
using Beryl.NumericalDerivation;

namespace Beryl.RootFinding
{    
    /// <summary>
    /// Manages the default parameters of the Root Finding module
    /// </summary>
    public static class DefaultRootFindingParameters
    {
        /// <summary>
        /// The initial default maximum number of iterations
        /// </summary>
        /// <value>10000</value>
        public static readonly int INITIAL_DEFAULT_MAX_ITERATIONS = 10000;
        /// <summary>
        /// The tolerance of the initial default stopping criteria (<see cref="AbsoluteCriteria"/>)
        /// </summary>
        /// <value>0.000001</value>
        public static readonly double INITIAL_ABSOLUTE_CRITERIA_TOLERANCE = 0.000001;
        /// <summary>
        /// The step of the initial default numerical derivative generator (type of the derivative: <see cref="CentralDerivative"/>)
        /// </summary>
        /// <value>0.0001</value>
        public static readonly double INITIAL_DEFAULT_DERIVATIVE_STEP = 0.0001;
        /// <summary>
        /// The default multiplicity of the searched zero using a <see cref="NewtonSolverFunction"/>
        /// </summary>
        /// <value>1</value>
        public const int DEFAULT_NEWTON_METHOD_MULTIPLICITY = 1;

        //the attribute behind DefaultMaxIterations
        private static int _defaultMaxIterations;
        /// <summary>
        /// <para>The defaul maximum number of iterations of the method before stopping</para>
        /// <para>Check <see cref="INITIAL_DEFAULT_MAX_ITERATIONS"/> for the intial default value</para>
        /// </summary>/// <value>The default order</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed order is negative</exception>
        public static int DefaultMaxIterations
        {
            get
            {
                return _defaultMaxIterations;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", "The number of iteractions must be non-negative");
                _defaultMaxIterations = value;
            }
        }

        //the attribute behind DefaultStoppingCriteria
        private static IStoppingCriteria _defaultStoppingCriteria;
        /// <summary>
        /// <para>The defaul stopping criteria for root finding methods</para>
        /// <para>Initially set as an <see cref="AbsoluteCriteria"/> with tolerance <see cref="INITIAL_ABSOLUTE_CRITERIA_TOLERANCE"/></para>
        /// </summary>
        /// <value>The default stopping criteria</value>
        /// <exception cref="System.ArgumentNullException">Thrown when the passed order is null</exception>
        public static IStoppingCriteria DefaultStoppingCriteria
        {
            get
            {

                return _defaultStoppingCriteria;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                _defaultStoppingCriteria = value;
            }
        }

        private static DerivativeGenerator _defaultDerivativeGenerator;
        /// <summary>
        /// <para>The defaul numerical derivative generator used by <see cref="NewtonSolver"/></para>
        /// <para>Initially set as a <see cref="CentralDerivative"/> generator of step <see cref="INITIAL_DEFAULT_DERIVATIVE_STEP"/>"/></para>
        /// </summary>
        /// <value>The default derivative generator</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed order is null</exception>
        public static DerivativeGenerator DefaultDerivativeGenerator
        {
            get
            {
                return _defaultDerivativeGenerator;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                _defaultDerivativeGenerator = value;
            }
        }

        static DefaultRootFindingParameters()
        {
            _defaultMaxIterations = INITIAL_DEFAULT_MAX_ITERATIONS;
            _defaultStoppingCriteria = new AbsoluteCriteria(INITIAL_ABSOLUTE_CRITERIA_TOLERANCE);
            _defaultDerivativeGenerator = CentralDerivative.MakeGenerator(INITIAL_DEFAULT_DERIVATIVE_STEP, 1);
        }

    }
}
