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
            TreeBinaryParentNode<int> tree = BuildParentTree.MinimalParentTree(array);
            TreeBinaryParentNode<int> child = (TreeBinaryParentNode<int>)tree.right.right;

            Assert.Equal(child.parent.value,4);
            Assert.Equal(tree.left.value,1);
            Assert.Null(tree.left.left);
            Assert.Null(child.parent.left);
            Assert.Equal(child.parent.right.value,14);
        }
    }
}
