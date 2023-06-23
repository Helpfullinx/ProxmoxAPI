using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxmoxAPI.Utility
{
    public class Socket
    {
        private string ip;
        private string port;

        public Socket()
        {
            ip = string.Empty;
            port = string.Empty;
        }

        public Socket(string ip, string port)
        {
            this.ip = ip;
            this.port = port;
        }

        public string IP { get { return ip; } }
        public string Port { get { return port; } }
        
    }
}
