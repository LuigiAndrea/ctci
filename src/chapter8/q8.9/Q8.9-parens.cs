using System;
using System.Collections.Generic;
using System.Text;

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

        public static HashSet<string> parenthesesNotOptimized(int n)
        {
            HashSet<string> list = new HashSet<string>();
            list = getParens(n);
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

        private static HashSet<string> getParens(int n)
        {
            HashSet<string> combParens = new HashSet<string>();

            if (n == 0)
            {
                combParens.Add("");
                return combParens;
            }

            HashSet<string> prevCombParens = getParens(n - 1);

            foreach (var paren in prevCombParens)
            {
                for (int i = 0; i < paren.Length; i++)
                {
                    if (paren[i] == '(')
                    {
                        string strParen = insertParen(i, paren);
                        combParens.Add(strParen);
                    }
                }

                combParens.Add(paren + "()");
            }

            return combParens;
        }

        private static string insertParen(int i, string paren) => new StringBuilder(paren).Insert(i+1,"()").ToString();
        
    }
}