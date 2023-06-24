namespace ProxmoxAPI.Utility
{
    public static class Connection
    {
        public static User? user { get; set; }
        public static Socket socket { get; set; }

        public static Uri baseURI()
        {
            return new Uri("https://" + socket + "/");
        }
    }
}
