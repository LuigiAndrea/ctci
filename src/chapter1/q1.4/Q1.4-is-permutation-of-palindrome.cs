namespace Chapter1
{
    public class Q1_4IsPermutationOfPalindrome
    {
        // Summary:
        // 
        //   Given a string, write a function to check if it is a permutation of a palindrome. 
        //   A palindrome is a word or phrase that is the same forwards and backwards. A permutation is a rearrangement of letters. 
        //   The palindrome does not need to be limited to just dictionary words. 
        //   The alghoritms is case-insensitive; abba is the same as aBba, delete the line s.ToLower() otherwise
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
                if (letters[el] != -1
                        && el != ' '
                        && letters[el] % 2 != 0)
                {
                    if (check == true)
                        return false;
                    else
                        check = true;

                    letters[el] = -1;
                }
            }

            return true;
        }
    }
}