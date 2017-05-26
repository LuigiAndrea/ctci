using Xunit;

using Chapter4;
using static Chapter4.Q4_6Successor<int>;
using static Tests.Chapter4.TestUtilities;

namespace Tests.Chapter4
{
    public class Q4_6
    {
        [FactAttribute]
        private static void TreeBinaryParentNodeBuildingTest()
        {
            int[] array = new int[7] { 1, 5, 12, 4, 14, 28, 33 };          

            TreeBinaryParentNode<int> tree = buildParentTree.MinimalParentTree(array);
            TreeBinaryParentNode<int> n = (TreeBinaryParentNode<int>)tree.left.right;

            TreeBinaryParentNode<int> s = successor(n.parent);
            Assert.Equal(12, s.value);
            Assert.Equal(n, s);

            TreeBinaryParentNode<int> sn = successor(n);
            Assert.Equal(4, sn.value);
            Assert.Equal(sn, tree);
            
            Assert.Null(successor((TreeBinaryParentNode<int>)tree.right.right));
            Assert.Null(successor(null));
        }
    }
}