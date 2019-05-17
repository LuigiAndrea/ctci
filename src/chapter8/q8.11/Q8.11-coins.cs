using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter8
{
    public static class Q8_11Coins
    {
        private static int calculateChange(int amount, int[] coins, int index)
        {
            if (index >= coins.Length - 1) return 1;
            int coin = coins[index];
            int ways = 0;

            for (int i = 0; i * coin <= amount; i++)
            {
                int amountRemaining = amount - i * coin;
                ways += calculateChange(amountRemaining, coins, index + 1);
            }
            return ways;
        }

        public static int calculateChange(int cents) => calculateChange(cents, new int[] { 25, 10, 5, 1 }, 0);
    }
}
