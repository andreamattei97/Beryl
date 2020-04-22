using Beryl.Utilities.Structures;

namespace Beryl.RootFinding
{
    /// <summary>
    /// Interface for defining a stopping criteria of a root finding method
    /// </summary>
    public interface IStoppingCriteria
    {
        /// <summary>
        /// Check if the given point fullfil the stopping condition
        /// </summary>
        /// <param name="point">The point to be checked</param>
        /// <returns>True if the point fullfil the criteria otherwise False</returns>
        bool FullfilCriteria(Point2D point);

    }
}
