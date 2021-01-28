using Xunit;

using static Chapter6.Q6_1HeavyPill;

namespace Tests.Chapter6
{
    public class Q6_1
    {
        [TheoryAttribute]
        [InlineDataAttribute(2.5, 1.2, 20, 13)]
        [InlineDataAttribute(1, 1.2, 30, 15)]
        [InlineDataAttribute(1, 5, 20, 5)]
        private static void HeavyPillTest(double normalWeight, double specialWeight, int bottles, int heavyBottle)
        {
            SetHeavyPillProblem(new Pill(normalWeight, specialWeight), bottles, heavyBottle);
            Assert.Equal(heavyBottle, GetHeavyBottle());
        }
    }
}
