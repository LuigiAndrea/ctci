using System.Collections.Generic;
using static Chapter4.Utilities;

namespace Chapter4
{
    public static class Q4_1RouteNodes
    {
        public static bool SearchRouteBetweenNodes<T>(GraphNode<T> startNode, GraphNode<T> endNode)
        {
            return breadhFirstSearch(startNode, endNode);
        }
    }
}