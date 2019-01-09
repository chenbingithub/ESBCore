using Abp.Modules;
using Abp.Reflection.Extensions;
using System;

namespace ESBCore.Service
{
    [DependsOn(
     typeof(ESBCoreModule))]
    public class ESBCoreServiceModule : AbpModule
    {
        public override void PreInitialize()
        {
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ESBCoreServiceModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

           
        }
    }
}
