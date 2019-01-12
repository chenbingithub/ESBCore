using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESB.Common.Http
{
    public interface IHttpConnection
    {
        string ConnectionUrl { get; }
        int ConnectionTimeout { get; }
        string BaseUrl { get; set; }
        string QueryUrl { get; set; }
    }
}
