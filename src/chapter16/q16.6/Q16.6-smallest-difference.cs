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
            int i = 0;
            int diff = int.MaxValue;
            int currentDiff = -1;
            for (int j = 0; j < b.Length; j++)
            {
                for (currentDiff = a[i] - b[j]; currentDiff < 0 && i < a.Length; i++)
                {
                    currentDiff = a[i] - b[j];

                    //optimizations
                    if (currentDiff < 0 && i == a.Length - 1)
                        return Difference(diff);

                    if (currentDiff == 0)
                        return diff = 0;
                }

                if (i != 0) i--;

                if (currentDiff >= 0 && currentDiff < diff)
                {
                    diff = currentDiff;
                }
            }

            return Difference(diff);
        }

        private static int Difference(int diff) => (diff == int.MaxValue) ? -1 : diff;
    }
}