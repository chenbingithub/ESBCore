using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Email.Configuration;
using Abp.MongoDb.Configuration;
using Abp.Redis.Configuration;
using Abp.SqlSugar.Configuration;
using Microsoft.AspNetCore.Hosting;
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

        public const string Mongo = "Abp:Mongo:ConnectionStrings";
        public const string MongoDatatabaseName = "Abp:Mongo:DatatabaseName";


        public static string RedisConnectionString() {
            var _appConfiguration = IocManager.Instance.Resolve<IHostingEnvironment>().GetAppConfiguration();
            return _appConfiguration[AppConfigurationConsts.RedisCache];
        }
        public static void EmailConfiguration(IAbpEmailConfiguration configuration=null) {
        var abpStartupConfiguration = IocManager.Instance.Resolve<IAbpStartupConfiguration>();
        var _appConfiguration = IocManager.Instance.Resolve<IHostingEnvironment>().GetAppConfiguration();

        abpStartupConfiguration.Modules.AbpEmail().Host= configuration!=null? configuration.Host:_appConfiguration["Abp:Email:Smtp:Host"];
        abpStartupConfiguration.Modules.AbpEmail().Port= configuration != null ? configuration.Port : int.Parse(_appConfiguration["Abp:Email:Smtp:Port"]);
        abpStartupConfiguration.Modules.AbpEmail().DefaultFromAddress = configuration != null ? configuration.UserName : _appConfiguration["Abp:Email:Smtp:UserName"];
        abpStartupConfiguration.Modules.AbpEmail().DefaultFromDisplayName=_appConfiguration["Abp:Email:Smtp:DefaultFromDisplayName"];

        abpStartupConfiguration.Modules.AbpEmail().Domain=_appConfiguration["Abp:Email:Smtp:Domain"];

        abpStartupConfiguration.Modules.AbpEmail().EnableSsl=bool.Parse(_appConfiguration["Abp:Email:Smtp:EnableSsl"]);
        abpStartupConfiguration.Modules.AbpEmail().UserName= configuration != null ? configuration.UserName : _appConfiguration["Abp:Email:Smtp:UserName"];
        abpStartupConfiguration.Modules.AbpEmail().Password= configuration != null ? configuration.Password : _appConfiguration["Abp:Email:Smtp:Password"];
        abpStartupConfiguration.Modules.AbpEmail().UseDefaultCredentials=bool.Parse(_appConfiguration["Abp:Email:Smtp:UseDefaultCredentials"]);
        }
        public static void RedisConfiguration(IAbpRedisConfiguration configuration=null)
        {
            var abpStartupConfiguration = IocManager.Instance.Resolve<IAbpStartupConfiguration>();
            var _appConfiguration = IocManager.Instance.Resolve<IHostingEnvironment>().GetAppConfiguration();
            abpStartupConfiguration.Modules.AbpRedis().ConnectionString = configuration != null ? configuration.ConnectionString : _appConfiguration[RedisCache];
            abpStartupConfiguration.Modules.AbpRedis().DatabaseId = configuration != null ? configuration.DatabaseId : int.Parse(_appConfiguration[RedisCacheDatabaseId]);
        }
        public static void MongoConfiguration(IAbpMongoDbConfiguration configuration=null)
        {
            var abpStartupConfiguration = IocManager.Instance.Resolve<IAbpStartupConfiguration>();
            var _appConfiguration = IocManager.Instance.Resolve<IHostingEnvironment>().GetAppConfiguration();
            abpStartupConfiguration.Modules.AbpMongoDb().ConnectionString = configuration != null ? configuration.ConnectionString : _appConfiguration[Mongo];
            abpStartupConfiguration.Modules.AbpMongoDb().DatatabaseName = configuration != null ? configuration.ConnectionString : _appConfiguration[MongoDatatabaseName];
        }
        public static void SqlSugarConfiguration(IAbpSqlSugarConfiguration configuration)
        {
            var abpStartupConfiguration = IocManager.Instance.Resolve<IAbpStartupConfiguration>();

            abpStartupConfiguration.Modules.AbpSqlSugar().ConnectionString = configuration.ConnectionString ;
            abpStartupConfiguration.Modules.AbpSqlSugar().DbType = configuration.DbType;
            
        }
    }
}
