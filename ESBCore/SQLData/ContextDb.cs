using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
namespace ESBCore.SQLData
{
   public class ContextDb
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static SqlSugarClient CreateRepository(SQLConfig config)
        {
            return new SqlSugarClient(new ConnectionConfig { ConnectionString = config.ConnectionString, DbType = config.DbType, IsAutoCloseConnection = true });
        }
    }
}
