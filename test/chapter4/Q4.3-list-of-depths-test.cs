using System.Collections.Generic;

using Xunit;

using Chapter4;
using static Chapter4.Q4_3ListOfDepths;
using static Chapter4.Q4_2MinimalTree;

namespace Tests.Chapter4
{
    public class Q4_3
    {
        [FactAttribute]
        private void ListOfDepthsTest()
        {
            TreeBinaryNode<int> tree = createTree();
            List<LinkedList<TreeBinaryNode<int>>> l = getListOfDepths<int>(tree) ?? new List<LinkedList<TreeBinaryNode<int>>>();
            int[][] result = {
                new int[1]{5},
                new int[2]{2,8},
                new int[4]{0,3,6,9},
                new int[4]{1,4,7,10}
            };

            for (int i = 0; i < l.Count; i++)
            {
                int j = 0;
                foreach (TreeBinaryNode<int> linkedListNode in l[i])
                {
                    Assert.True(linkedListNode.value.Equals(result[i][j++]));
                }
            }
        }

        [FactAttribute]
        private void ListOfDepthsNullTest()
        {
            List<LinkedList<TreeBinaryNode<int>>> list = getListOfDepths<int>(null);
            Assert.True(list.Count.Equals(0));
        }

        private TreeBinaryNode<int> createTree()
        {
            const int size = 11;
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = i;
            }

            return MinimalTree(array);
        }
    }
}