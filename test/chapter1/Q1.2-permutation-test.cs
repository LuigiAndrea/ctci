using System;
using static Chapter1.Q1_2Permutation;
using Xunit;

namespace Tests.Chapter1
{
    public class Q1_2
    {

        [TheoryAttribute]
        [InlineDataAttribute("1ff1a", "f1a1f", true)]
        [InlineDataAttribute("", "", true)]
        [InlineDataAttribute("a", "fsd", false)]
        [InlineDataAttribute("bca", "adb", false)]
        public void PermutationTest(string s1, string s2, bool res)
        {

            Func<string, string, bool>[] funcToRun = new Func<string, string, bool>[]{
                permutation,permutationEff
            };

            foreach (var f in funcToRun)
            {
                if (res)
                {
                    Assert.True(f(s1, s2));
                }
                else
                {
                    Assert.False(f(s1, s2));
                }
            }
        }
    }
}