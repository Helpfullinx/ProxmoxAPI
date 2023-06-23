using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxmoxAPI.access.Domain
{
    public class Domain
    {
        private string realm;
        private string type;


        public Domain() {
            realm = "default";
            type = "pam";
        }

        public Domain(string realm, string type)
        {
            this.realm = realm;
            this.type = type;
        }

        public string Realm { get { return realm; } set { realm = value; } }
        public string Type { get { return type; }  set { type = value; } }

        //TODO: Add GET and POST methods for Domain and Realms
    }
}
