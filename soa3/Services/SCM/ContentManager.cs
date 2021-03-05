using SOA3.Models;
using SOA3.Models.SCM;

namespace SOA3.Services
{
    public class ContentManager
    {
        private IContentManagerFactory factory;
        private IRepo repo;

        public ContentManager(IContentManagerFactory factory){
            this.factory = factory;
        }

        public void InitRepo(string name, Project project){
            repo = factory.CreateSCM(name, project);
            AddBranch("master");
        }

        public void AddBranch(string name){
            IBranch branch = factory.CreateBranch(name);
            repo.AddBranch(branch);
        }

        public void AddCommit(IBranch branch, string name, string description){
            ICommit commit = factory.CreateCommit(name, description);
            branch.AddCommit(commit);
        }

        public IRepo GetRepo(){ return repo; }
    }
}