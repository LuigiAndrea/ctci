using System.Text;
using static System.Console;
using System;

namespace Chapter2
{
    public class LinkedListNode
    {
        public LinkedListNode next;
        public LinkedListNode prev;
        public int data;
        private static StringBuilder list = new StringBuilder();

        public LinkedListNode(int d, LinkedListNode p, LinkedListNode n)
        {
            data = d;
            prev = p;
            next = n;

            setNextNode(n);
            setPrevNode(p);

        }
        public LinkedListNode(int d)
        {
            data = d;
        }

        public LinkedListNode()
        {
        }

        public void setNextNode(LinkedListNode n)
        {
            if (n != null)
                n.prev = this;
        }

        public void setPrevNode(LinkedListNode p)
        {
            if (p != null)
                p.next = this;
        }

        public void printLinkedList()
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