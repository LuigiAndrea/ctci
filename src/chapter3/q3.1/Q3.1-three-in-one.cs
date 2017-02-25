//Three in One. Describe how you could use a single array to implement three stacks.
using Chapter3.Exceptions;
using System;

namespace Chapter3
{
    public class Q3_1ThreeInOne
    {
        public enum stacks { first, second, third };
        public class FixedMultiStack
        {
            private int[] array;
            private int arrayCapacity;
            private int numberOfStack = 3;
            private IndexArray[] idxStack;

            //Parameter: capacity
            // Size of the array that have to contain the stacks
            public FixedMultiStack(int capacity)
            {
                if (capacity < numberOfStack)
                    throw new ArgumentException("Capacity cannot be less than the number of the stacks available");
                idxStack = new IndexArray[numberOfStack];
                this.arrayCapacity = capacity;
                for (int i = 0; i < numberOfStack; i++)
                {
                    idxStack[i] = new IndexArray(i * capacity / numberOfStack,
                            (i + 1) * capacity / numberOfStack - 1);
                }

                array = new int[capacity];
            }

            public void push(stacks s, int el)
            {
                IndexArray idx = idxStack[(int)s];

                if (!isFull(s))
                {
                    array[idx.Current] = el;
                    idx.Current++;
                }
                else
                    throw new FullStackException();
            }

            public int pop(stacks s)
            {
                IndexArray idx = idxStack[(int)s];

                if (!isEmpty(s))
                {
                    int result = array[idx.Current - 1];
                    array[idx.Current] = 0;
                    idx.Current = idx.Current.Equals(0) ? 0 : idx.Current - 1;
                    return result;
                }
                else
                    throw new EmptyStackException();
            }

            public bool isEmpty(stacks s)
            {
                IndexArray idx = idxStack[(int)s];
                return idx.Current.Equals(idx.First);
            }

            public bool isFull(stacks s)
            {
                IndexArray idx = idxStack[(int)s];
                return idx.Current > idx.Last;
            }

            public int peek(stacks s)
            {
                IndexArray idx = idxStack[(int)s];
                return array[idx.Current - 1];
            }

            private class IndexArray
            {
                public int First { get; set; }
                public int Last { get; set; }
                public int Current { get; set; }

                public IndexArray(int f, int l)
                {
                    First = f;
                    Last = l;
                    Current = First;
                }
            }
        }
    }
}