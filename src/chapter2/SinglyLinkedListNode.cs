using System.Text;
using static System.Console;

namespace Chapter2
{
    public class SinglyLinkedListNode
    {
        public SinglyLinkedListNode next;
        public SinglyLinkedListNode prev;
        public int data;
        private static StringBuilder list = new StringBuilder();

        public SinglyLinkedListNode(int d, SinglyLinkedListNode p, SinglyLinkedListNode n)
        {
            data = d;
            next = n;
            setPrevNode(p);
        }
        public SinglyLinkedListNode(int d)
        {
            data = d;
        }

        public SinglyLinkedListNode()
        {
        }

        private void setPrevNode(SinglyLinkedListNode p)
        {
            if (p != null)
                p.next = this;
        }
        public void printForward()
        {
            list.Clear();
            stringForward();
            WriteLine(list);
        }

        private void stringForward()
        {
            if (next != null)
            {
                list.Append($"{data} --> ");
                next.stringForward();
            }
            else
            {
                list.Append(data);
            }
        }
    }
}