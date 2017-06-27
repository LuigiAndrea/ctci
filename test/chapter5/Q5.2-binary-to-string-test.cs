using Xunit;

using static Chapter5.Q5_2BinaryToString;

namespace Tests.Chapter5
{
    public class Q5_2
    {
        [FactAttribute]
        private static void PrintBinaryTest()
        {
            const string value = ".011";
            const string Err = "Error";

            Assert.Equal(printBinary(0.375), value);
            Assert.Equal(printBinary2(0.375), value);
            Assert.Equal(printBinary(0.37), Err);
            Assert.Equal(printBinary2(0.37), Err);
            Assert.Equal(printBinary(-5), Err);
            Assert.Equal(printBinary2(-8), Err);
            Assert.Equal(printBinary(5), Err);
            Assert.Equal(printBinary2(8), Err);
        }
    }
}
