using System;
using System.Collections.Generic;
using BSTSequencesUtilities;
using System.Linq;

namespace Chapter4
{
    public static class Q4_9BSTSequences<T>
    {
        public static List<List<T>> allSequences(TreeBinaryNode<T> node)
        {
            List<List<T>> result = new List<List<T>>();
            if (node == null)
            {
                result.Add(new List<T>());
                return result;
            }

            List<T> prefix = new List<T>();
            prefix.Add(node.value);

            List<List<T>> leftSeq = allSequences(node.left);
            List<List<T>> rightSeq = allSequences(node.right);

            foreach (var left in leftSeq)
            {
                foreach (var right in rightSeq)
                {
                    List<List<T>> mergedList = new List<List<T>>();
                    mergeLists(left, right, prefix, mergedList);
                    result.AddRange(mergedList);
                }
            }

            return result;
        }

        private static void mergeLists(List<T> first, List<T> second, List<T> prefix, List<List<T>> results)
        {

            if (first.Count == 0 || second.Count == 0)
            {
                List<T> res = new List<T>(prefix);
                res.AddRange(first);
                res.AddRange(second);
                results.Add(res);
                return;
            }

            T firstEl = first.GetAndRemoveFirst();
            prefix.Insert(prefix.Count, firstEl);
            mergeLists(first, second, prefix, results);
            prefix.RemoveAt(prefix.Count - 1);
            first.Insert(0, firstEl);

            T secondEl = second.GetAndRemoveFirst();
            prefix.Insert(prefix.Count, secondEl);
            mergeLists(first, second, prefix, results);
            prefix.RemoveAt(prefix.Count - 1);
            second.Insert(0, secondEl);
        }
    }
}
