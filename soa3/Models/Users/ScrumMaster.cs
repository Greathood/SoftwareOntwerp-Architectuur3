using SOA3.Models.Sprints;
using SOA3.Models.Users;
using System;
using System.Collections.Generic;

namespace SOA3.Models.Users
{
    public class ScrumMaster : User
    {
        List<Sprint> Sprints;

        public ScrumMaster() {
            Sprints = new List<Sprint>();
        }

        public void addSprint(Sprint s) {      
            Sprints.Add(s);
        }
    }
}
