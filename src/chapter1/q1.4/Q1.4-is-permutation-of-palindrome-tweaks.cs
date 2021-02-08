namespace Chapter1
{
    public class Q1_4IsPermutationOfPalindromeTweak
    { 
         //Tweaks of the standard solution
        public static bool isPermutationOfPalindrome2(string s)
        {
            int[] letters = new int[256];
            s = s.ToLower();
            int count = 0;
            foreach (char el in s)
            {
                if (el != ' ')
                {
                    int val = ++letters[el];
                    if (val % 2 != 0)
                    {
                        count++;
                    }
                    else
                    {
                        count--;
                    }
                }
            }

            return count <= 1 ? true : false;
        }
    }
}