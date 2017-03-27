using Xunit;

using Chapter4;
using static Chapter4.Utilities;
using Type = Chapter4.Utilities.TypeTraversal;

namespace Tests.Chapter4
{
    public static class TestUtilities
    {
        /// <summary>
        /// Determine if the values of a TreeBinaryNode are the same as the values provided.</summary>
        /// <param name="result"> Array of values to check.</param>
        /// <param name="tree"> TreeBinaryNode to check.</param>
        /// <param name="type"> Specify how to visit the TreeBinaryNode.</param>
        public static void checkValues<T>(T[] result, TreeBinaryNode<T> tree, Type type = Type.preOrder)
        {
            Traversal<T> t = new Traversal<T>(type, tree);
            Assert.True(t.EqualsToArray(result));
        }
    }
}