using System;

namespace Beryl.Utilities
{
    //represented a fixed tollerance (the reference value is not considered)
    class AbsoluteTollerance:ITollerance
    {

        private double _tollerance=0;
        public double Tollerance
        {
            get{ return _tollerance; }
            set
            {
                if(value < 0 || !value.IsFinite()) 
                    throw new ArgumentOutOfRangeException("Tollerance", "The tollerance must be finite and non-negative");
                _tollerance = value;
            }
        }

        public double GetTollerance(double refValue) => _tollerance;

        public AbsoluteTollerance(double tollerance) => Tollerance = tollerance;

    }
}
