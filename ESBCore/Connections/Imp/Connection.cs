using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESB.Common.FTP;
using ESB.Common.Http;
using ESB.Core.Connections.Models;
using ESB.Core.Connections.DB;
using System.Net.Mail;
using ESB.Common.Redis;
using Abp.Redis;
using StackExchange.Redis;
using ESBCore.Configuration;
using Abp.SqlSugar.Configuration;
using Abp.Email.Configuration;
using Abp.MongoDb.Configuration;
using Abp.Redis.Configuration;

namespace ESB.Core.Connections.Imp
{
    public class Connection : IConnection
    {
        private IDatabase kvclient;
        public Connection()
        {
            kvclient = RedisClientFactory.CreateRepository(AppConfigurationConsts.RedisConnectionString());
        }
        public void GetEmailConn(Models.Connection con)
        {
            var email = kvclient.GetStringKey<Conn_email>("Conn:email:" + con.Name);
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
        public void GetMongoConn(Models.Connection con)
        {
            var mongo = kvclient.GetStringKey<Conn_mongo>("Conn:Mongo:" + con.Name);
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
        public void GetRedisConn(Models.Connection con)
        {
            var redis = kvclient.GetStringKey<Conn_redis>("Conn:redis:" + con.Name);
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
        public FtpOperator Getftpconn(Models.Connection con)
        {
            var ftp = kvclient.GetStringKey<Conn_ftp>("Conn:ftp:" + con.Name);
            if (ftp == null)
            {
                throw new Exception("未找到对应连接");
            }
            return new FtpOperator(new Uri(ftp.host), ftp.username, ftp.passwd);
        }

        public IHttpConnection Gethttpconn(Models.Connection con)
        {
            var http = kvclient.GetStringKey<Conn_http>("Conn:http:" + con.Name);
            if (http == null)
            {
                throw new Exception("未找到对应连接");
            }

            return Common.Http.SessionFactory.CreateHttpConnection(http.host);
        }

        public void Getsqlconn(Models.Connection con)
        {
            var sql = kvclient.GetStringKey<Conn_sql>("Conn:sql:" + con.Name);
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
