using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace DataAccess
{
    public interface IProductRespository
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(string name);
        void InsertProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int productid);
        IEnumerable<Product> GetProductsByFkProvider(int fk);
    }
}
