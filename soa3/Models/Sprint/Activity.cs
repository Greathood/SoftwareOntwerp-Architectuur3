using SOA3.States;
using SOA3.States.BacklogState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA3.Models
{
    class Activity
    {
        public BacklogState backlogState;
        Developer developer;
        string description;

        public bool done() {
            if (backlogState is DoneBacklogState) {
                return true;
            }
            return false;
        }
    }
}
