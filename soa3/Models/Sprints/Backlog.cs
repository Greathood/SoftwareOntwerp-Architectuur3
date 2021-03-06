using SOA3.States;
using SOA3.States.BacklogState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA3.Models.Sprints
{
    public class Backlog
    {
        public List<BacklogItem> backlogItems;
        public Dictionary<BacklogItem, DateTime> burnDown;

        public Backlog() {
            burnDown = new Dictionary<BacklogItem, DateTime>();
            backlogItems = new List<BacklogItem>();
        }

        public void updateBacklogItem(BacklogItem backlogItem) {
            //notify all subscribers that the state of one of our backlog items changed
            backlogItem.Notify();

            //if the item has done state, we can add it to our burndown chart
            if (backlogItem.backlogState is DoneBacklogState && !burnDown.ContainsKey(backlogItem)) {
                //later on we can plot a graph using the datetime + points of backlogitem
                burnDown.Add(backlogItem, DateTime.Now);            
            }

            else if (backlogItem.backlogState is TodoBacklogState && burnDown.ContainsKey(backlogItem))
            {
                //backlogitem already got set to done once, we dont remove it, but duplicate it and set its value negative
                BacklogItem backlogItemNegative = new BacklogItem(backlogItem);
                backlogItemNegative.points = 0 - backlogItemNegative.points;
                burnDown.Add(backlogItemNegative, DateTime.Now);
            }
        }

        public void addBacklogItem(BacklogItem backlogItem) {
            backlogItems.Add(backlogItem);
        }

        public string getBurndown() {
            string s = "Burndown: ";

            foreach (KeyValuePair<BacklogItem, DateTime> point in burnDown) {
                s += point.Value.ToString() + " points ='" + point.Key.points + "' "; 
            }
            return s;
        }
    }
}
