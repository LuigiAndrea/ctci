using System.Text;

namespace Chapter2
{
    public abstract class LinkedListNode
    {
        public int data;
        protected static StringBuilder list = new StringBuilder();
        abstract public void printLinkedList();

    }
}