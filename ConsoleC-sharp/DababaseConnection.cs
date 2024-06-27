using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleC_sharp
{
    internal class DababaseConnection
    {
        private readonly string _connection;

        public DababaseConnection(string connection)
        {
            this._connection = connection;
        }

        public SqlConnection getOpenConnection()
        {
            var conn = new SqlConnection(this._connection);
            conn.Open();
            return conn;
        }
    }
}
