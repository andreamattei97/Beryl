using System;
using Beryl.Utilities.Structures;

namespace Beryl.RootFinding
{
    //checks if the difference between the current and previous solutions is smaller than the given tolerance
    /// <summary>
    /// Stopping criteria based on the distance between 2 consecutive iterations
    /// </summary>
    public class SuccessiveAbsoluteCriteria : IReferenceStoppingCriteria
    {

        //the attribute behind Tolerance
        private double _tolerance;

        /// <summary>
        /// The maximum accepted distance between 2 consecutive iterations
        /// </summary>
        /// <value>The maximum distance</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when a negative value is passed</exception>
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

        private Vector2D _previousPoint;

        /// <param name="tolerance">The maximum accepted distance between 2 consecutive iterations</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when a negative tolerance is passed</exception>
        public SuccessiveAbsoluteCriteria(double tolerance)
        {
            Tolerance = tolerance;
        }

        /// <summary>
        /// Check if the absolute distance between 2 consecutive iteration is less than the tolerance.
        /// At the end of the control stores the passed point as previous iteration
        /// </summary>
        /// <param name="point">The point to check</param>
        /// <returns>True if the distance is less than the tolerance, otherwise False</returns>
        public bool FullfilCriteria(Vector2D point)
        {
            bool success = Math.Abs(point.x - _previousPoint.x) < Tolerance;
            _previousPoint = point;
            return success;
        }

        /// <summary>
        /// Set initial estimation reference
        /// </summary>
        /// <param name="referencePoint">The initial estimation reference</param>
        public void SetReference(Vector2D referencePoint)
        {
            _previousPoint = referencePoint;
        }
    }
}
