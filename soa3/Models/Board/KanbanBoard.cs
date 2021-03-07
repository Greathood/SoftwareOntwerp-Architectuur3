using System;
using System.Collections.Generic;

namespace SOA3.Models.Board
{
    class KanbanBoard : IBoard
    {
        public Backlog backlog { get; set; }

        public KanbanBoard()
        {
            backlog = new Backlog();
        }

        public void AddBacklogItem(BacklogItem item)
        {
            backlog.addBacklogItem(item);
        }

        public void AddSprint(Sprint sprint)
        {
            Console.WriteLine("Sprints aren't available with KanbanBoards");
        }

        public void SetCurrentSprint(Sprint sprint)
        {
            Console.WriteLine("No sprint to set");
        }

        public List<Sprint> getSprints()
        {
            Console.WriteLine("Sprints aren't available with KanbanBoards");
            return null;
        }
    }
}
