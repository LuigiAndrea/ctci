namespace Chapter5
{
    public static class Q5_6Conversion
    {
        public static uint conversion(int numberA, int numberB)
        {
            uint numberOfDifferentBits = 0;

            for (uint differences = (uint)(numberA ^ numberB); differences != 0; differences >>= 1)
                numberOfDifferentBits += differences & 1;

            return numberOfDifferentBits;
        }

        public static int conversion2(int numberA,int numberB){
             int numberOfDifferentBits = 0;

            for (int differences = numberA ^ numberB; differences != 0; differences &= (differences-1))
                numberOfDifferentBits++; 

            return numberOfDifferentBits;
        }
    }
}
