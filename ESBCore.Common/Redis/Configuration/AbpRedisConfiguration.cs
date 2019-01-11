
namespace Abp.Redis.Configuration
{
   public  class AbpRedisConfiguration : IAbpRedisConfiguration
    {
        public AbpRedisConfiguration()
        {
            DatabaseId = -1;
        }
        public string ConnectionString { get; set; }
        public int DatabaseId { get; set; }
    }
}