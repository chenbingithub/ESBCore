using Abp.Dependency;
using Castle.Core.Configuration;
using ESBCore.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESB.Common.Mongo
{
    public   class MongoConfig
    {
       
        public static string ConnectionStrings
        {
            
            get {
                var environment = IocManager.Instance.Resolve<IHostingEnvironment>();
                var configuration = environment.GetAppConfiguration();
                return configuration[AppConfigurationConsts.Mongodb]; }
        }
    }
}
