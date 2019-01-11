using ESB.Common.FTP;
using ESB.Common.Http;
using ESB.Core.Connections.DB;
using ESB.Core.Connections.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ESB.Core.Connections
{
    public interface IConnectionManage
    {
        Conn_http Gethttpconn(string con);
        bool Sethttpconn(Conn_http con);
        Conn_ftp Getftpconn(string con);
        bool Setftpconn(Conn_ftp con);
        Conn_sql Getsqlconn(string con);
        bool Setsqlconn(Conn_sql con);
        Conn_email Getemailconn(string con);
        bool Setemailconn(Conn_email con);
    }

    public interface IConnection
    {
        IHttpConnection Gethttpconn(Connection con);
       
        FtpOperator Getftpconn(Connection con);
        void GetEmailConn(Models.Connection con);
        void GetMongoConn(Models.Connection con);
        void GetRedisConn(Models.Connection con);
        void Getsqlconn(Models.Connection con);
    }
}
