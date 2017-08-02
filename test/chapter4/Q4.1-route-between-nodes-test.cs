using Xunit;

using Chapter4;
using static Chapter4.Utilities;
using static Chapter4.Q4_1RouteBetweenNodes;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Tests.Chapter4
{
    public class Q4_1
    {
        Graph<int> graph = populateGraph<int>(listOfNodes);
        static List<AdjacencyList<int>> listOfNodes = new List<AdjacencyList<int>>(){
                    new AdjacencyList<int>() { fatherName = 3, children = new List<int> { 5, 23 } },
                    new AdjacencyList<int>() { fatherName = 15, children = new List<int> { 8 }  },
                    new AdjacencyList<int>() { fatherName = 13, children = new List<int> { 3,8,11} },
                    new AdjacencyList<int>() { fatherName = 23, children = new List<int> { 13 } },
                    new AdjacencyList<int>() { fatherName = 11, children= new List<int>{200} },
                    new AdjacencyList<int>() { fatherName = 8, children= new List<int>{13} }
            };


        [FactAttribute]
        private void RouteBetweenNodesTest()
        {
            GraphNode<int> node23 = graph.getNode(23);
            GraphNode<int> node15 = graph.getNode(15);
            
            testGraph(() => Assert.False(searchRouteBetweenNodes(node23, node15)));
            testGraph(() => Assert.True(searchRouteBetweenNodes(node15, node23)));
            testGraph(() => Assert.Equal(getRouteBetweenNodes(node15, node23), "15 -> 8 -> 13 -> 3 -> 23"));
            testGraph(() => Assert.Equal(getRouteBetweenNodes(node23, node15), $"No route between the nodes {node23.value} and {node15.value}"));

            //We have a node with value 3 but this is a different instance
            GraphNode<int> newInstanceNode3 = new GraphNode<int>(3);
            testGraph(() => Assert.Equal(getRouteBetweenNodes(node23, newInstanceNode3), $"No route between the nodes {node23.value} and {newInstanceNode3.value}"));

            Exception exception = Record.Exception(() => getRouteBetweenNodes(node15, null));
            Assert.IsType<ArgumentNullException>(exception);
        }

        private void testGraph(Action test)
        {
            test();
            cleanGrapth(graph);
        }

    }
}