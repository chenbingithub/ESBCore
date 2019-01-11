namespace Abp.MongoDb.Configuration
{
    public class AbpMongoDbConfiguration : IAbpMongoDbConfiguration
    {
        public string ConnectionString { get; set; }

        public string DatatabaseName { get; set; }
    }
}