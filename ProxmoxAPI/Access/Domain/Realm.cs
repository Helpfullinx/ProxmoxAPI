using ProxmoxAPI.Utility.HttpRequests;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProxmoxAPI.Access.Domain
{
    [Serializable]
    public class Realm : GET, POST
    {
        public enum RealmType
        {
            AD,
            LDAP,
            OPENID,
            PAM,
            PVE
        }

        public enum TfaType
        {
            YUBICO,
            OAUTH
        }

        public Realm (string realm, RealmType type)
        {
            this.realm = realm;
            this.type = type;
        }

        public string realm { get; set; }

        public string comment { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public RealmType type { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TfaType tfa { get; set; }


        public Task<HttpResponseMessage> GET()
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> POST()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

    }
}
