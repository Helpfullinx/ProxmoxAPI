namespace ProxmoxAPI.Utility
{
    public class HttpInterface
    {
        public static HttpClient client { get; set; }

        static HttpInterface()
        {
            var handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = delegate { return true; },
            };

            client = new HttpClient(handler);
        }
    }
}
