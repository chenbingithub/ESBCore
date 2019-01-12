
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESB.Common.Http
{
    public class HttpConnection : IHttpConnection
    {
        public HttpConnection()
        {

        }
        public int ConnectionTimeout
        {
            get
            {
                return 200;
            }
        }
        public string BaseUrl
        {
            get;set;
        }

        public string ConnectionUrl
        {
            get { return BaseUrl + QueryUrl; }
        }

        public string QueryUrl
        {
            get;
            set;
        }
    }
}
