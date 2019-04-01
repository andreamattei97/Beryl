using System;

namespace Beryl.Utilities
{
    //useful extra math functions that are not in System.Math
    class MathExtra
    {
        //calculates the factorial of the number
        public static int Factorial(int number)
        {
            if (number < 0)
                throw new ArgumentOutOfRangeException("number", "The number must be non-negative");

            int result = 1;
            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }

        //calculates the binomial coefficient (n k)
        public static int BinomialCoefficient(int n, int k)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException("n", "n must be non-negative");
            if (k > n)
                throw new ArgumentOutOfRangeException("k", "k must be less than n");
            else if (k < 0)
                throw new ArgumentOutOfRangeException("k", "k must be non-negative");
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }

        //calculates the nearest greater power of 2 of a number (for negatives numbers it finds the nearest power of 2 of its module)
        public static int Superior2Power(int n)
        {
            int result = 1;

            if (n < 0) //calculates the module
                n = -n;
            else if (n == 0) //no operations required
                return result;

            n -= 1; //for adjusting the result if n is a power of 2

            while (n != 0)
            {
                n = n >> 1;
                result *= 2;
            }
            return result;
        }

    }
}