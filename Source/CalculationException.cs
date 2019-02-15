using System;

namespace Beryl
{
    //exception throwed when a calculation fails
    class CalculationException : Exception
    {
        public CalculationException(string message) : base(message)
        {
        }
    }
}
