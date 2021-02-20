using Xunit;

using static Chapter16.Q16_7NumberMax;

namespace Tests.Chapter6
{
    public class Q16_7
    {
        [TheoryAttribute]
        [InlineDataAttribute(31, 4)]
        [InlineDataAttribute(-5, -10)]
        [InlineDataAttribute(2, 0)]
        public void FirstNumberMaxTest(int a, int b)
        {
            Assert.Equal(a, GetMaxNumber(a, b));
        }

        [TheoryAttribute]
        [InlineDataAttribute(1, 4)]
        [InlineDataAttribute(-50, -10)]
        [InlineDataAttribute(0, 10)]
        public void SecondNumberMaxTest(int a, int b)
        {
            Assert.Equal(b, GetMaxNumber(a, b));
        }

        [TheoryAttribute]
        [InlineDataAttribute(4, 4)]
        [InlineDataAttribute(-50, -50)]
        [InlineDataAttribute(0, 0)]
        public void Test(int a, int b)
        {
            Assert.Equal(a, GetMaxNumber(a, b));
        }
    }
}
