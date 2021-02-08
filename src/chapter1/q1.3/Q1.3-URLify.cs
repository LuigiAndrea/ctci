using System;

namespace Chapter1
{
    public class Q1_3URLify
    {
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