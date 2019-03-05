

namespace Beryl.NumericalIntegration
{

    public delegate double IntegratalFunction(double a, double b);

    public static class IntegrationExtension
    {

        public static IntegratalFunction TrapezoidIntegral(this Function function,double maxStep=0.01)
        {
            return NumericalIntegration.TrapezoidIntegral.MakeIntegral(function, maxStep);
        }

        public static double TrapezoidIntegrate(this Function function,double a,double b,double maxStep=0.01)
        {
            return NumericalIntegration.TrapezoidIntegral.MakeIntegral(function, maxStep)(a, b);
        }

        public static IntegratalFunction SimpsonIntegral(this Function function, double maxStep = 0.01)
        {
            return NumericalIntegration.SimpsonIntegral.MakeIntegral(function, maxStep);
        }

        public static double SimpsonIntegrate(this Function function, double a, double b, double maxStep=0.01)
        {
            return NumericalIntegration.SimpsonIntegral.MakeIntegral(function, maxStep)(a, b);
        }

    }
}
