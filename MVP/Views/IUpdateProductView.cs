using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace MVP.Views
{
    public interface IUpdateProductView
    {
        Product Product { get; }
        void SuccessUpdate(string message);
        void ErrorUpdate(string error);
    }
}
