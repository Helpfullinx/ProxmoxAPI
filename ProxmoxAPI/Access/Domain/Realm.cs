using ProxmoxAPI.Utility.HttpRequests;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProxmoxAPI.Access.Domain
{
    [Serializable]
    public class Realm : Postable, HttpRequestable
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

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

        public FormUrlEncodedContent FormContent()
        {
            throw new NotImplementedException();
        }

        public string GetURI()
        {
            throw new NotImplementedException();
        }
    }
}
