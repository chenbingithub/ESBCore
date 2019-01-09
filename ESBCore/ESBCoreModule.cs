using Abp.Hangfire;
using Abp.Hangfire.Configuration;
using Abp.MailKit;
using Abp.Modules;
using Abp.Net.Mail.Smtp;
using Abp.Reflection.Extensions;
using Abp.Runtime.Caching.Redis;
using ESBCore.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;

namespace ESBCore
{
    [DependsOn(typeof(AbpHangfireAspNetCoreModule), typeof(AbpMailKitModule), typeof(AbpRedisCacheModule))]
    public class ESBCoreModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;
        public ESBCoreModule(IHostingEnvironment env)
        {
            _appConfiguration = env.GetAppConfiguration();
        }
        public override void PreInitialize()
        {
            IocManager.Register<ISmtpEmailSenderConfiguration, MySmtpEmailSenderConfiguration>();
            //使用hangfire
            Configuration.BackgroundJobs.UseHangfire();

            //设置所有缓存的默认过期时间
            Configuration.Caching.ConfigureAll(cache =>
            {
                cache.DefaultAbsoluteExpireTime = TimeSpan.FromMinutes(2);
            });
            //设置某个缓存的默认过期时间 根据 "CacheName" 来区分
            Configuration.Caching.Configure("CacheName", cache =>
            {
                cache.DefaultAbsoluteExpireTime = TimeSpan.FromMinutes(2);
            });
            //使用redis数据库缓存
            Configuration.Caching.UseRedis(option =>
            {
                option.ConnectionString = _appConfiguration["Abp:RedisCache:ConnectionStrings"];
                option.DatabaseId = int.Parse(_appConfiguration["Abp:RedisCache:DatabaseId"]);
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ESBCoreModule).GetAssembly());
        }
    }
}
