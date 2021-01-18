// Summary:
// Implement an algorithm to find the kth to last element of a singly linked list
using Singly = Chapter2.SinglyLinkedListNode;

namespace Chapter2
{
    public class Q2_2KthToLastElement
    {
        //k=1 last element
        //k=2 the second to last element
        public static Singly KLastElement(Singly head, int k)
        {
            if (k <= 0)
                return null;

            Singly node = head;
            int i = 0;

            while (node != null)
            {
                i++;
                node = node.next;
            }

            int index = i - k;
            if (index < 0)
                return null;

            node = head;
            i = 0;

            while (i != index)
            {
                i++;
                node = node.next;
            }

            return node;
        }

        public static Singly KLastElementTwoPointers(Singly head, int k)
        {
            Singly p1 = head;
            Singly p2 = head;

            for (int i = 0; i < k; i++)
            {
                if(p1==null) return null;
                p1 = p1.next;
            }

            while (p1 != null)
            {
                p1 = p1.next;
                p2 = p2.next;
            }

            return p2;

        }
    }
}