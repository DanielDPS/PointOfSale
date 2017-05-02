using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace Service.Factories
{
    public static class SaleFactory
    {
        public static Sale ConvertToSale(this ShoppingSale shoppingcar)
        {
            Sale sale = new Sale();
            sale.Date = DateTime.Now;
            sale.Total = shoppingcar.Total;
            sale.Details = shoppingcar.ListSale;
            return sale;
        }
    }
}
