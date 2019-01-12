using ESB.Common.FTP;
using ESB.Common.Http;
using ESBCore.Domain.Entities;

namespace ESBCore.Connections
{
    public interface IConnectionManage
    {
        HttpConfiguration Gethttpconn(string con);
        bool Sethttpconn(HttpConfiguration con);
        FtpConfiguration Getftpconn(string con);
        bool Setftpconn(FtpConfiguration con);
        SqlConfiguration Getsqlconn(string con);
        bool Setsqlconn(SqlConfiguration con);
        EmailConfiguration Getemailconn(string con);
        bool Setemailconn(EmailConfiguration con);
    }

    
}
