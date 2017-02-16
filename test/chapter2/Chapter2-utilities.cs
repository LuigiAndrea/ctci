<<<<<<< HEAD
using System;
using Chapter2;

=======
using LinkedListNode = Chapter2.LinkedListNode;
>>>>>>> 7c9d9639b60ded7b0639a66d5805b790806122cd
namespace Tests.Chapter2
{
    internal class Utilities
    {
<<<<<<< HEAD
        internal static T buildLinkedListNodeFromArray<T>(int[] values) where T : LinkedListNode, new()
        {
            if (values.Length == 0)
                return null;
            T node = (T)Activator.CreateInstance(typeof(T), new object[] { values[0], null, null });
            T nodePrec = node;
            for (int i = 1; i < values.Length; i++)
            {
                nodePrec = (T)Activator.CreateInstance(typeof(T), new object[] { values[i], nodePrec, null });
=======
        internal static LinkedListNode buildLinkedListNodeFromArray(int[] values)
        {
            if (values.Length == 0)
                return null;

            LinkedListNode node = new LinkedListNode(values[0], null, null);
            LinkedListNode nodePrec = node;
            for (int i = 1; i < values.Length; i++)
            {
                nodePrec = new LinkedListNode(values[i], nodePrec, null);
>>>>>>> 7c9d9639b60ded7b0639a66d5805b790806122cd
            }

            return node;
        }
    }
}