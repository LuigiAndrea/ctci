using System;

namespace Chapter16
{
    public static class Q16_5FactorialZeros
    {
        public static int GetFactorialTrailingZeros(int n)
        {
            if (n < 0)
                throw new ArgumentException("Please provide a positive number");

            var trailingZeros = 0;

            for (int div = 5; n / div != 0; div *= 5)
            {
                trailingZeros += n / div;
            }

            return trailingZeros;
        }
    }
}