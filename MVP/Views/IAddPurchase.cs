using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace MVP.Views
{
    public interface IAddPurchase
    {
        Purchase purchase { get; }
        void SuccessPurchase(string message);
        void ErrorPurchase(string error);
    }
}
