using SOA3.Models.SCM;
using SOA3.Models.Users;
using System.Collections.Generic;

namespace SOA3.Models.Board
{
    public class SoftwareProject : Project
    {
        private readonly List<IRepo> _repos = new List<IRepo>();
        public SoftwareProject(ProductOwner productOwner, string name, string description) : base(productOwner, name, description) { }

        public void AddRepo(IRepo repo)
        {
            _repos.Add(repo);
        }
    }
}
