//Follow up Iterative version
//Suppose the digits are stored in forward order. Repeat the precendent problem.

using Singly = Chapter2.SinglyLinkedListNode;

namespace Chapter2
{
    public class Q2_5SumListFollowUpIterative
    {
        public static Singly addListsForward2(Singly list1, Singly list2)
        {
            int n1 = getNumber(list1);
            int n2 = getNumber(list2);
            int sum = n1+ n2;

            return buildList(sum);
        }

        private static int getNumber(Singly list)
        {
          int number =0;
          while(list !=null){
              number*=10;
              number+=list.data;
              list=list.next;
          }

          return number;
        }

        private static Singly buildList(int num){
            Singly result = null;
            Singly next = null;
            while(num > 0){
                result = new Singly(num%10,null,next);
                num/=10;
                next = result;
            }

            return result;
        }


    }
}