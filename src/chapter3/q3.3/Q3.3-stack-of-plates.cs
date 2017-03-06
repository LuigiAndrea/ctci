// Imagine a (literal) stack of plates. If the stack gets too high, it might topple. 
// Therefore, in real life, we would likely start a new stack when the previous stack exceeds some threshold.
// Implement a data structure SetOfStacks that mimics this. SetOfStacks should be composed of several stacks and 
// should create a new stack once the previous one exceeds capacity. 
// SetOfStacks.push() and SetOfStacks. pop() should behave identically to a single stack 
// (that is, pop() should return the same values as it would if there were just a single stack). 

namespace Chapter3
{
    public class Q3_3StackOfPlates
    {
        public class SetOfStacks
        {
            protected StackOfStacks listOfStacks = new StackOfStacks();
            private int capacityStacks;

            public SetOfStacks(int capacityStacks)
            {
                this.capacityStacks = capacityStacks;
                listOfStacks.push(new StackWithCapacity(capacityStacks));
            }
            public void push(int item)
            {
                StackWithCapacity stack = getLastStack();
                if (!stack.isFull())
                {
                    stack.push(item);
                }
                else
                {
                    stack = new StackWithCapacity(this.capacityStacks);
                    stack.push(item);
                    listOfStacks.push(stack);         
                }
            }

            public int pop()
            {
                StackWithCapacity stack = getLastStack();
                int val = stack.pop();
                if (stack.isEmpty() && this.listOfStacks.Count > 1)
                    listOfStacks.pop();

                return val;
            }

            private StackWithCapacity getLastStack()
            {
                return listOfStacks.peek();
            }

            protected class StackOfStacks : Stack<StackWithCapacity>
            {
                private int count = 0;
                public int Count
                {
                    get
                    {
                        return count;
                    }
                }
                new public void push(StackWithCapacity item)
                {
                    this.count++;
                    base.push(item);
                }

                new public StackWithCapacity pop()
                {
                    this.count--;
                    return base.pop(); ;
                }
            }
        }

        public class StackWithCapacity : Stack<int>
        {
            private int capacity;
            private int count = 0;
            public int Count
            {
                get
                {
                    return count;
                }
            }

            public StackWithCapacity(int cap)
            {
                this.capacity = cap;
            }

            new public void push(int item)
            {
                this.count++;
                base.push(item);
            }

            new public int pop()
            {
                this.count++;
                return base.pop();
            }

            public bool isFull()
            {
                return this.capacity.Equals(this.count);
            }
        }
    }
}