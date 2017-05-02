using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Models;
using Service.Responses;
using Service.Requests;
namespace Service
{
   public  class PurchaseService
    {

       IPurchaseRepository IpurchaseR;
       public PurchaseService(IPurchaseRepository IPR)
       {
           IpurchaseR = IPR;
       }

       public PurchaseResponse InsertOnPurchase(PurchaseRequest request)
       {

           PurchaseResponse response = new PurchaseResponse();
           try
           {
               IpurchaseR.InsertOnPurchase(request.Purchase);

               response.Success = true;
           }
           catch (Exception e)
           {
               response.Exception = e;
               response.Success = false;
           }
           return response;
       }
    }
}
