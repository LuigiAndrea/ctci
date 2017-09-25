
using System.Collections.Generic;

namespace Chapter4
{
    public static class Q4_7BuildOrder
    {
        public static Project[] BuildOrder(string[] projects, (string firstProject, string secondProject)[] dependencies)
        {
            GraphProject graph = buildGraph(projects, dependencies);
            Project[] order = new Project[graph.GetNodes().Count];

            int offsetArray = addNonDependent(order, graph.GetNodes(), 0);
            int offsetRemoveDep = 0;

            while (offsetArray < order.Length)
            {
                Project current = order[offsetRemoveDep];
                if (current == null)
                    return null;
                offsetRemoveDep++;
                removeDep(current);
                offsetArray = addNonDependent(order, current.GetChildren(), offsetArray);
            }
            return order;
        }

        private static GraphProject buildGraph(string[] projects, (string firstProject, string secondProject)[] dependencies)
        {
            GraphProject graph = new GraphProject();
            foreach (var project in projects)
                graph.CreateOrGetNode(project);

            foreach (var dep in dependencies)
            {
                Project prjA = graph.CreateOrGetNode(dep.firstProject);
                Project prjB = graph.CreateOrGetNode(dep.secondProject);
                prjA.AddChildAndDependency(prjB);
            }

            return graph;
        }

        private static void removeDep(Project prj)
        {
            foreach (var child in prj.GetChildren())
                child.Value.DecreaseDependencies();
        }

        public static int addNonDependent(Project[] order, Dictionary<string, Project> projects, int offset)
        {
            foreach (var prj in projects)
            {
                if (prj.Value.GetNumberOfDependencies() == 0)
                {
                    order[offset] = prj.Value;
                    offset++;
                }
            }
            return offset;
        }
    }
}
