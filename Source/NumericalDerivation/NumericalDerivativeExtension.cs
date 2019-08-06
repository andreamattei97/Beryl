namespace Beryl.NumericalDerivation
{
    public static class DerivativeExtension
    {
        #region CentralDerivative

        public static double CentralDerivative(this Function function,double x,double step,int order)
        {
            return NumericalDerivation.CentralDerivative.MakeDerivative(function, step, order)(x);
        }

        public static double CentralDerivative(this Function function, double x, double step)
        {
            return NumericalDerivation.CentralDerivative.MakeDerivative(function, step, DefaultNumericalDerivationParameters.DefaultOrder)(x);
        }

        public static Function CentralDerivative(this Function function,double step,int order)
        {
            return NumericalDerivation.CentralDerivative.MakeDerivative(function, step, order);
        }

        public static Function CentralDerivative(this Function function, double step)
        {
            return NumericalDerivation.CentralDerivative.MakeDerivative(function, step, DefaultNumericalDerivationParameters.DefaultOrder);
        }

        #endregion

        #region BackwardDerivative

        public static double BackwardDerivative(this Function function, double x, double step, int order)
        {
            return NumericalDerivation.BackwardDerivative.MakeDerivative(function, step, order)(x);
        }

        public static double BackwardDerivative(this Function function, double x, double step)
        {
            return NumericalDerivation.BackwardDerivative.MakeDerivative(function, step, DefaultNumericalDerivationParameters.DefaultOrder)(x);
        }

        public static Function BackwardDerivative(this Function function, double step, int order)
        {
            return NumericalDerivation.BackwardDerivative.MakeDerivative(function, step, order);
        }

        public static Function BackwardDerivative(this Function function, double step)
        {
            return NumericalDerivation.BackwardDerivative.MakeDerivative(function, step, DefaultNumericalDerivationParameters.DefaultOrder);
        }

        #endregion

        #region ForwardDerivative

        public static double ForwardDerivative(this Function function, double x, double step, int order)
        {
            return NumericalDerivation.ForwardDerivative.MakeDerivative(function, step, order)(x);
        }

        public static double ForwardDerivative(this Function function, double x, double step)
        {
            return NumericalDerivation.ForwardDerivative.MakeDerivative(function, step, DefaultNumericalDerivationParameters.DefaultOrder)(x);
        }

        public static Function ForwardDerivative(this Function function, double step, int order)
        {
            return NumericalDerivation.ForwardDerivative.MakeDerivative(function, step, order);
        }

        public static Function ForwardDerivative(this Function function, double step)
        {
            return NumericalDerivation.ForwardDerivative.MakeDerivative(function, step, DefaultNumericalDerivationParameters.DefaultOrder);
        }

        #endregion
    }
}
