using System;
using System.Collections.Generic;

namespace SOA3.Models.SCM.Mercury
{
    public class MercuryBranch : IBranch
    {
        public string Name { get; }
        public LinkedList<ICommit> Commits { get; }

        public MercuryBranch(string name)
        {
            Name = name;
            Commits = new LinkedList<ICommit>(new LinkedList<MercuryCommit>());
        }
        public bool AddCommit(ICommit commit)
        {
            if (commit is MercuryCommit mercuryCommit)
            {
                Commits.AddFirst(mercuryCommit);
                return true;
            }

            Console.WriteLine("Only Mercury commits can be added to a Mercury branch!");
            return false;
        }

        public void PrintCommits()
        {
            foreach (var commit in Commits)
            {
                Console.WriteLine(commit.ToString());
            }
        }
    }
}