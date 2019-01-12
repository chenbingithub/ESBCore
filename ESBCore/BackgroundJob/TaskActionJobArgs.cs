using System;
using System.Collections.Generic;
using System.Text;

namespace ESBCore.BackgroundJob
{
    [Serializable]
    public class TaskActionJobArgs
    {

        
        /// <summary>
        /// 目标服务
        /// </summary>
        public string Targetservice { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 返回值索引
        /// </summary>
        public string Resultindex { get; set; }

        public DateTime Time { get; set; }

        public Contenttype Contenttype { get; set; }

        public Actiontype Actiontype { get; set; }
        
    }

    /// <summary>
    /// 消息传递模式 
    /// </summary>
    public enum Actiontype
    {
    /// <summary>
    /// 消息，有去无回
    /// </summary>
    Message,    
                /// <summary>
                /// 请求应答，有去有回
                /// </summary>
    Reqrep      
  }
    /// <summary>
    /// 传递消息的格式
    /// </summary>
    public enum Contenttype
    {
    /// <summary>
    /// Json
    /// </summary>
        Json
    }
}
