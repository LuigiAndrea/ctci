using Xunit;

using Chapter4;
using static Chapter4.Q4_2MinimalTree;

using static Tests.Chapter4.TestUtilities;

namespace Tests.Chapter4
{
    public class Q4_2
    {

        [FactAttribute]
        private void minimalTreeEvenTest()
        {
            const int size = 8;

            int[] result = new int[size] { 7, 3, 1, 5, 11, 9, 13, 15 };

            int[] array = buildSortedArray(size);
            TreeBinaryNode<int> tree = MinimalTree(array);

            checkValues(result, tree);
        }

        [FactAttribute]
        private void minimalTreeOddTest()
        {
            const int size = 5;
            int[] result = new int[size] { 5, 1, 3, 7, 9 };

            int[] array = buildSortedArray(5);
            TreeBinaryNode<int> tree = MinimalTree(array);

            checkValues(result, tree);
        }

        [FactAttribute]
        private void minimalTreeEmptyTest()
        {
            TreeBinaryNode<int> tree = MinimalTree(new int[] { });
            Assert.Null(tree);
        }

        [FactAttribute]
        private void minimalTreeNullTest()
        {
            TreeBinaryNode<int> tree = MinimalTree(null);
            Assert.Null(tree);
        }

        private int[] buildSortedArray(int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
                array[i] = i * 2 + 1;

            return array;
        }
    }
}