using System;
using System.Collections.Generic;

namespace Chapter8
{
    public static class Q8_7PermNoDups
    {
        public static List<string> getPermutations(string phrase)
        {
            List<string> result = new List<string>();
            if (phrase.Length == 0)
            {
                result.Add("");
                return result;
            }

            List<string> partialResult = new List<string>();
            for (int i = 0; i < phrase.Length; i++)
            {
                string begin = phrase.Substring(0, i);
                string end = phrase.Substring(i+1);
                partialResult = getPermutations(begin + end);
                foreach (var item in partialResult)
                {
                    result.Add(phrase[i] + item);
                }
            }

            return result;
        }
    }
}
