using SOA3.Models.Board;
using System.Collections.Generic;

namespace SOA3.Models.Users
{
    public class ProductOwner : User
    {
        List<Sprint> Sprints;

        public ProductOwner()
        {
            Sprints = new List<Sprint>();
        }

        public void addSprint(Sprint sprint)
        {
            Sprints.Add(sprint);
        }

        public List<Sprint> getSprints()
        {
            return Sprints;
        }
    }
}
