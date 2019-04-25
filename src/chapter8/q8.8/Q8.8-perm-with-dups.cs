using System;
using System.Collections.Generic;
using System.Text;
using static Chapter8.Q8_7PermNoDups;

namespace Chapter8
{
    public static class Q8_8PermWithDups
    {
        public static List<string> buildPermutations(string phrase)
        {
            if (phrase == null)
                RaisePermutationException(nameof(getPermutations));

            Dictionary<char, int> frequencyTbl = buildFrequencyTable(phrase);
            List<string> result = new List<string>();
            getPermutations(frequencyTbl, "", phrase.Length, result);
            return result;
        }

        private static void getPermutations(Dictionary<char, int> counts, string prefix, int remaining, List<string> result)
        {
            if (remaining == 0)
            {
                result.Add(prefix);
                return;
            }
            
            foreach (char c in counts.Keys)
            {
                int count = counts[c];

                if (count > 0)
                {
                    var freq = new Dictionary<char,int>(counts);
                    freq[c] = count - 1;
                    getPermutations(freq, prefix + c, remaining-1, result);
                    freq[c] = count;
                }
            }
        }

        private static Dictionary<char, int> buildFrequencyTable(string sentence)
        {
            Dictionary<char, int> freqTbl = new Dictionary<char, int>();

            foreach (char c in sentence)
            {
                if (freqTbl.ContainsKey(c))
                {
                    freqTbl[c] += 1;
                }
                else
                {
                    freqTbl.Add(c, 1);
                }
            }

            return freqTbl;
        }

    }
}