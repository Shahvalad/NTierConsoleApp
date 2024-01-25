using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierConsoleAppp.Data
{
    public class DbContext
    {
        private const string ConnectionString =
                 "server=localhost\\SQLEXPRESS; database=Northwind; trusted_connection = true; TrustServerCertificate=True;";

        public static SqlConnection OpenConneciton()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }

    }
}
