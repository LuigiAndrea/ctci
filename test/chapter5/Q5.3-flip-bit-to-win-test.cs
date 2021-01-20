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
            Assert.Equal(32,count);
            count = flipBit(0);
            Assert.Equal(0,count);
            count = flipBit(-1148952);
            Assert.Equal(15,count);
            count = flipBit(8646467);
            Assert.Equal(10,count);
        }
    }
}
