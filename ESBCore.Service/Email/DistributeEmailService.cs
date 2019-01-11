using Abp.Application.Services;
using Abp.Net.Mail.Smtp;
using ESBCore.BackgroundJob;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace ESBCore.Service.Email
{
    public class DistributeEmailService: BaseService
    {
        private ISmtpEmailSender _emailSender;
        public DistributeEmailService(ISmtpEmailSender smtpEmailSender)
        {
            _emailSender = smtpEmailSender;
        }
        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="args"></param>
        public override void Execute(TaskActionJobArgs args) {
            SendEmail(args);
        }
        public void SendEmail(TaskActionJobArgs action)
        {
            
            Logger.Info("准备:JsonConvert.DeserializeObject<EmailModel>(action.message)");
            var message = JsonConvert.DeserializeObject<EmailModel>(action.Message);
            Logger.Info("完成:JsonConvert.DeserializeObject<EmailModel>(action.message)");

            string[] targets = message.targets;
            string[] ccTargets = message.ccTargets;
            string content = message.content;
            string subject = message.subject;
           
            try
            {
                
                MailMessage mailMessage = new MailMessage();
               // mailMessage.From = new MailAddress("pub@chinergy.com.cn", "pub@chinergy.com.cn");

                if (targets != null)
                {
                    foreach (var tar in targets)    //目的地址
                    {
                        MailAddress to = new MailAddress(tar);
                        mailMessage.To.Add(to);
                    }
                }

                if (ccTargets != null)
                {
                    foreach (var ccTar in ccTargets)    //抄送地址
                    {
                        MailAddress cc = new MailAddress(ccTar);
                        mailMessage.CC.Add(cc);
                    }
                }

                mailMessage.Subject = subject;     //主题
                mailMessage.Body = content;        //内容
                mailMessage.BodyEncoding = System.Text.Encoding.UTF8;//正文编码
                mailMessage.IsBodyHtml = true;              //设置为HTML格式
                mailMessage.Priority = MailPriority.High;   //优先级

                Logger.Info("Send Email:开始发送,subject:" + subject + ",content:" + content);
                _emailSender.Send(mailMessage);
                Logger.Info("Send Email:发送成功 To:" + string.Join(",", mailMessage.To.Select(u => u.Address)));
            }
            catch (Exception ex)
            {
                string temp = "DistributeEmail error";
                Logger.Error(temp + ex.ToString());
                throw;
            }
        }
    }
}
