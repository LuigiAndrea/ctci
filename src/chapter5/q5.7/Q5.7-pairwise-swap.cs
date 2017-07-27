using System;

namespace Chapter5
{
    public static class Q5_7PairwiseSwap
    {
        public static int pairwiseSwap(int number) 
                    => (int)(((uint)0xaaaaaaaa & number) >> 1) | ((0x55555555 & number) << 1);
    }
}
