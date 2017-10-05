using System.Collections.Generic;

using Xunit;

using static Chapter4.Utilities;
using Chapter4;

namespace Tests.Chapter4
{
    public class Q4_3
    {
        [FactAttribute]
        private void ListOfDepthsTest()
        {
            TreeBinaryNode<int> tree = createNumericBalancedTree(11);
            List<LinkedList<TreeBinaryNode<int>>> l = Q4_3ListOfDepths.getListOfDepths<int>(tree);
            List<LinkedList<TreeBinaryNode<int>>> l2 = Q4_3ListOfDepthsIterative.getListOfDepths<int>(tree);
            int[][] result = {
                new int[1]{5},
                new int[2]{2,8},
                new int[4]{0,3,6,9},
                new int[4]{1,4,7,10}
            };

            checkValues(l, result);
            checkValues(l2, result);
        }

        [FactAttribute]
        private void ListOfDepthsNullTest()
        {
            List<LinkedList<TreeBinaryNode<int>>> list = Q4_3ListOfDepths.getListOfDepths<int>(null);
            Assert.True(list.Count.Equals(0));
            List<LinkedList<TreeBinaryNode<int>>> list2 = Q4_3ListOfDepthsIterative.getListOfDepths<int>(null);
            Assert.True(list2.Count.Equals(0));
        }

        private void checkValues<T>(List<LinkedList<TreeBinaryNode<T>>> l, T[][] result)
        {
            for (int i = 0; i < l.Count; i++)
            {
                int j = 0;
                foreach (TreeBinaryNode<T> linkedListNode in l[i])
                {
                    Assert.True(linkedListNode.value.Equals(result[i][j++]));
                }
            }
        }
    }
}