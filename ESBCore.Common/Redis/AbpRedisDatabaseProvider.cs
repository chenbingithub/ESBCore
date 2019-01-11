using Abp.Dependency;
using Abp.Redis.Configuration;
using Abp.SqlSugar.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
namespace Abp.Redis
{
   public class AbpRedisDatabaseProvider: IAbpRedisDatabaseProvider, ITransientDependency
    {
        public IDatabase Database { get { return ConnectionMultiplexer.Connect(_sqlConfiguration.ConnectionString).GetDatabase(_sqlConfiguration.DatabaseId); } }

        private IAbpRedisConfiguration _sqlConfiguration;
        public AbpRedisDatabaseProvider(IAbpRedisConfiguration redisConfiguration)
        {
            _sqlConfiguration = redisConfiguration;
            
        }
        
    }
}
