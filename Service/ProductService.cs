using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Models;
using Service.Factories;
using Service.Responses;
using Service.Views;
using Service.Requests;
namespace Service
{
    public class ProductService
    {

        private IProductRespository IproductR;
        public ProductService(IProductRespository IPR)
        {
            IproductR = IPR;
        }


        public ProductListResponse GetProductById(ProductReadRequest read)
        {

            ProductListResponse productList = new ProductListResponse();
            try
            {
               
                IEnumerable<ProductViewModel> list = IproductR.GetProductsByFkProvider(read.IdProvider).ConvertToCollectionProductViewModel();
                productList.List = list;
                productList.Success = true;
            }
            catch (Exception e)
            {
               
                productList.Exception = e;
                productList.Success = false;
            }
            return productList;
        }

        public ProductListResponse GetProducts()
        {
            ProductListResponse productResponse = new ProductListResponse();
            try
            {
                IEnumerable<ProductViewModel> products = IproductR.GetAllProducts().ConvertToCollectionProductViewModel();
                productResponse.List = products;
                productResponse.Success = true;
            }
            catch (Exception e)
            {
                productResponse.Exception = e;
                productResponse.Success = false;
            }
            return productResponse;
        }

        public ProductResponse InsertProduct(ProductRequest productRequest)
        {
            ProductResponse productResponse = new ProductResponse();
            try
            {
                IproductR.InsertProduct(productRequest.product);
                productResponse.Success = true;
            }
            catch (Exception e)
            {
                productResponse.Exception = e;
                productResponse.Success = false;
            }
            return productResponse;
        }

        public ProductResponse DeleteProduct(ProductReadRequest productReques)
        {
            ProductResponse productResponse = new ProductResponse();
            try
            {
                IproductR.DeleteProduct(productReques.IdProduct);
                productResponse.Success = true;
            }
            catch (Exception e)
            {
                productResponse.Exception = e;
                productResponse.Success = false;
            }
            return productResponse;
        }

        public ProductResponse GetProductByName(ProductReadRequest productRead)
        {
            ProductResponse productResponse = new ProductResponse();
            try
            {
                IproductR.GetProduct(productRead.Name);
                productResponse.Success = true;
            }
            catch (Exception e)
            {
                productResponse.Exception = e;
                productResponse.Success = false;
            }
            return productResponse;
        }

        public ProductResponse UpdateProduct(ProductRequest productReques)
        {
            ProductResponse productResponse = new ProductResponse();
            try
            {
                IproductR.UpdateProduct(productReques.product);
                productResponse.Success = true;
            }
            catch (Exception e)
            {
                productResponse.Exception = e;
                productResponse.Success = false;
            }
            return productResponse;
        }
            


    }
}
