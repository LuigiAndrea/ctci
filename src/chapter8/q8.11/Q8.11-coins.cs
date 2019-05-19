using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter8
{
    public static class Q8_11Coins
    {
        static int[] coins = new int[] { 25, 10, 5, 1 };
        private static int calculateChange(int amount, int index)
        {
            if (index >= coins.Length - 1)
                return 1;

            int coin = coins[index];
            int ways = 0;

            for (int i = 0; i * coin <= amount; i++)
            {
                int remainingAmount = amount - i * coin;
                ways += calculateChange(remainingAmount, index + 1);
            }
            return ways;
        }

        public static int calculateChangeOptimized(int amount, int[,] mappings, int index)
        {
            if (mappings[amount, index] > 0)
                return mappings[amount, index];

            if (index >= coins.Length - 1)
                return 1;

            int coin = coins[index];
            int ways = 0;

            for (int i = 0; i * coin <= amount; i++)
            {
                int remainingAmount = amount - i * coin;
                ways += calculateChangeOptimized(remainingAmount, mappings, index + 1);
            }

            mappings[amount, index] = ways;

            return ways;
        }

        public static int calculateChange(int cents)
        {
            validateCents(cents);
            return calculateChange(cents, 0);
        }

        public static int calculateChangeOptimized(int cents)
        {
            validateCents(cents);
           return calculateChangeOptimized(cents, new int[cents + 1, coins.Length], 0);
        }

        private static void validateCents(int cents)
        {
            if (cents < 1)
                throw new ArgumentException($"{nameof(validateCents)} The amount to make the change must be greater than 0");
        }
    }
}
