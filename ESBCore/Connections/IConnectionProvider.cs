using System.Collections.Generic;
using ESBCore.Domain.Entities;

namespace ESBCore.Connections
{
    public interface IConnectionProvider
    {
        IEnumerable<Connection> GetConnections();
    }
}
