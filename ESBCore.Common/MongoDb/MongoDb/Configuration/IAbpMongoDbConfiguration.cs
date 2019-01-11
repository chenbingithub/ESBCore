namespace Abp.MongoDb.Configuration
{
    public interface IAbpMongoDbConfiguration
    {
        string ConnectionString { get; set; }

        string DatatabaseName { get; set; }
    }
}
