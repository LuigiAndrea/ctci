using System;

namespace Chapter5
{
    public static class Q5_4NextNumber
    {
        public static (int smallestNum, int largestNum) nextNumber(int num)
        {
            if (num <= 0)
                throw new ArgumentException(message: $"The number {nameof(num)} must be positive", paramName: nameof(num));

            int smallestNum = 0;
            int largestNum = 0;

            largestNum = getLargestNumber(num);
            smallestNum = getSmallestNumber(num);
            return (smallestNum, largestNum);
        }

        private static int getLargestNumber(int num)
        {
            int temp = num;
            int numberZeros = 0;
            int numberOnes = 0;
            //rightmost non-trailing zero
            while ((temp & 1) == 0)
            {
                numberZeros++;
                temp >>= 1;
            }

            while ((temp & 1) == 1)
            {
                numberOnes++;
                temp >>= 1;
            }

            if (numberOnes + numberZeros == 31)
                return -1;

            int rightmostNonTrailingZero = numberZeros + numberOnes;

            num |= 1 << rightmostNonTrailingZero;
            num &= -1 << rightmostNonTrailingZero;
            num |= (1 << (numberOnes - 1)) - 1;
            return num;

        }

        private static int getSmallestNumber(int num)
        {
            int temp = num;
            int numberZeros = 0;
            int numberOnes = 0;
            //rightmost non-trailing one
            while ((temp & 1) == 1)
            {
                numberOnes++;
                temp >>= 1;
            }

            if (temp == 0) return -1;

            while ((temp & 1) == 0)
            {
                numberZeros++;
                temp >>= 1;
            }

            int rightmostNonTrailingOne = numberZeros + numberOnes;

            num &= -1 << rightmostNonTrailingOne + 1;
            int mask = ((1 << numberOnes + 1) - 1) << (numberZeros - 1);
            num |= mask;

            return num;
        }
    }
}
