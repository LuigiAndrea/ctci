namespace Chapter1
{
    public class Q1_4IsPermutationOfPalindromeBit
    {
        //case-insensitive. Letters between A-Za-z, no Extended ASCII
        public static bool isPermutationOfPalindromeBit(string s)
        {
            s.ToLower();
            int bitVector = 0;

            foreach (char el in s)
            {
                int index = GetCharacterValue(el);
                bitVector = Toggle(bitVector, index);
            }

            return (bitVector & (bitVector - 1)) == 0;
        }

        public static int GetCharacterValue(char el)
        {

            if (el >= 'a' && el <= 'z')
                return el - 'a';
            else
                return -1;
        }

        public static int Toggle(int bitVector, int index)
        {
            if (index == -1)
                return bitVector;

            int mask = 1 << index;

            if ((bitVector & mask) == 0)
            {
                bitVector |= mask;
            }
            else
            {
                bitVector &= ~mask;
            }

            return bitVector;
        }
    }
}