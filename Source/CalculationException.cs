using System;

namespace Beryl
{
    //exception throwed when a calculation fails
    class CalculationException : Exception
    {
        public CalculationException(string message,Exception innerException=null) : base(message,innerException)
        {
        }
    }
}
