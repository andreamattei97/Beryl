using Beryl.Utilities.Structures;

namespace Beryl.RootFinding
{

    /// <summary>
    /// A delegate that encapsulates a bisection method-based solver of a function
    /// </summary>
    /// <param name="inf">The infimum of the range where to search the root</param>
    /// <param name="sup">The supremum of the range where to search the root</param>
    /// <returns>The estimation of the root</returns>
    public delegate double BisectionSolverFunction(double inf, double sup);

    /// <summary>
    /// A delegate that encapsulates a Newton's method-based solver of a function
    /// </summary>
    /// <param name="x0">The initial estimation of the root</param>
    /// <param name="multiplicity">The multiplicity of root (default value 1)</param>
    /// <returns>The estimation of the root</returns>
    public delegate double NewtonSolverFunction(double x0, int multiplicity = DefaultRootFindingParameters.DEFAULT_NEWTON_METHOD_MULTIPLICITY);

    /// <summary>
    /// A delegate that encapsulates a secant method-based solver of a function
    /// </summary>
    /// <param name="x0">The first initial estimation of the root</param>
    /// <param name="x1">The second initial estimation of the root</param>
    /// <returns>The estimation of the root</returns>
    public delegate double SecantSolverFunction(double x0, double x1);
}
