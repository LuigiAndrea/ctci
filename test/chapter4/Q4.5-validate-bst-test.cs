using Xunit;

using Chapter4;
using static Chapter4.Utilities;
using bst = Chapter4.Q4_5ValidateBST;
using bst2 = Chapter4.Q4_5ValidateBST2;
using bst3 = Chapter4.Q4_5ValidateBST3;
using System;

namespace Tests.Chapter4
{
    public class Q4_5
    {
        [FactAttribute]
        private void validateBSTTest()
        {
            Func<TreeBinaryNode<int>, bool>[] funcToRun = new Func<TreeBinaryNode<int>, bool>[]{
                bst.IsBST,bst2.IsBST,bst3.IsBST
            };

            TreeBinaryNode<int> tree = CreateBinarySearchTree<TreeBinaryNode<int>>(13);
            TreeBinaryNode<int> tree2 = new TreeBinaryNode<int>(13, null, tree.right);

            foreach (var f in funcToRun)
            {
                Assert.True(f(tree));
                Assert.False(f(tree2));
                Assert.True(f(null));
            }
        }
    }
}
