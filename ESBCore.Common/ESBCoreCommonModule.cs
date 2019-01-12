using Abp.Modules;
using Abp.SqlSugar.Configuration;
using Abp.Redis.Configuration;
using System;
using System.Reflection;
using Abp.MongoDb.Configuration;
using Abp.Email.Configuration;
using Abp.Net.Mail.Smtp;
using Abp.SqlSugar.Repositories;

namespace ESBCore.Common
{
    /// <summary>
    /// This module is used to implement "Data Access Layer" in SqlSugar.
    /// </summary>
    public class ESBCoreCommonModule : AbpModule
    {
        public override void PreInitialize()
        {
            IocManager.Register<ISmtpEmailSenderConfiguration, MySmtpEmailSenderConfiguration>();
            IocManager.Register<IAbpEmailConfiguration, AbpEmailConfiguration>();
            IocManager.Register<IAbpMongoDbConfiguration, AbpMongoDbConfiguration>();
            IocManager.Register<IAbpRedisConfiguration, AbpRedisConfiguration>();
            IocManager.Register<IAbpSqlSugarConfiguration, AbpSqlSugarConfiguration>();
         
    }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
