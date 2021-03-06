using SOA3.Models;
using SOA3.Models.SCM;
using SOA3.Models.Sprints;

namespace SOA3.Services{
    public interface IContentManagerFactory {
        IRepo CreateSCM(string name, Project project);
        IBranch CreateBranch(string name);
        ICommit CreateCommit(string name, string description);
    }
}