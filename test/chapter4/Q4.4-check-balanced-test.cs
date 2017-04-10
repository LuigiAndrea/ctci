using Xunit;

using Chapter4;
using static Tests.Chapter4.TestUtilities;
using cb = Chapter4.Q4_4CheckBalanced<int>;
using cbTweak = Chapter4.Q4_4CheckBalancedTweak<int>;

namespace Tests.Chapter4
{
    public class Q4_4
    {
        [FactAttribute]
        private void checkBalancedTest()
        {
            TreeBinaryNode<int> tree = createNumericBalancedTree(15); //Differ by 0
            TreeBinaryNode<int> tree2 = createNumericBalancedTree(13); //Differ by 1
            TreeBinaryNode<int> tree3 = new TreeBinaryNode<int>(100, tree, new TreeBinaryNode<int>(700));
            TreeBinaryNode<int> tree4 = new TreeBinaryNode<int>(1);

            //Without Tweaks
            Assert.True(cb.isBalanced(tree));
            Assert.True(cb.isBalanced(tree2));
            Assert.False(cb.isBalanced(tree3));
            Assert.True(cb.isBalanced(tree4));

            //With Tweaks
            Assert.True(cbTweak.isBalanced(tree));
            Assert.True(cbTweak.isBalanced(tree2));
            Assert.False(cbTweak.isBalanced(tree3));
            Assert.True(cbTweak.isBalanced(tree4));
        }

        [FactAttribute]
        private void checkBalancedNullTest()
        {
            Assert.True(cb.isBalanced(null));
            Assert.True(cbTweak.isBalanced(null));
        }
    }
}