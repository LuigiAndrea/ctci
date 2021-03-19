using System;
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

        [TheoryAttribute]
        [InlineDataAttribute(9, 11, 0)]
        [InlineDataAttribute(12, 11, 1)]
        [InlineDataAttribute(0, 10, 0)]
        [InlineDataAttribute(20, 2, 10)]
        [InlineDataAttribute(20, 3, 6)]
        [InlineDataAttribute(-20, 2, -10)]
        [InlineDataAttribute(20, -3, -6)]
        [InlineDataAttribute(-20, -2, 10)]
        [InlineDataAttribute(-20, -3, 6)]
        [InlineDataAttribute(-3, 3, -1)]
        public void DivideTest(int a, int b, int result)
        {
            Assert.Equal(result, Divide(a, b));
        }

        [TheoryAttribute]
        [InlineDataAttribute(5, 0)]
        [InlineDataAttribute(-12, 0)]
        private void DivideExceptionTest(int a, int b)
        {
            Exception actualException = Record.Exception(() => Divide(a, b));
            Assert.IsType<ArgumentException>(actualException);
        }
    }
}
