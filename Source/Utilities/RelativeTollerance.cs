using System;

namespace Beryl.Utilities
{
    //the tollerance is with respect to a reference value
    class RelativeTollerance : ITollerance
    {

        private double _tollerance = 0;
        public double Tollerance
        {
            get { return _tollerance; }
            set
            {
                if (value == Double.NaN || value < 0 || Double.IsInfinity(value))
                    throw new ArgumentOutOfRangeException("Tollerance", "The tollerance must be non-negative");
                _tollerance = value;
            }
        }

        public double GetTollerance(double refValue) => _tollerance * refValue;

        public RelativeTollerance(double tollerance) => Tollerance = tollerance;
    }
}
