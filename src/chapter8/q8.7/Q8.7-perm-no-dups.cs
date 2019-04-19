using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter8
{
    public static class Q8_7PermNoDups
    {
        public static List<string> getPermutations(string phrase)
        {
            if (phrase == null)
                RaisePermutationException(nameof(getPermutations));

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
                string end = phrase.Substring(i + 1);
                partialResult = getPermutations(begin + end);
                foreach (var item in partialResult)
                {
                    result.Add(phrase[i] + item);
                }
            }

            return result;
        }

        public static List<string> getPermutations2(string phrase)
        {
            if (phrase == null)
                RaisePermutationException(nameof(getPermutations2));

            List<string> perm = new List<string>();

            if (phrase.Length == 0)
            {
                perm.Add("");
                return perm;
            }

            string firstChar = phrase.Substring(0, 1);
            string remainder = phrase.Substring(1);

            List<string> words = getPermutations2(remainder);

            foreach (var word in words)
            {
                for (int i = 0; i <= word.Length; i++)
                {
                    string newPhrase = new StringBuilder(word).Insert(i, firstChar).ToString();
                    perm.Add(newPhrase);
                }
            }
            return perm;
        }

        public static List<string> getPermutations3(string phrase)
        {
            if (phrase == null)
                RaisePermutationException(nameof(getPermutations3));
            List<string> result = new List<string>();
            getPerm("", phrase, result);
            return result;
        }

        private static void getPerm(string prefix, string phrase, List<string> result)
        {
            if (phrase.Length == 0)
            {
                result.Add(prefix);
            }

            for (int i = 0; i < phrase.Length; i++)
            {
                string begin = phrase.Substring(0, i);
                string end = phrase.Substring(i + 1);
                string character = phrase.Substring(i, 1);
                getPerm(character + prefix, begin + end, result);
            }
        }

        public static List<string> getPermutationsIterative(string phrase)
        {
            if (phrase == null)
                RaisePermutationException(nameof(getPermutationsIterative));

            int size = phrase.Length;
            List<string> perm = new List<string>();
            perm.Add(phrase.Substring(0, 1));
            phrase = phrase.Substring(1);

            if (phrase == String.Empty)
                return perm;

            List<string> result = new List<string>();

            foreach (char c in phrase)
            {
                result.Clear();
                foreach (string str in perm)
                {
                    result.AddRange(InsertChar(c, str));
                }
                perm.Clear();
                perm.AddRange(result);
            }
            
            return perm;
        }

        private static List<string> InsertChar(char c, string str)
        {
            List<string> result = new List<string>();
            for (int i = 0; i <= str.Length; i++)
            {
                result.Add(new StringBuilder(str).Insert(i, c).ToString());
            }
            return result;
        }

        private static void RaisePermutationException(string method) => throw new ArgumentException($"{method}: The string to permutate must be not null");
    }
}
