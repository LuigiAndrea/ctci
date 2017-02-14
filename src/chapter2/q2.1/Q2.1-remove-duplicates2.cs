// FOLLOW UP
// How would you solve this problem if a temporary buffer is not allowed?
// Used built in LinkedList and LinkedListNode

using System.Collections.Generic;

namespace Chapter2
{
    public class Q2_1RemoveDuplicates2
    {
        public static void removeDuplicatesNoBuffer(LinkedList<int> list)
        {
            LinkedListNode<int> head = list.First;
            LinkedListNode<int> nextNode;
            LinkedListNode<int> newNode;

            while (head != null)
            {
                nextNode = head.Next;
                while (nextNode != null)
                {
                    newNode = nextNode.Next;
                    if (head.Value.Equals(nextNode.Value))
                    {
                        list.Remove(nextNode);
                    }

                    nextNode = newNode;
                }
                head = head.Next;
            }
        }

        //Different approach using the tail of the list
        public static void removeDuplicatesNoBuffer2(LinkedList<int> list)
        {
            LinkedListNode<int> head = list.First;
            LinkedListNode<int> tail = list.Last;
            LinkedListNode<int> previousNode;
            while (head != null)
            {
                while (tail != head)
                {
                    previousNode = tail.Previous;
                    if (tail.Value.Equals(head.Value))
                    {
                        list.Remove(tail);
                    }
                    tail = previousNode;
                }

                head = head.Next;
                tail = list.Last;
            }
        }
    }
}