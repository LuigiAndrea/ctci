using Xunit;

using Chapter4;
using static Chapter4.Q4_8FirstCommonAncestorWithoutLinkParent<int>;
using static Chapter4.Utilities;
using System;

namespace Tests.Chapter4
{
    public class Q4_8WithoutLinkParent
    {
        static int[] array = new int[10] { 1, 5, 12, 4, 14, 28, 33, 3, 9, 19 };
        static TreeBinaryNode<int> tree = CreateBinaryTree<TreeBinaryNode<int>,int>(array);

        [FactAttribute]
        private void FCASameLevelWithoutLinkParentTest()
        {
            TreeBinaryNode<int> firstNode = tree.right.right;
            TreeBinaryNode<int> secondNode = tree.left.right;

            TreeBinaryNode<int> ancestor = commonAncestorWithoutLinkParent(tree, firstNode, secondNode);

            Assert.Equal(tree, ancestor);
        }

        [FactAttribute]
        private void FCADifferentLevelWithoutLinkParentTest()
        {
            TreeBinaryNode<int> firstNode = tree.right;
            TreeBinaryNode<int> secondNode = tree.right.right.right;

            TreeBinaryNode<int> ancestor = commonAncestorWithoutLinkParent(tree, firstNode, secondNode);

            Assert.Equal(tree.right, ancestor);
        }

        [FactAttribute]
        private void FCADDescendantOfItselfWithoutLinkParentTest()
        {
            TreeBinaryNode<int> firstNode = tree.right;
            TreeBinaryNode<int> secondtNode = tree.right;
            TreeBinaryNode<int> ancestor = commonAncestorWithoutLinkParent(tree, firstNode, secondtNode);
            Assert.Equal(tree.right, ancestor);
        }

        [FactAttribute]
        private void FCANodeOfAnotherTreeWithoutLinkParentTest()
        {
            TreeBinaryNode<int> tree2 = CreateBinaryTree<TreeBinaryNode<int>,int>(new int[5] { 1, 1, 2, 3, 0 });

            TreeBinaryNode<int> firstNode = tree.right;
            TreeBinaryNode<int> secondtNode = tree2.left;
            TreeBinaryNode<int> ancestor = commonAncestorWithoutLinkParent(tree, firstNode, secondtNode);
            Assert.Null(ancestor);
        }

        [FactAttribute]
        private void FCARootWithoutLinkParentTest()
        {
            TreeBinaryNode<int> ancestor = commonAncestorWithoutLinkParent(tree, tree, tree);
            Assert.Equal(tree, ancestor);
        }


        [FactAttribute]
        private void FCANullValuesWithoutLinkParentTest()
        {
            TreeBinaryNode<int> ancestor = commonAncestorWithoutLinkParent(tree, null, null);
            Assert.Null(ancestor);
        }
    }
}
