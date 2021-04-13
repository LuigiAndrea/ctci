using System.Collections;
using System.Collections.Generic;
using System;
namespace Chapter1
{
    public class Q1_2Permutation
    {
        public static bool permutation(string a, string b)
        {
            if (a.Length != b.Length)
                return false;

            char[] s1 = a.ToCharArray();
            Array.Sort(s1);
            char[] s2 = b.ToCharArray();
            Array.Sort(s2);

            return System.Linq.Enumerable.SequenceEqual(s1, s2);
        }

        public static bool permutationEff(string a, string b)
        {
            if (a.Length != b.Length)
                return false;

            int[] letters = new int[256];

            foreach (char el in a)
            {
                letters[el]++;
            }

            foreach (char el in b)
            {
                letters[el]--;
                if (letters[el] < 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
