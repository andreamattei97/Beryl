using System;

namespace Beryl
{
    //exception throwed when a calculation fails
    class CalculationException : Exception
    {
        public Function PassedFunction
        {
            get;
            private set;
        }
        public CalculationException(string message,Function passedFunction=null,Exception innerException=null) : base(message,innerException)
        {
            PassedFunction = passedFunction;
        }
    }
}
