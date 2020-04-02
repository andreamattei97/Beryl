using System;

using Beryl.Utilities.Structures;

namespace Beryl.RootFinding
{
    /// <summary>
    /// Stopping criteria based on the absolute distance of f(x) from 0
    /// </summary>
    public class AbsoluteCriteria : IStoppingCriteria
    {
        //attribute behind Tolerance
        private double _tolerance;
        /// <summary>
        /// The maximum accepted absolute distance of f(x) from 0
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
                if (value <0)
                    throw new ArgumentOutOfRangeException("Tolerance", "The tolerance must be non-negative");
                _tolerance = value;
            }
        }

        /// <param name="tolerance">The maximum accepted absolute distance of f(x) from 0</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when a negative tolerance is passed</exception>
        public AbsoluteCriteria(double tolerance)
        {
            Tolerance = tolerance;
        }

        /// <summary>
        /// Check if the absolute distance of the point from y=0 is less than the tolerance
        /// </summary>
        /// <param name="point"></param>
        /// <returns>True if the distance is less than the tolerance, otherwise False</returns>
        public bool FullfilCriteria(Vector2D point)
        {
            return Math.Abs(point.y)<Tolerance;
        }
        
    }
}
