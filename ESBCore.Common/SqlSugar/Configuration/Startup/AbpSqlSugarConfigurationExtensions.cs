
using Abp.Configuration.Startup;
using Abp.SqlSugar.Configuration;

namespace Abp.Configuration.Startup
{
    /// <summary>
    /// Defines extension methods to <see cref="IModuleConfigurations"/> to allow to configure ABP  module.
    /// </summary>
    public static class AbpSqlSugarConfigurationExtensions
    {
        /// <summary>
        /// Used to configure ABP SqlSugar module.
        /// </summary>
        public static IAbpSqlSugarConfiguration AbpSqlSugar(this IModuleConfigurations configurations)
        {
            return configurations.AbpConfiguration.Get<IAbpSqlSugarConfiguration>();
        }
    }
}