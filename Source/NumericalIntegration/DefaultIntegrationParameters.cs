using System;

namespace Beryl.NumericalIntegration
{
    public static class DefaultIntegrationParameters
    {
        public static readonly double INITIAL_DEFAULT_MAX_STEP = 0.01;

        private static double _defaultMaxStep;
        public static double DefaultMaxStep
        {
            get
            {
                return _defaultMaxStep;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("value", "The maximum step must be positive");
                _defaultMaxStep = value;
            }
        }

        static DefaultIntegrationParameters()
        {
            _defaultMaxStep = INITIAL_DEFAULT_MAX_STEP;
        }

    }
}
