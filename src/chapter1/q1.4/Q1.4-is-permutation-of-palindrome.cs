namespace Chapter1
{
    public class Q1_4IsPermutationOfPalindrome
    {
        public static bool isPermutationOfPalindrome(string s)
        {
            int[] letters = new int[256];
            s = s.ToLower();

            foreach (char el in s)
            {
                letters[el]++;
            }

            bool check = false;
            foreach (char el in s)
            {
                if (el != ' ' && letters[el] % 2 != 0)
                {
                    if (check == true)
                        return false;
                    else
                        check = true;

                    letters[el]--;
                }
            }

            return true;
        }
    }
}