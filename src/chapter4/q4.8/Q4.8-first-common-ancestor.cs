using System;
using System.Collections.Generic;

namespace Chapter4
{
    public static class Q4_8FirstCommonAncestor<T>
    {
        public static TreeBinaryParentNode<T> commonAncestor(TreeBinaryParentNode<T> firstNode, TreeBinaryParentNode<T> secondNode)
        {
            int diff = getDepth(firstNode) - getDepth(secondNode);
            TreeBinaryParentNode<T> deepNode = diff > 0 ? firstNode : secondNode;
            TreeBinaryParentNode<T> swallowNode = diff > 0 ? secondNode : firstNode;

            deepNode = goingUp(deepNode, Math.Abs(diff));

            if(deepNode == swallowNode)
                return swallowNode.parent;

            while(swallowNode !=null && deepNode!= swallowNode){
                deepNode = deepNode.parent;
                swallowNode = swallowNode.parent;
            }

            return (swallowNode == null) ? null : swallowNode;
        }

        private static int getDepth(TreeBinaryParentNode<T> node)
        {
            int depth = 0;
            while (node.parent != null)
            {
                node = node.parent;
                depth++;
            }

            return depth;
        }

        private static TreeBinaryParentNode<T> goingUp(TreeBinaryParentNode<T> node, int diff)
        {
            while (diff > 0)
            {
                node = node.parent;
                diff--;
            }

            return node;
        }
    }
}
