using System.Collections.Generic;

namespace Beryl.Utilities.Extension
{
    public static class LinkedListExtension
    {
        public static T[] ToArray<T>(this LinkedList<T> list)
        {
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
