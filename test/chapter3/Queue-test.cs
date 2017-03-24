using Xunit;
using System;

using Chapter3;
using Chapter3.Exceptions;

namespace Tests.Chapter3
{
    public class QueueTests
    {
        [FactAttribute]
        private static void queueTest()
        {
            Queue<int> queue = new Queue<int>();
            queue.add(3);
            queue.add(4);
            Assert.True(queue.peek().Equals(3));
            Assert.True(queue.remove().Equals(3));
            Assert.False(queue.isEmpty());
            Assert.True(queue.remove().Equals(4));
            Assert.True(queue.isEmpty());
        }

        [FactAttribute]
        private static void stackExceptionTest()
        {
            Queue<int> q = new Queue<int>();

            Exception ex = Record.Exception(() => q.remove());
            Assert.IsType<EmptyQueueException>(ex);

            ex = Record.Exception(() => q.peek());
            Assert.IsType<EmptyQueueException>(ex);
        }
    }
}