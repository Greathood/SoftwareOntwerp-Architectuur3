using SOA3.States;
using SOA3.States.BacklogState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA3.Models
{
    public class Backlog
    {
        public List<BacklogItem> backlogItems;
        public Dictionary<DateTime, BacklogItem> burnDown;

        public Backlog() {
            burnDown = new Dictionary<DateTime, BacklogItem>();
            backlogItems = new List<BacklogItem>();
        }

        public void updateBacklogItem(BacklogItem backlogItem) {
            //notify all subscribers that the state of one of our backlog items changed
            backlogItem.Notify();

            //if the item has done state, we can add it to our burndown chart
            if (backlogItem.backlogState is DoneBacklogState) {
                //later on we can plot a graph using the datetime + points of backlogitem
                burnDown.Add(DateTime.Now, backlogItem);            
            }

            else if (backlogItem.backlogState is TodoBacklogState) {
                //check if backlogitem is in done and got set back, than we would have to update the burndown
                if (burnDown.ContainsValue(backlogItem)) {
                    //backlogitem already got set to done once, we dont remove it, but duplicate it and set its value negative
                    BacklogItem backlogItemNegative = new BacklogItem(backlogItem);
                    backlogItemNegative.points = 0 - backlogItemNegative.points;
                    burnDown.Add(DateTime.Now, backlogItemNegative);
                }
            }
        }

        public void addBacklogItem(BacklogItem backlogItem) {
            backlogItems.Add(backlogItem);
        }

        public string getBurndown() {
            string s = "Burndown: ";

            foreach (KeyValuePair<DateTime, BacklogItem> point in burnDown) {
                s += point.Key.ToString() + " points ='" + point.Value.points + "' "; 
            }
            return s;
        }
    }
}
