using SOA3.Models.Board;
using System.Collections.Generic;

namespace SOA3.Models.SCM
{
    public interface IRepo
    {
        string Name { get; set; }
        List<IBranch> Branches { get; set; }
        Project Project { get; set; }

        void AddBranch(IBranch branch);

        ICommit FindCommit(string name);
    }
}