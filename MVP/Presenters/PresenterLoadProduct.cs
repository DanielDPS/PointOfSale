using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Models;
using MVP.Views;
using Service;
using Service.Responses;
namespace MVP.Presenters
{
    public class PresenterLoadProduct
    {
        private IProductListView _view;
        private ProductService productService;
        public PresenterLoadProduct(IProductRespository IproductR,IProductListView view)
        {
            productService = new ProductService(IproductR);
            _view = view;
        }
        public void LoadProductPresenter()
        {
            ProductListResponse productResponse = productService.GetProducts();
            if (productResponse.Success)
                _view.SuccessLoadProduct(productResponse.List);
            else
                _view.ErrorLoadProduct(string.Format("{0}",productResponse.Exception.Message));
        }
    }
}
