using System;

namespace Beryl.Utilities.Extension
{
    /// <summary>
    /// Contains useful Double extension methods
    /// </summary>
    public static class DoubleExtension
    {
        /// <summary>
        /// Returns if the number is finite (i.e. is not infinity or NaN).
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <returns>True if the number is not infinity or NaN, otherwise returns False</returns>
        public static bool IsFinite(this double number)
        {
            return !double.IsInfinity(number) && !double.IsNaN(number);
        }

        /// <summary>
        /// Check if the array of double contains only finite numbers
        /// </summary>
        /// <param name="numbers">The vector to check</param>
        /// <returns>True if all elements of the array are finite (i.e. not infinity or NaN), otherwise returns False</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed numbers vector is null</exception>
        public static bool IsFinite(this double[] numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException("numbers");

            bool NonFinite = false;
            foreach(double number in numbers)
            {
                if (double.IsInfinity(number) || double.IsNaN(number))
                {
                    NonFinite = true;
                    break;
                }
            }
            return NonFinite;
        }

        /// <summary>
        /// Calculates the order of magnitude of the given number
        /// </summary>
        /// <param name="number">The numver to check</param>
        /// <returns>The order of magnitude of the number (if the number is 0 it returns 0)</returns>
        public static int OrderOfMagnitude(this double number)
        {
            if (number == 0)
                return 0;
            return (int)(System.Math.Floor(System.Math.Log10(System.Math.Abs(number))));
        }
    }
}
