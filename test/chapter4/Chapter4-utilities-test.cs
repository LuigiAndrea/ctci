using Xunit;

using Chapter4;
using static Chapter4.Utilities;
using type = Chapter4.Utilities.Traversal<int>.typeTraversal;

namespace Tests.Chapter4
{
    public class Chapter4UtilitiesTest
    {
        TreeBinaryNode<int> tbn;
        Traversal<int> t;

        public Chapter4UtilitiesTest()
        {
            createTree();
        }

        [FactAttribute]
        private void Chapter4PreOrderTest()
        {
            int[] result = new int[6] { 3, 7, 2, 5, 9, 23 };
            t = new Traversal<int>(type.preOrder, tbn);
            Assert.True(t.EqualsToArray(result));
        }

        [FactAttribute]
        private void Chapter4InOrderTest()
        {
            int[] result = new int[6] { 2, 7, 5, 3, 9, 23 };
            t = new Traversal<int>(type.inOrder, tbn);
            Assert.True(t.EqualsToArray(result));
        }

        [FactAttribute]
        private void Chapter4PostOrderTest()
        {
            int[] result = new int[6] { 2, 5, 7, 23, 9, 3 };
            t = new Traversal<int>(type.postOrder, tbn);
            Assert.True(t.EqualsToArray(result));
        }

        [FactAttribute]
        private void Chapter4NullTest()
        {
            t = new Traversal<int>(type.preOrder, null);
            Assert.False(t.EqualsToArray(null));
            Assert.Empty(t.getTraversalList());
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
    }
}