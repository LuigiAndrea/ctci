using System;
using System.Collections;
using static System.Console;

namespace Chapter5
{
    public static class Utilities
    {
        /// <summary>
        /// Get the bit at position index
        ///</summary>
        /// <param name="num"> The number</param>
        /// <param name="index"> The position of the bit to get. The index is zero based</param>
        /// <returns>A boolean that indicates the value of the bit (True 1 and False 0)</returns>
        public static bool getBit(int num, int index) => (num & (1 << index)) > 0;

        /// <summary>
        /// Set the bit at position index
        ///</summary>
        /// <param name="num"> The number</param>
        /// <param name="index"> The position of the bit to set. The index is zero based</param>
        /// <returns>The new number.</returns>
        public static int setBit(int num, int index) => num | (1 << index);

        /// <summary>
        /// Update the bit at position index
        ///</summary>
        /// <param name="num"> The number</param>
        /// <param name="index"> The position of the bit to update. The index is zero based</param>
        /// <param name="bit"> true for one and false for 0. Simply used to determine what value to update the bit</param>
        /// <returns>The new number.</returns>
        public static int updateBit(int num, int index, bool bit) => bit ? num | (1 << index) : num & ~(1 << index);

        /// <summary>
        /// Flip the bit at position index. From 0 to 1 and viceversa.
        ///</summary>
        /// <param name="num"> The number</param>
        /// <param name="index"> The position of the bit to flip. The index is zero based</param>
        /// <returns>The new number.</returns>
        public static int flipBit(int num, int index) => num ^ (1 << index);

        /// <summary>
        /// Clear the bit at position index
        ///</summary>
        /// <param name="num"> The number</param>
        /// <param name="index"> The position of the bit to clear. The index is zero based</param>
        /// <returns>The new number.</returns>
        public static int clearBit(int num, int index) => num & ~(1 << index);

        /// <summary>
        /// Clear the bits from the Most Significant bit to Index(Inclusive)
        ///</summary>
        /// <param name="num"> The number</param>
        /// <param name="index"> The Index. The index is zero based</param>
        /// <returns>The new number.</returns>
        public static int clearFromMostSignificantBitThroughIndex(int num, int index) => num & ((1 << index) - 1);

        /// <summary>
        /// Clear the bits from Index to Zero (inclusive)
        ///</summary>
        /// <param name="num"> The number</param>
        /// <param name="index"> The Index. The index is zero based</param>
        /// <returns>The new number.</returns>
        public static int clearFromIndexThroughZero(int num, int index) => num & (-1 << index + 1);

        /// <summary>
        /// Print a monochorome screen
        ///</summary>
        /// <param name="screen"> Bytes of the monochrome screen</param>
        /// <param name="width"> The width of the screen in pixels. Always divisible by 8</param>
        /// <example> 
        /// This sample shows how to use the PrintBinaryTree Class.
        /// <code>
        // byte[] b = new byte[8];
        // b[0] = 0b0001_0111;
        // b[1] = 0b0101_0000;
        // b[2] = 0b0000_0000;
        // b[3] = 0b1100_0000;
        // b[4] = 0b0000_0000;
        // b[5] = 0b0111_0000;
        // b[6] = 0b0000_0000;
        // b[7] = 0b1010_0000;
        // const int width = 16;
        // printMonochromeScreen(DrawLine(b, width, 7,15,1), width);
        /// </code>
        /// </example>
        public static void printMonochromeScreen(Byte[] screen, int width)
        {
            if (width % 8 != 0)
                throw new ArgumentException(paramName: nameof(width), message: "The width must be divisible by 8");

            int byteXRows = width / 8;

            for (int row = 0; row < screen.Length; row++)
            {
                printByte(new BitArray(BitConverter.GetBytes(screen[row])));

                if ((row + 1) % byteXRows == 0)
                    WriteLine();
            }
        }

        private static void printByte(BitArray byteToBit)
        {
            for (var i = 7; i >= 0; i--)
                Write((bool)byteToBit[i] ? 1 : 0);
        }
    }
}


