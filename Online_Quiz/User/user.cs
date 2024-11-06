using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Quiz.User
{
    public class user
    {
        private int user_id;
        private string username;

        public int Id { get => user_id; set => user_id = value; }
        public string Username { get => username; set => username = value; }

        public user(int user_id, string username)
        {
            this.user_id = user_id;
            this.username = username;
        }
    }
}
