using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxmoxAPI.Utility.HttpRequests
{
    internal interface HttpRequestable
    {
        public string GetURI();
    }
}
