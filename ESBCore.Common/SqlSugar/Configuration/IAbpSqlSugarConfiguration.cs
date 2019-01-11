using SqlSugar;

namespace Abp.SqlSugar.Configuration
{
    public interface IAbpSqlSugarConfiguration
    {
        string ConnectionString { get; set; }

        /// <summary>
        ///DbType.SqlServer Or Other
        ///MySql = 0,
        ///SqlServer = 1,
        ///Sqlite = 2,
        ///Oracle = 3,
        ///PostgreSQL = 4
        /// </summary>
        DbType DbType { get; set; }
    }
}
