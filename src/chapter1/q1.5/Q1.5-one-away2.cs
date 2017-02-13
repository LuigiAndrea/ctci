using System;

namespace Chapter1
{
    public class Q1_5OneAway2
    {
        public static bool oneAway2(string str1, string str2)
        {
            int diff = str1.Length - str2.Length;
            if (Math.Abs(diff) > 1)
                return false;

            bool result = false;
            switch (diff)
            {
                case -1:
                    result = OneEditAway(str1, str2);
                    break;
                case 0:
                    result = OneEditAway(str1, str2);
                    break;
                case 1:
                    result = OneEditAway(str2, str1);
                    break;
            }
            return result;
        }

        public static bool OneEditAway(string str1, string str2)
        {
            int shorterIndex = 0;
            int longerIndex = 0;
            bool found = false;
            while (shorterIndex < str1.Length && longerIndex < str2.Length)
            {
                if (str1[shorterIndex] != str2[longerIndex])
                {
                    if (shorterIndex != longerIndex)
                    {
                        return false;
                    }

                    if (str1.Length.Equals(str2.Length))
                    {
                        if (found)
                            return false;
                        found = true;
                        shorterIndex++;
                    }
                }
                else
                {
                    shorterIndex++;
                }

                longerIndex++;
            }

            return true;
        }
    }
}