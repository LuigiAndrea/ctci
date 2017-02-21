//Sum Lists: You have two numbers represented by a linked list,where each node contains a single digit. 
//The digits are stored in reverse order,such that the 1's digit is at the head of the list. 
//Write a function that adds the two numbers and returns the sum as a linked list. 

using Singly = Chapter2.SinglyLinkedListNode;

namespace Chapter2
{
    public class Q2_5SumList
    {
        public static Singly addLists(Singly list1, Singly list2)
        {
            return addListsCarry(list1, list2, 0);
        }

        private static Singly addListsCarry(Singly list1, Singly list2, int carry)
        {
            if (list1 == null && list2 == null && carry == 0)
                return null;

            int value = ((list1 != null) ? list1.data : 0) +
                        ((list2 != null) ? list2.data : 0) +
                        carry;

            Singly res = new Singly(value % 10, null,
                        addListsCarry(list1?.next, list2?.next, value > 9 ? 1 : 0));
            return res;
        }
    }
}