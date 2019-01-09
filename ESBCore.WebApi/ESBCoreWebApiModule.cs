using Abp.Modules;
using Abp.Reflection.Extensions;
using ESBCore.Configuration;
using ESBCore.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;

namespace ESBCore.WebApi
{
    [DependsOn(typeof(ESBCoreServiceModule), typeof(AbpAspNetCoreModule))]
    public class ESBCoreWebApiModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public ESBCoreWebApiModule(IHostingEnvironment env)
        {
            _appConfiguration = env.GetAppConfiguration();
        }

      public override void PreInitialize()
      {
          Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(
              typeof(ESBCoreServiceModule).GetAssembly()
            );
    }

      public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ESBCoreWebApiModule).GetAssembly());
        }
    }
}
