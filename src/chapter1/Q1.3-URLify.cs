using System;

namespace Chapter1
{
    public class Q1_3URLify
    {

        // Summary:
        //   
        // URLi : Write a method to replace all spaces in a string with '%20 
        // You may assume that the string has sufficient space at the end to hold the additional characters, 
        // and that you are given the "true" length of the string.
        //
        // Parameters:
        //   str:
        //      The string to replace its characters
        //
        // Returns:
        //     The new String after replacing its spaces

        public static string URLify(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i].Equals(' '))
                {
                    str = str.Substring(0, i) + "%20" + str.Substring(i + 1);
                    i += 2;
                }
            }
            return str;
        }
    }
}