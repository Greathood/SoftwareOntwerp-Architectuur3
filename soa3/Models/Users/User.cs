using System;

namespace SOA3.Models.Users
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void Update(string data)
        {
            Console.WriteLine("Notification Received: " + data);
        }
    }
}
