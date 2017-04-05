using System;

namespace Chapter4
{
    public static class Q4_4CheckBalancedTweak<T>
    {
        public static bool isBalanced(TreeBinaryNode<T> tree)
        {
            return checkDepth(tree) != Int32.MinValue;
        }
        private static int checkDepth(TreeBinaryNode<T> node)
        {
            if (node == null)
                return -1;

            int leftDepth = checkDepth(node.left);
            if (leftDepth == Int32.MinValue)
                return Int32.MinValue;

            int rightDepth = checkDepth(node.right);
            if (rightDepth == Int32.MinValue)
                return Int32.MinValue;

            if (Math.Abs(leftDepth - rightDepth) > 1)
                return Int32.MinValue;
            else
                return Math.Max(leftDepth, rightDepth) + 1;
        }
    }
}