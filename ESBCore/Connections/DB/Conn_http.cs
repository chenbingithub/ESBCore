using ESBCore.BackgroundJob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESB.Core.Connections.DB
{
    public class Conn_http
    {
        public string key { get; set; }
       // public bool is_active { get; set; }
        public string host { get; set; }
        public ConnectType connection { get; set; }
        public Contenttype contenttype { get; set; }

        public Actiontype actiontype { get; set; }
        //public string methon { get; set; }
        //public int timeout { get; set; }
        public string service_key { get; set; }
       // public string message_key { get; set; }



    }

    /// <summary>
    /// http连接类型 通道或对外连接
    /// </summary>
    public enum ConnectType
    {
        outgoing,
        channel
    }
}
