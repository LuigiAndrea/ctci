using System;
using static Chapter1.Q1_5OneAway;
using static Chapter1.Q1_5OneAway2;
using Xunit;

namespace Tests.Chapter1
{
    public class Q1_5
    {
        [TheoryAttribute]
        [InlineDataAttribute("abcd", "aBcd")]
        [InlineDataAttribute("", "")]
        [InlineDataAttribute(" ", " ")]
        [InlineDataAttribute("a", " ")]
        [InlineDataAttribute("abc", "ac")]
        public void TestIsOneAway(string s1, string s2)
        {
            Assert.True(oneAway(s1, s2));
            Assert.True(oneAway2(s1, s2));
        }

        [TheoryAttribute]
        [InlineDataAttribute("abc d", "aBcd")]
        [InlineDataAttribute("!a", "a!")]
        [InlineDataAttribute("AD", "")]
        public void TestIsNotOneAway(string s1, string s2)
        {
            Assert.False(oneAway(s1, s2));
            Assert.False(oneAway2(s1, s2));
        }
    }
}