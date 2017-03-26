using System.Collections.Generic;

namespace Chapter4
{
    public static class Utilities
    {
        public class Traversal<T>
        {
            public enum typeTraversal { preOrder, inOrder, postOrder }
            List<T> listOrder = new List<T>();

            public Traversal(typeTraversal type, TreeBinaryNode<T> t)
            {
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
            }

            public List<T> getTraversalList()
            {
                return this.listOrder;
            }
            private void inOrderTraversal(TreeBinaryNode<T> node)
            {
                if (node != null)
                {
                    inOrderTraversal(node.left);
                    this.listOrder.Add(node.value);
                    inOrderTraversal(node.right);
                }
            }

            private void preOrderTraversal(TreeBinaryNode<T> node)
            {
                if (node != null)
                {
                    this.listOrder.Add(node.value);
                    preOrderTraversal(node.left);
                    preOrderTraversal(node.right);
                }
            }

            private void postOrderTraversal(TreeBinaryNode<T> node)
            {
                if (node != null)
                {
                    postOrderTraversal(node.left);
                    postOrderTraversal(node.right);
                    this.listOrder.Add(node.value);
                }
            }

            public bool EqualsToArray(int[] result)
            {
                if (result==null || result.Length != this.listOrder.Count)
                    return false;
                for (int i = 0; i < this.listOrder.Count; i++)
                    if (!this.listOrder[i].Equals(result[i]))
                        return false;

                return true;
            }
        }
    }
}