using System;

namespace Beryl.Utilities
{
    public static class DoubleExtension
    {
        //extension method for cheking if a number is not infinity or NaN
        public static bool IsFinite(this Double number)
        {
            return !Double.IsInfinity(number) && !Double.IsNaN(number);
        }
    }
}
