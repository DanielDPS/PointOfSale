using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Views;
namespace Service.Responses
{
   public class ProductResponse :BaseResponse
    {
       public ProductViewModel product { get; set; }
    }
}
