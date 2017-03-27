using System.Collections.Generic;

namespace Chapter4
{
    public static class Utilities
    {
        /// <summary>
        /// Let visit and store the nodes of a TreeBinaryNode in three different approaches.
        ///</summary>
        public enum TypeTraversal { preOrder, inOrder, postOrder }
        public class Traversal<T>
        {
            List<T> listOrder = new List<T>();

            public Traversal(TypeTraversal type, TreeBinaryNode<T> t)
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

            /// <returns>Return a list of TreeBinaryNode's values as they are visited</returns>
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

            /// <summary>
            /// Determine if the values of this instance of TreeBinaryNode are the same as the values provided.
            ///</summary>
            /// <param name="result"> Array of values to compare.</param>
            /// <returns>A bool value equals to True if all the values are the same.</returns>  

            public bool EqualsToArray(T[] result)
            {
                if (result == null || result.Length != this.listOrder.Count)
                    return false;
                for (int i = 0; i < this.listOrder.Count; i++)
                    if (!this.listOrder[i].Equals(result[i]))
                        return false;

                return true;
            }
        }
    }
}