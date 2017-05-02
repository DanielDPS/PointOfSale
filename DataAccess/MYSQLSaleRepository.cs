using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using MySql.Data.MySqlClient;
using System.Data;
namespace DataAccess
{
    public  class MYSQLSaleRepository:ISaleRepository
    {
        private MySqlCommand command;
        public void AddSale(Sale sale)
        {
            using (MySqlConnection connection = new MySqlConnection(Connection.Builder))
            {
                command = new MySqlCommand("InsertOnSale", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("idout", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                command.Parameters.Add("pdate", MySqlDbType.Date).Value = sale.Date;
                command.Parameters.Add("ptotal", MySqlDbType.Decimal, 11).Value = sale.Total;
                connection.Open();
                command.ExecuteNonQuery();
                sale.Id = (int)command.Parameters["idout"].Value;
                connection.Close();

                foreach (CarItemSale saleItem in sale.Details)
                {
                    command = new MySqlCommand("InsertOnSaleDetail", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("pfkproduct", MySqlDbType.Int32).Value = saleItem.Code;
                    command.Parameters.Add("pfksale", MySqlDbType.Int32).Value = sale.Id;
                    command.Parameters.Add("pfkuser", MySqlDbType.Int32).Value = saleItem.Fkuser;
                    command.Parameters.Add("pquantity", MySqlDbType.Int32).Value = saleItem.Quantity;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();       
                }

            }
        }
    }
}
