using ESBCore.BackgroundJob;

namespace ESBCore.Domain.Entities
{
    public class HttpConfiguration : EntityBase
  {
        public string Key { get; set; }
        public string Host { get; set; }
        public ConnectType Connection { get; set; }
        public Contenttype Contenttype { get; set; }

        public Actiontype Actiontype { get; set; }
        public string ServiceKey { get; set; }



    }

    /// <summary>
    /// http连接类型 通道或对外连接
    /// </summary>
    public enum ConnectType
    {
        Outgoing,
        Channel
    }
}
