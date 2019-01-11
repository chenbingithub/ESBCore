using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESB.Core.Connections.Models
{
   public  class Connection
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ConnectionType Type { get; set; }
    }

    public enum ConnectionType
    {
        email,
        ftp,
        http,
        sql,
        mongo,
        redis
    }
}
