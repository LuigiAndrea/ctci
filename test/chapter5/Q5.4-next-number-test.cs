using Xunit;

using static Chapter5.Q5_4NextNumber;

namespace Tests.Chapter5
{
    public class Q5_4
    {
        [FactAttribute]
        private static void NextNumberTest()
        {
            int s; int l;
            (s, l) = nextNumber(287);
            Assert.Equal((s, l), (252, 303));
            (s, l) = nextNumber(4);
            Assert.Equal((s, l), (2, 8));
            (s, l) = nextNumber(113);
            Assert.Equal((s, l), (108, 114));
            (s, l) = nextNumber(56);
            Assert.Equal((s, l), (52, 67));
            (s, l) = nextNumber(int.MaxValue);
            Assert.Equal((s, l), (-1, -1));
            (s, l) = nextNumber(int.MaxValue - 1);
            Assert.Equal((s, l), (int.MaxValue-2, -1));
            (s, l) = nextNumber(int.MaxValue - 2);
            Assert.Equal((s, l), (int.MaxValue-4, int.MaxValue-1));


            // (int s2, int l2) = nextNumber(56);
            // (int s2, int l2) = nextNumber(int.MaxValue);
            // WriteLine($"{s} - > {l}");
            // WriteLine($"{s2} - > {l2}");
        }
    }
}
