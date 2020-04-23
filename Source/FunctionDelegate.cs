using Beryl.Utilities.Structures;

namespace Beryl
{
    /// <summary>
    /// Encapsulates a generic function of type y=f(x) with x scalar
    /// </summary>
    /// <param name="x">The point in which the function is calculated</param>
    /// <returns>The value of the function in x</returns>
    public delegate double Function (double x);

    /// <summary>
    /// Encapsulates a generic function of type y=f(x) with x vector
    /// </summary>
    /// <param name="x">The array of points in which the function is calculated</param>
    /// <returns>The value of the function in each point of x</returns>
    public delegate double[] ArrayFunction(double[] x);

    public delegate T MapFunction<T>(T structure) where T : IMap<T>;
}