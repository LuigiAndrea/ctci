using Xunit;

using Chapter4;
using static Chapter4.Q4_6Successor<int>;
using static Chapter4.Q4_6SuccessorIterative<int>;
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

            TreeBinaryParentNode<int> sIt = successorIt(n.parent);
            Assert.Equal(12, sIt.value);
            Assert.Equal(n, sIt);

            TreeBinaryParentNode<int> sn = successor(n);
            Assert.Equal(4, sn.value);
            Assert.Equal(sn, tree);

            TreeBinaryParentNode<int> snIt = successorIt(n);
            Assert.Equal(4, snIt.value);
            Assert.Equal(snIt, tree);

            TreeBinaryParentNode<int> lastNode = (TreeBinaryParentNode<int>)tree.right.right;
            Assert.Null(successor(lastNode));
            Assert.Null(successor(null));

            Assert.Null(successorIt(lastNode));
            Assert.Null(successorIt(null));
        }
    }
}