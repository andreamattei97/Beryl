using System;

using Beryl.Utilities.Extension;

namespace Beryl
{
    /// <summary>
    /// Contains useful extra math functions not present in System.Math
    /// </summary>
    public static class MathExtra
    {
        /// <summary>
        /// Calculates the factorial of the given number
        /// </summary>
        /// <param name="number">The number of which the factorial is calculated</param>
        /// <returns>The factorial of the number</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when a negative number is passed</exception>
        public static int Factorial(int number)
        {
            if (number < 0)
                throw new ArgumentOutOfRangeException("number", "The number must be non-negative");

            int result = 1;
            for(int i=1;i<=number;i++)
            {
                result *= i;
            }

            return result;
        }
        
        /// <summary>
        /// Calculates the binomial coefficient of the form n choose k
        /// </summary>
        /// <param name="n">the upper number</param>
        /// <param name="k">the lower number</param>
        /// <returns>The binomial coefficient of the pair</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when n is negative</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when k is less that n</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when k is negative</exception>
        public static int BinomialCoefficient(int n,int k)
        {
            if(n < 0)
                throw new ArgumentOutOfRangeException("n", "n must be non-negative");
            if (k > n)
                throw new ArgumentOutOfRangeException("k", "k must be less than n");
            else if (k < 0)
                throw new ArgumentOutOfRangeException("k", "k must be non-negative");
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }

        /// <summary>
        /// Calculates the precision for which a number approximated an expected value
        /// </summary>
        /// <param name="expected">The expected value</param>
        /// <param name="number">The number to check</param>
        /// <returns>The number of significant figures equal before the first different figures between the 2 number</returns>
        /// <remarks>If the 2 numbers are equals it returns int.MaxValue</remarks>
        public static int CalculatePrecision(double expected, double number)
        {
            if (expected == number)
                return int.MaxValue;
            return expected.OrderOfMagnitude() - (expected - number).OrderOfMagnitude();
        }
    }
}