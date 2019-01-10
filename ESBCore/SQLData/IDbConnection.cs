using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESBCore.SQLData
{
    public interface IDbConnection
    {
        SimpleClient GetSQLSimpleClient(SQLConfig config);
    }
}
