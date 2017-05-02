using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Models;
using MVP.Views;
using Service;
using Service.Requests;
using Service.Responses;
namespace MVP.Presenters
{
    public   class PresenterUpdateProduct
    {
        private IUpdateProductView _view;
        private ProductService productService;
        public PresenterUpdateProduct(IProductRespository IproductR,IUpdateProductView view)
        {
            productService = new ProductService(IproductR);
            _view = view;
        }
        public void UpdateProductPresenter()
        {
            ProductRequest productRequest = new ProductRequest();
            productRequest.product = _view.Product;
            ProductResponse productResponse = productService.UpdateProduct(productRequest);
            if (productResponse.Success)
                _view.SuccessUpdate("Se actualizo");
            else
                _view.ErrorUpdate(string.Format("{0}",productResponse.Exception.Message));
        }
    }
}
