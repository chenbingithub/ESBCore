using System;
using System.Collections.Generic;
using System.Text;
using StackExchange.Redis;

namespace Abp.Redis.Repositories
{
    public interface IAbpRedisRepository
    {
      IDatabase Database { get; }
    }
}
