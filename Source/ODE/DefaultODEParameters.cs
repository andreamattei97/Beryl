using System;

namespace Beryl.ODE
{
    public static class DefaultODEParameters
    {
        public static readonly int INITIAL_DEFAULT_MAX_ITERATIONS = 1000000;
        public static readonly double INITIAL_DEFAULT_DISCRETIZER_STEP = 0.001;

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

        private static SingleStepIteration _defaultauxiliaryIterator;
        public static SingleStepIteration DefaultauxiliaryIterator
        {
            get
            {
                return _defaultauxiliaryIterator;
            }
            set
            {
                if ( value == null)
                    throw new ArgumentNullException("value");
                _defaultauxiliaryIterator = value;
            }
        }

        private static IDiscretizer _defaultDiscretizer;
        public static IDiscretizer DefaultDiscretizer
        {
            get
            {
                return _defaultDiscretizer;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                _defaultDiscretizer = value;
            }
        }

        static DefaultODEParameters()
        {
            DefaultMaxIterations = INITIAL_DEFAULT_MAX_ITERATIONS;
            _defaultauxiliaryIterator = RungeKuttaSolver.Iteration;
            DefaultDiscretizer =new UniformDiscretizer(INITIAL_DEFAULT_DISCRETIZER_STEP);
        }

    }
}
