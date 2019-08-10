namespace Beryl.NumericalIntegration
{

    public static class NumericalIntegrationExtension
    {

        public static IntegratalFunction TrapezoidIntegral(this Function function)
        {
            return NumericalIntegration.TrapezoidIntegral.MakeIntegral(function, DefaultIntegrationParameters.DefaultMaxStep);
        }

        public static IntegratalFunction TrapezoidIntegral(this Function function,double maxStep)
        {
            return NumericalIntegration.TrapezoidIntegral.MakeIntegral(function, maxStep);
        }

        public static double TrapezoidIntegrate(this Function function,double a,double b,double maxStep)
        {
            return NumericalIntegration.TrapezoidIntegral.MakeIntegral(function, maxStep)(a, b);
        }

        public static double TrapezoidIntegrate(this Function function, double a, double b)
        {
            return NumericalIntegration.TrapezoidIntegral.MakeIntegral(function, DefaultIntegrationParameters.DefaultMaxStep)(a, b);
        }

        public static IntegratalFunction SimpsonIntegral(this Function function, double maxStep)
        {
            return NumericalIntegration.SimpsonIntegral.MakeIntegral(function, maxStep);
        }

        public static IntegratalFunction SimpsonIntegral(this Function function)
        {
            return NumericalIntegration.SimpsonIntegral.MakeIntegral(function, DefaultIntegrationParameters.DefaultMaxStep);
        }

        public static double SimpsonIntegrate(this Function function, double a, double b, double maxStep)
        {
            return NumericalIntegration.SimpsonIntegral.MakeIntegral(function, maxStep)(a, b);
        }

        public static double SimpsonIntegrate(this Function function, double a, double b)
        {
            return NumericalIntegration.SimpsonIntegral.MakeIntegral(function, DefaultIntegrationParameters.DefaultMaxStep)(a, b);
        }

    }
}
