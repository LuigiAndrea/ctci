using System.Collections.Generic;
using System.Linq;

namespace Chapter4
{
    public class Graph<T>
    {
        public List<GraphNode<T>> nodes;
        public GraphNode<T> getNode(T value) => this.nodes.FirstOrDefault(x => x.value.Equals(value));
        public Graph(List<GraphNode<T>> graphNodes) => nodes = graphNodes;
    }
    public class GraphNode<T>
    {
        public T value;
        public bool visited;
        public List<GraphNode<T>> adjacent = new List<GraphNode<T>>();

        public GraphNode(T graphValue) => value = graphValue;
        public GraphNode(T graphValue, List<GraphNode<T>> graphNodes)
        {
            value = graphValue;
            adjacent = graphNodes;
        }
    }
}
