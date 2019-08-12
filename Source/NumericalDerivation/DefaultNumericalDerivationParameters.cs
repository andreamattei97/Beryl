using System;

namespace Beryl.NumericalDerivation
{
    public static class DefaultNumericalDerivationParameters
    {
        public static readonly int INITIAL_DEFAULT_ORDER = 1;

        private static int _defaultOrder;
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
