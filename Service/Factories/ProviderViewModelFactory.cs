using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Service.Views;
namespace Service.Factories
{
    public static class ProviderViewModelFactory
    {
        public static IEnumerable<ProviderViewModel> ConvertToCollectionProviderViewModel(this IEnumerable<Provider> providers)
        {
            List<ProviderViewModel> _providers = new List<ProviderViewModel>();
            foreach (Provider provider in providers)
            {
                _providers.Add(provider.ConvertToProviderViewModel());
            }
            return _providers;
        }

        public static ProviderViewModel ConvertToProviderViewModel(this Provider provider)
        {

            ProviderViewModel providerVM = new ProviderViewModel();
            providerVM.Id = Convert.ToString(provider.Id);
            providerVM.Name = provider.Name;
            providerVM.Surnames = provider.Surnames;
            providerVM.Direction = provider.Direction;
            providerVM.Type = provider.Type;

            return providerVM;
        }

    }
}
