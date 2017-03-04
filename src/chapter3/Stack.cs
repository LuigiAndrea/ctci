using Chapter3.Exceptions;

namespace Chapter3
{
    public class Stack<T>
    {
        private class StackNode
        {
            internal T data;
            internal StackNode next;

            public StackNode(T data)
            {
                this.data = data;
            }
        }

        private StackNode top;

        public T pop()
        {
            if (top == null)
                throw new EmptyStackException();

            T item = top.data;
            top = top.next;
            return item;
        }

        public void push(T item)
        {
            StackNode t = new StackNode(item);
            t.next = top;
            top = t;
        }

        public T peek()
        {
            if (top == null)
                throw new EmptyStackException();
            return top.data;
        }

        public bool isEmpty()
        {
            return top == null;
        }
    }
}