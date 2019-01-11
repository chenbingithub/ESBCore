using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Redis;
using ESB.Common.Redis;
using ESB.Core.Connections.DB;
using ESBCore.Configuration;
using StackExchange.Redis;

namespace ESB.Core.Connections.Imp
{
    public class ConnectionManage : IConnectionManage
    {
        private IDatabase kvclient;
        public ConnectionManage()
        {
            kvclient = RedisClientFactory.CreateRepository(AppConfigurationConsts.RedisConnectionString());
        }
        public Conn_email Getemailconn(string con)
        {
            
            return kvclient.GetStringKey<Conn_email>("Conn:email:" + con);
        }

        public Conn_ftp Getftpconn(string con)
        {
            
            return kvclient.GetStringKey<Conn_ftp>("Conn:ftp:" + con);
        }

        public Conn_http Gethttpconn(string con)
        {
            
            return kvclient.GetStringKey<Conn_http>("Conn:http:" + con);
        }

        public Conn_sql Getsqlconn(string con)
        {
            
            return kvclient.GetStringKey<Conn_sql>("Conn:sql:" + con);
        }

        public bool Setemailconn(Conn_email con)
        {
            
            return kvclient.SetStringKey<Conn_email>("Conn:email:" + con.Key, con);
        }

        public bool Setftpconn(Conn_ftp con)
        {
            
            return kvclient.SetStringKey<Conn_ftp>("Conn:ftp:" + con.key, con);
        }

        public bool Sethttpconn(Conn_http con)
        {
            
            return kvclient.SetStringKey<Conn_http>("Conn:http:" + con.key, con);
        }

        public bool Setsqlconn(Conn_sql con)
        {
            
            return kvclient.SetStringKey<Conn_sql>("Conn:sql:" + con.Key, con);
        }
    }
}
