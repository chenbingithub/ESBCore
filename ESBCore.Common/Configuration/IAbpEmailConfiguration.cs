using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.Email.Configuration
{
    public interface IAbpEmailConfiguration
    {
        //
        // 摘要:
        //     SMTP Host name/IP.
         string Host { get; set; }
        //
        // 摘要:
        //     SMTP Port.
         int Port { get; set; }
        //
        // 摘要:
        //     User name to login to SMTP server.
         string UserName { get; set; }
        //
        // 摘要:
        //     Password to login to SMTP server.
         string Password { get; set; }
        //
        // 摘要:
        //     Domain name to login to SMTP server.
         string Domain { get; set; }
        //
        // 摘要:
        //     Is SSL enabled?
         bool EnableSsl { get; set; }
        //
        // 摘要:
        //     Use default credentials?
         bool UseDefaultCredentials { get; set; }
        /// <summary>
        /// Use default credentials?
        /// </summary>
        string DefaultFromAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string DefaultFromDisplayName { get; set; }

    }
}
