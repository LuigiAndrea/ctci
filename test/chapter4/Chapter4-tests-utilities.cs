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

        /// <summary>
        /// Create a Numeric Balanced Tree with also information about the parents.
        /// </summary>
        /// <param name="array">Array of nodes to use to build the tree.</param>
        public static class buildParentTree
        {
            public static TreeBinaryParentNode<int> MinimalParentTree(int[] array)
            {
                return (array == null) ? null
                                    : MinimalParentTree(array, 0, array.Length - 1, null);
            }

            private static TreeBinaryParentNode<int> MinimalParentTree(int[] array, int start, int end, TreeBinaryParentNode<int> parent)
            {
                TreeBinaryParentNode<int> currentParent = parent;

                if (start > end)
                    return null;

                int midIndex = (start + end) / 2;
                int middle = array[midIndex];
                parent = new TreeBinaryParentNode<int>(middle, null, null, currentParent);
                parent.left = MinimalParentTree(array, start, midIndex - 1, parent);
                parent.right = MinimalParentTree(array, midIndex + 1, end, parent);

                return parent;
            }
        }
    }
}