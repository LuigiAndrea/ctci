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
            int[] result = new int[6] { 3, 7, 2, 5, 9, 23 };
            checkValues(result, _fixture.tree.tbn, Type.preOrder);
        }

        [FactAttribute]
        private void Chapter4InOrderTest()
        {
            int[] result = new int[6] { 2, 7, 5, 3, 9, 23 };
            checkValues(result, _fixture.tree.tbn, Type.inOrder);
        }

        [FactAttribute]
        private void Chapter4PostOrderTest()
        {
            int[] result = new int[6] { 2, 5, 7, 23, 9, 3 };
            checkValues(result, _fixture.tree.tbn, Type.postOrder);

        }

        [FactAttribute]
        private void Chapter4EmptyAndNullTest()
        {
            checkValues(new int[] { }, null);
            Assert.Empty(new Traversal<int>(Type.preOrder, null).getTraversalList());
        }

        [FactAttribute]
        private void Chapter4CharTest()
        {
            char[] result = new char[4] { 'R', 's', 'f', 'A' };
            checkValues(result, _fixture.tree.charTree);
        }

        [FactAttribute]
        private void Chapter4getDepthTest()
        {
            Assert.True(getDepth(_fixture.tree.tbn).Equals(2));
            Assert.True(getDepth(_fixture.tree.charTree).Equals(2));
            Assert.True(getDepth(new TreeBinaryNode<int>(5)).Equals(0));
            Assert.True(getDepth<int>(null).Equals(-1));
        }
    }
}