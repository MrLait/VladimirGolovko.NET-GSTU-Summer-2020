using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DataAccessTests
{
    public class DatabaseConnectionBase
    {
        public string DbConnString { get; } = @"Data Source=LAIT-PC\SQLEXPRESS;Initial Catalog=SQLServer.Task6.Database;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}
