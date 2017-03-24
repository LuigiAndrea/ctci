using Xunit;
using System;

using Chapter3.Exceptions;
using Chapter3;

namespace Tests.Chapter3
{
    public class StackTest
    {
        [FactAttribute]
        private static void stackTest()
        {
            Stack<int> stack = new Stack<int>();
            stack.push(41);
            stack.push(4);
            Assert.True(stack.peek().Equals(4));
            Assert.True(stack.pop().Equals(4));
            Assert.False(stack.isEmpty());
            Assert.True(stack.pop().Equals(41));
            Assert.True(stack.isEmpty());
        }

        [FactAttribute]
        private static void stackExceptionTest()
        {
            Stack<int> stack = new Stack<int>();

            Exception ex = Record.Exception(() => stack.pop());
            Assert.IsType<EmptyStackException>(ex);

            ex = Record.Exception(() => stack.peek());
            Assert.IsType<EmptyStackException>(ex);
        }
    }
}