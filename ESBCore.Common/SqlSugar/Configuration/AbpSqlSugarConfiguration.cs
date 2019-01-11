using SqlSugar;

namespace Abp.SqlSugar.Configuration
{
   public  class AbpSqlSugarConfiguration : IAbpSqlSugarConfiguration
    {
        public string ConnectionString { get; set; }


        public DbType DbType { get; set; }
    }
}