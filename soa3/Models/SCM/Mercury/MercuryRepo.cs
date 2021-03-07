using SOA3.Models.Board;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SOA3.Models.SCM.Mercury
{
    public class MercuryRepo : IRepo
    {
        public string Name { get; set; }
        public List<IBranch> Branches { get; set; }
        public Project Project { get; set; }

        public MercuryRepo(string name, Project project)
        {
            Name = name;
            Project = project;
            Branches = new List<IBranch>(new List<MercuryBranch>());
        }

        public void AddBranch(IBranch branch)
        {
            if (branch is MercuryBranch)
            {
                Branches.Add(branch);
            }
            else
            {
                Console.WriteLine("Only Mercury Branches can be added to Mercury Repos");
            }
        }

        public ICommit FindCommit(string name)
        {
            foreach (var branch in Branches)
            {
                var commit = branch.Commits.First(x => x.Name == name);
                if (commit is ICommit)
                {
                    return commit;
                }

            }

            return null;
        }
    }
}