using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.MongoDb.Configuration;
using MongoDB.Driver;

namespace Abp.MongoDb
{
    /// <summary>
    /// Implements <see cref="IMongoDatabaseProvider"/> that gets database from active unit of work.
    /// </summary>
    public class AbpMongoDatabaseProvider : IAbpMongoDatabaseProvider, ITransientDependency
    {
        public MongoDatabase Database { get;private set; }


        private readonly IAbpMongoDbConfiguration _configuration;

        public AbpMongoDatabaseProvider(IAbpMongoDbConfiguration mongoDbConfiguration)
        {
            _configuration = mongoDbConfiguration;
            Database = new MongoClient(_configuration.ConnectionString)
            .GetServer()
            .GetDatabase(_configuration.DatatabaseName);
        }
    }
}