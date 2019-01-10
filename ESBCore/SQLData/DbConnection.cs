using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
namespace ESBCore.SQLData
{
   public class DbConnection: IDbConnection
    {
        /// <summary>
        /// 创建连接配置
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="dbType"> 
        ///MySql = 0,
        ///SqlServer = 1,
        ///Sqlite = 2,
        ///Oracle = 3,
        ///PostgreSQL = 4
        ///<param>
        /// <returns></returns>
        public SimpleClient GetSQLSimpleClient(SQLConfig config)
        {
            return new SimpleClient(new SqlSugarClient(new ConnectionConfig { ConnectionString = config.ConnectionString, DbType=config.DbType, IsAutoCloseConnection=config.IsAutoCloseConnection }));
        }
    }
}
