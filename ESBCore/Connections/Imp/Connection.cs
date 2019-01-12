using System;
using Abp.Email.Configuration;
using Abp.MongoDb.Configuration;
using Abp.Redis;
using Abp.Redis.Configuration;
using Abp.SqlSugar.Configuration;
using ESB.Common.FTP;
using ESB.Common.Http;
using ESB.Common.Redis;
using ESBCore.Configuration;
using ESBCore.Domain.Entities;
using StackExchange.Redis;

namespace ESBCore.Connections.Imp
{
    public class Connection 
    {
        private IDatabase kvclient;
        public Connection()
        {
            kvclient = RedisClientFactory.CreateRepository(AppConfigurationConsts.RedisConnectionString());
        }
        public void GetEmailConn(Domain.Entities.Connection con)
        {
            var email = kvclient.GetStringKey<EmailConfiguration>("Conn:email:" + con.Name);
            if (email == null)
            {
                throw new Exception("未找到对应连接");
            }
            AppConfigurationConsts.EmailConfiguration(new AbpEmailConfiguration {
                Host = email.Host,
                Port = email.Port,
                UserName = email.UserName,
                Password = email.Password,
            });
        }
        public void GetMongoConn(Domain.Entities.Connection con)
        {
            var mongo = kvclient.GetStringKey<MongoConfiguration>("Conn:Mongo:" + con.Name);
            if (mongo == null)
            {
                throw new Exception("未找到对应连接");
            }
            AppConfigurationConsts.MongoConfiguration(new AbpMongoDbConfiguration
            {
               ConnectionString= mongo.Connectionstring,
                DatatabaseName = mongo.DatatabaseName,
            });
        }
        public void GetRedisConn(Domain.Entities.Connection con)
        {
            var redis = kvclient.GetStringKey<RedisConfiguration>("Conn:redis:" + con.Name);
            if (redis == null)
            {
                throw new Exception("未找到对应连接");
            }
            AppConfigurationConsts.RedisConfiguration(new AbpRedisConfiguration
            {
                ConnectionString=redis.Connectionstring,
                DatabaseId=redis.DatabaseId
            });
        }
        public FtpOperator Getftpconn(Domain.Entities.Connection con)
        {
            var ftp = kvclient.GetStringKey<FtpConfiguration>("Conn:ftp:" + con.Name);
            if (ftp == null)
            {
                throw new Exception("未找到对应连接");
            }
            return new FtpOperator(new Uri(ftp.Host), ftp.Username, ftp.Password);
        }

        public IHttpConnection Gethttpconn(Domain.Entities.Connection con)
        {
            var http = kvclient.GetStringKey<HttpConfiguration>("Conn:http:" + con.Name);
            if (http == null)
            {
                throw new Exception("未找到对应连接");
            }

            return ESB.Common.Http.SessionFactory.CreateHttpConnection(http.Host);
        }

        public void Getsqlconn(Domain.Entities.Connection con)
        {
            var sql = kvclient.GetStringKey<SqlConfiguration>("Conn:sql:" + con.Name);
            if (sql == null)
            {
                throw new Exception("未找到对应连接");
            }
            AppConfigurationConsts.SqlSugarConfiguration(new AbpSqlSugarConfiguration {
                ConnectionString = sql.Connectionstring,
                DbType = sql.Engine

            } );

        }
    }
}
