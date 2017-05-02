using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;
using MySql.Data.MySqlClient;
namespace DataAccess
{
    public class MYSQLProviderRepository:IProviderRepository
    {
        private MySqlDataReader reader;
        private MySqlCommand command;
        public IEnumerable<Provider> GetProviders()
        {
            using (MySqlConnection connection = new MySqlConnection(Connection.Builder))
            {
                command = new MySqlCommand("SelectAllProviders",connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                reader = command.ExecuteReader();
                List<Provider> providers = new List<Provider>();
                while (reader.Read())
                {
                    Provider provider = new Provider();
                    provider.Id = (int)reader["idprovider"];
                    provider.Name = (string)reader["name"];
                    provider.Surnames = (string)reader["surnames"];
                    provider.Direction = (string)reader["direction"];
                    provider.Type = (string)reader["type"];
                    providers.Add(provider);
                }
                return providers;
            }
        }
    }
}
