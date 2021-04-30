using System;
using Xunit;
using static Chapter1.Q1_1IsUnique;

namespace Tests.Chapter1
{
    public class Q1_1
    {
        [TheoryAttribute]
        [InlineDataAttribute("abcdefgh", true)]
        [InlineDataAttribute("", true)]
        [InlineDataAttribute("1", true)]
        [InlineDataAttribute("11", false)]
        [InlineDataAttribute("abcdefghilgmn", false)]
        [MemberData(nameof(TestDataIsUnique.getString), MemberType = typeof(TestDataIsUnique))]
        public void IsUniqueTest(string s, bool result)
        {

            Func<string, bool>[] funcToRun = new Func<string, bool>[]{
                isUnique, isUnique2, isUnique3, isUnique4
            };

            foreach (var f in funcToRun)
            {
                Assert.Equal(result, f(s));
            }
        }
    }

    class TestDataIsUnique
    {
        public static TheoryData<String, bool> getString()
            => new TheoryData<String, bool>() { { new String('a', 256), false } };
    }
}
