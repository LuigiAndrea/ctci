using System.Text;
using static System.Console;
using System;

namespace Chapter2
{
    public abstract class LinkedListNode
    {
        public int data;
        protected static StringBuilder list = new StringBuilder();
        abstract public void printLinkedList();

    }
}