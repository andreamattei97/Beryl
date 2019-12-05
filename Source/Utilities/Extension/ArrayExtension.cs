using System;

namespace Beryl.Utilities.Extension
{
    public static class ArrayExtension
    {
        public static T[] SubSegment<T>(this T[] array, int startingIndex, int length)
        {
            if (startingIndex < 0 && startingIndex >= array.Length)
                new ArgumentOutOfRangeException("startingIndex", "the starting index is out of bounds");
            if (length < 0)
                new ArgumentOutOfRangeException("length", "the length must be non-negative");
            if (startingIndex + length >= array.Length)
                new ArgumentOutOfRangeException("length", "the length correspond to a sub-segment out of bounds");

            T[] result = new T[length];
            for(int i=startingIndex;i<startingIndex+length;i++)
            {
                result[i - startingIndex] = array[i];
            }

            return result;
        }
    }
}
