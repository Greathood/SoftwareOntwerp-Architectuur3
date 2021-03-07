using SOA3.Models.Board;
using SOA3.Models.Users;
using System.Collections.Generic;

namespace SOA3.Models.Forum
{
    public class Forum
    {
        List<Thread> threads;
        Sprint sprint;

        public Forum(Sprint sprint)
        {
            threads = new List<Thread>();
            this.sprint = sprint;
        }

        public Thread addThread(BacklogItem backlogItem, string title, string description, User creator)
        {
            Thread thread = new Thread(backlogItem, title, description, creator, sprint);
            threads.Add(thread);
            return thread;
        }
    }
}
