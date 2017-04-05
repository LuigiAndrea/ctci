using System.Collections.Generic;
using static System.Math;
using static System.Console;

namespace Chapter4
{
    public static class Utilities
    {
        /// <summary>
        /// Visit and store the nodes of a TreeBinaryNode in three different approaches.
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

        /// <summary>
        /// Class to print a TreeBinaryNode nicely
        ///</summary>
        /// <example> 
        /// This sample shows how to use the PrintBinaryTree Class.
        /// <code>
        ///  const int size = 10;
        ///  int[] array = new int[size];
        ///  for (int i = 0; i<size; i++)
        ///      array[i] = i;
        ///  TreeBinaryNode<int> a = MinimalTree(array);
        ///  PrintBinaryTree<int>.pretty(a);
        /// </code>
        /// </example>
        public static class PrintBinaryTree<T>
        {
            private static string nullNode = "[-,-]";
            private class NodePrint
            {
                public TreeBinaryNode<T> left;
                public TreeBinaryNode<T> right;
                public string pairDesc;

                public NodePrint(TreeBinaryNode<T> left, TreeBinaryNode<T> right)
                {
                    bool leftisNull = left == null ? true : false;
                    bool rightIsNull = right == null ? true : false;
                    this.left = left;
                    this.right = right;

                    if (!leftisNull && !rightIsNull)
                    {
                        this.pairDesc = $"[{left.value},{right.value}] ";
                    }
                    else if (!leftisNull)
                    {
                        this.pairDesc = $"[{left.value},-] ";
                    }
                    else if (!rightIsNull)
                    {
                        this.pairDesc = $"[-,{right.value}] ";
                    }
                    else
                    {
                        this.pairDesc = nullNode;
                    }
                }

                public NodePrint(TreeBinaryNode<T> root)
                {
                    this.left = root.left;
                    this.right = root.right;
                    this.pairDesc = $" --- {root.value} ---";
                }
            }
            public static void pretty(TreeBinaryNode<T> node)
            {
                if (node == null)
                    return;

                Queue<NodePrint> oldQ = new Queue<NodePrint>();
                Queue<NodePrint> newQ = new Queue<NodePrint>();

                oldQ.Enqueue(new NodePrint(node));

                NodePrint root = oldQ.Dequeue();
                WriteLine(root.pairDesc);
                WriteLine();

                if (root.left != null || root.right != null)
                    oldQ.Enqueue(new NodePrint(root.left, root.right));

                while (oldQ.Count > 0)
                {
                    int ind = oldQ.Count;

                    for (int i = 0; i < ind; i++)
                    {
                        NodePrint n = oldQ.Dequeue();

                        Write(n.pairDesc);

                        TreeBinaryNode<T> a = n.left;
                        TreeBinaryNode<T> b = n.right;

                        addElements(a, ref newQ);
                        addElements(b, ref newQ);
                    }

                    WriteLine();
                    WriteLine();
                    ind = newQ.Count;

                    bool atLeastOne = false;
                    for (int i = 0; i < ind; i++)
                    {
                        NodePrint n = newQ.Dequeue();
                        if (n.pairDesc != nullNode)
                        {
                            atLeastOne = true;
                        }

                        oldQ.Enqueue(n);

                    }

                    if (!atLeastOne)
                        return;
                }
            }

            private static void addElements(TreeBinaryNode<T> node, ref Queue<NodePrint> queue)
            {
                if (node != null)
                {
                    if (node.left != null && node.right != null)
                    {
                        queue.Enqueue(new NodePrint(node.left, node.right));
                    }
                    else if (node.right != null)
                    {
                        queue.Enqueue(new NodePrint(null, node.right));
                    }
                    else if (node.left != null)
                    {
                        queue.Enqueue(new NodePrint(node.left, null));
                    }
                    else
                    {
                        queue.Enqueue(new NodePrint(null, null));
                    }
                }
            }
        }

        /// <summary>
        /// Calculate the depth of a Binary Tree.
        ///</summary>
        /// <param name="node"> TreeBinaryNode. The root of the Binary Tree.</param>
        /// <returns>The length of the Binary Tree.</returns>
        public static int getDepth<T>(TreeBinaryNode<T> node)
        {
            if (node == null)
                return -1;

            return Max(getDepth(node.left), getDepth(node.right)) + 1;
        }
    }
}