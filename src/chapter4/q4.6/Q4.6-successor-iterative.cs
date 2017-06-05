
namespace Chapter4
{
    public static class Q4_6SuccessorIterative<T>
    {
        public static TreeBinaryParentNode<T> successorIt(TreeBinaryParentNode<T> node)
        {
            TreeBinaryParentNode<T> succ = null;

            if (node == null)
                return null;

            if (node.right != null)
            {
                node = (TreeBinaryParentNode<T>)node.right;
                while (node.left != null)
                {
                    node = (TreeBinaryParentNode<T>)node.left;
                }

                succ = node;
            }
            else
            {
                while (node.parent?.right == node)
                {
                    node = node.parent;
                }
                succ = node.parent;
            }

            return succ;
        }
    }
}