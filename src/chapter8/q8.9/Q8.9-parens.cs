using System;
using System.Collections.Generic;

namespace Chapter8
{
    public static class Q8_9Parens
    {
        public static List<string> parentheses(int n)
        {
            List<string> list = new List<string>();
            parens(list, n, n, 0, new char[n * 2]);
            return list;
        }

        private static void parens(List<string> list, int left, int right, int index, char[] str)
        {
            if (left > right || left < 0)
                return;
            if (right == 0 && left == 0)
            {
                list.Add(String.Concat(str));
            }
            else
            {
                str[index] = '(';
                parens(list, left - 1, right, index + 1, str);
                str[index] = ')';
                parens(list, left, --right, ++index, str);
            }
        }
    }
}