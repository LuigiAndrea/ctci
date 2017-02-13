using System;
using static Chapter1.Q1_4IsPermutationOfPalindrome;
using static Chapter1.Q1_4IsPermutationOfPalindromeTweak;
using static Chapter1.Q1_4IsPermutationOfPalindromeBit;
using Xunit;

namespace Tests.Chapter1
{
    public class Q1_4
    {
        [TheoryAttribute]
        [InlineDataAttribute("")]
        [InlineDataAttribute(" ")]
        [InlineDataAttribute("  ")]
        [InlineDataAttribute("abbdbbbad")]
        [InlineDataAttribute("abab")]
        [InlineDataAttribute("aB? a Bb-B-?~")]
        [InlineDataAttribute("a")]
        [InlineDataAttribute("r ra")]
        [InlineDataAttribute("abBa")]
        [InlineDataAttribute("aaBBBbbb")]
        public void TestisPermPalTrue(string s)
        {
            Assert.True(isPermutationOfPalindrome(s));
            Assert.True(isPermutationOfPalindrome2(s));
            Assert.True(isPermutationOfPalindromeBit(s));
        }

        [TheoryAttribute]
        [InlineDataAttribute("ab")]
        [InlineDataAttribute("aaabbb")]
        [InlineDataAttribute("aa ~ bbb")]
        [InlineDataAttribute("A man, a plan, a canal, panama")]
        public void TestisPermPalFalse(string s)
        {
            Assert.False(isPermutationOfPalindrome(s));
            Assert.False(isPermutationOfPalindrome2(s));
        }

        [TheoryAttribute]
        [InlineDataAttribute("ab")]
        [InlineDataAttribute("aaabbb")]
        [InlineDataAttribute("A man, a plan, a canal, panama")]
        public void TestisPermPalBitFalse(string s)
        {
            Assert.False(isPermutationOfPalindromeBit(s));
        }

        [TheoryAttribute]
        [InlineDataAttribute("aa ~ bbb")]
        [InlineDataAttribute("aa ~ bBb")]
        [InlineDataAttribute("aaBBBbbb")]
        public void TestisPermPalBitTrue(string s)
        {
            Assert.True(isPermutationOfPalindromeBit(s));
        }
    }
}