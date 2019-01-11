using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ESB.Common.Http
{
    public interface IHttpOperator
    {
        T Post<T>(IHttpConnection conn, object content);
        T Put<T>(IHttpConnection conn, object content);
        T Delete<T>(IHttpConnection conn);
        T Get<T>(IHttpConnection conn);
        void TryGet(IHttpConnection conn);
        void TryPost(IHttpConnection conn, object content);
    }
}
