using System;
using Xunit;

using Chapter4;
using static Chapter4.Utilities;
using Type = Chapter4.Utilities.TypeTraversal;

using static Tests.Chapter4.TestUtilities;

namespace Tests.Chapter4
{
    public class Chapter4UtilitiesTestFixture : IDisposable
    {
        public Tree tree { get; private set; }
        public Chapter4UtilitiesTestFixture()
        {
            tree = new Tree();
        }

        public void Dispose()
        {
            tree.Dispose();
        }

    }
    public class Chapter4UtilitiesTest : IClassFixture<Chapter4UtilitiesTestFixture>
    {
        private readonly Chapter4UtilitiesTestFixture _fixture;

        public Chapter4UtilitiesTest(Chapter4UtilitiesTestFixture fixture)
        {
            _fixture = fixture;

        }

        [FactAttribute]
        private void Chapter4PreOrderTest()
        {
            int[] result = new int[6] { 3, 7, 2, 9, 5, 23 };
            checkValues(result, _fixture.tree.NumericTree, Type.preOrder);
        }

        [FactAttribute]
        private void Chapter4InOrderTest()
        {
            int[] result = new int[6] { 7, 2, 3, 5, 9, 23 };
            checkValues(result, _fixture.tree.NumericTree, Type.inOrder);
        }

        [FactAttribute]
        private void Chapter4PostOrderTest()
        {
            int[] result = new int[6] { 2, 7, 5, 23, 9, 3 };
            checkValues(result, _fixture.tree.NumericTree, Type.postOrder);

        }

        [FactAttribute]
        private void Chapter4EmptyAndNullTraversalTest()
        {
            checkValues(new int[] { }, null);
            Assert.Empty(new Traversal<int>(Type.preOrder, null).getTraversalList());
        }

        [FactAttribute]
        private void Chapter4getDepthTest()
        {
            Assert.True(getDepth(_fixture.tree.NumericTree).Equals(2));
            Assert.True(getDepth(_fixture.tree.CharTree).Equals(2));
            Assert.True(getDepth(new TreeBinaryNode<int>(5)).Equals(0));
            Assert.True(getDepth<int>(null).Equals(-1));
        }


        [FactAttribute]
        private void Chapter4createBinaryTree()
        {
            Assert.Equal(typeof(TreeBinaryNode<int>), _fixture.tree.NumericTree.GetType());
            Assert.Equal(typeof(TreeBinaryParentNode<int>), _fixture.tree.ParentTree.GetType());
        }

        [FactAttribute]
        private void Chapter4CreateBinarySearchTreeTree()
        {
            Assert.Equal(typeof(TreeBinaryNode<int>), _fixture.tree.SearchTree.GetType());
            Assert.Equal(typeof(TreeBinaryParentNode<int>), _fixture.tree.SearchParentTree.GetType());
        }
    }
}
