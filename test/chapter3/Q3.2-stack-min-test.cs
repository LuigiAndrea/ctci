using Xunit;

using static Chapter3.Q3_2StackMin;
using Chapter3.Exceptions;

namespace Tests.Chapter3
{
    public class Q3_2
    {
        [TheoryAttribute]
        [MemberDataAttribute("getStack", MemberType = typeof(DataStackMin))]
        public static void stackMinTest(StackWithMin m)
        {
            for (int i = 0; i < 4; i++)
            {
                m.pop();
                Assert.True(m.min().Equals(1));
            }

            m.pop();
            Assert.True(m.min().Equals(2));
        }

        [FactAttribute]
        public static void stackMinExceptionTest()
        {
            StackWithMin min = new StackWithMin();
            var exception = Record.Exception(() => min.pop());
            Assert.NotNull(exception);
            Assert.IsType<EmptyStackException>(exception);
        }
    }

    class DataStackMin
    {
        public static TheoryData<StackWithMin> getStack()
        {
            int[] values = { 4, 2, 3, 1, 1, 5, 1, 3 };

            StackWithMin min = new StackWithMin();
            foreach (int el in values)
            {
                min.push(el);
            }

            return new TheoryData<StackWithMin>() { min };
        }
    }
}