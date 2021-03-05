using SOA3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA3.States.SprintState
{
    public class SprintState
    {
        public Sprint sprint;
        public void setSprint(Sprint sprint)
        {
            this.sprint = sprint;
        }

        public virtual void start()
        {
            sprint.setState(new ActiveSprintState());
        }

        public virtual void finish()
        {
            sprint.setState(new FinishedSprintState());
        }

        public virtual void startReview()
        {
            sprint.setState(new ReviewSprintState());
        }

        public virtual void close()
        {
            sprint.setState(new ClosedSprintState());
        }
    }
}
