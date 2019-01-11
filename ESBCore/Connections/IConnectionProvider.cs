using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESB.Core.Connections.Models
{
    public interface IConnectionProvider
    {
        IEnumerable<Connection> GetConnections();
    }
}
