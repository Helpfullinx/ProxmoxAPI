using ProxmoxAPI.Access;
using ProxmoxAPI.Access.Domain;
using ProxmoxAPI.Utility.HttpRequests;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace ProxmoxAPI.Utility
{
    public class ProxmoxConnection
    {
        //public User? user { get; set; }
        //public Socket socket { get; set; }

        //public static Uri baseURI()
        //{
        //    return new Uri("https://" + socket + "/");
        //}

        public ProxmoxConnection()
        {
            HttpInterface.client.BaseAddress = new Uri("https://" + Socket.ToString + "/");
        }

        public async Task<Ticket> getTicket()
        {
            return await POST(new Ticket());
        }

        private async Task<T> POST<T>(T item) where T : Postable, HttpRequestable
        { 
            // TODO: Give each object a Serialize, Deserialize function AND URI(s) and BodyData members.
            // TODO: Perform a POST to the server and generalize a serialize function against the generic type

            using HttpResponseMessage response = await HttpInterface.client.PostAsync(item.GetURI(), item.FormContent());
            response.EnsureSuccessStatusCode();

            using HttpContent respContent = response.Content;
            {
                string ticketRaw = respContent.ReadAsStringAsync().Result;
                JsonNode? data = JsonNode.Parse(ticketRaw)["data"];

                return JsonSerializer.Deserialize<T>(data);
            }
        }
    }
}
