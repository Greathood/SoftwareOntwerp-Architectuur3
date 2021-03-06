using SOA3.Models.Users;
using SOA3.Models.Sprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA3.Models.Forum
{
    public class Forum
    {
        List<Thread> threads;
        Sprint sprint;

        public Forum(Sprint sprint) {
            threads = new List<Thread>();
            this.sprint = sprint;
        }

        public Thread addThread(BacklogItem backlogItem, string title, string description, User creator) {
            Thread thread = new Thread(backlogItem, title, description, creator, sprint);
            threads.Add(thread);
            return thread;
        }
    }
}
