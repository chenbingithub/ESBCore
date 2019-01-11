using Abp.Redis;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Abp.Redis.Repositories
{
   public class AbpRedisRepositoryBase
    {
        public IDatabase Database
        {
            get { return _databaseProvider.Database; }
        }
        private IAbpRedisDatabaseProvider _databaseProvider;
        public AbpRedisRepositoryBase(IAbpRedisDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }
        #region String 可以设置过期时间

        /// <summary>
        /// 保存单个key value
        /// </summary>
        /// <param name="key">Redis Key</param>
        /// <param name="value">保存的值</param>
        /// <param name="expiry">过期时间</param>
        /// <returns></returns>
        public bool SetStringKey(string key, string value, TimeSpan? expiry = default(TimeSpan?))
        {
            return Database.StringSet(key, value, expiry);
        }

        /// <summary>
        /// 保存多个key value
        /// </summary>
        /// <param name="arr">key</param>
        /// <returns></returns>
        public bool SetStringKey(KeyValuePair<RedisKey, RedisValue>[] arr)
        {
            return Database.StringSet(arr);
        }

        /// <summary>
        /// 保存一个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool SetStringKey<T>(string key, T obj, TimeSpan? expiry = default(TimeSpan?))
        {
            string json = JsonConvert.SerializeObject(obj);
            return Database.StringSet(key, json, expiry);
        }

        /// <summary>
        /// 获取单个key的值
        /// </summary>
        /// <param name="key">Redis Key</param>
        /// <returns></returns>

        public RedisValue GetStringKey(string key)
        {
            return Database.StringGet(key);
        }


        /// <summary>
        /// 获取多个Key
        /// </summary>
        /// <param name="listKey">Redis Key集合</param>
        /// <returns></returns>
        public RedisValue[] GetStringKey(List<RedisKey> listKey)
        {
            return Database.StringGet(listKey.ToArray());
        }

        /// <summary>
        /// 获取一个key的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetStringKey<T>(string key)
        {
            return JsonConvert.DeserializeObject<T>(Database.StringGet(key));
        }


        #endregion

        #region Hash

        /// <summary>
        /// 保存一个集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">Redis Key</param>
        /// <param name="list">数据集合</param>
        /// <param name="getModelId"></param>
        public void HashSet<T>(string key, List<T> list, Func<T, string> getModelId)
        {
            List<HashEntry> listHashEntry = new List<HashEntry>();
            foreach (var item in list)
            {
                string json = JsonConvert.SerializeObject(item);
                listHashEntry.Add(new HashEntry(getModelId(item), json));
            }
            Database.HashSet(key, listHashEntry.ToArray());
        }

        /// <summary>
        /// 获取Hash中的单个key的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">Redis Key</param>
        /// <param name="hasFildValue">RedisValue</param>
        /// <returns></returns>
        public T GetHashKey<T>(string key, string hasFildValue)
        {
            if (!string.IsNullOrWhiteSpace(key) && !string.IsNullOrWhiteSpace(hasFildValue))
            {
                RedisValue value = Database.HashGet(key, hasFildValue);
                if (!value.IsNullOrEmpty)
                {
                    return JsonConvert.DeserializeObject<T>(value);
                }
            }
            return default(T);
        }

        /// <summary>
        /// 获取hash中的多个key的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">Redis Key</param>
        /// <param name="listhashFields">RedisValue value</param>
        /// <returns></returns>
        public List<T> GetHashKey<T>(string key, List<RedisValue> listhashFields)
        {
            List<T> result = new List<T>();
            if (!string.IsNullOrWhiteSpace(key) && listhashFields.Count > 0)
            {
                RedisValue[] value = Database.HashGet(key, listhashFields.ToArray());
                foreach (var item in value)
                {
                    if (!item.IsNullOrEmpty)
                    {
                        result.Add(JsonConvert.DeserializeObject<T>(item));
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 获取hashkey所有Redis key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<T> GetHashAll<T>(string key)
        {
            List<T> result = new List<T>();
            RedisValue[] arr = Database.HashKeys(key);
            foreach (var item in arr)
            {
                if (!item.IsNullOrEmpty)
                {
                    result.Add(JsonConvert.DeserializeObject<T>(item));
                }
            }
            return result;
        }

        /// <summary>
        /// 获取hashkey所有的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<T> HashGetAll<T>(string key)
        {
            List<T> result = new List<T>();
            HashEntry[] arr = Database.HashGetAll(key);
            foreach (var item in arr)
            {
                if (!item.Value.IsNullOrEmpty)
                {
                    result.Add(JsonConvert.DeserializeObject<T>(item.Value));
                }
            }
            return result;
        }

        /// <summary>
        /// 删除hasekey
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashField"></param>
        /// <returns></returns>
        public bool DeleteHase(RedisKey key, RedisValue hashField)
        {
            return Database.HashDelete(key, hashField);
        }

        #endregion

        #region key

        /// <summary>
        /// 删除单个key
        /// </summary>
        /// <param name="key">redis key</param>
        /// <returns>是否删除成功</returns>
        public bool KeyDelete(string key)
        {
            return Database.KeyDelete(key);
        }

        /// <summary>
        /// 删除多个key
        /// </summary>
        /// <param name="keys">rediskey</param>
        /// <returns>成功删除的个数</returns>
        public long KeyDelete(RedisKey[] keys)
        {
            return Database.KeyDelete(keys);
        }

        /// <summary>
        /// 判断key是否存储
        /// </summary>
        /// <param name="key">redis key</param>
        /// <returns></returns>
        public bool KeyExists(string key)
        {
            return Database.KeyExists(key);
        }

        /// <summary>
        /// 重新命名key
        /// </summary>
        /// <param name="key">就的redis key</param>
        /// <param name="newKey">新的redis key</param>
        /// <returns></returns>
        public bool KeyRename(string key, string newKey)
        {
            return Database.KeyRename(key, newKey);
        }
        #endregion


        /// <summary>
        /// 追加值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void StringAppend(string key, string value)
        {
            ////追加值，返回追加后长度
            long appendlong = Database.StringAppend(key, value);
        }


    }
}
