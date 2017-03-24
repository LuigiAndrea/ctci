using Xunit;
using System;

using Chapter3.Exceptions;
using Chapter3;

namespace Tests.Chapter3
{
    public class StackPlateTest
    {
        [FactAttribute]
        private static void stackPlateTest()
        {
            StackPlate stack = new StackPlate(3);
            Assert.True(stack.isEmpty());

            stack.push(41);
            stack.push(4);
            Assert.True(stack.peek().Equals(4));

            stack.push(32);
            Assert.True(stack.isFull());
            Assert.True(stack.Count.Equals(3));

            Assert.True(stack.getBottom().Equals(41));
            Assert.True(stack.peekBottom().Equals(4));
            Assert.True(stack.Count.Equals(2));

            stack.pop();
            Assert.True(stack.peek().Equals(4));

            stack.pop();
            Assert.True(stack.Count.Equals(0));
            Assert.True(stack.isEmpty());

            stack.push(11);
            Assert.True(stack.getBottom().Equals(11));
            Assert.True(stack.Count.Equals(0));
            Assert.True(stack.isEmpty());
        }

        [FactAttribute]
        private static void stackPlateExceptionTest()
        {
            StackPlate stack = new StackPlate(3);

            Exception ex = Record.Exception(() => stack.pop());
            Assert.IsType<EmptyStackException>(ex);

            ex = Record.Exception(() => stack.peek());
            Assert.IsType<EmptyStackException>(ex);

            ex = Record.Exception(() => stack.getBottom());
            Assert.IsType<EmptyStackException>(ex);

            ex = Record.Exception(() => stack.peekBottom());
            Assert.IsType<EmptyStackException>(ex);

            for (int i = 0; i < 3; i++)
            {
                stack.push(i);
            }

            ex = Record.Exception(() => stack.push(1000));
            Assert.IsType<FullStackException>(ex);
        }
    }
}