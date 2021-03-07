using SOA3.Models.Users;
using SOA3.States.SprintState;
using System;
using System.Collections.Generic;

namespace SOA3.Models.Board
{
    public class Sprint
    {
        string name;
        DateTime startTime;
        DateTime endTime;
        Dictionary<User, int> team;
        public Backlog backlog;
        ScrumMaster scrumMaster;
        public SprintState sprintState;

        public Sprint(string name, DateTime startTime, DateTime endTime, ScrumMaster scrumMaster)
        {
            backlog = new Backlog();
            this.scrumMaster = scrumMaster;
            this.name = name;
            this.startTime = startTime;
            this.endTime = endTime;
            this.sprintState = new InitializedSprintState();
            sprintState.setSprint(this);
            team = new Dictionary<User, int>();
        }

        public void setState(SprintState sprintState)
        {
            sprintState.setSprint(this);
            this.sprintState = sprintState;
        }

        public void addTeamMember(User user)
        {
            if (!team.ContainsKey(user))
            {
                team.Add(user, 0);
            }
        }

        public void removeTeamMember(User user)
        {
            if (team.ContainsKey(user))
            {
                team.Remove(user);
            }
        }

        public Dictionary<User, int> getTeam()
        {
            foreach (BacklogItem backlogItem in backlog.burnDown.Keys)
            {
                if (team.ContainsKey(backlogItem.developer))
                {
                    team[backlogItem.developer] += backlogItem.points;
                }
            }
            return team;
        }
    }
}
