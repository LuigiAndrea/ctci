using System;
using System.Collections.Generic;

namespace Chapter4
{
    public static class Q4_8FirstCommonAncestorWithoutLinkParent<T>
    {
        public static TreeBinaryNode<T> commonAncestorWithoutLinkParent(TreeBinaryNode<T> root, TreeBinaryNode<T> firstNode, TreeBinaryNode<T> secondNode)
        {
            if (!cover(root, firstNode) || !cover(root, secondNode))
                return null;

            return commonAncestor(root, firstNode, secondNode);
        }
        private static TreeBinaryNode<T> commonAncestor(TreeBinaryNode<T> root, TreeBinaryNode<T> firstNode, TreeBinaryNode<T> secondNode)
        {
            if (root == firstNode || root == secondNode)
                return root;

            bool firstNodeIsOnLeft = cover(root.left, firstNode);
            bool secondNodeIsOnLeft = cover(root.left, secondNode);

            if (firstNodeIsOnLeft != secondNodeIsOnLeft)
                return root;

            TreeBinaryNode<T> succNode = firstNodeIsOnLeft ? root.left: root.right;
            
            return commonAncestorWithoutLinkParent(succNode, firstNode, secondNode);
        }

        private static bool cover(TreeBinaryNode<T> root, TreeBinaryNode<T> node)
        {
            if (root == null)
                return false;
            if (root == node)
                return true;

            return cover(root.left, node) || cover(root.right, node);
        }
    }
}
