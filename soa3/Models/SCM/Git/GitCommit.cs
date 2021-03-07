using System;
using System.Diagnostics.CodeAnalysis;

namespace SOA3.Models.SCM.Git
{
    class GitCommit : ICommit
    {
        public string Hash { get; }
        public string Name { get; }
        public string Description { get; }
        private DateTime CommitDate { get; }

        public GitCommit(string name, string description)
        {
            Name = name;
            Description = description;
            Hash = Guid.NewGuid().ToString();
            CommitDate = DateTime.Now;
        }

        [ExcludeFromCodeCoverage]
        public string ToString()
        {
            return "Commit: " + Hash + " - " + CommitDate + "\n" +
                   "Name: " + Name + "\n" +
                   "Description: " + (string.IsNullOrEmpty(Description) ? "N\\A" : Description) + "\n";
        }
    }
}