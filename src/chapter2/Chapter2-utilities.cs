using System;

namespace Chapter2
{
    public static class Utilities
    {
        public static T buildLinkedListNodeFromArray<T>(int[] values) where T : LinkedListNode, new()
        {
            if (values==null || values.Length == 0)
                return null;
            T node = (T)Activator.CreateInstance(typeof(T), new object[] { values[0], null, null });
            T nodePrec = node;
            for (int i = 1; i < values.Length; i++)
            {
                nodePrec = (T)Activator.CreateInstance(typeof(T), new object[] { values[i], nodePrec, null });
            }
            return node;
        }
    }
}