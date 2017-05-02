using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Views;
namespace Service.Responses
{
    public class ProductListResponse:BaseResponse
    {
        public IEnumerable<ProductViewModel> List { get; set; }
    }
}
