using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace DataAccess
{
    public static class Connection
    {
        private static MySqlConnectionStringBuilder builder;

        public static string Builder
        {
            get
            {
                builder = new MySqlConnectionStringBuilder
                {
                    Server = "localhost",
                    UserID ="root",
                    Password = "",
                    Database= "sales4"
                };

                return builder.ToString();
            }
        }
    }
}
