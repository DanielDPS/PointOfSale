using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace MVP.Views
{
   public  interface IAddProductView
    {
       Product Product { get; }
       void SuccessAddProduct(string message);
       void ErrorAddProduct(string error);
    }
}
