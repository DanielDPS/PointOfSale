using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Models;
using Service.Requests;
using Service.Views;
using Service.Factories;
using Service.Responses;
namespace Service
{
    public class ProviderService
    {
        IProviderRepository IproviderRepository;
        public ProviderService(IProviderRepository IproviderR)
        {
            IproviderRepository = IproviderR;
        }

        public ProviderListResponse GetProviders()
        {
            ProviderListResponse list = new ProviderListResponse();
            try
            {
                list.Success = true;
                IEnumerable<ProviderViewModel> providers = IproviderRepository.GetProviders().ConvertToCollectionProviderViewModel();
                list.ListProvider = providers;
            }
            catch (Exception e)
            {
                list.Success = false;
                list.Exception = e;
            }
            return list;

        }
    }
}
