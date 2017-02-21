//Follow up
//Suppose the digits are stored in forward order. Repeat the precendent problem.

using Singly = Chapter2.SinglyLinkedListNode;

namespace Chapter2
{
    public class Q2_5SumListFollowUp
    {

        protected class PartialSum
        {
            public Singly sum = null;
            public int carry = 0;
        }

        public static Singly addListsForward(Singly list1, Singly list2)
        {
            int len1 = lengthList(list1);
            int len2 = lengthList(list2);

            if (len1 > len2)
            {
                list2 = padList(list2, len1 - len2);
            }
            else if (len1 < len2)
            {
                list1 = padList(list1, len2 - len1);
            }


            PartialSum res = addLists(list1, list2);
            Singly r = null;
            if (res.carry > 0)
            {
                r = new Singly(res.carry, null, res.sum);
                r.data = res.carry;
            }

            return r ?? res.sum;
        }

        private static PartialSum addLists(Singly list1, Singly list2)
        {
            PartialSum sum = null;
            //or list2
            if (list1 == null)
            {
                sum = new PartialSum();
                return sum;
            }

            sum = addLists(list1.next, list2.next);
            int value = list1.data + list2.data + sum.carry;
            Singly s = new Singly(value % 10, null, sum.sum);
            sum.sum = s;
            sum.carry = value / 10;
            return sum;
        }

        private static Singly padList(Singly l, int padding)
        {
            Singly precNode = l;
            Singly newNode = null;
            for (int i = 0; i < padding; i++)
            {
                newNode = new Singly();
                newNode.next = precNode;
                precNode = newNode;
            }

            return newNode;
        }

        private static int lengthList(Singly l)
        {
            if (l == null)
                return 0;

            int count = 1;
            while (l.next != null)
            {
                count++;
                l = l.next;
            }
            return count;
        }
    }
}