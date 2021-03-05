using SOA3.Models.Users;
using System;
using System.Collections.Generic;

namespace SOA3.Models
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
