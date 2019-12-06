namespace Beryl.NumericalDerivation
{
    /// <summary>
    /// Encapsulates a method that generates the derivative of the given function
    /// </summary>
    /// <param name="function">The function to derive</param>
    /// <returns>The derivative function</returns>
    public delegate Function DerivativeGenerator(Function function);
}
