using System;
using System.Collections.Generic;
using System.Text;

namespace ESBCore.BackgroundJob
{
    [Serializable]
    public class TaskActionJobArgs
    {

        /// <summary>
        /// 请求来源地址
        /// </summary>
        //public string source { get; set; }
        /// <summary>
        /// 目标服务
        /// </summary>
        public string targetservice { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 返回值索引
        /// </summary>
        public Guid resultindex { get; set; }

        public DateTime time { get; set; }

        public Contenttype contenttype { get; set; }

        public Actiontype actiontype { get; set; }
        /// <summary>
        /// catch累加
        /// </summary>
        public int errorcount { get; set; }
    }

    /// <summary>
    /// 消息传递模式 
    /// </summary>
    public enum Actiontype
    {
        message,    //消息，有去无回
        reqrep      //请求应答，有去有回
    }
    /// <summary>
    /// 传递消息的格式
    /// </summary>
    public enum Contenttype
    {
        json
    }
}
