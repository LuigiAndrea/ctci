using Xunit;

using static Chapter16.Q16_8Operations;

namespace Tests.Chapter16
{
    public class Q16_9
    {
        [TheoryAttribute]
        [InlineDataAttribute(5, 11, 55)]
        [InlineDataAttribute(5, 0, 0)]
        [InlineDataAttribute(0, 10, 0)]
        [InlineDataAttribute(2, -10, -20)]
        [InlineDataAttribute(-2, -10, 20)]
        [InlineDataAttribute(-3, 3, -9)]
        public void MultiplyTest(int a, int b, int result)
        {
            Assert.Equal(result, Multiply(a, b));
        }
    }
}
