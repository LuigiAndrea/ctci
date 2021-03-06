using Xunit;

using static Chapter16.Q16_6SmallestDifference;
using static Chapter16.Q16_6SmallestDifferenceAbs;

namespace Tests.Chapter16
{
    public class Q16_6
    {

        [TheoryAttribute]
        [MemberData(nameof(TestDataSmallestDifference.getSPDNegative), MemberType = typeof(TestDataSmallestDifference))]
        public void SmallestDiffNegativeTest(int[] a, int[] b)
        {
            Assert.Equal(-1, SmallestPairDifference(a, b));
        }

        [TheoryAttribute]
        [MemberData(nameof(TestDataSmallestDifference.getSPDOne), MemberType = typeof(TestDataSmallestDifference))]
        public void SmallestDiffOneTest(int[] a, int[] b)
        {
            Assert.Equal(1, SmallestPairDifference(a, b));
            Assert.Equal(1, SmallestPairDifferenceAbs(a, b));

        }

        [TheoryAttribute]
        [MemberData(nameof(TestDataSmallestDifference.getSPDArrayDiffSize), MemberType = typeof(TestDataSmallestDifference))]
        public void SmallestDifferenceArrayDiffSizeTest(int[] a, int[] b)
        {
            Assert.Equal(2, SmallestPairDifference(a, b));
            Assert.Equal(1, SmallestPairDifferenceAbs(a, b));
        }

        [FactAttribute]
        public void SmallestDiffFirsTest()
        {
            int[] a = new int[] { 11, 10, 12 };
            int[] b = new int[] { 0, 0, 0 };

            Assert.Equal(10, SmallestPairDifference(a, b));
            Assert.Equal(10, SmallestPairDifferenceAbs(a, b));
        }

        [FactAttribute]
        public void SmallestDiffZeroTest()
        {
            int[] a = new int[] { -2, -5, 5, 0 };
            int[] b = new int[] { -2, -1, 6, 2 };

            Assert.Equal(0, SmallestPairDifference(a, b));
            Assert.Equal(0, SmallestPairDifferenceAbs(a, b));
        }

        [FactAttribute]
        public void SmallestDiffTest()
        {
            int[] a = new int[] { 5, 15, 40, 55 };
            int[] b = new int[] { 10, 19, 22, 72 };

            Assert.Equal(5, SmallestPairDifference(a, b));
            Assert.Equal(4, SmallestPairDifferenceAbs(a, b));
        }

        [FactAttribute]
        public void SmallestDiffNegativeAbsTest()
        {
            int[] a = new int[] { -2, -3, -5 };
            int[] b = new int[] { 2, 3, 5 };

            Assert.Equal(4, SmallestPairDifferenceAbs(a, b));
        }
    }

    class TestDataSmallestDifference
    {
        public static TheoryData<int[], int[]> getSPDNegative()
        {
            return new TheoryData<int[], int[]>() { {new int[] { 0, 0, 0 }, new int[] { 10, 10, 10 }},
                                                    {new int[] { -2, -3, -5 }, new int[] { 2, 3, 5 }}
                                                    };
        }
        public static TheoryData<int[], int[]> getSPDOne()
        {
            return new TheoryData<int[], int[]>() { {new int[] { 17, 15, 10 }, new int[] { 2, 8, 9 }},
                                                    {new int[] { -5, 4, 5, 12 }, new int[] { -6, 2, 10, 18 }},
                                                    {new int[] { -1,2,30 }, new int[] { 5,7,10,15,19,29 }},
                                                    {new int[] { 18,5,6,9,15,4 }, new int[] { 2,8 }}
                                                    };
        }

        public static TheoryData<int[], int[]> getSPDArrayDiffSize()
        {
            return new TheoryData<int[], int[]>() { {new int[] { 10, 15, 17 }, new int[] { 13, 18, 22, 25, 29 }},
                                                    {new int[] { 10, 18, 15, 22 }, new int[] { 2, 8,11 }},
                                                    };
        }
    }
}
