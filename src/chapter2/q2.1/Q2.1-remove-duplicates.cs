using System.Collections.Generic;

namespace Chapter2
{
    public class Q2_1RemoveDuplicates
    {
        // Summary:
        // Write code to remove duplicates from an unsorted linked list.
        // Used built in LinkedList and LinkedListNode
        public static void removeDuplicates(LinkedList<int> list)
        {
            Dictionary<int, bool> d = new Dictionary<int, bool>();
            LinkedListNode<int> head = list.First;

            while (head != null)
            {
                LinkedListNode<int> nextNode = head.Next;
                if (d.ContainsKey(head.Value))
                {
                    list.Remove(head);
                }
                else
                {
                    d.Add(head.Value, true);
                }

                head = nextNode;
            }
        }
    }
}