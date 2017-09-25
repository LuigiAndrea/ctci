using System.Collections.Generic;

namespace Chapter4
{
    public class GraphProject
    {
        Dictionary<string, Project> nodes = new Dictionary<string, Project>();
        public Dictionary<string, Project> GetNodes() => nodes;

        public Project CreateOrGetNode(string name)
        {
            if (!nodes.ContainsKey(name))
            {
                Project project = new Project(name);
                nodes.Add(name, project);
                return project;
            }
            else
            {
                return nodes[name];
            }
        }
    }
}
