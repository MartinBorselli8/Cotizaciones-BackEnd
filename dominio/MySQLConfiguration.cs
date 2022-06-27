using System;
using System.Collections.Generic;
using System.Text;

namespace dominio
{
    public class MySQLConfiguration
    {
        public MySQLConfiguration(string connectionString) => ConnectionString = connectionString;
        public string ConnectionString { get; set; }
    }
}
