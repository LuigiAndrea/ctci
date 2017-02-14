using static System.Console;
using LinkedListNode = Chapter2.LinkedListNode;
using static Chapter2.Q2_1RemoveDuplicatesFromScratch;
//using System.Collections.Generic;
//using System.Text;

namespace Program.ctci
{
    public class CrackingTheCodeInterview
    {
        public static void Main(string[] args)
        {
            LinkedListNode node = new LinkedListNode(0, null, null);
            LinkedListNode nodePrec = node;
            for (int i = 1; i < 5; i++)
            {
                nodePrec = new LinkedListNode(i-i%2, nodePrec, null);
            }
            node.printLinkedList();
            removeDuplicates(node);
            node.printLinkedList();

        }
    }
}
