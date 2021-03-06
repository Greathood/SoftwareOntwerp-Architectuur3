using SOA3.Models.Sprints;
using SOA3.Models.Users;
using SOA3.States.SprintState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA3.Models.Users
{
    public class ProductOwner : User
    {
        List<Sprint> Sprints;

        public ProductOwner() {
            Sprints = new List<Sprint>();
        }

        public void addSprint(Sprint sprint) {
            Sprints.Add(sprint);
        }

        public List<Sprint> getSprints()
        {
            return Sprints;
        }
    }
}
