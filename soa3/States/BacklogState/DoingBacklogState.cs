using System;

namespace SOA3.States.BacklogState
{
    public class DoingBacklogState : BacklogState
    {
        public override void done()
        {
            //check if all possibly subactivities are done
            if (backlogItem.checkActiviesState())
            {
                //all activities are done, we can set our state to done;
                backlogItem.setState(new DoneBacklogState());
            }
            else {
                Console.WriteLine("not all activites are done.");
            }
        }
    }
}
