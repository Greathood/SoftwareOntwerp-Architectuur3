using SOA3.Models.Users;
using System;

namespace SOA3.Models.Forum
{
    public class Comment
    {
        public string text;
        public User user;
        public DateTime date;

        public Comment(string text, User user)
        {
            this.text = text;
            this.user = user;
            date = new DateTime();
        }
    }
}
