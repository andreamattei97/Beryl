using System;
using Beryl.Utilities.Structures;

namespace Beryl.RootFinding
{
    //checks if the difference between the current and previous solutions (normalized to current solution) is smaller than the given tolerance
    public class SuccessiveRelativeCriteria : IStoppingCriteria
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
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Tolerance", "The tolerance must be non-negative");
                _tolerance = value;
            }
        }

        public Vector2D PreviousPoint
        {
            get;
            private set;
        }

        public SuccessiveRelativeCriteria(double tolerance) => Tolerance = tolerance;

        public bool FullfilCriteria(Vector2D point)
        {
            bool success = Math.Abs(point.x - PreviousPoint.x) < Tolerance*Math.Abs(point.x);
            PreviousPoint = point;
            return success;
        }

        public void SetCriteria(Vector2D referencePoint)
        {
            PreviousPoint = referencePoint;
        }
    }
}
