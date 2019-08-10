namespace Beryl.NumericalIntegration
{
    public static class DefaultIntegrationParameters
    {
        public static readonly double INITIAL_DEFAULT_MAX_STEP = 0.01;

        public static double DefaultMaxStep
        {
            get;
            set;
        }

        static DefaultIntegrationParameters()
        {
            DefaultMaxStep = INITIAL_DEFAULT_MAX_STEP;
        }

    }
}
