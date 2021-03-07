using SOA3.Models.Board;
using System;

namespace SOA3.Models.Users
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void Update(object data)
        {
            try
            {
                BacklogItem item = (BacklogItem)data;
                //We can do something here with the data for now just print a console line
                Console.WriteLine("Notification Received: " + item.description + " Has been updated");
            } catch {
                //Normally use logger here, for now print line
                Console.WriteLine("Can't cast data object to backlogitem");
            }
           
        }
    }
}
