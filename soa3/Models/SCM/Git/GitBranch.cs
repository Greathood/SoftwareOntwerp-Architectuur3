using System;
using System.Collections.Generic;

namespace SOA3.Models.SCM.Git
{
    class GitBranch : IBranch
    {
        public LinkedList<ICommit> Commits { get; }
        public string Name { get; }

        public GitBranch(string name)
        {
            Name = name;
            Commits = new LinkedList<ICommit>(new LinkedList<GitCommit>());        }

        public bool AddCommit(ICommit commit)
        {
            if (commit is GitCommit gitCommit)
            {
                Commits.AddFirst(gitCommit);
                return true;
            }

            Console.WriteLine("Only Git commits can be added to a git branch!");
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