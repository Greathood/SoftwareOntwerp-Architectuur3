using SOA3.Models.Users;
using SOA3.States.BacklogState;

namespace SOA3.Models.Board
{
    public class Activity
    {
        public BacklogState backlogState;
        User developer;
        string description;

        public Activity(User developer, string description)
        {
            this.developer = developer;
            this.description = description;
        }

        public bool done()
        {
            if (backlogState is DoneBacklogState)
            {
                return true;
            }
            return false;
        }
    }
}
