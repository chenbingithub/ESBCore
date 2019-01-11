using Abp.Configuration;
using Abp.Net.Mail.Smtp;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.Email.Configuration
{
    public class MySmtpEmailSenderConfiguration : SmtpEmailSenderConfiguration
    {
        private readonly IAbpEmailConfiguration _appConfiguration;


        public MySmtpEmailSenderConfiguration(ISettingManager settingManager, IAbpEmailConfiguration configuration) : base(settingManager)
        {
            _appConfiguration = configuration;
        }
        public override string Host => _appConfiguration.Host;
        public override int Port => _appConfiguration.Port;
        public override string DefaultFromAddress => _appConfiguration.DefaultFromAddress;
        public override string DefaultFromDisplayName => _appConfiguration.DefaultFromDisplayName;

        public override string Domain => _appConfiguration.Domain;

        public override bool EnableSsl => _appConfiguration.EnableSsl;
        public override string UserName => _appConfiguration.UserName;
        public override string Password => _appConfiguration.Password;
        public override bool UseDefaultCredentials =>_appConfiguration.UseDefaultCredentials;

        //public override string Host => _appConfiguration["Abp:Email:Smtp:Host"];
        //public override int Port => int.Parse(_appConfiguration["Abp:Email:Smtp:Port"]);
        //public override string DefaultFromAddress => _appConfiguration["Abp:Email:Smtp:UserName"];
        //public override string DefaultFromDisplayName => _appConfiguration["Abp:Email:Smtp:DefaultFromDisplayName"];

        //public override string Domain => _appConfiguration["Abp:Email:Smtp:Domain"];

        //public override bool EnableSsl => bool.Parse(_appConfiguration["Abp:Email:Smtp:EnableSsl"]);
        //public override string UserName => _appConfiguration["Abp:Email:Smtp:UserName"];
        //public override string Password => _appConfiguration["Abp:Email:Smtp:Password"];
        //public override bool UseDefaultCredentials => bool.Parse(_appConfiguration["Abp:Email:Smtp:UseDefaultCredentials"]);


    }
}
