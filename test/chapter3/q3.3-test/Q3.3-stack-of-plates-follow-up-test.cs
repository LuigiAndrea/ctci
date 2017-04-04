using Xunit;

using static Chapter3.Q3_3StackOfPlatesFollowUp;
using Chapter3.Exceptions;
using System;

namespace Tests.Chapter3
{
    public class Q3_3_FollowUp
    {
        [FactAttribute]
        public static void Q3_3StackOfPlatesTest()
        {
            int[] values = { 4, 2, 3, 10, 5, 1, 33, 44 };
            DataSetOfStacks sos = new DataSetOfStacks(3);
            sos.buildStack(values);
            Assert.True(sos.length().Equals(3));
            sos.pop();
            Assert.True(sos.popAt(1).Equals(1));
            Assert.True(sos.length().Equals(2));
            Assert.True(sos.popAt(0).Equals(3));
            Assert.True(sos.popAt(0).Equals(10));

            for (int i = 2; i >= 0; i--)
                sos.push(i * 10);

            Assert.True(sos.peek().Equals(0));
            Assert.True(sos.pop().Equals(0));

            for (int i = 6; i > 0; i--)
                sos.pop();

            Assert.True(sos.isEmpty());

        }

        [FactAttribute]
        public static void Q3_3StackOfPlatesExceptionTest()
        {
            DataSetOfStacks dsm = new DataSetOfStacks(3);
            var exception = Record.Exception(() => dsm.pop());
            Assert.IsType<EmptyStackException>(exception);

            exception = Record.Exception(() => dsm.peek());
            Assert.IsType<EmptyStackException>(exception);

            exception = Record.Exception(() => dsm.popAt(-5));
            Assert.IsType<ArgumentException>(exception);

            exception = Record.Exception(() => dsm.popAt(5));
            Assert.IsType<ArgumentException>(exception);

            exception = Record.Exception(() => new DataSetOfStacks(0));
            Assert.IsType<ArgumentException>(exception);
        }

        class DataSetOfStacks : SetOfStacks
        {
            public DataSetOfStacks(int c) : base(c) { }

            public void buildStack(int[] values)
            {
                foreach (int el in values)
                {
                    base.push(el);
                }
            }

            public int length()
            {
                return base.listOfStacks.Count;
            }
        }
    }
}