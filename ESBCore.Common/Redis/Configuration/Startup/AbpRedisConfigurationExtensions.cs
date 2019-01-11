
using Abp.Redis.Configuration;

namespace Abp.Configuration.Startup
{
    /// <summary>
    /// Defines extension methods to <see cref="IModuleConfigurations"/> to allow to configure ABP MongoDb module.
    /// </summary>
    public static class AbpRedisConfigurationExtensions
    {
        /// <summary>
        /// Used to configure ABP SqlSugar module.
        /// </summary>
        public static IAbpRedisConfiguration AbpRedis(this IModuleConfigurations configurations)
        {
            return configurations.AbpConfiguration.Get<IAbpRedisConfiguration>();
        }


    }
}