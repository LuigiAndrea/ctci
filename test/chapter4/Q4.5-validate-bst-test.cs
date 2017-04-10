using Xunit;

using Chapter4;
using static Tests.Chapter4.TestUtilities;
using bst = Chapter4.Q4_5ValidateBST;
using bst2 = Chapter4.Q4_5ValidateBST2;

namespace Tests.Chapter4
{
    public class Q4_5
    {
        [FactAttribute]
        private void validateBSTTest()
        {
            TreeBinaryNode<int> tree = createNumericBalancedTree(13);
            TreeBinaryNode<int> tree2 = new TreeBinaryNode<int>(13, null, tree.right);

            Assert.True(bst.isBST(tree));
            Assert.True(bst2.isBST(tree));

            Assert.False(bst.isBST(tree2));
            Assert.False(bst2.isBST(tree2));
        }

        [FactAttribute]
        private void validateBSTNullTest()
        {
            Assert.True(bst.isBST(null));
            Assert.True(bst2.isBST(null));
        }
    }
}