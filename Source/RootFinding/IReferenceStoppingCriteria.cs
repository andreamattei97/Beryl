using Beryl.Utilities.Structures;

namespace Beryl.RootFinding
{
    /// <summary>
    /// Interface for defining a stopping criteria that store an initial reference estimation (first iteriation)
    /// </summary>
    public interface IReferenceStoppingCriteria:IStoppingCriteria
    {
        /// <summary>
        /// Set reference point for the criteria
        /// </summary>
        /// <param name="referencePoint">The reference point of the criteria</param>
        void SetReference(Vector2D referencePoint);
    }
}
