using Chapter1;
using Xunit;

namespace Tests.Chapter1
{
    public class Q1_6
    {
        [TheoryAttribute]
        [InlineDataAttribute("abcd")]
        [InlineDataAttribute("abbcdeef")]
        [InlineDataAttribute("")]
        [InlineDataAttribute(" ")]
        [InlineDataAttribute("aaaaaaaaaabcdefgh")]
        public void TestCompressOriginalString(string str)
        {
            string r = Q1_6Compress.compress(str);
            Assert.True(str.Equals(r));
            string r2 = Q1_6Compress2.compress(str);
            Assert.True(str.Equals(r2));
        }

        [TheoryAttribute]
        [InlineDataAttribute("aabbbccccbccdd")]
        public void TestCompressNewString(string str)
        {
            string test="a2b3c4b1c2d2";
            string r = Q1_6Compress.compress(str);
            Assert.True(r.Equals(test));
            string r2 = Q1_6Compress2.compress(str);
            Assert.True(r2.Equals(test));
        }

        [TheoryAttribute]
        [InlineDataAttribute("aaaaaaaaaabbbc   bccd--?")]
        public void TestCompressNewString2(string str)
        {
            string test="a10b3c1 3b1c2d1-2?1";
            string r = Q1_6Compress.compress(str);
            Assert.True(r.Equals(test));
            string r2 = Q1_6Compress2.compress(str);
            Assert.True(r2.Equals(test));
        }

        [TheoryAttribute]
        [InlineDataAttribute("%%%dff---")]
        public void TestCompressNewString3(string str)
        {
            string test="%3d1f2-3";
            string r = Q1_6Compress.compress(str);
            Assert.True(r.Equals(test));
            string r2 = Q1_6Compress2.compress(str);
            Assert.True(r2.Equals(test));
        }
    }
}