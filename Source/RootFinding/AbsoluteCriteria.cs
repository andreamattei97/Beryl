using System;
using Beryl.Utilities.Structures;

namespace Beryl.RootFinding
{
    //checks if the value of the approximated solution is smaller than the given tolerance
    class AbsoluteCriteria : IStoppingCriteria
    {
        private double _tolerance;
        public double Tolerance
        {
            get
            {
                return _tolerance;
            }
            private set
            {
                if (value <0)
                    throw new ArgumentOutOfRangeException("Tolerance", "The tolerance must be non-negative");
                _tolerance = value;
            }
        }

        public AbsoluteCriteria(double tolerance)
        {
            Tolerance = tolerance;
        }

        bool IStoppingCriteria.FullfilCriteria(Vector2D point)
        {
            return Math.Abs(point.y)<Tolerance;
        }

        public void SetCriteria(Vector2D referencePoint){}
    }
}
