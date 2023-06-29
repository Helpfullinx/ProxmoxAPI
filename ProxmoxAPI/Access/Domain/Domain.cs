using ProxmoxAPI.Utility;
using System.Text.Json.Nodes;
using System.Text.Json;
using ProxmoxAPI.Utility.HttpRequests;
using System.Text.Json.Serialization;

namespace ProxmoxAPI.Access.Domain
{
    public class Domain : Postable, HttpRequestable
    {
        const string requestUri = "api2/json/access/domains";

        [JsonPropertyName("realm")]
        private List<Realm> realms = new();

        public Domain()
        {
        }

        public List<Realm> Realm { get { return realms; } set { realms = value; } }

        public FormUrlEncodedContent FormContent()
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> GET()
        {
            using HttpResponseMessage response = await HttpInterface.client.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();
            using HttpContent respContent = response.Content;
            {
                string ticketRaw = respContent.ReadAsStringAsync().Result;
                JsonNode data = JsonNode.Parse(ticketRaw)["data"];

                foreach (var item in data.AsArray())
                {
                    realms.Add(JsonSerializer.Deserialize<Realm>(item));
                }

                return response;
            }
        }

        public string GetURI()
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> POST()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string s = string.Empty;
            foreach (Realm realm in realms)
            {
                 s += realm + "\n";
            }

            return s;
        }
    }
}
