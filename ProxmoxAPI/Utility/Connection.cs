using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProxmoxAPI.Access;

namespace ProxmoxAPI.Utility
{
    public class Connection
    {
        private User user;
        private Socket socket;

        public Connection()
        {
            this.user = new User();
            socket = new Socket();
        }

        public Connection(User user, Socket socket)
        {
            this.user = user;
            this.socket = socket;
        }

        public string getSocket()
        {
            return socket.IP + ":" + socket.Port;
        }

        public Uri baseURI()
        {
            var u = "https://" + getSocket() + "/";
            return new Uri(u);
        }

        public User User { get { return user; } }
        public Socket Socket { get { return Socket; } }
    }
}
