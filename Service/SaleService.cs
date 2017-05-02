using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Models;
using Service.Requests;
using Service.Responses;
namespace Service
{ 
    public  class SaleService
    {
        private ISaleRepository IsaleR;
        public SaleService(ISaleRepository ISR)
        {
            this.IsaleR = ISR;
        }

        public SaleResponse AddSale(SaleRequest saleRequest)
        {
            SaleResponse saleResponse = new SaleResponse();
            try
            {
                IsaleR.AddSale(saleRequest.Sale);
                saleResponse.Success = true;
            }
            catch (Exception e)
            {
                saleResponse.Exception = e;
                saleResponse.Success = false;
            }
            return saleResponse;
        }
    }
}
