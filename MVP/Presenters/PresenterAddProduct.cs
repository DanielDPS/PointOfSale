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
    public class PresenterAddProduct
    {
        private IAddProductView _view;
        private ProductService productService;
        public PresenterAddProduct(IProductRespository IproductR,IAddProductView view)
        {
            productService = new ProductService(IproductR);
            _view = view; 
        }

        public void AddProductPresenter()
        {
            ProductRequest productRequest = new ProductRequest();
            productRequest.product = _view.Product;
            ProductResponse productResponse = productService.InsertProduct(productRequest);
            if (productResponse.Success)
                _view.SuccessAddProduct("Se inserto");
            else
                _view.ErrorAddProduct(string.Format("{0}",productResponse.Exception.Message));
        }

    }
}
