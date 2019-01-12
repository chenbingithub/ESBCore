namespace ESBCore.Domain.Entities
{
    public  class FtpConfiguration : EntityBase
  {
        public string Key { get; set; }
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
