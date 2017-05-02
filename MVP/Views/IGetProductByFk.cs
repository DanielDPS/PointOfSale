using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Views;
namespace MVP.Views
{
    public interface IGetProductByFk
    {
        int Fkprovider { get; }
        void SuccessProductList(IEnumerable<ProductViewModel> products);
        void ErrorProductList(string error);
    }
}
