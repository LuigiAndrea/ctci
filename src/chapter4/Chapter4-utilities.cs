using static System.Console;

namespace Chapter4
{
    public static class Utilities
    {
        public static void inOrderTraversal(TreeBinaryNode<int> node)
        {
            if (node != null)
            {
                inOrderTraversal(node.left);
                WriteLine(node.value);
                inOrderTraversal(node.right);
            }
        }

        public static void preOrderTraversal(TreeBinaryNode<int> node)
        {
            if (node != null)
            {
                WriteLine(node.value);
                preOrderTraversal(node.left);
                preOrderTraversal(node.right);
            }
        }

        public static void postOrderTraversal(TreeBinaryNode<int> node)
        {
            if (node != null)
            {
                postOrderTraversal(node.left);
                postOrderTraversal(node.right);
                WriteLine(node.value);
            }
        }
    }
}