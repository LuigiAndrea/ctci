using Xunit;

using Chapter4;
using static Chapter4.Utilities;
using bst = Chapter4.Q4_5ValidateBST;
using bst2 = Chapter4.Q4_5ValidateBST2;

namespace Tests.Chapter4
{
    public class Q4_5
    {
        [FactAttribute]
        private void validateBSTTest()
        {
            TreeBinaryNode<int> tree = CreateBinarySearchTree<TreeBinaryNode<int>>(13);
            TreeBinaryNode<int> tree2 = new TreeBinaryNode<int>(13, null, tree.right);

            Assert.True(bst.IsBST(tree));
            Assert.True(bst2.IsBST(tree));

            Assert.False(bst.IsBST(tree2));
            Assert.False(bst2.IsBST(tree2));
        }

        [FactAttribute]
        private void validateBSTNullTest()
        {
            Assert.True(bst.IsBST(null));
            Assert.True(bst2.IsBST(null));
        }
    }
}