// Summary:
// Write code to remove duplicates from an unsorted linked list. (Double Linked List)
// Used LinkedListNode from scratch

using System.Collections.Generic;

namespace Chapter2
{
    public class Q2_1RemoveDuplicatesFromScratch
    {
        public static void removeDuplicates(DoubleLinkedListNode node)
        {
            Dictionary<int, bool> dic = new Dictionary<int, bool>();
            while (node != null)
            {
                if (dic.ContainsKey(node.data))
                {
                    node.prev.next = node.next;

                    if (node.next != null)
                    {
                        node.next.prev = node.prev;
                    }
                }
                else
                {
                    dic.Add(node.data, true);
                }

                node = node.next;
            }
        }

        public static void removeDuplicatesNoBuffer(DoubleLinkedListNode head)
        {
            DoubleLinkedListNode currentNode = head;
            DoubleLinkedListNode nextNode;
            while (currentNode != null)
            {
                nextNode = currentNode.next;
                while (nextNode != null)
                {
                    if (currentNode.data.Equals(nextNode.data))
                    {
                        nextNode.prev.next = nextNode.next;
                        if (nextNode.next != null)
                            nextNode.next.prev = nextNode.prev;
                    }
                    nextNode = nextNode.next;
                }
                currentNode = currentNode.next;
            }
        }
    }
}

