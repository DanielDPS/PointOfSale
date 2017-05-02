using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace MVP.Views
{
    public  interface IAddSaleView
    {
        Sale sale { get; }
        void SuccessSale(string message);
        void ErrorSale(string error);
    }
}
