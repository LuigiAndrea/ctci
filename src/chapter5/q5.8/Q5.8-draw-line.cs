using System;

namespace Chapter5
{
    public static class Q5_8DrawLine
    {
        public static byte[] DrawLine(byte[] screen, int width, int x1, int x2, int y)
        {
            //Check that the horizontal lines have the same number of pixels
            if (width < 0 || width % 8 != 0 || (screen.Length % (width / 8)) != 0)
                throw new ArgumentException(message: "The width is wrong for this screen ", paramName: nameof(width));
            else if (y < 0 || y >= (screen.Length / (width / 8)))
                throw new ArgumentException(message: "The y is out of range for this screen ", paramName: nameof(y));
            else if (x1 < 0 || x2 < 0 || x1 > x2 || x1 > width || x2 > width)
                throw new ArgumentException(message: "The position of the horizontal line is wrong ", paramName: $"({nameof(x1)},{nameof(x2)})");

            int currentLine = (width / 8) * y;

            int startOffset = x1 % 8;
            int firstFullByte = x1 / 8;
            if (startOffset != 0)
                firstFullByte++;

            int endOffset = x2 % 8;
            int lastFullByte = x2 / 8;
            if (endOffset != 7)
                lastFullByte--;

            for (int b = firstFullByte; b <= lastFullByte; b++)
                screen[currentLine + b] = (byte)0xFF;

            byte startMask = (byte)((uint)0xFF >> startOffset);
            byte endMask = (byte)~((uint)(0xFF >> (endOffset + 1)));

            if ((x1 / 8) == (x2 / 8))
            {
                screen[currentLine + (x1 / 8)] |= (byte)(startMask & endMask);
            }
            else
            {
                if (startOffset != 0)
                    screen[currentLine + firstFullByte - 1] |= startMask;

                if (endOffset != 7)
                    screen[currentLine + lastFullByte + 1] |= endMask;
            }

            return screen;
        }
    }
}
