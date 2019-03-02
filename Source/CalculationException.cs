using System;

namespace Beryl
{
    //exception throwed when a calculation fails
    class CalculationException : Exception
    {
        public Func<Double, Double> PassedFunction
        {
            get;
            private set;
        }
        public CalculationException(string message, Func<double, double> passedFunction = null, Exception innerException = null) : base(message, innerException)
        {
            PassedFunction = passedFunction;
        }
    }
}