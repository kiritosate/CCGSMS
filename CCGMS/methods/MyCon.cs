using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CCGMS.methods
{
    internal class MyCon
    {
        public static MySqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GuidanceDB"].ConnectionString;
            return new MySqlConnection(connectionString);
        }
    }
}
