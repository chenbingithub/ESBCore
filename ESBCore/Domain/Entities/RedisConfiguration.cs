namespace ESBCore.Domain.Entities
{
    public class RedisConfiguration : EntityBase
  {
        public string Key { get; set; }
        public string Connectionstring { get; set; }
        public int DatabaseId { get; set; }
    }

   
}
