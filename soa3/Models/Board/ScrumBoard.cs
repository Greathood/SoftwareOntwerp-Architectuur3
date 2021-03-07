using System;
using System.Collections.Generic;

namespace SOA3.Models.Board
{
    class ScrumBoard : IBoard
    {
        public List<Sprint> sprints { get; set; }    
        Sprint currentSprint = null;

        public ScrumBoard()
        {
            sprints = new List<Sprint>();
        }

        public void AddBacklogItem(BacklogItem item)
        {
            if (currentSprint is null)
            {
                Console.WriteLine("Sprint not set, please set the current sprint you want to add to first");
            }
            else
            {
                currentSprint.backlog.addBacklogItem(item);
            }
        }

        public void AddSprint(Sprint sprint)
        {
            sprints.Add(sprint);
            //If current sprint not set lets set the current sprint to the one we just added
            if (currentSprint is null) { currentSprint = sprint; }
        }

        public void SetCurrentSprint(Sprint sprint)
        {
            if (sprints.Contains(sprint))
            {
                currentSprint = sprint;
            }
            else
            {
                Console.WriteLine("This sprint isn't part of this board");
            }
        }

        public List<Sprint> getSprints()
        {
            return sprints;
        }
    }
}
