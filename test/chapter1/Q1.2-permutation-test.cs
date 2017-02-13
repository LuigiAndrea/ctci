using System;
using static Chapter1.Q1_2Permutation;
using Xunit;

namespace Tests.Chapter1
{
    public class Q1_2
    {

        [TheoryAttribute]
        [InlineDataAttribute("1ff1a", "f1a1f")]
        [InlineDataAttribute("", "")]
        public void TestPermutationTrue(string s1, string s2)
        {
            bool r = permutation(s1, s2);
            Assert.True(r);
        }

        [TheoryAttribute]
        [InlineDataAttribute("a", "fsd")]
        [InlineDataAttribute("bca", "adb")]
        public void TestPermutationFalse(string s1, string s2)
        {
            bool r = permutation(s1, s2);
            Assert.False(r);
        }

        [TheoryAttribute]
        [InlineDataAttribute("1ff1a", "f1a1f")]
        [InlineDataAttribute("", "")]
        public void TestPermutationEffTrue(string s1, string s2)
        {
            bool r = permutationEff(s1, s2);
            Assert.True(r);
        }

        [TheoryAttribute]
        [InlineDataAttribute("a", "fsd")]
        [InlineDataAttribute("bca", "adb")]
        public void TestPermutationEffFalse(string s1, string s2)
        {
            bool r = permutationEff(s1, s2);
            Assert.False(r);
        }
    }
}