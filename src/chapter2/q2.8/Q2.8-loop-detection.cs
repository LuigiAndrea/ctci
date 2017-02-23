//Loop Detection: Given a circular linked list, 
//implement an algorithm that returns the node at the beginning of the loop. 

using Singly = Chapter2.SinglyLinkedListNode;

namespace Chapter2
{
    public class Q2_8LoopDetection
    {
        public static Singly loopDetection(Singly listHead)
        {
            if (listHead == null)
            {
                return null;
            }

            Singly nodeCollision = findCollisionNode(listHead);

            if (nodeCollision == null)
                return nodeCollision;

            while (nodeCollision != listHead)
            {
                nodeCollision = nodeCollision.next;
                listHead = listHead.next;
            }

            return nodeCollision;
        }

        private static Singly findCollisionNode(Singly list)
        {
            Singly p1 = new Singly(list.data, null, list.next);
            Singly p2 = new Singly(list.data, null, list.next);
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