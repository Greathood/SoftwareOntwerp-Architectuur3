using SOA3.Models.Board;
using SOA3.Models.SCM;
using SOA3.Models.SCM.Git;

namespace SOA3.Services
{
    class GitFactory : IContentManagerFactory
    {
        public IBranch CreateBranch(string name)
        {
            GitBranch gBranch = new GitBranch(name);
            return gBranch;
        }

        public ICommit CreateCommit(string name, string description)
        {
            GitCommit gCommit = new GitCommit(name, description);
            return gCommit;
        }

        public IRepo CreateSCM(string name, Project project)
        {
            GitRepo gRepo = new GitRepo(name, project);
            return gRepo;
        }
    }
}
