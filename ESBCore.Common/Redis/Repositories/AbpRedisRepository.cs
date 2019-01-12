using Abp.Redis;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Abp.Dependency;

namespace Abp.Redis.Repositories
{
   public class AbpRedisRepository: IAbpRedisRepository, ITransientDependency
  {
        public IDatabase Database
        {
            get { return _databaseProvider.Database; }
        }
        private IAbpRedisDatabaseProvider _databaseProvider;
        public AbpRedisRepository(IAbpRedisDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }
        


    }
}
