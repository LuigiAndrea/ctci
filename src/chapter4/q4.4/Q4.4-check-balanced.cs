using System;
using static Chapter4.Utilities;

namespace Chapter4
{
    public static class Q4_4CheckBalanced<T>
    {
        public static bool isBalanced(TreeBinaryNode<T> tree)
        {
            if (tree == null)
                return true;

            int diff = getDepth(tree.left) - getDepth(tree.right);
            if (Math.Abs(diff) > 1)
                return false;
            else
                return isBalanced(tree.left) && isBalanced(tree.right);
        }
    }
}