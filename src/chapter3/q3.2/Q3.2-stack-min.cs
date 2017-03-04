// Stack Min: How would you design a stack which, in addition to push and pop, has a function min
// which returns the minimum element? Push, pop and min should all operate in 0(1) time.
using Chapter3.Exceptions;

namespace Chapter3
{
    public class Q3_2StackMin
    {
        public class StackWithMin : Stack<int>
        {
            Stack<int> stackForMin = new Stack<int>();

            new public void push(int item)
            {
                base.push(item);

                if (item <= min())
                {
                    stackForMin.push(item);
                }

            }

            new public int pop()
            {
                int value = base.pop();
                if (value == min())
                    stackForMin.pop();

                return value;
            }

            public int min()
            {
                if (base.isEmpty())
                    throw new EmptyStackException();
                return (stackForMin.isEmpty())
                        ? int.MaxValue
                        : stackForMin.peek();
            }
        }
    }
}