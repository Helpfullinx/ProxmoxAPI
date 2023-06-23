using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProxmoxAPI.access.Domain;

namespace ProxmoxAPI.Utility
{
    public class User
    {
        private string username;
        private string password;
        private Domain domain;

        public User()
        {
            username = string.Empty;
            password = string.Empty;
            domain = new Domain();
        }

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
            domain = new Domain();
        }

        public string UserName { get { return (username + "@" + domain.Type); } set { username = value; } }

        public string Password { get { return password; } set { password = value; } }
    }
}
