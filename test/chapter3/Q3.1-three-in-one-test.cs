using Xunit;
using static Chapter3.Q3_1ThreeInOne;
using Chapter3.Exceptions;
using System;

namespace Tests.Chapter3
{
    public class Q3_1
    {
        [TheoryAttribute]
        [InlineDataAttribute(21)]
        public static void multiStackEmptyAndFullTest(int capacity)
        {
            FixedMultiStack f = new FixedMultiStack(capacity);
            Assert.True(f.isEmpty(stacks.first));
            Assert.False(f.isFull(stacks.first));

            for (int i = 0; i < 7; i++)
            {
                f.push(stacks.first, i + 3);
            }

            Assert.False(f.isEmpty(stacks.first));
            Assert.True(f.isFull(stacks.first));
        }

        [TheoryAttribute]
        [InlineDataAttribute(21)]

        public static void multiStackPushAndPopTest(int capacity)
        {
            FixedMultiStack f = new FixedMultiStack(capacity);

            f.push(stacks.second, 4);
            f.push(stacks.first, 14);
            f.push(stacks.third, 41);
            f.push(stacks.first, 3);

            Assert.False(f.isEmpty(stacks.first));
            f.pop(stacks.first);
            f.peek(stacks.first);
            f.peek(stacks.first);
            f.pop(stacks.first);
            Assert.True(f.isEmpty(stacks.first));

            Assert.False(f.isEmpty(stacks.second));
            f.pop(stacks.second);
            Assert.True(f.isEmpty(stacks.second));

            Assert.False(f.isEmpty(stacks.third));
            f.pop(stacks.third);
            Assert.True(f.isEmpty(stacks.third));
        }

        [FactAttribute]
        public static void multiStackExceptionTest()
        {
            var exception = Record.Exception(() => new FixedMultiStack(0));
            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);

            exception = null;
            FixedMultiStack f = new FixedMultiStack(3);

            exception = Record.Exception(() => f.pop(stacks.third));
            Assert.IsType<EmptyStackException>(exception);

            exception = null;
            f.push(stacks.first, 5);
            Assert.True(f.isFull(stacks.first));
            exception = Record.Exception(() => f.push(stacks.first, 15));
            Assert.IsType<FullStackException>(exception);
        }
    }
}