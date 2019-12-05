using System;

namespace Beryl.ODE
{
    //exception throwed when a calculation fails
    class ODECalculationException : Exception
    {
        public ODEFunction PassedFunction
        {
            get;
            private set;
        }
        public ODECalculationException(string message, ODEFunction passedFunction = null, Exception innerException = null) : base(message, innerException)
        {
            PassedFunction = passedFunction;
        }
    }
}