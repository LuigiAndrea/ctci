using Xunit;

using Chapter4;
using static Chapter4.Utilities;
using Type = Chapter4.Utilities.TypeTraversal;

using static Tests.Chapter4.TestUtilities;

namespace Tests.Chapter4
{
    public class Chapter4UtilitiesTest
    {
        TreeBinaryNode<int> tbn;
        TreeBinaryNode<char> charTree;

        public Chapter4UtilitiesTest()
        {
            createTree();
            createCharTree();
        }

        [FactAttribute]
        private void Chapter4PreOrderTest()
        {
            int[] result = new int[6] { 3, 7, 2, 5, 9, 23 };
            checkValues(result, tbn, Type.preOrder);
        }

        [FactAttribute]
        private void Chapter4InOrderTest()
        {
            int[] result = new int[6] { 2, 7, 5, 3, 9, 23 };
            checkValues(result, tbn, Type.inOrder);
        }

        [FactAttribute]
        private void Chapter4PostOrderTest()
        {
            int[] result = new int[6] { 2, 5, 7, 23, 9, 3 };
            checkValues(result, tbn, Type.postOrder);
        }

        [FactAttribute]
        private void Chapter4EmptyAndNullTest()
        {
            checkValues(new int[] { }, null);
            Assert.Empty(new Traversal<int>(Type.preOrder, null).getTraversalList());
        }

        [FactAttribute]
        private void Chapter4CharTest()
        {
            char[] result = new char[4] { 'R', 's', 'f', 'A' };
            checkValues(result, charTree);
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

        private void createCharTree()
        {
            TreeBinaryNode<char> tl = new TreeBinaryNode<char>('s');
            TreeBinaryNode<char> tr = new TreeBinaryNode<char>('A');
            charTree = new TreeBinaryNode<char>('R', tl, tr);
            tl.left = new TreeBinaryNode<char>('f');
        }
    }
}