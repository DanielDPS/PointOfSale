using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace Service.Factories
{
    public static  class PurchaseFactory
    {
        public static Purchase ConvertToPurchase(this ShoppingCar shopping)
        {
            Purchase purchase = new Purchase();
            purchase.Date = DateTime.Now;
            purchase.Total = shopping.Total;
            purchase.Purchases = shopping.ListPurchase;
            return purchase;
        }

    }
}
