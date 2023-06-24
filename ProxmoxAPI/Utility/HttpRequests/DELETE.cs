using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxmoxAPI.Utility.HttpRequests
{
    public interface DELETE
    {
        Task<HttpResponseMessage> DELETE();
    }
}
