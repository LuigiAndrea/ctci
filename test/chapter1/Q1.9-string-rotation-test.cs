using static Chapter1.Q1_9StringRotation;
using Xunit;

namespace Tests.Chapter1
{
    public class Q1_9
    {
        [TheoryAttribute]
        [InlineDataAttribute("erbottlewat", "bottlewater", true)]
        [InlineDataAttribute("casa", "saca", true)]
        [InlineDataAttribute("", "d", false)]
        [InlineDataAttribute("", "", false)]
        [InlineDataAttribute(" ", " ", true)]
        [InlineDataAttribute("201", "102", false)]
        [InlineDataAttribute(null, null, false)]
        [InlineDataAttribute("d", null, false)]
        [InlineDataAttribute("Ho", "Home", false)]
        public void StringRotationTest(string str1, string str2, bool B)
        {
            Assert.Equal(B, IsStringRotation(str1, str2));
        }
    }
}
