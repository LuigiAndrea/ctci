using System;
using System.Collections.Generic;

namespace Chapter4
{
    public static class Q4_8FirstCommonAncestor
    {
        public static TreeBinaryParentNode<int> commonAncestor(TreeBinaryParentNode<int> firstNode, TreeBinaryParentNode<int> secondNode)
        {
            int diff = getDepth(firstNode) - getDepth(secondNode);
            TreeBinaryParentNode<int> deepNode = diff > 0 ? firstNode : secondNode;
            TreeBinaryParentNode<int> swallowNode = diff > 0 ? secondNode : firstNode;

            deepNode = goingUp(deepNode, Math.Abs(diff));

            if(deepNode.value == swallowNode.value)
                return swallowNode.parent;

            while(swallowNode !=null && deepNode.value != swallowNode.value){
                deepNode = deepNode.parent;
                swallowNode = swallowNode.parent;
            }

            return (swallowNode == null) ? null : swallowNode;
        }

        private static int getDepth(TreeBinaryParentNode<int> node)
        {
            int depth = 0;
            while (node.parent != null)
            {
                node = node.parent;
                depth++;
            }

            return depth;
        }

        private static TreeBinaryParentNode<int> goingUp(TreeBinaryParentNode<int> node, int diff)
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
