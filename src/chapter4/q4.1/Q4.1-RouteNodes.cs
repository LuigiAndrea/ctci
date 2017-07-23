using System.Collections.Generic;
using System.Text;
using static Chapter4.Utilities;

namespace Chapter4
{
    public static class Q4_1RouteNodes
    {

        public static bool searchRouteBetweenNodes<T>(GraphNode<T> startNode, GraphNode<T> endNode)
        {
            return breadhFirstSearch(startNode, endNode);
        }


        /// <summary>
        /// Search if there is a path between two nodes and return that path
        ///</summary>
        /// <param name="startNode"> Source node.</param>
        /// <param name="endNode"> Destination node.</param>
        ///<returns>A string representing the route between the two nodes</returns>
        public static string getRouteBetweenNodes<T>(GraphNode<T> startNode, GraphNode<T> endNode)
        {
            string noRoute = $"No route between the nodes {startNode.value} and {endNode.value}";

            if (startNode == null || endNode == null)
                return noRoute;

            Queue<GraphNode<T>> q = new Queue<GraphNode<T>>();
            Queue<StringBuilder> listOfPaths = new Queue<StringBuilder>();

            q.Enqueue(startNode);
            listOfPaths.Enqueue(new StringBuilder().Append(startNode.value));

            while (q.Count > 0)
            {
                StringBuilder pathVisiting = listOfPaths.Dequeue();
                GraphNode<T> father = q.Dequeue();
                father.visited = true;
                if (father.Equals(endNode))
                {
                    return pathVisiting.ToString();
                }

                foreach (GraphNode<T> child in father.adjacent)
                {
                    if (child.visited == false)
                    {
                        StringBuilder path = new StringBuilder();
                        path.Append($"{pathVisiting} -> {child.value}");
                        listOfPaths.Enqueue(path);

                        q.Enqueue(child);
                    }
                }
            }

            return noRoute;
        }
    }
}