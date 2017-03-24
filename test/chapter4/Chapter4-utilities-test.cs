using Xunit;
using System.Collections.Generic;

using t = Chapter4.Utilities.Traversal<int>;
using Chapter4;

namespace Tests.Chapter4
{
    public class Chapter4UtilitiesTest
    {
        TreeBinaryNode<int> tbn;

        public Chapter4UtilitiesTest()
        {
            createTree();
        }

        [FactAttribute]
        private void Chapter4PreOrderTest()
        {
            int[] result = new int[6] { 3, 7, 2, 5, 9, 23 };
            List<int> list = t.getTraversalList(t.typeTraversal.preOrder, tbn);
            checkTree(list, result);
        }

        [FactAttribute]
        private void Chapter4InOrderTest()
        {
            int[] result = new int[6] { 2, 7, 5, 3, 9, 23 };
            List<int> list = t.getTraversalList(t.typeTraversal.inOrder, tbn);
            checkTree(list, result);
        }

        [FactAttribute]
        private void Chapter4PostOrderTest()
        {
            int[] result = new int[6] { 2, 5, 7, 23, 9, 3 };
            List<int> list = t.getTraversalList(t.typeTraversal.postOrder, tbn);
            checkTree(list, result);
        }

        private void createTree()
        {
            TreeBinaryNode<int> tl = new TreeBinaryNode<int>(7);
            TreeBinaryNode<int> tr = new TreeBinaryNode<int>(9);
            tbn = new TreeBinaryNode<int>(3, tl, tr);
            tl.left = new TreeBinaryNode<int>(2);
            tl.right = new TreeBinaryNode<int>(5);
            tr.right = new TreeBinaryNode<int>(23);
        }

        private void checkTree(List<int> list, int[] result)
        {
            for (int i = 0; i < list.Count; i++)
                Assert.True(list[i].Equals(result[i]));
        }
    }
}