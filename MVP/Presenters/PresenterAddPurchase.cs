using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVP.Views;
using DataAccess;
using Models;
using Service;
using Service.Requests;
using Service.Responses;
namespace MVP.Presenters
{
   public class PresenterAddPurchase
    {

       private IAddPurchase _view;
       private PurchaseService purchaseService;
       public PresenterAddPurchase(IPurchaseRepository IPR, IAddPurchase Iadd)
       {
           purchaseService = new PurchaseService(IPR);
           _view = Iadd;
       }

       public void AddPurchase()
       {
           PurchaseRequest request = new PurchaseRequest();
           request.Purchase = _view.purchase;
           PurchaseResponse response = purchaseService.InsertOnPurchase(request);
           if (response.Success)
           {
               _view.SuccessPurchase("Bien man");

           }
           else
           {
               _view.ErrorPurchase(string.Format("{0}",response.Exception.Message));

           }

       }
    }
}
