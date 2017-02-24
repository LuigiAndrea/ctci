using System;

namespace Chapter3
{
    public class Queue<T>
    {
        private class QueueNode
        {
            internal T data;
            internal QueueNode next;

            public QueueNode(T data)
            {
                this.data = data;
            }
        }

        private QueueNode first;
        private QueueNode last;

        public void add(T item)
        {
            QueueNode q = new QueueNode(item);

            if (first == null)
            {
                first = q;
            }

            if (last != null)
            {
                last.next = q;
            }

            last = q;
        }

        public T remove()
        {
            if (first == null)
                throw new Exception("Empty Queue");

            T item = first.data;
            first = first.next;
            if (first == null)
                last = null;
            return item;
        }

        public T peek()
        {
            if (first == null)
                throw new Exception("Empty Queue");
            return first.data;
        }

        public bool isEmpty()
        {
            return first == null;
        }
    }
}