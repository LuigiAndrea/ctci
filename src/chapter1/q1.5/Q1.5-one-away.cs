using System;

namespace Chapter1
{
    public class Q1_5OneAway
    {
        public static bool oneAway(string str1, string str2)
        {
            int diff = str1.Length - str2.Length;
            if (Math.Abs(diff) > 1)
                return false;

            bool result = false;
            switch (diff)
            {
                case -1:
                    result = OneInsertOrDelete(str1, str2);
                    break;
                case 0:
                    result = oneZeroReplace(str1, str2);
                    break;
                case 1:
                    result = OneInsertOrDelete(str2, str1);
                    break;
            }
            return result;
        }

        public static bool oneZeroReplace(string str1, string str2)
        {
            bool found = false;
            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] != str2[i])
                {
                    if (found)
                    {
                        return false;
                    }
                    found = true;
                }
            }

            return true;
        }

        public static bool OneInsertOrDelete(string str1, string str2)
        {
            int shorterIndex = 0;
            int longerIndex = 0;
            while (shorterIndex < str1.Length && longerIndex < str2.Length)
            {
                if (str1[shorterIndex] != str2[longerIndex])
                {
                    if (shorterIndex != longerIndex)
                    {
                        return false;
                    }

                    longerIndex++;
                }
                else
                {
                    longerIndex++;
                    shorterIndex++;
                }
            }

            return true;
        }
    }
}