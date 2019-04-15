namespace Beryl.NumericalDerivation
{

    public static class DerivativeExtension
    {

        public static double CentralDerivative(this Function function,double x,double step,int order=1)
        {
            return NumericalDerivation.CentralDerivative.MakeDerivative(function, step, order)(x);
        }

        public static Function CentralDerivative(this Function function,double step,int order=1)
        {
            return NumericalDerivation.CentralDerivative.MakeDerivative(function, step, order);
        }

        public static double BackwardDerivative(this Function function, double x, double step, int order = 1)
        {
            return NumericalDerivation.BackwardDerivative.MakeDerivative(function, step, order)(x);
        }

        public static double ForwardDerivative(this Function function, double x, double step, int order = 1)
        {
            return NumericalDerivation.ForwardDerivative.MakeDerivative(function, step, order)(x);
        }

    }
}
