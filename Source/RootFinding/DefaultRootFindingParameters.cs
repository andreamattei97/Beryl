using System;
using Beryl.NumericalDerivation;

namespace Beryl.RootFinding
{
    public static class DefaultRootFindingParameters
    {
        public static readonly int INITIAL_DEFAULT_MAX_ITERATIONS = 10000;
        public static readonly double INITIAL_ABSOLUTE_CRITERIA_TOLERANCE = 0.000001;
        public static readonly double INITIAL_DEFAULT_DERIVATIVE_STEP = 0.0001;
        public const int DEFAULT_NEWTON_METHOD_MULTIPLICITY = 1;

        private static int _defaultMaxIterations;
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

        private static IStoppingCriteria _defaultStoppingCriteria;
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
