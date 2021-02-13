using System;
using Xunit;

using static Chapter16.Q16_6SmallestDifference;

namespace Tests.Chapter6
{
    public class Q16_6
    {

        [FactAttribute]
        public void SmallestDiffNegativeTest()
        {
            Assert.Equal(-1,SmallestPairDifference(new int[]{0,0,0},new int[]{10,10,10}));
        }
    }
}
