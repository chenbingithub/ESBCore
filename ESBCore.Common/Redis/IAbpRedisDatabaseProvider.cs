using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.Redis
{
    public interface IAbpRedisDatabaseProvider
    {

        /// <summary>
        /// Gets the <see cref="RedisDatabase"/>.
        /// </summary>
        IDatabase Database { get; }

    }
}
