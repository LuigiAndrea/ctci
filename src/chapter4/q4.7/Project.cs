using System.Collections.Generic;

namespace Chapter4
{
    public class Project
    {
        Dictionary<string, Project> children = new Dictionary<string, Project>();
        int numberOfDependencies = 0;
        string name;

        public Project(string nameProject) => name = nameProject;

        public void AddChildAndDependency(Project prj)
        {
            children.Add(prj.name, prj);
            prj.IncreaseDependencies();
        }
      
        public Dictionary<string, Project> GetChildren() => children;
        public string GetName() => name;
        public int GetNumberOfDependencies() => numberOfDependencies;
        public void IncreaseDependencies() => ++numberOfDependencies;
        public void DecreaseDependencies() => --numberOfDependencies;
    }
}
