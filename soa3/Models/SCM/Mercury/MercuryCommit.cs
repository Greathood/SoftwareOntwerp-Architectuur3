using System;

namespace SOA3.Models.SCM.Mercury
{
    public class MercuryCommit : ICommit
    {
        public string Hash { get; }
        public string Name { get; }
        public string Description { get; }

        public MercuryCommit(string name, string description)
        {
            Name = name;
            Description = description;
            Hash = Guid.NewGuid().ToString();
        }

        public string ToString()
        {
            return "Mercury Commit: " + Hash + "\n" +
                   "Name: " + Name + "\n" +
                   "Description: " + (string.IsNullOrEmpty(Description) ? "N\\A" : Description) + "\n";
        }
    }
}