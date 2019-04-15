using System;

namespace Beryl.Utilities.Math
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
            for(int i=1;i<=number;i++)
            {
                result *= i;
            }

            return result;
        }
        
        //calculates the binomial coefficient (n k)
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
    }
}