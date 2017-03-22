using Xunit;

using static Chapter3.Q3_4QueueViaStacks;
using Chapter3.Exceptions;
using System;

namespace Tests.Chapter3
{
    public class Q3_4
    {
        [FactAttribute]
        public static void Q3_4QueueViaStacksTest()
        {
            MyQueue<String> myQueue = new MyQueue<String>();

            for (int i = 0; i < 3; i++)
                myQueue.add(i.ToString() + i.ToString());

            Assert.True(myQueue.remove().Equals("00"));
            Assert.True(myQueue.remove().Equals("11"));
            Assert.True(myQueue.peek().Equals("22"));
            Assert.False(myQueue.isEmpty());
            myQueue.remove();
            Assert.True(myQueue.isEmpty());

            myQueue.add("Luigi");
            myQueue.add("Andrea");
            Assert.False(myQueue.isEmpty());
            Assert.True(myQueue.remove().Equals("Luigi"));
        }

        [FactAttribute]
        public static void Q3_4QueueViaStacksExceptionTest()
        {
            MyQueue<String> myQueue = new MyQueue<String>(); 
            Exception ext = Record.Exception(()=> myQueue.peek());
            Assert.IsType<EmptyQueueException>(ext);

            ext = Record.Exception(() => myQueue.remove());
            Assert.IsType<EmptyQueueException>(ext);
        }
    }
}
