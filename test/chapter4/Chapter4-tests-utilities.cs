using Xunit;

using Chapter4;
using static Chapter4.Utilities;
using Type = Chapter4.Utilities.TypeTraversal;
using static Chapter4.Q4_2MinimalTree;

namespace Tests.Chapter4
{
    public static class TestUtilities
    {
        /// <summary>
        /// Determine if the values of a TreeBinaryNode are the same as the values provided.
        ///</summary>
        /// <param name="result"> Array of values to check.</param>
        /// <param name="tree"> TreeBinaryNode to check.</param>
        /// <param name="type"> Specify how to visit the TreeBinaryNode.</param>
        public static void checkValues<T>(T[] result, TreeBinaryNode<T> tree, Type type = Type.preOrder)
        {
            Traversal<T> t = new Traversal<T>(type, tree);
            Assert.True(t.EqualsToArray(result));
        }

        /// <summary>
        /// Create a Numeric Balanced Tree.
        ///</summary>
        /// <param name="size">Number of nodes contained in the tree.</param>
        public static TreeBinaryNode<int> createNumericBalancedTree(int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
                array[i] = i;

            return MinimalTree(array);
        }

    }
}