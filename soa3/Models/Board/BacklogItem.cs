using SOA3.Models.SCM;
using SOA3.Models.Users;
using SOA3.States.BacklogState;
using System.Collections.Generic;

namespace SOA3.Models.Board
{
    public class BacklogItem
    {
        Backlog backlog;
        private List<Activity> activities;
        public User developer;
        public BacklogState backlogState;
        private List<User> subscribedUsers = new List<User>();
        private IBranch _branch;

        public int points { get; set; }
        public string description { get; set; }

        public BacklogItem(Backlog backlog, string description, int points)
        {
            this.backlog = backlog;
            this.description = description;
            backlogState = new TodoBacklogState();
            backlogState.setBacklogItem(this);
            this.points = points;
            activities = new List<Activity>();
        }

        public BacklogItem(BacklogItem backlogItem)
        {
            BacklogItem backlogItem1 = this;
            backlogItem1.developer = backlogItem.developer;
            backlogItem1.backlog = backlogItem.backlog;
            backlogItem1.description = backlogItem.description;
            backlogState = new TodoBacklogState();
            backlogItem1.backlogState.setBacklogItem(backlogItem1);
            backlogItem1.points = backlogItem.points;
            activities = new List<Activity>();
        }

        public void Subscribe(User user)
        {
            subscribedUsers.Add(user);
        }

        public void Unsubscribe(User user)
        {
            subscribedUsers.Remove(user);
        }

        public void Notify()
        {
            foreach (var user in subscribedUsers)
            {
                user.Update(this);
            }
        }

        public void assign(User developer)
        {
            this.developer = developer;
            Notify();
        }

        public void setState(BacklogState backlogState)
        {
            backlogState.setBacklogItem(this);
            this.backlogState = backlogState;
            backlog.updateBacklogItem(this);
            Notify();
        }

        public void AddActivity(Activity activity)
        {
            activities.Add(activity);
        }

        public bool checkActiviesState()
        {
            foreach (Activity a in activities)
            {
                if (!a.done())
                {
                    return false;
                }
            }
            //passed the for loop so activities is either empty or everything is done
            return true;
        }
    }
}