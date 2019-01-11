using Abp.MongoDb.Configuration;
using Abp.Email.Configuration;

namespace Abp.Configuration.Startup
{
    /// <summary>
    /// Defines extension methods to <see cref="IModuleConfigurations"/> to allow to configure ABP MongoDb module.
    /// </summary>
    public static class AbpEmailConfigurationExtensions
    {
        /// <summary>
        /// Used to configure ABP MongoDb module.
        /// </summary>
        public static IAbpEmailConfiguration AbpEmail(this IModuleConfigurations configurations)
        {
            return configurations.AbpConfiguration.Get<IAbpEmailConfiguration>();
            
        }
    }
}