using static System.Console;

namespace Chapter2
{
    public class DoubleLinkedListNode:LinkedListNode
    {
        public DoubleLinkedListNode next;
        public DoubleLinkedListNode prev;

        public DoubleLinkedListNode(int d, DoubleLinkedListNode p, DoubleLinkedListNode n)
        {
            data = d;
            prev = p;
            next = n;

            setNextNode(n);
            setPrevNode(p);
        }
        public DoubleLinkedListNode(int d)
        {
            data = d;
        }

        public DoubleLinkedListNode()
        {
        }

        public void setNextNode(DoubleLinkedListNode n)
        {
            if (n != null)
                n.prev = this;
        }

        public void setPrevNode(DoubleLinkedListNode p)
        {
            if (p != null)
                p.next = this;
        }

        public override void printLinkedList()
        {
            list.Clear();
            prev?.stringBackward();
            stringForward();
            WriteLine(list);
        }

        private void stringBackward()
        {
            if (prev != null)
            {
                list.Insert(0, $"{data} --> ");
                prev.stringBackward();
            }
            else
            {
                list.Insert(0, $"{data} --> ");
            }
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