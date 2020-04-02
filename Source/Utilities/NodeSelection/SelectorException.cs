using System;

namespace Beryl.Utilities.NodeSelection
{
    /// <summary>
    /// The exception throwned when a selector cannot find any node that contains the passed value 
    /// </summary>
    /// <typeparam name="ParameterType">The type of the searched value</typeparam>
    public class SelectorException<ParameterType>:Exception
    {

        /// <summary>
        /// The value searched
        /// </summary>
        public readonly ParameterType X;

        /// <summary>
        /// Initializes the exception with searched value
        /// </summary>
        /// <param name="x">The searched value</param>
        public SelectorException(ParameterType x):base("No node found associated to the argument: "+x.ToString())
        {
            X = x;
        }
    }
}
