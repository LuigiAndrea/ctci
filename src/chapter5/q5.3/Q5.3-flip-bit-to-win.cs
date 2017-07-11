using System;
using static System.Math;

namespace Chapter5
{
    public static class Q5_3FlipBitToWin
    {
        public static int flipBit(int num)
        {
            uint number = (uint)num;

            if (~number == 0)
                return BitConverter.GetBytes(number).Length;

            int currentLength = 0;
            int previousLength = 0;

            int max = 0;

            while (number != 0)
            {   //it is 1 bit
                if ((number & 1) == 1)
                {
                    currentLength++;
                }
                else
                { //it is 0 bit
                    previousLength = ((number & 2) == 0) ? 0 : currentLength;
                    currentLength = 0;
                }

                max = Max(currentLength + previousLength + 1, max);
                number >>= 1;
            }
            return max;
        }
    }
}