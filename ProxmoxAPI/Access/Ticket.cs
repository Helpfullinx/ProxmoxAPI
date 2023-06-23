using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using ProxmoxAPI.Utility;

namespace ProxmoxAPI.Access
{
    public class Ticket : POST
    {
        private string ticket;
        private string clusterName;
        private string CSRFPreventionToken;
        private Connection connection;

        public Ticket()
        {
            ticket = string.Empty;
            clusterName = string.Empty;
            CSRFPreventionToken = string.Empty;
            connection = new Connection();
        }

        public Ticket(string ticket, string clusterName, string csrfPreventationToken)
        {
            this.ticket = ticket;
            this.clusterName = clusterName;
            CSRFPreventionToken = csrfPreventationToken;
            connection = new Connection();
        }

        /// <summary>
        /// Takes a Connection object and performs an HTTP request against the server to obtain the values for the ticket, CSRFPrevention Token, and the clusterName
        /// </summary>
        /// <param name="con"></param>
        public Ticket(Connection con)
        {
            connection = con;
            var ticket_raw = POST().Result;
            var data = JsonObject.Parse(ticket_raw)["data"];

            ticket = data["ticket"].ToString();
            CSRFPreventionToken = data["CSRFPreventionToken"].ToString();
            clusterName = data["clustername"].ToString();

        }

        public string getTicket { get { return ticket; } }
        public string getCSRFPreventionToken { get { return CSRFPreventionToken; } }
        public string getClusterName { get { return clusterName; } }

        public async Task<string> POST()
        {
            var values = new Dictionary<string, string>
            {
                { "username", connection.User.UserName },
                { "password", connection.User.Password }
            };

            var content = new FormUrlEncodedContent(values);

            var requestUri = "api2/json/access/ticket";

            using HttpResponseMessage response = await HttpInterface.Get(connection.baseURI()).PostAsync(requestUri, content);
            {
                using HttpContent respContent = response.Content;
                {
                    return respContent.ReadAsStringAsync().Result;
                }
            }
        }
    }
}
