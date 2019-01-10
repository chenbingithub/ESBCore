using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESB.Common.KVData
{
    public class RedisClientFactory
    {
        private readonly static object _lock = new object();
        private static IDatabase _instance;
        /// <summary>
        /// 单例模式获取redis连接实例
        /// </summary>
        public static IDatabase CreateRepository(string connectionStrings)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = ConnectionMultiplexer.Connect(connectionStrings).GetDatabase();
                }
            }
            return _instance;
        }
    }
}
