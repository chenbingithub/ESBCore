
using Abp.Dependency;
using ESBCore.Configuration;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESB.Common.KVData
{
    public   class RedisConfig
    {
        public static string ConnectionStrings
        {
            get
            {
                var environment = IocManager.Instance.Resolve<IHostingEnvironment>();
                var configuration = environment.GetAppConfiguration();
                return configuration[AppConfigurationConsts.RedisCache];
            }
        }
        public static string DatabaseId
        {
            get
            {
                var environment = IocManager.Instance.Resolve<IHostingEnvironment>();
                var configuration = environment.GetAppConfiguration();
                return configuration[AppConfigurationConsts.RedisCacheDatabaseId];
            }
        }

    }
}
