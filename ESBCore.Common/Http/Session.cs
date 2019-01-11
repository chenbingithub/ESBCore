using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESB.Common.Http
{
    public  class SessionFactory
    {
        public static IHttpConnection CreateHttpConnection(string strConn)
        {
            IHttpConnection conn = new HttpConnection();
            conn.BaseUrl = strConn;
            return conn;
        }
    }
}
