using System;
using System.Collections.Generic;

namespace Beryl.Utilities.Extension
{
    /// <summary>
    /// Contains useful extension methods for <see cref="System.Collections.Generic.LinkedList{T}"/>
    /// </summary>
    public static class LinkedListExtension
    {
        /// <summary>
        /// Returns an array of the elements of the linked list in its order
        /// </summary>
        /// <typeparam name="T">The type of the elements of the list</typeparam>
        /// <param name="list">The linked list source of the elements</param>
        /// <returns>The array of the elements of the linked list</returns>
        /// <exception cref="ArgumentNullException">Thrown when the passed list is null</exception>
        public static T[] ToArray<T>(this LinkedList<T> list)
        {
            if (list == null)
                throw new ArgumentNullException("list");

            T[] result = new T[list.Count];
            LinkedListNode<T> currentNode = list.First;
            for (int i = 0; i < list.Count; i++)
            {
                result[i] = currentNode.Value;
                currentNode = currentNode.Next;
            }
            return result;
        }
    }
}
