using System;
using System.Text.RegularExpressions;

namespace Chapter8
{
    public static class Q8_14BooleanEvaluation
    {
        public static int CountEvaluation(string s, bool result)
        {
            string regex = @"(?x)  
                            ^[01]  
                            ([\|\^\&] [01])*$";
            //Check if the string is valid
            if(Regex.IsMatch(s,regex)){
                return countEval(s, result);
            }
            else 
                throw new ArgumentException($"{nameof(CountEvaluation)} must have a valid string s");
        }

        private static int countEval(string s, bool result)
        {
            if (s.Length == 0) return 0;
            if (s.Length == 1) return (result == stringToBoolean(s)) ? 1 : 0;

            int ways = 0;
            for (int i = 1; i < s.Length; i += 2)
            {
                char c = s[i];
                string left = s.Substring(0, i);
                string right = s.Substring(i+1, s.Length - (i + 1));

                int leftTrue = countEval(left, true);
                int leftFalse = countEval(left, false);
                int rightTrue = countEval(right, true);
                int rightFalse = countEval(right, false);

                int total = (leftTrue + leftFalse) * (rightTrue + rightFalse);
                int subwaysTrue = 0;

                if (c == '^')
                {
                    subwaysTrue = leftTrue * rightFalse + leftFalse * rightTrue;
                } else if(c == '&'){
                    subwaysTrue = leftTrue * rightTrue;
                } else if(c == '|'){
                    subwaysTrue = leftTrue * rightFalse + leftFalse * rightTrue + leftTrue * rightTrue;
                }
                      
                ways+=(result) ? subwaysTrue : total-subwaysTrue;
            }

            return ways;
        }


        //Create an optimized version TODO

        private static bool stringToBoolean(string s) => (s == "1") ? true : false;
    }
}
