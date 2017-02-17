// Implement an algorithm Recursive to find the kth to last element of a singly linked list

using Singly = Chapter2.SinglyLinkedListNode;

namespace Chapter2
{
    public class Q2_2KthToLastElementRecursive
    {
        internal class Index
        {
            internal int value = 0;
        }
        public static Singly KLastElementRec(Singly head, int k)
        {
            Index idx = new Index();
            return KLastElementRec(head, k, idx);
        }

        private static Singly KLastElementRec(Singly head, int k, Index idx)
        {
            if (head == null)
                return null;

            Singly node = KLastElementRec(head.next, k, idx);
            idx.value++;

            if (idx.value == k)
                return head;

            return node;
        }

        //The static version
        public class KThLastEleRec
        {
            private static int idx = 0;
            public static Singly KLastElementRec2(Singly head, int k)
            {
                idx = 0;
                return KLastElementRec(head,k);
            }

            private static Singly KLastElementRec(Singly head, int k)
            {
                if (head == null)
                    return null;

                Singly node = KLastElementRec(head.next, k);
                idx++;

                if (idx == k)
                    return head;

                return node;

            }
        }
    }
}

