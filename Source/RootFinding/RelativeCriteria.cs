using System;

using Beryl.Utilities.Structures;

namespace Beryl.RootFinding
{
    /// <summary>
    /// Stopping criteria based on the distance normalized to a reference point of f(x) from 0
    /// </summary>
    public class RelativeCriteria : IReferenceStoppingCriteria
    {
        //the reference value of the distance
        private double _referenceValue;

        //the attribute behind Tolerance
        private double _tolerance;
        /// <summary>
        /// The maximum accepted normalized distance from 0
        /// </summary>
        /// <value>The maximum normalized distance</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when a negative value is passed</exception>
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

        /// <param name="tolerance">The maximum accepted normalized distance of f(x) from 0</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when a negative tolerance is passed</exception>
        public RelativeCriteria(double tolerance)
        {
            Tolerance = tolerance;
        }

        /// <summary>
        /// Check if the normalized distance of the point from y=0 is less than the tolerance
        /// </summary>
        /// <param name="point"></param>
        /// <returns>True if the distance is less than the tolerance, otherwise False</returns>
        public bool FullfilCriteria(Vector2D point)
        {
            return Math.Abs(point.y)<Tolerance*Math.Abs(_referenceValue);
        }

        /// <summary>
        /// Set initial estimation reference
        /// </summary>
        /// <param name="referencePoint">The initial estimation reference</param>
        public void SetReference(Vector2D referencePoint)
        {
            _referenceValue = referencePoint.y;
        }
    }
}
