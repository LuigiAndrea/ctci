using System.Text;
using static System.Console;

namespace Chapter2
{
    public class SinglyLinkedListNode : LinkedListNode
    {
        public SinglyLinkedListNode next;

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

        public SinglyLinkedListNode() { }

        private void setPrevNode(SinglyLinkedListNode p)
        {
            if (p != null)
                p.next = this;
        }

        public override void printLinkedList()
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