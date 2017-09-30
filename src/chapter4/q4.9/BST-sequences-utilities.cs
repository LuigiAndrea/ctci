using static System.Console;
using System.Collections.Generic;
using System.Linq;

namespace Chapter4.BSTSequencesUtilities
{
    public static class ExtensionsSequences
    {
        public static T GetAndRemoveFirst<T>(this List<T> list)
        {
            T elem = list.First();
            list.RemoveAt(0);
            return elem;
        }
    }

    public static class UtilitiesBSTSequences
    {
        /// <summary>
        /// Print all possible sequences that could have led to the binary search tree passed as parameter
        ///</summary>
        /// <param name="results"> A list that contains all the sequences.</param>
        /// <example> 
        /// This sample shows how to use PrintSequences method
        /// <code>
        /// const int size = 5;
        /// int[] array = new int[size];
        /// for (int i = 0; i < size; i++)
        ///     array[i] = i;
        /// TreeBinaryNode<int> a = MinimalTree(array);
        /// List<List<int>> r = allSequences(a);
        /// PrintSequences(r);
        /// </code>
        /// </example>
        public static void PrintSequences<T>(List<List<T>> results)
        {
            foreach (var list in results)
            {
                for (int i = 0; i < list.Count; i++)
                    Write($"{list[i]}{(i < list.Count - 1 ? " - " : "")}");
                WriteLine();
            }
        }
    }
}