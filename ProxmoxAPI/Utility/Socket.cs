namespace ProxmoxAPI.Utility
{
    public class Socket
    {
        private string ip;
        private string port;

        public Socket(string ip, string port)
        {
            this.ip = ip;
            this.port = port;
        }

        public string IP { get { return ip; } }
        public string Port { get { return port; } }

        public override string ToString()
        {
            return ip + ":" + port;
        }
        
    }
}
