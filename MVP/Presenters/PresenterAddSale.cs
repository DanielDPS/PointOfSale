using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Service;
using Service.Responses;
using Service.Requests;
using MVP.Views;
namespace MVP.Presenters
{
    public class PresenterAddSale
    {
        private IAddSaleView _view;
        private SaleService saleService;
        public PresenterAddSale(ISaleRepository IsaleR, IAddSaleView view)
        {
            saleService = new SaleService(IsaleR);
            _view = view;
        }
        public void AddSalePresenter()
        {
            SaleRequest saleRequest = new SaleRequest();
            saleRequest.Sale = _view.sale;
            SaleResponse saleResponse = saleService.AddSale(saleRequest);
            if (saleResponse.Success)
                _view.SuccessSale("Se inserto la venta");
            else
                _view.ErrorSale(string.Format("{0}",saleResponse.Exception.Message));
        }

    }
}
