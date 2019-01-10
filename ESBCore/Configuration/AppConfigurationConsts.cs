using System;
using System.Collections.Generic;
using System.Text;

namespace ESBCore.Configuration
{
    public class AppConfigurationConsts
    {
        /// <summary>
        /// mongo数据库连接key
        /// </summary>
        public const string Mongodb = "Abp:Mongodb:ConnectionStrings"; 
        /// <summary>
        /// Hangfire连接redis数据库key
        /// </summary>
        public const string HangfireRedis = "Abp:HangfireRedis:ConnectionStrings"; 

        public const string RedisCache = "Abp:RedisCache:ConnectionStrings"; 

        public const string RedisCacheDatabaseId = "Abp:RedisCache:DatabaseId";


    }
}
