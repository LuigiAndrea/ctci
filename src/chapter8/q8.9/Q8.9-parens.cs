using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter8
{
    public static class Q8_9Parens
    {
        private static char leftParens = '(';
        private static char rightParens = ')';
        public static List<string> parentheses(int n)
        {
            List<string> list = new List<string>();
            parens(list, n, n, 0, new char[n * 2]);
            return list;
        }

        public static List<string> parenthesesWithoutArray(int n)
        {
            List<string> list = new List<string>();
            parens2(list, n, n, 0, new StringBuilder(new String('\t', n * 2)));
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
                str[index] = leftParens;
                parens(list, left - 1, right, index + 1, str);
                str[index] = rightParens;
                parens(list, left, --right, ++index, str);
            }
        }

        private static void parens2(List<string> list, int left, int right, int index, StringBuilder str)
        {
            if (left > right || left < 0)
                return;
            if (right == 0 && left == 0)
            {
                list.Add(String.Concat(str));
            }
            else
            {
                addParen(index, str, leftParens);
                parens2(list, left - 1, right, index + 1, str);
                addParen(index, str, rightParens);
                parens2(list, left, --right, ++index, str);
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
                        string strParen = insertParens(i, paren);
                        combParens.Add(strParen);
                    }
                }

                combParens.Add(paren + "()");
            }

            return combParens;
        }

        private static string insertParens(int i, string paren) => new StringBuilder(paren).Insert(i + 1, "()").ToString();

        private static void addParen(int index, StringBuilder sb, char character)
        {
            sb.Remove(index, 1);
            sb.Insert(index, character);
        }

    }
}