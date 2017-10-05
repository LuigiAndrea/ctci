using Xunit;

using Chapter4;
using static Chapter4.Q4_8FirstCommonAncestor<int>;
using static Chapter4.Utilities;
using System;

namespace Tests.Chapter4
{
    public class Q4_8
    {
        static int[] array = new int[10] { 1, 5, 12, 4, 14, 28, 33, 3, 9, 19 };
        static TreeBinaryParentNode<int> tree = BuildParentTree.MinimalParentTree(array);

        [FactAttribute]
        private void FCASameLevelTest()
        {
            TreeBinaryParentNode<int> firstNode = (TreeBinaryParentNode<int>)tree.right.right;
            TreeBinaryParentNode<int> secondNode = (TreeBinaryParentNode<int>)tree.left.right;

            TreeBinaryParentNode<int> ancestor = commonAncestor(firstNode, secondNode);

            Assert.Equal(tree, ancestor);
        }

        [FactAttribute]
        private void FCADifferentLevelTest()
        {
            TreeBinaryParentNode<int> firstNode = (TreeBinaryParentNode<int>)tree.right;
            TreeBinaryParentNode<int> secondNode = (TreeBinaryParentNode<int>)tree.right.right.right;

            TreeBinaryParentNode<int> ancestor = commonAncestor(firstNode, secondNode);

            Assert.Equal(tree.right, ancestor);
        }

        [FactAttribute]
        private void FCADDescendantOfItselfTest()
        {
            TreeBinaryParentNode<int> firstNode = (TreeBinaryParentNode<int>)tree.right;
            TreeBinaryParentNode<int> secondtNode = (TreeBinaryParentNode<int>)tree.right;
            TreeBinaryParentNode<int> ancestor = commonAncestor(firstNode, secondtNode);
            Assert.Equal(tree.right, ancestor);
        }

        [FactAttribute]
        private void FCANodeOfAnotherTreeTest()
        {
            TreeBinaryParentNode<int> tree2 = BuildParentTree.MinimalParentTree(new int[5] { 1,1,2,3,0 });

            TreeBinaryParentNode<int> firstNode = (TreeBinaryParentNode<int>)tree.right;
            TreeBinaryParentNode<int> secondtNode = (TreeBinaryParentNode<int>)tree2.left;
            TreeBinaryParentNode<int> ancestor = commonAncestor(firstNode, secondtNode);
            Assert.Equal(null, ancestor);
        }

         [FactAttribute]
        private void FCARootTest()
        {
            TreeBinaryParentNode<int> ancestor = commonAncestor(tree, tree);
            Assert.Equal(tree, ancestor);
        }


        [FactAttribute]
        private void FCAExceptionsTest()
        {
            Exception actualException = Record.Exception(() => commonAncestor(null, null));
            Assert.IsType<ArgumentNullException>(actualException);
        }
    }
}
