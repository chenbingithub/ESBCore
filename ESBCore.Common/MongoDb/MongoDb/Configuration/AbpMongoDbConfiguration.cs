namespace Abp.MongoDb.Configuration
{
    internal class AbpMongoDbConfiguration : IAbpMongoDbConfiguration
    {
        public string ConnectionString { get; set; }

        public string DatatabaseName { get; set; }
    }
}