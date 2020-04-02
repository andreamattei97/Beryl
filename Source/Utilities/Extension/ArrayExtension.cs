using System;

namespace Beryl.Utilities.Extension
{
    /// <summary>
    /// Contains useful array extension methods
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Get the sub-array of the given that starts at the given index and has the given length
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array</typeparam>
        /// <param name="array">The array from which the sub-array is taken</param>
        /// <param name="startingIndex">The starting index of the sub-array</param>
        /// <param name="length">The length of the sub-array</param>
        /// <returns>The sub-array that starts and startingIndex of the given length</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed starting index is out of the bound of the array (i.e. less than 0 or greater than or equal to the length of the original array).</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the passed length is negativa</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the desired sub-array exceeds the boundary of the original array (i.e. the sum of the passed startingIndex and the passed length is greater than or equal to the length of the original array).</exception>
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
