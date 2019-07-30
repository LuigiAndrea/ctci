using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Chapter8
{
    public static class Q8_14BooleanEvaluation
    {
        public static int CountEvaluation(string s, bool result)
        {
            if (s != null && isStringValid(s))
            {
                return countEval(s, result);
            }
            else
            {
                throw new ArgumentException($"{nameof(CountEvaluation)} must have a valid string s");
            }
        }

        public static int CountEvaluationOptimized(string s, bool result)
        {
            if (s != null && isStringValid(s))
            {
                return countEval(s, result);
            }
            else
            {
                throw new ArgumentException($"{nameof(CountEvaluationOptimized)} must have a valid string s");
            }
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
                string right = s.Substring(i + 1, s.Length - (i + 1));

                int leftTrue = countEval(left, true);
                int leftFalse = countEval(left, false);
                int rightTrue = countEval(right, true);
                int rightFalse = countEval(right, false);

                int total = (leftTrue + leftFalse) * (rightTrue + rightFalse);
                int subwaysTrue = 0;

                if (c == '^')
                {
                    subwaysTrue = leftTrue * rightFalse + leftFalse * rightTrue;
                }
                else if (c == '&')
                {
                    subwaysTrue = leftTrue * rightTrue;
                }
                else if (c == '|')
                {
                    subwaysTrue = leftTrue * rightFalse + leftFalse * rightTrue + leftTrue * rightTrue;
                }

                ways += (result) ? subwaysTrue : total - subwaysTrue;
            }

            return ways;
        }

         private static int countEval(string s, bool result, Dictionary<string,int> hashMap)
        {
            if(hashMap.ContainsKey(result + s))
                return hashMap[result+s];

            if (s.Length == 0) return 0;
            if (s.Length == 1) return (result == stringToBoolean(s)) ? 1 : 0;

            int ways = 0;
            for (int i = 1; i < s.Length; i += 2)
            {
                char c = s[i];
                string left = s.Substring(0, i);
                string right = s.Substring(i + 1, s.Length - (i + 1));

                int leftParenthesizeWays = getParenthesizeCount(s);
                int rightParenthesizeWays = getParenthesizeCount(s);

                int leftTrue = countEval(left, true, hashMap);
                int leftFalse = leftParenthesizeWays - leftTrue;
                int rightTrue = countEval(right, true, hashMap);
                int rightFalse = rightParenthesizeWays - rightTrue;

                int total = (leftTrue + leftFalse) * (rightTrue + rightFalse);
                int subwaysTrue = 0;

                if (c == '^')
                {
                    subwaysTrue = leftTrue * rightFalse + leftFalse * rightTrue;
                }
                else if (c == '&')
                {
                    subwaysTrue = leftTrue * rightTrue;
                }
                else if (c == '|')
                {
                    subwaysTrue = leftTrue * rightFalse + leftFalse * rightTrue + leftTrue * rightTrue;
                }

                ways += (result) ? subwaysTrue : total - subwaysTrue;
            }
            
            return hashMap[result+s] = ways;;
        }

        private static bool stringToBoolean(string s) => (s == "1") ? true : false;

        private static bool isStringValid(string s)
        {
            string regex = @"(?x)  
                            ^[01]  
                            ([\|\^\&] [01])*$";

            if (Regex.IsMatch(s, regex))
                return true;

            return false;

        }

        private static int getParenthesizeCount(string s){
           int numberOfOperators = s.Length - 2;
           return factorial(2 * numberOfOperators)/
                    (factorial(numberOfOperators+1)*factorial(numberOfOperators));
       
        }

        private static int factorial(int n){
            int fact = 1;
            for(int i=n; i>0;i--){
                fact*=i;
            }
            return fact;
        }
    }
}
