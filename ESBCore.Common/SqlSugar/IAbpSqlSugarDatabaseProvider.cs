using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.SqlSugar
{
    public interface IAbpSqlSugarDatabaseProvider
    {

        /// <summary>
        /// Gets the <see cref="MongoDatabase"/>.
        /// </summary>
        SqlSugarClient Database { get; }

    }
}
