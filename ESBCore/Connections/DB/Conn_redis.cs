using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESB.Core.Connections.DB
{
    public class Conn_redis
    {
        public string Key { get; set; }
        public string Connectionstring { get; set; }
        public int DatabaseId { get; set; }
    }

   
}
