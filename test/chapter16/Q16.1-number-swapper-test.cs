using Xunit;

using static Chapter16.Q16_1NumberSwapper;

namespace Tests.Chapter16
{
    public class Q16_1
    {
        static int prev_a;
        static int prev_b;

        [TheoryAttribute]
        [InlineDataAttribute(5, 2)]
        [InlineDataAttribute(2, 5)]
        [InlineDataAttribute(-1, 2)]
        [InlineDataAttribute(2, -2)]
        [InlineDataAttribute(-2, -7)]
        [InlineDataAttribute(-10, 3)]
        private void NumberSwapperTest(int a, int b)
        {
            prev_a = a;
            prev_b = b;
            SwapNumber(ref a, ref b);
            Assert.Equal(b, prev_a);
            Assert.Equal(a, prev_b);
        }

        [TheoryAttribute]
        [InlineDataAttribute(5, 2)]
        [InlineDataAttribute(2, 5)]
        [InlineDataAttribute(-1, 2)]
        [InlineDataAttribute(2, -2)]
        [InlineDataAttribute(-2, -7)]
        [InlineDataAttribute(-10, 3)]
        private void NumberSwapperXorTest(int a, int b)
        {
            prev_a = a;
            prev_b = b;
            SwapNumber(ref a, ref b);
            Assert.Equal(b, prev_a);
            Assert.Equal(a, prev_b);
        }
    }
}
