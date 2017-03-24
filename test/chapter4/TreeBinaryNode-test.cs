using Xunit;

using Chapter4;

namespace Tests.Chapter4
{
    public class TreeBinaryNodeTests
    {
        [FactAttribute]
        private static void TreeBinaryNodeTest()
        {
            TreeBinaryNode<int> tbn = new TreeBinaryNode<int>(6);
            TreeBinaryNode<int> left = new TreeBinaryNode<int>(61);
            tbn.left = new TreeBinaryNode<int>(61);
            tbn.right = new TreeBinaryNode<int>(43);

            Assert.True(tbn.value.Equals(6));
            Assert.True(tbn.left.right == null);
            Assert.True(tbn.right.value.Equals(43));
        }

        [FactAttribute]
        private static void TreeBinaryNodeDifferentConstructorTest()
        {
            TreeBinaryNode<int> tbn = new TreeBinaryNode<int>(1, new TreeBinaryNode<int>(2), new TreeBinaryNode<int>(3));

            Assert.True(tbn.value.Equals(1));
            Assert.True(tbn.left.value.Equals(2));
            Assert.True(tbn.right.value.Equals(3));

            TreeBinaryNode<int> leftNode = tbn.left;
            leftNode.left = new TreeBinaryNode<int>(4);
            Assert.True(leftNode.left.value.Equals(4));
            Assert.True(tbn.left.right == null);
        }
    }
}