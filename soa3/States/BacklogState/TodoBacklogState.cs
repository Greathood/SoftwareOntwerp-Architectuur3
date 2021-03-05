using System;

namespace SOA3.States.BacklogState
{
    public class TodoBacklogState : BacklogState
    {
        public override void done()
        {
            //cant change state to done casue not yet started;
        }
    }
}
