using System;

namespace Beryl.NumericalDerivation
{
    /// <summary>
    /// Manages the default parameters of the Numerical Derivation module
    /// </summary>
    public static class DefaultNumericalDerivationParameters
    {
        /// <summary>
        /// The initial default order
        /// </summary>
        /// <value>1</value>
        public static readonly int INITIAL_DEFAULT_ORDER = 1;

        //the attribute behind DefaultOrder
        private static int _defaultOrder;
        /// <summary>
        /// <para>The default order of finite differences</para>
        /// <para>Check <see cref="DefaultNumericalDerivationParameters.INITIAL_DEFAULT_ORDER"/> for the intial default value</para>
        /// </summary>
        /// <value>The default order</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed order is negative</exception>
        public static int DefaultOrder
        {
            get
            {
                return _defaultOrder;
            }
            set
            {
                if(value<0)
                    throw new ArgumentOutOfRangeException("value", "The order of the derivative must be non-negative");
                _defaultOrder = value;
            }
        }

        static DefaultNumericalDerivationParameters()
        {
            _defaultOrder = INITIAL_DEFAULT_ORDER;
        }
    }
}
