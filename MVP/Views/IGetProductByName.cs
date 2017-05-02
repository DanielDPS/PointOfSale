using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Views;
namespace MVP.Views
{
    public interface IGetProductByName
    {
        string Productname { get; }
        void SuccessProduct(IEnumerable<ProductViewModel> products);
        void ErrorProduct(string error);
    }
}
