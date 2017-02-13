using System;
using static Chapter1.Q1_1IsUnique;
using System.Text;
using Xunit;

namespace Tests.Chapter1 {
    public class Q1_1
    {
        [TheoryAttribute]
        [InlineDataAttribute("abcdefgh")]
        [InlineDataAttribute("")]
        [InlineDataAttribute("1")]
        public void TestTrueisUnique(string s)
        {
            bool r = isUnique(s);
            Assert.True(r);
        }

        [TheoryAttribute]
        [InlineDataAttribute("11")]
        [InlineDataAttribute("abcdefghilgmn")]
        [MemberData("getString", MemberType = typeof(TestDataIsUnique))]
        public void TestFalseisUnique(string s)
        {
            bool r = isUnique(s);
            Assert.False(r);
        }

        [TheoryAttribute]
        [InlineDataAttribute("abcdefgh")]
        [InlineDataAttribute("")]
        [InlineDataAttribute("1")]
        public void TestTrueisUnique2(string s)
        {
            bool r = isUnique2(s);
            Assert.True(r);
        }

        [TheoryAttribute]
        [InlineDataAttribute("11")]
        [InlineDataAttribute("abcdefghilgmn")]
        [MemberData("getString", MemberType = typeof(TestDataIsUnique))]
        public void TestFalseisUnique2(string s)
        {
            bool r = isUnique2(s);
            Assert.False(r);
        }

        [TheoryAttribute]
        [InlineDataAttribute("abcdefgh")]
        [InlineDataAttribute("")]
        [InlineDataAttribute("1")]
        public void TestTrueisUnique3(string s)
        {
            bool r = isUnique3(s);
            Assert.True(r);
        }

        [TheoryAttribute]
        [InlineDataAttribute("11")]
        [InlineDataAttribute("abcdefghilgmn")]
        [MemberData("getString", MemberType = typeof(TestDataIsUnique))]
        public void TestFalseisUnique3(string s)
        {
            bool r = isUnique3(s);
            Assert.False(r);
        }
    }

    class TestDataIsUnique
    {
        public static TheoryData<String> getString()
        {
            StringBuilder sb = new StringBuilder();

            for (short i = 0; i <= 256; i++)
                sb.Append('a');

            return new TheoryData<String>() { sb.ToString() };
        }
    }
}