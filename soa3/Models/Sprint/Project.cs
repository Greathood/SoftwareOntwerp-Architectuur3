using System.Collections.Generic;
using SOA3.Models.SCM;

namespace SOA3.Models
{
    public class Project
    {
        List<Sprint> sprints;
        private List<IRepo> _repos;
        ProductOwner productOwner;
        string title { get; set; }
        string description { get; set; }

        public Project(ProductOwner productOwner, string title, string description) {
            this.productOwner = productOwner;
            this.title = title;
            this.description = description;
        }

        internal void addRepo(IRepo repo)
        {
            _repos.Add(repo);
        }
    }
}
