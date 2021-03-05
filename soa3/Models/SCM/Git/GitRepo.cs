using System;
using System.Collections.Generic;

namespace SOA3.Models.SCM.Git
{
    class GitRepo : IRepo
    {
        public string Name { get; set; }
        public List<IBranch> Branches { get; set; }
        public Project Project { get; set; }
        public GitRepo(string name, Project project)
        {
            Name = name;
            Project = project;
            Branches = new List<IBranch>();
        }

        public void AddBranch(IBranch branch)
        {
            if (branch is GitBranch)
            {
                Branches.Add(branch);
            }
            else
            {
                Console.WriteLine("Only Git Branches can be added to Git Repos");
            }
            
        }

        public ICommit FindCommit(string name)
        {
            foreach (var branch in Branches)
            {
                foreach (var commit in branch.Commits)
                {
                    if (commit.Name == name)
                    {
                        return commit;
                    }
                }
            }
                
            return null;
        }
    }
}