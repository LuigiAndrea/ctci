using Xunit;

using Chapter3;

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
    }
}