using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESBCore.SQLData
{
    public class SQLConfig
    {
       
        /// <summary>
        ///DbType.SqlServer Or Other
        ///MySql = 0,
        ///SqlServer = 1,
        ///Sqlite = 2,
        ///Oracle = 3,
        ///PostgreSQL = 4
        /// </summary>
        public DbType DbType { get; set; }
        /// <summary>
        ///Database Connection string
        /// </summary>
        public string ConnectionString { get; set; }
       
    }
}
