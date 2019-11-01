using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CitizensRegistryApp.Core.Data
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
