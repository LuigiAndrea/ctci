//FOLLOW UP
//Implements a function popAt(int index) which performs a pop operation on a specific substack
using System.Collections.Generic;
using System.Linq;
using System;

namespace Chapter3
{
    public class Q3_3StackOfPlatesFollowUp
    {
        public class SetOfStacks
        {
            protected List<StackPlate> listOfStacks = new List<StackPlate>();
            private int capacityStacks;
            public SetOfStacks(int capacityStacks)
            {
                if (capacityStacks <= 0)
                    throw new ArgumentException("The size of the stacks has to be positive");
                this.capacityStacks = capacityStacks;
                listOfStacks.Add(new StackPlate(capacityStacks));
            }

            public void push(int item)
            {
                StackPlate stack = getStack(listOfStacks.Count - 1);
                if (!stack.isFull())
                {
                    stack.push(item);
                }
                else
                {
                    stack = new StackPlate(this.capacityStacks);
                    stack.push(item);
                    listOfStacks.Add(stack);
                }
            }

            public int pop()
            {
                int lastStackIndex = listOfStacks.Count - 1;
                StackPlate stack = getStack(lastStackIndex);
                int val = stack.pop();
                if (stack.isEmpty() && this.listOfStacks.Count > 1)
                    listOfStacks.RemoveAt(lastStackIndex);

                return val;
            }

            public int popAt(int index)
            {
                if(listOfStacks.Count <= index || index <0)
                    throw new ArgumentException("no stack at the index provided");

                return leftShif(index);
            }

            public int peek(){
                int lastStackIndex = listOfStacks.Count - 1;
                StackPlate stack = getStack(lastStackIndex);
                return stack.peek();
            }
            public bool isEmpty()
            {
                return listOfStacks[0].isEmpty();
            }
            protected StackPlate getStack(int i)
            {
                return listOfStacks.ElementAt(i);
            }

            private int leftShif(int index)
            {
                int numberStacks = listOfStacks.Count;
                StackPlate prevStack = getStack(index);
                int result = prevStack.pop();
               
                for (int i = index + 1; i < numberStacks; i++)
                {
                    StackPlate stack = getStack(i);
                    int val = stack.getBottom();
                    if (stack.isEmpty() && this.listOfStacks.Count > 1)
                        listOfStacks.RemoveAt(i);
                    prevStack.push(val);
                    prevStack = stack;
                }
                return result;
            }
        }
    }
}