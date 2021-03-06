using SOA3.Models;
using SOA3.Models.Sprints;
using System;

namespace SOA3.States.BacklogState
{
    public class BacklogState
    {
        public BacklogItem backlogItem;

        public void setBacklogItem(BacklogItem backlogItem)
        {
            this.backlogItem = backlogItem;
        }

        public virtual void todo()
        {
            backlogItem.setState(new TodoBacklogState());
        }
        public virtual void doing()
        {
            backlogItem.setState(new DoingBacklogState());
        }
        public virtual void done()
        {
            backlogItem.setState(new DoneBacklogState());
        }
    }
}
