using System;

namespace SOA3.States.BacklogState
{
    public class DoneBacklogState : BacklogState
    {
        public override void doing()
        {
            Console.WriteLine("lets stick to the scrum rules, going back to doing is not allowed, back to todo is.");
        }
    }
}
