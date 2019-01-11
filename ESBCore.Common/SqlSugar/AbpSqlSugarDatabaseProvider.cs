using Abp.Dependency;
using Abp.SqlSugar.Configuration;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
namespace Abp.SqlSugar
{
   public class AbpSqlSugarDatabaseProvider : IAbpSqlSugarDatabaseProvider, ITransientDependency
    {
        public SqlSugarClient Database { get { return new SqlSugarClient(new ConnectionConfig { ConnectionString = _sqlConfiguration.ConnectionString, DbType = _sqlConfiguration.DbType, IsAutoCloseConnection = true }); } }
        private IAbpSqlSugarConfiguration _sqlConfiguration;
        public AbpSqlSugarDatabaseProvider(IAbpSqlSugarConfiguration sqlConfiguration)
        {
            _sqlConfiguration = sqlConfiguration;
        }
        
    }
}
