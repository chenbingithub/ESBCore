using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESB.Common.Http
{
    public class HttpOperatorFactory
    {
        private readonly static object _lock = new object();
        private static IHttpOperator _instance;
        public static IHttpOperator CreateRepository()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new HttpOperator();
                    }
                }
            }
            return _instance;
        }
    }
}
