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
    public  class MYSQLProductRepository:IProductRespository
    {
        private MySqlCommand command;
        private MySqlDataReader reader;
        public IEnumerable<Product> GetAllProducts()
        {
            using (MySqlConnection connection = new MySqlConnection(Connection.Builder))
            {
                command = new MySqlCommand("SelectProducts", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                reader = command.ExecuteReader();
                List<Product> products =new List<Product>();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.Id =(int)reader["idproduct"];
                    product.Name = (string)reader["name"];
                    product.Description = (string)reader["description"];
                    product.Purchaseprice = (decimal)reader["purchaseprice"];
                    product.Saleprice = (decimal)reader["saleprice"];
                    product.Stock = (int)reader["stock"];
                    product.Fkproveedor = (int)reader["fkprovider"];
                    products.Add(product);
                    
                }
                return products;
            }
        }

        public Product GetProduct(string name)
        {
            using (MySqlConnection connection = new MySqlConnection(Connection.Builder))
            {
                command = new MySqlCommand("SelectProductByName", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("pname", MySqlDbType.VarChar, 30).Value = name;
                connection.Open();
                reader = command.ExecuteReader();
                Product product = null;
                while (reader.Read())
                {
                    product = new Product();
                    product.Id = (int)reader["idproduct"];
                    product.Name = (string)reader["name"];
                    product.Description = (string)reader["description"];
                    product.Purchaseprice = (decimal)reader["purchaseprice"];
                    product.Saleprice = (decimal)reader["saleprice"];
                    product.Stock = (int)reader["stock"];
                    product.Fkproveedor = (int)reader["fkprovider"];
                }
                return product;
            }
        }

        public void InsertProduct(Product product)
        {
            using (MySqlConnection connection = new MySqlConnection(Connection.Builder))
            {
                command = new MySqlCommand("InsertOnProduct", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("pname", MySqlDbType.VarChar, 30).Value = product.Name;
                command.Parameters.Add("pdescription", MySqlDbType.VarChar, 100).Value = product.Description;
                command.Parameters.Add("ppurchaseprice", MySqlDbType.Decimal, 11).Value = product.Purchaseprice;
                command.Parameters.Add("psaleprice", MySqlDbType.Decimal, 11).Value = product.Saleprice;
                command.Parameters.Add("pstock", MySqlDbType.Int32).Value = product.Stock;
                command.Parameters.Add("pfkprovider", MySqlDbType.Int32).Value = product.Fkproveedor;
                connection.Open();
                command.ExecuteNonQuery();
            }
           
        }
        public void UpdateProduct(Product product)
        {
            using (MySqlConnection connection = new MySqlConnection(Connection.Builder))
            {
                command = new MySqlCommand("UpdateOnProduct", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("pidproduct", MySqlDbType.Int32).Value = product.Id;
                command.Parameters.Add("pname", MySqlDbType.VarChar, 30).Value = product.Name;
                command.Parameters.Add("pdescription", MySqlDbType.VarChar, 100).Value = product.Description;
                command.Parameters.Add("ppurchaseprice", MySqlDbType.Decimal, 11).Value = product.Purchaseprice;
                command.Parameters.Add("psaleprice", MySqlDbType.Decimal, 11).Value = product.Saleprice;
                command.Parameters.Add("pstock", MySqlDbType.Int32).Value = product.Stock;
                command.Parameters.Add("pfkprovider", MySqlDbType.Int32).Value = product.Fkproveedor;
                connection.Open();
                command.ExecuteNonQuery();
            }
            
        }




        public void DeleteProduct(int productid)
        {
            using (MySqlConnection connection = new MySqlConnection(Connection.Builder))
            {
                command = new MySqlCommand("DeleteOnProduct", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("pidproduct", MySqlDbType.Int32).Value = productid;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }




        public IEnumerable<Product> GetProductsByFkProvider(int fk)
        {
            using (MySqlConnection connection = new MySqlConnection(Connection.Builder))
            {

                command = new MySqlCommand("SelectProductById",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("pfk", MySqlDbType.Int32).Value = fk; 
                connection.Open();
                reader = command.ExecuteReader();
                List<Product> products = new List<Product>();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.Id = (int)reader["idproduct"];
                    product.Name = (string)reader["name"];
                    product.Description = (string)reader["description"];
                    product.Purchaseprice = (decimal)reader["purchaseprice"];
                    product.Saleprice = (decimal)reader["saleprice"];
                    product.Stock = (int)reader["stock"];
                    product.Fkproveedor = (int)reader["fkprovider"];
                    products.Add(product);    
                }
                return products;

            }
        }
    }
}
