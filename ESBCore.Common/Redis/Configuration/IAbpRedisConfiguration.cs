
namespace Abp.Redis.Configuration
{
    public interface IAbpRedisConfiguration
    {
         string ConnectionString { get; set; }
         int DatabaseId { get; set; }
    }
}
