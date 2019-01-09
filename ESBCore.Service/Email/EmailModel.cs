using System;
using System.Collections.Generic;
using System.Text;

namespace ESBCore.Service.Email
{
    public class EmailModel
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string subject { get; set; }    
        /// <summary>
        /// 邮件内容
        /// </summary>
        public string content { get; set; }     
        /// <summary>
        /// 邮件目的地
        /// </summary>
        public string[] targets { get; set; }    
        /// <summary>
        /// 邮件抄送目的地
        /// </summary>
        public string[] ccTargets { get; set; }     
    }
}
