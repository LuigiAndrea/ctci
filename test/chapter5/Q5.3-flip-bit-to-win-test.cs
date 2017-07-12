using Xunit;

using static Chapter5.Q5_3FlipBitToWin;

namespace Tests.Chapter5
{
    public class Q5_3
    {
        [FactAttribute]
        private static void FlipBitTest()
        {
            int count = flipBit(-1);
            Assert.Equal(count,32);
            count = flipBit(0);
            Assert.Equal(count, 0);
            count = flipBit(-1148952);
            Assert.Equal(count, 15);
            count = flipBit(8646467);
            Assert.Equal(count, 10);
        }
    }
}
