using SqlSugar;

namespace ESBCore.Domain.Entities
{
    public class SqlConfiguration : EntityBase
  {
        public string Key { get; set; }
        public DbType Engine { get; set; }
        public string Connectionstring { get; set; }
    }

}
