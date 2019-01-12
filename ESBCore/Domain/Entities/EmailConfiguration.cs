using ESBCore.Domain;

namespace ESBCore.Domain.Entities
{
    public  class EmailConfiguration: EntityBase
  {
        public string Key { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
