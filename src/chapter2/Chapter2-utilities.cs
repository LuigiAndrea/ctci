using System;

namespace Chapter2
{
    public static class Utilities
    {
        public static TList buildLinkedListNodeFromArray<TList,TValues>(TValues[] values) where TList : LinkedListNode, new()
        {
            if (values==null || values.Length == 0)
                return null;
            TList node = (TList)Activator.CreateInstance(typeof(TList), new object[] { values[0], null, null });
            TList nodePrec = node;
            for (int i = 1; i < values.Length; i++)
            {
                nodePrec = (TList)Activator.CreateInstance(typeof(TList), new object[] { values[i], nodePrec, null });
            }
            return node;
        }
    }
}