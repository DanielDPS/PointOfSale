using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace Service.Responses
{
    public class PurchaseResponse:BaseResponse
    {
       public CarItemPurchase CarItem { get; set; }
    }
}
