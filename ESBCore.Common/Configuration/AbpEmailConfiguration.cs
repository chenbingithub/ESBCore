using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.Email.Configuration
{
   public class AbpEmailConfiguration: IAbpEmailConfiguration
    {
        //
        // 摘要:
        //     SMTP Host name/IP.
        public  string Host { get; set; }
        //
        // 摘要:
        //     SMTP Port.
        public  int Port { get; set; }
        //
        // 摘要:
        //     User name to login to SMTP server.
        public  string UserName { get; set; }
        //
        // 摘要:
        //     Password to login to SMTP server.
        public  string Password { get; set; }
        //
        // 摘要:
        //     Domain name to login to SMTP server.
        public  string Domain { get; set; }
        //
        // 摘要:
        //     Is SSL enabled?
        public  bool EnableSsl { get; set; }
        //
        // 摘要:
        //     Use default credentials?
        public  bool UseDefaultCredentials { get; set; }

        /// <summary>
        /// Use default DefaultFromAddress?
        /// </summary>
        public string DefaultFromAddress { get; set; }
        /// <summary>
        /// Use default DefaultFromDisplayName?
        /// </summary>
        public string DefaultFromDisplayName { get; set; }
    }
}
