using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using Models;
namespace DataAccess
{
    public class MYSQLUserRepository:IUserRepository
    {
        private MySqlCommand command;
        private MySqlDataReader reader;
        public User GetUserByUserPassword(string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(Connection.Builder))
            {
                command = new MySqlCommand("SelectUserByUserPass",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("pusername", MySqlDbType.VarChar, 30).Value = username;
                command.Parameters.Add("ppassword", MySqlDbType.VarChar, 30).Value = password;
                connection.Open();
                reader = command.ExecuteReader();
                User user = null;
                while (reader.Read())
                {
                    user = new User();
                    user.Id = (int )reader["iduser"];
                    user.Username = (string)reader["username"];
                    user.Password = (string)reader["password"];
                    user.Name = (string)reader["name"];
                    user.Surnames = (string)reader["surnames"];
                    
                }
                return user;
            }
        }
    }
}
