//Loop Detection: Given a circular linked list, 
//implement an algorithm that returns the node at the beginning of the loop. 

using Singly = Chapter2.SinglyLinkedListNode;

namespace Chapter2
{
    public class Q2_8LoopDetection
    {
        public static Singly loopDetection(Singly list)
        {
            if (list == null)
            {
                return null;
            }

           Singly nodeCollision = findNode(list);

           while(nodeCollision != list){
               nodeCollision=nodeCollision.next;
               list = list.next;
           }

            return nodeCollision;
        }

        private static Singly findNode(Singly list)
        {
            Singly p1 = new Singly(list.data,null,list.next);
            Singly p2 = new Singly(list.data,null,list.next);
            Singly result = null;
            while (p1 != p2 && p1 != null && p2 != null)
            {
                p1 = p1?.next;
                p2 = p2?.next?.next;
            }

            if (p1 == p2)
            {
                result = p2;
            }

            return result;
        }
    }
}