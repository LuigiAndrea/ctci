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

            smallestNum = getSmallestNumber(num,
            (numberOnes, numberZeros) =>
                        {
                            int copy = num;
                            copy &= (-1 << (numberZeros + numberOnes + 1));
                            int mask = ((1 << (numberOnes + 1)) - 1) << (numberZeros - 1);
                            copy |= mask;

                            return copy;
                        });

            largestNum = getLargestNumber(num,
            (numberOnes, numberZeros) =>
                    {
                        int copy = num;
                        int rightmostNonTrailingZero = numberZeros + numberOnes;

                        copy |= (1 << rightmostNonTrailingZero);
                        copy &= (-1 << rightmostNonTrailingZero);
                        copy |= ((1 << (numberOnes - 1)) - 1);
                        return copy;
                    });

            return (smallestNum, largestNum);
        }

        public static (int smallestNum, int largestNum) nextNumber2(int num)
        {
            if (num <= 0)
                throw new ArgumentException(message: $"The number {nameof(num)} must be positive", paramName: nameof(num));

            int smallestNum = 0;
            int largestNum = 0;

            largestNum = getLargestNumber(num,
                (numberOnes, numberZeros) => num - 1 + (1 << numberZeros) + (1 << (numberOnes - 1)));

            smallestNum = getSmallestNumber(num,
                (numberOnes, numberZeros) => num + 1 - (1 << numberOnes) - (1 << (numberZeros - 1)));
            return (smallestNum, largestNum);
        }
        private static int getLargestNumber(int num, Func<int, int, int> getNumber)
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

            return getNumber(numberOnes, numberZeros);

        }
        private static int getSmallestNumber(int num, Func<int, int, int> getNumber)
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

            return getNumber(numberOnes, numberZeros);
        }
    }
}
