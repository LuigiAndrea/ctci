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
            int size = byteToBit.Length;
            for (var i = size - 1; i >= 0; i--)
                Write((bool)byteToBit[i] ? 1 : 0);
        }
    }
}


