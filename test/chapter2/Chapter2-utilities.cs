using LinkedListNode = Chapter2.LinkedListNode;
namespace Tests.Chapter2
{
    internal class Utilities
    {
        internal static LinkedListNode buildLinkedListNodeFromArray(int[] values)
        {
            if (values.Length == 0)
                return null;

            LinkedListNode node = new LinkedListNode(values[0], null, null);
            LinkedListNode nodePrec = node;
            for (int i = 1; i < values.Length; i++)
            {
                nodePrec = new LinkedListNode(values[i], nodePrec, null);
            }

            return node;
        }
    }
}