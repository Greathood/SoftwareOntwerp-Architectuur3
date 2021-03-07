using SOA3.Models.Users;
using System;

namespace SOA3.Models.Board
{
    public class Project
    {
        private IBoard board;
        private readonly ProductOwner productOwner;
        string title { get; set; }
        string description { get; set; }

        public Project(ProductOwner productOwner, string title, string description)
        {
            this.productOwner = productOwner;
            this.title = title;
            this.description = description;
        }

        public void AddBoard(IBoard board)
        {
            this.board = board;
        }

        public void AddBacklogItem(BacklogItem item)
        {
            board.AddBacklogItem(item);
        }

        public void AddSprint(Sprint sprint)
        {
            if(board is ScrumBoard)
            {
                board.AddSprint(sprint);
            }
        }

        public IBoard GetBoard()
        {
            return board;
        }

        public SoftwareProject ConvertToSoftwareProject()
        {
            return new SoftwareProject(productOwner, title, description);
        }
    }
}
