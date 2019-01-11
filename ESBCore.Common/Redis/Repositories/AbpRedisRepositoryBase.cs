using Abp.Redis;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Abp.Redis.Repositories
{
   public class AbpRedisRepositoryBase
    {
        public IDatabase Database
        {
            get { return _databaseProvider.Database; }
        }
        private IAbpRedisDatabaseProvider _databaseProvider;
        public AbpRedisRepositoryBase(IAbpRedisDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }
        


    }
}
