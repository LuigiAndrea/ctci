using Xunit;

using Chapter4;
using static Chapter4.Utilities;

namespace Tests.Chapter4
{
    public class TreeBinaryParentNodeTest
    {
        [FactAttribute]
        private static void TreeBinaryParentNodeBuildingTest()
        {
            int[] array = new int[5] { 1, 5, 12, 4, 14 };
            TreeBinaryParentNode<int> tree = CreateBinaryTree<TreeBinaryParentNode<int>,int>(array);
            TreeBinaryParentNode<int> child = (TreeBinaryParentNode<int>)tree.right.right;

            Assert.Equal(4,child.parent.value);
            Assert.Equal(1,tree.left.value);
            Assert.Null(tree.left.left);
            Assert.Null(child.parent.left);
            Assert.Equal(14,child.parent.right.value);
        }
    }
}
