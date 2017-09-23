using System;
using Xunit;

using static Chapter5.Q5_8DrawLine;

namespace Tests.Chapter5
{
    public class Q5_8
    {
        const int width = 16;
        byte[] screen = new byte[8] { 0b0001_0111, 0b0101_0000, 0b0000_0000, 0b1100_0000, 0b0000_0000, 0b0111_0000, 0b0000_0000, 0b1010_0000 };

        [FactAttribute]
        private void drawlineDifferentByteTest()
        {
            byte[] output = DrawLine(screen, width, 7, 15, 1);
            byte[] expectedByte = new byte[8] { 0b0001_0111,0b0101_0000,
                                                0b0000_0001,0b1111_1111,
                                                0b0000_0000,0b0111_0000,
                                                0b0000_0000,0b1010_0000 };
            Assert.Equal(expectedByte, output);
        }

        [FactAttribute]
        private void drawlineSameByteTest()
        {
            byte[] output = DrawLine(screen, width, 0, 3, 2);
            byte[] expectedByte = new byte[8] { 0b0001_0111, 0b0101_0000,
                                                0b0000_0000, 0b1100_0000,
                                                0b1111_0000, 0b0111_0000,
                                                0b0000_0000, 0b1010_0000 };
            Assert.Equal(expectedByte, output);
        }

        [FactAttribute]
        private void drawlineScreenNullExceptionTest()
        {
            Exception exception = Record.Exception(() => DrawLine(null, width, 0, 3, 2));
            Assert.IsType<ArgumentNullException>(exception);
        }

        [TheoryAttribute]
        [InlineDataAttribute(width, 0, 3, 4)] //y wrong
        [InlineDataAttribute(width, 4, 3, 2)] //x1 > x2
        [InlineDataAttribute(width, 1, 16, 2)] // x2 too big
        [InlineDataAttribute(24, 1, 15, 2)] //width wrong, horizontal lines must have the same number of pixels
        [InlineDataAttribute(12, 1, 9, 0)]
        [InlineDataAttribute(-8, 1, 9, 0)]
        [InlineDataAttribute(width, -1, 10, 2)] //negative values
        [InlineDataAttribute(width, 1, 10, -2)]
        [InlineDataAttribute(width, 1, -10, 2)]
        private void drawlineArgumentExceptionsTest(int width, int x1, int x2, int y)
        {
            Exception actualException = Record.Exception(() => DrawLine(screen, width, x1, x2, y));
            Assert.IsType<ArgumentException>(actualException);
        }
    }
}
