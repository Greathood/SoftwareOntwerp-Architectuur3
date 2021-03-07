using SOA3.Models.Users;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SOA3.Models.Board
{
    [ExcludeFromCodeCoverage]
    public class Report
    {
        Sprint sprint;
        string header { get; set; }
        string footer { get; set; }

        public Report(Sprint sprint)
        {
            this.sprint = sprint;
            this.header = "";
            this.footer = "";
        }

        public string reportAsString()
        {
            string s = "";
            s += header;
            s += "Team members: ";

            //team members with obtained points
            Dictionary<User, int> users = sprint.getTeam();
            foreach (User user in users.Keys)
            {
                s += "'" + user.FirstName + " " + user.LastName + "' with total points: '" + users[user] + "', ";
            }
            s += "\n";
            s += sprint.backlog.getBurndown();

            s += footer;
            return s;
        }
    }
}
