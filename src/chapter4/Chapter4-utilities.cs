using System.Collections.Generic;

namespace Chapter4
{
    public static class Utilities
    {
        public static class Traversal<T>
        {
            public enum typeTraversal { preOrder, inOrder, postOrder }
            static List<T> listOrder = new List<T>();

            public static List<T> getTraversalList(typeTraversal type, TreeBinaryNode<T> t)
            {
                clearList();
                switch ((int)type)
                {
                    case 0:
                        preOrderTraversal(t);
                        break;
                    case 1:
                        inOrderTraversal(t);
                        break;
                    case 2:
                        postOrderTraversal(t);
                        break;
                }

                return listOrder;
            }
            private static void inOrderTraversal(TreeBinaryNode<T> node)
            {
                if (node != null)
                {
                    inOrderTraversal(node.left);
                    listOrder.Add(node.value);
                    inOrderTraversal(node.right);
                }
            }

            private static void preOrderTraversal(TreeBinaryNode<T> node)
            {
                if (node != null)
                {
                    listOrder.Add(node.value);
                    preOrderTraversal(node.left);
                    preOrderTraversal(node.right);
                }
            }

            private static void postOrderTraversal(TreeBinaryNode<T> node)
            {
                if (node != null)
                {
                    postOrderTraversal(node.left);
                    postOrderTraversal(node.right);
                    listOrder.Add(node.value);
                }
            }

            private static void clearList()
            {
                listOrder.Clear();
            }
        }
    }
}