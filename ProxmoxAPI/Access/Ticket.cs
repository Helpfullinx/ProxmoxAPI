using System.Text.Json;
using System.Text.Json.Nodes;
using ProxmoxAPI.Utility;
using ProxmoxAPI.Utility.HttpRequests;

namespace ProxmoxAPI.Access
{
    [Serializable]
    public class Ticket : POST 
    {
        const string requestUri = "api2/json/access/ticket";

        public string username { get; set; }
        public string ticket { get; set; }
        public string clustername { get; set; }
        public string CSRFPreventionToken { get; set; }

        public Ticket()
        {
        }

        /// <summary>
        /// Populates the Ticket given there is a username and password
        /// </summary>
        public async Task<HttpResponseMessage> POST()
        {
            Connection.user.EnsureUserAndPassNonNull();
            Dictionary<string, string> values = new()
            {
                { "username", Connection.user.UserName },
                { "password", Connection.user.Password }
            };

            FormUrlEncodedContent content = new FormUrlEncodedContent(values);

            using HttpResponseMessage response = await HttpInterface.client.PostAsync(requestUri, content);
            response.EnsureSuccessStatusCode();
            using HttpContent respContent = response.Content;
            {
                string ticketRaw = respContent.ReadAsStringAsync().Result;

               // Console.WriteLine(ticketRaw);

                JsonNode data = JsonNode.Parse(ticketRaw)["data"];

                //Console.WriteLine(data.ToString());
                username = data["username"].ToString();

                ticket = data["ticket"].ToString();
                CSRFPreventionToken = data["CSRFPreventionToken"].ToString();

                var test = data["clustername"];
                clustername = (test == null) ? string.Empty : test.ToString();


                return response;
            }
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
