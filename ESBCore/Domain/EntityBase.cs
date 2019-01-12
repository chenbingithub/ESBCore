using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;

namespace ESBCore.Domain
{
    public class EntityBase: Entity<string>
  {
        public EntityBase()
        {
          this.Id = Guid.NewGuid().ToString("N");
        }
    }
}
