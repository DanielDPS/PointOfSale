using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MVP.Views
{
    public interface IDeleteProduct
    {
        int Idproduct { get; }
        void SuccessDelete(string message);
        void ErrorDelete(string error);
    }
}
