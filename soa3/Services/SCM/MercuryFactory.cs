using SOA3.Models.Board;
using SOA3.Models.SCM;
using SOA3.Models.SCM.Mercury;

namespace SOA3.Services
{
    public class MercuryFactory : IContentManagerFactory
    {
        public IBranch CreateBranch(string name)
        {
            MercuryBranch mBranch = new MercuryBranch(name);
            return mBranch;
        }

        public ICommit CreateCommit(string name, string description)
        {
            MercuryCommit mCommit = new MercuryCommit(name, description);
            return mCommit;
        }

        public IRepo CreateSCM(string name, Project project)
        {
            MercuryRepo mRepo = new MercuryRepo(name, project);
            return mRepo;
        }
    }
}