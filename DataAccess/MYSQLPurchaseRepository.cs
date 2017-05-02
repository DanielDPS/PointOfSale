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
    public class MYSQLPurchaseRepository :IPurchaseRepository
    {
        private MySqlCommand command;
        public void InsertOnPurchase(Purchase purchase)
        {
            using (MySqlConnection connection = new MySqlConnection(Connection.Builder))
            {
                command = new MySqlCommand("InsertOnPurchase",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("pidout", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                command.Parameters.Add("pdate", MySqlDbType.Date).Value = purchase.Date;
                command.Parameters.Add("ptotal", MySqlDbType.Decimal, 11).Value = purchase.Total;
                connection.Open();
                command.ExecuteNonQuery();
                purchase.Id = (int)command.Parameters["pidout"].Value;
                connection.Close();


                foreach (CarItemPurchase item in purchase.Purchases)
                {

                    command = new MySqlCommand("InsertOnPurchaseDetail",connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("pidpurchase", MySqlDbType.Int32).Value = purchase.Id;
                    command.Parameters.Add("pfkproduct", MySqlDbType.Int32).Value = item.Code;
                    command.Parameters.Add("pquantity", MySqlDbType.Int32).Value = item.Quantity;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                }

            }
        }
    }
}
