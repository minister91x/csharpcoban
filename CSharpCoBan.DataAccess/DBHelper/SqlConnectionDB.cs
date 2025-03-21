using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCoBan.DataAccess.DBHelper
{
    public class SqlConnectionDB : Connection<SqlConnection>
    {
        SqlConnection connection;
        public override SqlConnection DoConnect()
        {
            var dich_den = System.Configuration.ConfigurationManager.ConnectionStrings["MyAppDbConnectionString"].ToString() ?? "";
            connection = new SqlConnection(dich_den);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            return connection;
        }
    }
}
