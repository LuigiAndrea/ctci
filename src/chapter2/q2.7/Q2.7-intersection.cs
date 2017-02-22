// Intersection: Given two (singly) linked lists, determine if the two lists intersect.
// Return the intersecting node. 
using Singly = Chapter2.SinglyLinkedListNode;

namespace Chapter2
{
    public class Q2_7Intersection
    {
        private class infoList
        {
            public int size;
            public Singly lastNode;

            public infoList(int size,Singly lastNode){
                this.size = size;
                this.lastNode = lastNode;
            }
        }

        public static Singly intersection(Singly l1, Singly l2)
        {
            if (l1 == null || l2 == null)
                return null;

            infoList res1 = getTailandSize(l1);
            infoList res2 = getTailandSize(l2);

            if (res1.lastNode != res2.lastNode)
            {
                return null;
            }

            int diffLists = 0; ;
            if (res1.size > res2.size)
            {
                diffLists = res1.size - res2.size;
                l1 = alignList(l1, diffLists);

            }
            else if (res1.size < res2.size)
            {
                diffLists = res2.size - res1.size;
                l2 = alignList(l2, diffLists);
            }

            return findIntersectionNode(l1, l2);

        }

        private static Singly findIntersectionNode(Singly l1, Singly l2)
        {
            while (l1 !=  l2 )
            {
                l1 = l1.next;
                l2 = l2.next;
            }

            return l1;
        }

        private static Singly alignList(Singly l1, int diffLists)
        {
            for (int i = 0; i < diffLists; i++)
            {
                l1 = l1.next;
            }

            return l1;
        }

        private static infoList getTailandSize(Singly l)
        {
            if (l == null)
                return null;

            int count = 1;
            while (l.next != null)
            {
                count++;
                l = l.next;
            }

            return new infoList(count,l);
        }
    }
}