// Implement a MyQueue class which implements a queue using two stacks

using Chapter3.Exceptions;

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

            public void add(T element) => newStack.push(element);
            
            public T remove()
            {
                if (oldStack.isEmpty())
                    shiftStacks();

                try
                {
                    return oldStack.pop();
                }
                catch (EmptyStackException ex)
                {                 
                    throw new EmptyQueueException($"{ex.TargetSite.DeclaringType.FullName} --> {nameof(remove)}");
                }
            }

            public T peek()
            {
                if (oldStack.isEmpty())
                    shiftStacks();

                try
                {
                    return oldStack.peek();
                }
                catch (EmptyStackException ex)
                {
                    throw new EmptyQueueException($"{ex.TargetSite.DeclaringType.FullName} --> {nameof(peek)}");
                }
            }

            private void shiftStacks()
            {
                while (!newStack.isEmpty())
                {
                    oldStack.push(newStack.pop());
                }
            }

            public bool isEmpty() => oldStack.isEmpty() && newStack.isEmpty();
            
        }
    }
}