// Summary:
// Implement an algorithm to delete a node in the middle 
//(any node but the first and last node, not necessarily the exact middle)
// of a Singly Linked List, given only access to that node.

using Singly = Chapter2.SinglyLinkedListNode;

namespace Chapter2
{
    public class Q2_3DeleteMiddleNode
    {
        //It is not possible to determine if the node passed to the function is the first node of a Singly Linked List
        public static bool DeleteMiddleNode(Singly middleNode)
        {
            if (middleNode == null || middleNode.next == null)
                return false;

            Singly nextNode = middleNode.next;
            middleNode.data = nextNode.data;
            middleNode.next = nextNode.next;
            return true;

        }
    }
}