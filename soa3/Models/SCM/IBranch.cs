using System;
using System.Collections.Generic;

namespace SOA3.Models.SCM
{
    public interface IBranch
    {
        string Name { get; }
        LinkedList<ICommit> Commits { get; }

        bool AddCommit(ICommit commit);

        void PrintCommits();

    }
}