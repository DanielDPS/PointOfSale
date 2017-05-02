using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Service;
using MVP.Views;
using Service.Requests;
using Service.Responses;
using Service.Views;
namespace MVP.Presenters
{
    public class PresenterProductByFk
    {

        private IGetProductByFk _view;
        private ProductService productService;
        public PresenterProductByFk(IProductRespository IPR, IGetProductByFk Iget)
        {
            productService = new ProductService(IPR);
            _view = Iget;
        }

        public void GetProductByFk()
        {
            ProductReadRequest read = new ProductReadRequest();
            read.IdProvider = _view.Fkprovider;
            ProductListResponse productList = productService.GetProductById(read);
            
            if (productList.Success)
            {
                _view.SuccessProductList(productList.List);
            }
            else
            {
                _view.ErrorProductList(string.Format("{0}", productList.Exception.Message));
            }

        }
    }
}
