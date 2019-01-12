namespace ESBCore.Domain.Entities
{
    public class MongoConfiguration : EntityBase
  {
        public string Key { get; set; }
        public string Connectionstring { get; set; }
        public string DatatabaseName { get; set; }
    }

   
}
