using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

using static Chapter8.Q8_5RecursiveMultiply;


namespace Tests.Chapter8
{
    public class Q8_5
    {
        [TheoryAttribute]
        [InlineDataAttribute(0, 5)]
        [InlineDataAttribute(0, 0)]
        [InlineDataAttribute(1, 0)]
        private static void zeroMultiply(int a, int b)
        {
            Assert.Equal(0, multiply(a, b));
            Assert.Equal(0, multiply_opt(a, b));
        }

        [TheoryAttribute]
        [InlineDataAttribute(31, 1, 31)]
        [InlineDataAttribute(1, 88, 88)]
        [InlineDataAttribute(1, 1, 1)]
        private static void oneMultiply(int a, int b, int result)
        {
            Assert.Equal(result, multiply(a, b));
            Assert.Equal(result, multiply_opt(a, b));
        }

        [TheoryAttribute]
        [InlineDataAttribute(31, 3, 93)]
        [InlineDataAttribute(8, 88, 704)]
        [InlineDataAttribute(10, 3, 30)]
        [InlineDataAttribute(11, 12, 132)]
        private static void GeneralMultiply(int a, int b, int result)
        {
            Assert.Equal(result, multiply(a, b));
            Assert.Equal(result, multiply_opt(a, b));
        }

        [TheoryAttribute]
        [InlineDataAttribute(-5, 1)]
        [InlineDataAttribute(12, -5)]
        [InlineDataAttribute(0, -1)]
        [InlineDataAttribute(-7, -1)]
        private static void exceptionMultiply(int a, int b)
        {
            Exception actualException = Record.Exception(() => multiply(a, b));
            Assert.IsType<ArgumentOutOfRangeException>(actualException);
            actualException = Record.Exception(() => multiply_opt(a, b));
            Assert.IsType<ArgumentOutOfRangeException>(actualException);
        }
    }
}