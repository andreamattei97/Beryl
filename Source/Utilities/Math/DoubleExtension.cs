namespace Beryl.Utilities.Math
{
    public static class DoubleExtension
    {
        //extension method for cheking if a number is not infinity or NaN
        public static bool IsFinite(this double number)
        {
            return !double.IsInfinity(number) && !double.IsNaN(number);
        }

        //extension method for checking if an array of doubles contains only finite numbers
        public static bool IsFinite(this double[] numbers)
        {
            bool NonFinite = false;
            foreach(double number in numbers)
            {
                if (double.IsInfinity(number) || double.IsNaN(number))
                {
                    NonFinite = false;
                    break;
                }
            }
            return NonFinite;
        }
    }
}
