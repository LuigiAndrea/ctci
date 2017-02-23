//Loop Detection: Given a circular linked list, 
//implement an algorithm that returns the node at the beginning of the loop. 

using Singly = Chapter2.SinglyLinkedListNode;
using System.Collections.Generic;

namespace Chapter2
{
    public class Q2_8LoopDetection2
    {
        public static Singly loopDetection2(Singly list)
        {
            Dictionary<Singly, bool> dic = new Dictionary<Singly, bool>();

            while (list != null)
            {
                if (dic.ContainsKey(list))
                {
                    return list;
                }

                dic.Add(list, false);
                list = list.next;
            }

            return null;
        }
    }
}