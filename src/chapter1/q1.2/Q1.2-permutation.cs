using System.Collections;
using System.Collections.Generic;
using System;
namespace Chapter1
{
    public class Q1_2Permutation
    {

        // Summary:
        //   Give two strings, write a method to decide if one is a permutation of the other
        //
        // Parameters:
        //   a:
        //     A string
        //   b:
        //     A String
        // Returns:
        //     a boolean value
        public static bool permutation(string a, string b)
        {
            if (a.Length != b.Length)
                return false;

            char[] s1 = a.ToCharArray();
            Array.Sort(s1);
            char[] s2 = b.ToCharArray();
            Array.Sort(s2);

            IStructuralEquatable se = s1;
            bool areEqual = se.Equals(s2, EqualityComparer<char>.Default);

            return areEqual ? true : false;
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