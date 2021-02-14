using System;

namespace Chapter16
{
    public class Q16_6SmallestDifferenceAbs
    {
        //Using Absolute Value
        public static int SmallestPairDifferenceAbs(int[] a, int[] b)
        {
            Array.Sort(a);
            Array.Sort(b);
            int diff = int.MaxValue;

            for (int i = 0, j = 0; i < a.Length && j < b.Length;)
            {
                int currentDiff = Math.Abs(a[i] - b[j]);
                if (currentDiff < diff)
                {
                    diff = currentDiff;
                }

                if (a[i] - b[j] < 0)
                {
                    i++;
                }
                else
                {
                    j++;
                }
            }

            return diff;
        }
    }
}