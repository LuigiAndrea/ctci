using System;

namespace Chapter16
{
    public class Q16_6SmallestDifference
    {
        //Without using absolute value, negative difference are ignored
        public static int SmallestPairDifference(int[] a, int[] b)
        {
            Array.Sort(a);
            Array.Sort(b);
            
            int diff = int.MaxValue;
            int currentDiff = -1;

            for (int i = 0, j = 0; i < a.Length && j < b.Length;)
            {
                currentDiff = a[i] - b[j];

                if (currentDiff == 0)
                    return diff = 0;

                if (currentDiff > 0 && currentDiff < diff)
                {
                    diff = currentDiff;
                }

                if (currentDiff < 0)
                {
                    i++;
                }
                else
                {
                    j++;
                }
            }

            return Difference(diff);
        }

        private static int Difference(int diff) => (diff == int.MaxValue) ? -1 : diff;
    }
}