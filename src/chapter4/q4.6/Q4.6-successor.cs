
namespace Chapter4
{
    public static class Q4_6Successor<T>
    {
        public static TreeBinaryParentNode<T> successor(TreeBinaryParentNode<T> node)
        {
            TreeBinaryParentNode<T> succ = null;

            if(node==null)
                return null;

            if (node.right != null)
            {
                succ = leftMostChild(node.right, null);
            }
            else
            {
                succ = goingUp(node);
            }

            return succ;
        }

        private static TreeBinaryParentNode<T> leftMostChild(TreeBinaryNode<T> node, TreeBinaryNode<T> lastNode)
        {
            TreeBinaryParentNode<T> lmc = null;
            if (node != null)
            {
                lmc = leftMostChild(node.left, node);
            }
            else
            {
                lmc = (TreeBinaryParentNode<T>)lastNode;
            }

            return lmc;
        }

        private static TreeBinaryParentNode<T> goingUp(TreeBinaryParentNode<T> node)
        {
            TreeBinaryParentNode<T> parent = node.parent;
            if (parent == null)
            {
                return null;
            }

            //while n right child of a n.parent
            TreeBinaryParentNode<T> succ = null;
            if (parent.right == node)
                succ = goingUp(parent);
            else
                succ = parent;

            return succ;
        }
    }
}