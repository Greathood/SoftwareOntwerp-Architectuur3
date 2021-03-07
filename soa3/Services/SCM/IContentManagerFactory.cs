using SOA3.Models.Board;
using SOA3.Models.SCM;

namespace SOA3.Services
{
    public interface IContentManagerFactory
    {
        IRepo CreateSCM(string name, Project project);
        IBranch CreateBranch(string name);
        ICommit CreateCommit(string name, string description);
    }
}