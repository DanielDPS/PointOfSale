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
    public class PresenterDeleteProduct
    {
        private IDeleteProduct _view;
        private ProductService productService;
        public PresenterDeleteProduct(IProductRespository IproductR,IDeleteProduct view)
        {
            productService = new ProductService(IproductR);
            _view = view;
        }
        public void DeleteProductPresenter()
        {
            ProductReadRequest productRead = new ProductReadRequest();
            productRead.IdProduct = _view.Idproduct;
            ProductResponse productResponse = productService.DeleteProduct(productRead);
            if (productResponse.Success)
                _view.SuccessDelete("Se ha eliminado");
            else
                _view.ErrorDelete(string.Format("{0}",productResponse.Exception.Message));

        }
    }
}
