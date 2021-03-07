using System.Collections.Generic;

namespace SOA3.Models.Board
{
    public interface IBoard
    {
        void AddBacklogItem(BacklogItem item);

        void AddSprint(Sprint sprint);

        void SetCurrentSprint(Sprint sprint);

        List<Sprint> getSprints();
    }
}
