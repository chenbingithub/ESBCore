using Abp.Redis;
using ESB.Common.Redis;
using ESBCore.Configuration;
using ESBCore.Domain.Entities;
using StackExchange.Redis;

namespace ESBCore.Connections.Imp
{
    public class ConnectionManage : IConnectionManage
    {
        private IDatabase _kvclient;
        public ConnectionManage()
        {
            _kvclient = RedisClientFactory.CreateRepository(AppConfigurationConsts.RedisConnectionString());
        }
        public EmailConfiguration Getemailconn(string con)
        {
            
            return _kvclient.GetStringKey<EmailConfiguration>("Conn:email:" + con);
        }

        public FtpConfiguration Getftpconn(string con)
        {
            
            return _kvclient.GetStringKey<FtpConfiguration>("Conn:ftp:" + con);
        }

        public HttpConfiguration Gethttpconn(string con)
        {
            
            return _kvclient.GetStringKey<HttpConfiguration>("Conn:http:" + con);
        }

        public SqlConfiguration Getsqlconn(string con)
        {
            
            return _kvclient.GetStringKey<SqlConfiguration>("Conn:sql:" + con);
        }

        public bool Setemailconn(EmailConfiguration con)
        {
            
            return _kvclient.SetStringKey<EmailConfiguration>("Conn:email:" + con.Key, con);
        }

        public bool Setftpconn(FtpConfiguration con)
        {
            
            return _kvclient.SetStringKey<FtpConfiguration>("Conn:ftp:" + con.Key, con);
        }

        public bool Sethttpconn(HttpConfiguration con)
        {
            
            return _kvclient.SetStringKey<HttpConfiguration>("Conn:http:" + con.Key, con);
        }

        public bool Setsqlconn(SqlConfiguration con)
        {
            
            return _kvclient.SetStringKey<SqlConfiguration>("Conn:sql:" + con.Key, con);
        }
    }
}
