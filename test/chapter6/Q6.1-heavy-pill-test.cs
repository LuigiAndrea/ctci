using System;
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
            HeavyPill hp = new HeavyPill();
            hp.SetHeavyPillProblem(new Pill(normalWeight, specialWeight), bottles, heavyBottle);
            Assert.Equal(heavyBottle, hp.GetHeavyBottle());
        }


        [TheoryAttribute]
        [InlineDataAttribute(2.5, 1.2, 1, 13)]
        [InlineDataAttribute(1.2, 1.2, 30, 15)]
        [InlineDataAttribute(1, 5, 20, 55)]
        [InlineDataAttribute(1, 5, 20, 0)]
        [InlineDataAttribute(-1, 5, 20, 0)]
        [InlineDataAttribute(1, 0, 20, 0)]
        private static void HeavyPillExceptionTest(double normalWeight, double specialWeight, int bottles, int heavyBottle)
        {
            HeavyPill hp = new HeavyPill();
            Exception ext = Record.Exception(() => hp.SetHeavyPillProblem(new Pill(normalWeight, specialWeight), bottles, heavyBottle));
            Assert.IsType<ArgumentException>(ext);
        }

        [FactAttribute]
        private static void HeavyPillExceptionWrongExecutionPathTest()
        {
            HeavyPill hp = new HeavyPill();
            Exception ext = Record.Exception(() => hp.GetHeavyBottle());
            Assert.IsType<InvalidProgramException>(ext);
        }
    }
}
