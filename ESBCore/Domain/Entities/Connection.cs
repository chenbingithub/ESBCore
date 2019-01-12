namespace ESBCore.Domain.Entities
{
   public  class Connection:  EntityBase
  {
        public string Name { get; set; }
        /// <summary>
        /// 目标服务
        /// </summary>
        public string Targetservice { get; set; }
        public string Description { get; set; }
        public ConnectionType Type { get; set; }
        public string ConfigurationKey { get; set; }
    
  }

    public enum ConnectionType
    {
        Email,
        Ftp,
        Http,
        Sql,
        Mongo,
        Redis
    }
}
