using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Views;
namespace MVP.Views
{
    public  interface IGetProvidersView
    {
        void SuccessProvider(IEnumerable<ProviderViewModel> providers);
        void ErrorProvider(string error);
    }
}
