using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESB.Common.Mongo
{
    public class MongoClientFactory
    {
        private readonly static object _lock = new object();
        private static  IMongoClient _client;
        public static IMongoDatabase CreateRepository()
        {
            if(_client==null)
            {
                lock (_lock)
                {
                    if (_client == null)
                    {
                        _client = new MongoClient(MongoConfig.ConnectionStrings);
                    }
                }
            }
            
            return _client.GetDatabase("esbcore_db");
        }
    }
}
