using System;
using Beryl.Utilities.Structures;

namespace Beryl.RootFinding
{
    //checks if the value of the approximated solution normalized to a fixed value is smaller than the given tolerance
    public class RelativeCriteria : IStoppingCriteria
    {

        public double ReferenceValue { get; private set; }

        private double _tolerance;
        public double Tolerance {
            get
            {
                return _tolerance;
            }
            private set
            {
                if(value < 0)
                    throw new ArgumentOutOfRangeException("Tolerance", "The tolerance must be non-negative");
                _tolerance = value;
            }
        }

        public RelativeCriteria(double tolerance)
        {
            Tolerance = tolerance;
        }
          
        public bool FullfilCriteria(Vector2D point)
        {
            return Math.Abs(point.y)<Tolerance*Math.Abs(ReferenceValue);
        }

        public void SetCriteria(Vector2D referencePoint)
        {
            ReferenceValue = referencePoint.y;
        }
    }
}
