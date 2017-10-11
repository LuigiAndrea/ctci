using System.Collections.Generic;
using static System.Math;
using static System.Console;
using static Chapter4.Q4_2MinimalTree;
using static Chapter4.Utilities.BuildParentTree;
using System;
using System.Linq;
using System.Text;

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
        ///  TreeBinaryNode<int> a = CreateBinaryTree<TreeBinaryNode<int>,int>(array);
        ///  PrintBinaryTree.pretty<int>(a);
        /// </code>
        /// </example>
        public static class PrintBinaryTree
        {
            private static string nullNode = "[-,-]";
            private class NodePrint<T>
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
            public static void pretty<T>(TreeBinaryNode<T> node)
            {
                if (node == null)
                    return;

                Queue<NodePrint<T>> oldQ = new Queue<NodePrint<T>>();
                Queue<NodePrint<T>> newQ = new Queue<NodePrint<T>>();

                oldQ.Enqueue(new NodePrint<T>(node));

                NodePrint<T> root = oldQ.Dequeue();
                WriteLine(root.pairDesc);
                WriteLine();

                if (root.left != null || root.right != null)
                    oldQ.Enqueue(new NodePrint<T>(root.left, root.right));

                while (oldQ.Count > 0)
                {
                    int ind = oldQ.Count;

                    for (int i = 0; i < ind; i++)
                    {
                        NodePrint<T> n = oldQ.Dequeue();

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
                        NodePrint<T> n = newQ.Dequeue();
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

            private static void addElements<T>(TreeBinaryNode<T> node, ref Queue<NodePrint<T>> queue)
            {
                if (node != null)
                {
                    if (node.left != null && node.right != null)
                    {
                        queue.Enqueue(new NodePrint<T>(node.left, node.right));
                    }
                    else if (node.right != null)
                    {
                        queue.Enqueue(new NodePrint<T>(null, node.right));
                    }
                    else if (node.left != null)
                    {
                        queue.Enqueue(new NodePrint<T>(node.left, null));
                    }
                    else
                    {
                        queue.Enqueue(new NodePrint<T>(null, null));
                    }
                }
            }
        }

        /// <summary>
        /// Create a Binary Search Tree.
        ///</summary>
        /// <param name="size">Number of nodes contained in the tree.</param>
        public static TTree CreateBinarySearchTree<TTree>(int size) where TTree : TreeBinaryNode<int>
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
                array[i] = i;

            return (TTree)((typeof(TTree) == typeof(TreeBinaryNode<int>))
                   ? MinimalTree(array)
                   : MinimalParentTree(array));
        }

         public static TTree CreateBinaryTree<TTree,T>(T[] values) where TTree : TreeBinaryNode<T> =>
                (TTree)((typeof(TTree) == typeof(TreeBinaryNode<T>))
                    ? MinimalTree(values)
                    : MinimalParentTree(values));
        

        /// <summary>
        /// Create a Balanced Tree with also information about the parents.
        /// </summary>
        /// <param name="array">Array of nodes to use to build the tree.</param>
        public static class BuildParentTree
        {
            public static TreeBinaryParentNode<T> MinimalParentTree<T>(T[] array)
            {
                return (array == null) ? null
                                    : MinimalParentTree<T>(array, 0, array.Length - 1, null);
            }

            private static TreeBinaryParentNode<T> MinimalParentTree<T>(T[] array, int start, int end, TreeBinaryParentNode<T> parent)
            {
                TreeBinaryParentNode<T> currentParent = parent;

                if (start > end)
                    return null;

                int midIndex = (start + end) / 2;
                T middle = array[midIndex];
                parent = new TreeBinaryParentNode<T>(middle, null, null, currentParent);
                parent.left = MinimalParentTree<T>(array, start, midIndex - 1, parent);
                parent.right = MinimalParentTree<T>(array, midIndex + 1, end, parent);

                return parent;
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

        /// <summary>
        /// Build a graph with no duplicates.
        ///</summary>
        /// <param name="adjacencyList"> A list that contains all the nodes to create.</param>
        /// <returns>The Graph.</returns>
        /// <example> 
        /// This sample shows how to use the generic populateGraph method
        /// <code>
        // List<AdjacencyList<int>> listOfNodes = new List<AdjacencyList<int>>(){
        //             new AdjacencyList<int>() { fatherName = 3, children = new List<int> { 13, 23, 5 } },
        //             new AdjacencyList<int>() { fatherName = 13, children = new List<int> { 3 } },
        //             new AdjacencyList<int>() { fatherName = 23, children = new List<int> { 13 } }
        //     };
        //     Call the method
        //     populateGraph<int>(listOfNodes);
        /// </code>
        /// </example>
        public static Graph<T> populateGraph<T>(List<AdjacencyList<T>> adjacencyList)
        {
            if (adjacencyList == null)
                throw new ArgumentNullException(paramName: nameof(adjacencyList), message: $"{nameof(adjacencyList)} must not be null");

            Dictionary<T, GraphNode<T>> instancesOfNodes = new Dictionary<T, GraphNode<T>>();
            List<GraphNode<T>> allNodesGraph = new List<GraphNode<T>>();
            GraphNode<T> father;

            foreach (var graphNode in adjacencyList)
            {
                T keyInstances = graphNode.fatherName;
                if (!instancesOfNodes.ContainsKey(keyInstances))
                {
                    father = new GraphNode<T>(graphNode.fatherName);
                    instancesOfNodes.Add(keyInstances, father);
                    allNodesGraph.Add(father);
                }
                else if (instancesOfNodes[keyInstances].adjacent.Count != 0)
                {//It means that the adjacencyList contains the same node more times (noisy in the data provided)
                    continue;
                }

                father = instancesOfNodes[keyInstances];
                var size = graphNode?.children?.Count;

                if (size == null) continue;

                for (int i = 0; i < size; i++)
                {
                    T childName = graphNode.children.ElementAt(i);
                    if (instancesOfNodes.ContainsKey(childName))
                    {
                        father.adjacent.Add(instancesOfNodes[childName]);
                    }
                    else //new child, we have to create a node
                    {
                        GraphNode<T> child = new GraphNode<T>(childName);
                        father.adjacent.Add(child);
                        instancesOfNodes.Add(child.value, child); //Added just for completeness
                        allNodesGraph.Add(child);
                    }
                }
            }

            return new Graph<T>(allNodesGraph);
        }

        public class AdjacencyList<T>
        {
            public T fatherName;
            public List<T> children;
        }

        /// <summary>
        /// Print the Graph without the bells and whistles.
        ///</summary>
        /// <param name="graph"> The Graph object.</param>
        public static void printGraph<T>(Graph<T> graph)
        {
            foreach (GraphNode<T> node in graph.nodes)
            {
                WriteLine($"Father: {node.value}");

                Write($"Children: ");
                if (node.adjacent.Count == 0)
                {
                    Write("None");
                }
                else
                {
                    Write(getString(node.adjacent));
                }

                WriteLine("\n");

            }

            string getString(List<GraphNode<T>> nodes) => $"[{string.Join("; ", nodes.Select(x => x.value))}]";

        }

        /// <summary>
        /// Search if there is a path between two nodes, depth-first-search
        ///</summary>
        /// <param name="startNode"> Source node.</param>
        /// <param name="endNode"> Destination node.</param>
        ///<returns>True if there is a connection between the two nodes, false otherwise</returns>
        public static bool depthFirstSearch<T>(GraphNode<T> startNode, GraphNode<T> endNode)
        {
            if (startNode == null || endNode == null)
                return false;

            startNode.visited = true;
            foreach (GraphNode<T> child in startNode.adjacent)
            {
                if (child == endNode)
                    return true;
                else
                {
                    if (child.visited == false)
                        return depthFirstSearch(child, endNode);
                }
            }
            return false;
        }


        /// <summary>
        /// Search if there is a path between two nodes, breadh-first-search
        ///</summary>
        /// <param name="startNode"> Source node.</param>
        /// <param name="endNode"> Destination node.</param>
        ///<returns>True if there is a connection between the two nodes, false otherwise</returns>
        public static bool breadhFirstSearch<T>(GraphNode<T> startNode, GraphNode<T> endNode)
        {
            if (startNode == null || endNode == null)
                return false;

            Queue<GraphNode<T>> q = new Queue<GraphNode<T>>();
            q.Enqueue(startNode);

            while (q.Count > 0)
            {
                GraphNode<T> father = q.Dequeue();
                father.visited = true;
                if (father == endNode)
                    return true;

                foreach (GraphNode<T> child in father.adjacent)
                {
                    if (child.visited == false)
                    {
                        q.Enqueue(child);
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Set all nodes visited property to false. Reset to its Initial state 
        ///</summary>
        /// <param name="graph"> The Graph.</param>
        public static void cleanGrapth<T>(Graph<T> graph) => graph.nodes.ForEach(x => x.visited = false);
    }

    public static class ExtensionsTreeBinaryNode
    {
        public static void printDescending<T>(this TreeBinaryNode<T> tree)
        {
            Utilities.PrintBinaryTree.pretty(tree);
        }
    }
}
