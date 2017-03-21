// Implement a MyQueue class which implements a queue using two stacks

namespace Chapter3
{
    public class Q3_4QueueViaStacks
    {
        public class MyQueue<T>
        {
            Stack<T> oldStack, newStack;

            public MyQueue()
            {
                oldStack = new Stack<T>();
                newStack = new Stack<T>();
            }

            public void add(T element)
            {
                newStack.push(element);
            }

            public T remove()
            {
                if (oldStack.isEmpty())
                {
                    shiftStacks();
                }
                return oldStack.pop();
            }

            public T peek()
            {
                if (oldStack.isEmpty())
                {
                    shiftStacks();
                }
                return oldStack.peek();
            }

            private void shiftStacks()
            {
                while (!newStack.isEmpty())
                {
                    oldStack.push(newStack.pop());
                }
            }

            public bool isEmpty()
            {
                return oldStack.isEmpty() && newStack.isEmpty();
            }
        }
    }
}