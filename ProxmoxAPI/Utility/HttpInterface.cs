using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxmoxAPI.Utility
{
    public class HttpInterface
    {
        private static readonly HttpClient client;

        static HttpInterface()
        {
            var handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = delegate { return true; },
            };

            client = new HttpClient(handler);
        }

        public static HttpClient Get(Uri uri)
        {
            client.BaseAddress = uri;
            return client;
        }
    }
}
