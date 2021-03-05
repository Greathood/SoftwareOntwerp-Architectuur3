using SOA3.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA3.Models.Forum
{
    public class Comment
    {
        public  string text;
        public User user;
        public DateTime date;

        public Comment(string text, User user) {
            this.text = text;
            this.user = user;
            date = new DateTime();
        }
    }
}
