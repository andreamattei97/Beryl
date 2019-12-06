using System;

namespace Beryl
{
    /// <summary>
    /// Exception throwed when a calculation fails
    /// </summary>
    public class CalculationException : Exception
    {
        /// <summary>
        /// The function on which the calculations were performed
        /// </summary>
        /// <value>The function passed to the method</value>
        public Function PassedFunction
        {
            get;
            private set;
        }

        /// <param name="message">The message of the exception</param>
        /// <param name="passedFunction">The function passed to the method</param>
        /// <param name="innerException">The expection that caused the current exception</param>
        public CalculationException(string message,Function passedFunction=null,Exception innerException=null) : base(message,innerException)
        {
            PassedFunction = passedFunction;
        }
    }
}
