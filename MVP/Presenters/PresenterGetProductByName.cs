using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Models;
using MVP.Views;
using Service;
using Service.Views;
using Service.Requests;
using Service.Responses;
namespace MVP.Presenters
{
   public  class PresenterGetProductByName
    {

       private IGetProductByName _view;
       private ProductService productService;
       public PresenterGetProductByName(IProductRespository IproductR,IGetProductByName view)
       {
           productService = new ProductService(IproductR);
           _view = view;
       }
       public void GetProductByNamePresenter()
       {
           ProductListResponse productList = productService.GetProducts();
           ProductReadRequest productRead = new ProductReadRequest();
           productRead.Name = _view.Productname;
           ProductResponse productResponse = productService.GetProductByName(productRead);
           IEnumerable<ProductViewModel> products = from c in productList.List where c.Name == productRead.Name select c;
           if (productResponse.Success)
           {
               if (_view.Productname == string.Empty)
                   _view.SuccessProduct(productList.List);
               else
                   _view.SuccessProduct(products);
           }
           else
               _view.ErrorProduct(string.Format("{0}",productResponse.Exception.Message));

       }
    }
}
