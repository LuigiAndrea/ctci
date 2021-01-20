using Xunit;

using static Chapter5.Utilities;

namespace Tests.Chapter5
{
    public class Chapter5UtilitiesTest
    {
        [FactAttribute]
        private static void UtilitiesTest()
        {
            int number = 100;
            int index = 3;
            Assert.False(getBit(number, index));
            Assert.Equal(108, setBit(number, index));

            Assert.Equal(108, updateBit(number, index, true));
            Assert.Equal(100, updateBit(number, index, false));

            Assert.Equal(108, flipBit(number, index));
            
            Assert.Equal(100, clearBit(number, index));
            Assert.Equal(4, clearFromMostSignificantBitThroughIndex(number, index));
            Assert.Equal(96, clearFromIndexThroughZero(number, index));
        }
    }
}
