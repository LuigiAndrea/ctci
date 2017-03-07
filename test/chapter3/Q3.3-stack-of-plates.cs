using Xunit;

using static Chapter3.Q3_3StackOfPlates;
using Chapter3;
using Chapter3.Exceptions;

namespace Tests.Chapter3
{
    public class Q3_3
    {
        [FactAttribute]
        public static void Q3_3StackOfPlatesTest()
        {
            int[] values = { 4, 2, 3, 1, 5, 1, 3 };

            DataSetOfStack dsm = new DataSetOfStack(3);
            dsm.buildStack(values);
            Assert.True(dsm.length().Equals(3));
            Assert.True(dsm.pop().Equals(3));
            Assert.True(dsm.length().Equals(2));
            for (int i = 0; i < 6; i++)
                dsm.pop();

            Assert.True(dsm.length().Equals(1));
            StackWithCapacity swc = dsm.getLastStack();
            Assert.True(swc.isEmpty());

            for (int i = 0; i < 3; i++)
                dsm.push(i);

            Assert.True(dsm.length().Equals(1));
            dsm.push(4);
            Assert.True(dsm.length().Equals(2));
            StackWithCapacity swc2 = dsm.getLastStack();
            Assert.True(swc2.Count.Equals(1));
        }

        [FactAttribute]
        public static void Q3_3StackOfPlatesExceptionTest()
        {
            DataSetOfStack dsm = new DataSetOfStack(3);
            var exception = Record.Exception(() => dsm.pop());
            Assert.IsType<EmptyStackException>(exception);
        }

        class DataSetOfStack : SetOfStacks
        {
            int capacity = 0;
            public DataSetOfStack(int c) : base(c)
            {
                this.capacity = c;
            }

            public int length()
            {
                return base.listOfStacks.Count;
            }

            new public StackWithCapacity getLastStack()
            {
                return base.getLastStack();
            }

            public void buildStack(int[] values)
            {
                foreach (int el in values)
                {
                    base.push(el);
                }
            }
        }
    }
}