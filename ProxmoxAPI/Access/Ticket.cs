using System.Text.Json;
using System.Text.Json.Nodes;
using ProxmoxAPI.Utility;
using ProxmoxAPI.Utility.HttpRequests;

namespace ProxmoxAPI.Access
{

    /// <summary>
    /// Class that holds <c>Ticket</c> information as defined by <see url="https://pve.proxmox.com/pve-docs/api-viewer/#/access/ticket" />
    /// </summary>
    public class Ticket : HttpRequestable, Postable
    {
        const string requestUri = "api2/json/access/ticket";

        public string username { get; set; }
        public string ticket { get; set; }
        public string clustername { get; set; }
        public string CSRFPreventionToken { get; set; }

        public Ticket()
        {
        }

        public string GetURI()
        {
            return requestUri;
        }

        public FormUrlEncodedContent FormContent()
        {
            Dictionary<string, string> values = new()
                {
                    { "username", User.Username },
                    { "password", User.Password }
                };
            return new FormUrlEncodedContent(values);
        }

        #region Object Override

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

        #endregion
    }
}
