using SOA3.Models.Sprints;
using SOA3.Models.Users;
using SOA3.States.BacklogState;
using System;
using System.Collections.Generic;

namespace SOA3.Models.Forum
{
    public class Thread
    {
        BacklogItem backlogItem;
        string title;
        string description;
        List<Comment> comments;
        public User creator;
        //needed for comment notification
        Sprint sprint;

        public Thread(BacklogItem backlogItem, string title, string description, User creator, Sprint sprint) {
            this.backlogItem = backlogItem;
            this.title = title;
            this.description = description;
            comments = new List<Comment>();
            this.creator = creator;
            this.sprint = sprint;
        }

        public bool addComment(Comment comment) {
            //make sure the backlog item is not done yet
            if (!(backlogItem.backlogState is DoneBacklogState)) {
                comments.Add(comment);

                //this should probably only get called when the amount of developers changes
                Dictionary<object, Action<Comment>> subscribers = new Dictionary<object, Action<Comment>>();

                foreach (User d in sprint.getTeam().Keys) {
                    subscribers.Add(d, c => {
                    Console.WriteLine("hey developer: " + d.FirstName + ", a new comment on thread: '" + this.title + "' got posted, with comment: '"
                        + c.text + "'.");
                    });
                }

                return true;
            }
            Console.WriteLine("backlog item is done! comments plaatsen niet mogelijk");
            return false;
        }
    }
}
