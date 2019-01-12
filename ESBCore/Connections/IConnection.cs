using System;
using System.Collections.Generic;
using System.Text;
using ESB.Common.FTP;
using ESB.Common.Http;
using ESBCore.Connections.Imp;

namespace ESBCore.Connections
{
  public interface IConnection
  {
    IHttpConnection Gethttpconn(Connection con);

    FtpOperator Getftpconn(Connection con);
    void GetEmailConn(Connection con);
    void GetMongoConn(Connection con);
    void GetRedisConn(Connection con);
    void Getsqlconn(Connection con);
  }
}
