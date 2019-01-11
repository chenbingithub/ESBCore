using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESB.Core.Connections.DB
{
    public class Conn_sql
    {
        public string Key { get; set; }
        //public bool is_active { get; set; }
        public DbType Engine { get; set; }
        public string Connectionstring { get; set; }
    }

}
