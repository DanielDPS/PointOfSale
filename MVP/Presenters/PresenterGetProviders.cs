using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAccess;
using Service;
using Service.Views;
using Service.Responses;
using MVP.Views;
namespace MVP.Presenters
{
    public class PresenterGetProviders
    {
        private IGetProvidersView _view;
        private ProviderService providerService;
        public PresenterGetProviders(IProviderRepository IPR, IGetProvidersView IGet)
        {
            providerService = new ProviderService(IPR);
            _view = IGet;
        }

        public void PresenterProviders()
        {
            ProviderListResponse providerList = providerService.GetProviders();
            if (providerList.Success)
            {
                _view.SuccessProvider(providerList.ListProvider);
            }
            else
            {
                _view.ErrorProvider( string.Format("{0}", providerList.Exception.Message));
            }

        }

    }
}
