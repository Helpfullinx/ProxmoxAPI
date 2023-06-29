namespace ProxmoxAPI.Utility
{
    public static class Socket
    {
        private static string ip;
        private static string port;


        public static string IP { get { return ip; } set { ip = value; } }
        public static string Port { get { return port; } set { port = value; } }

        public static new string ToString => ip + ":" + port;

    }
}
