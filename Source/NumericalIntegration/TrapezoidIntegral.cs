using System;
using Beryl.Utilities;

namespace Beryl.NumericalIntegration
{
    //numerical integral based on the trapezoid composite formula
    class TrapezoidIntegral
    {

        public static IntegratalFunction MakeIntegral(Function function, double maxStep)
        {
            return (new TrapezoidIntegral(function,maxStep)).Integrate;
        }

        private readonly double maxStep;

        private readonly Function function;
        private readonly Function wrappedFunction;

        private TrapezoidIntegral(Function function, double maxStep)
        {

            if (maxStep <= 0)
                throw new ArgumentOutOfRangeException("maxStep", "the maximum step of integration must be positive");

            this.maxStep = maxStep;

            this.function= function;
            wrappedFunction = FunctionWrapper.MakeWrapper(function);

        }

        //approximates the integral between a and b divided the interval in n sub-intervals (with n defined by the parameter intervals) 
        //each integrated with a trapezoid formula
        public double Integrate(double a,double b)
        {

            int intervals =(int) Math.Ceiling((b - a) / maxStep);
            double correctedStep = (b - a) / intervals;

            double result = correctedStep / 2 * (wrappedFunction(a) + wrappedFunction(b));
            for(int i=1;i<intervals;i++)
            {
                double x = a + correctedStep * i;
                result += wrappedFunction(x)*correctedStep;
            }

            return result;
        }

    }
}
