using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Service.Views;
namespace Service.Factories
{
    public static class ProductViewModelFactory
    {
        public static IEnumerable<ProductViewModel> ConvertToCollectionProductViewModel(this IEnumerable<Product> products)
        {
            List<ProductViewModel> productList = new List<ProductViewModel>();
            foreach (Product product in products)
            {
                productList.Add(product.ConvertToProductViewModel());
            }
            return productList;
        }
        public static ProductViewModel ConvertToProductViewModel(this Product product)
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Id = Convert.ToString(product.Id);
            productViewModel.Name = product.Name;
            productViewModel.Description = product.Description;
            productViewModel.Purchaseprice = product.Purchaseprice.ToString();
            productViewModel.Saleprice = product.Saleprice.ToString();
            productViewModel.Stock = product.Stock.ToString();
            productViewModel.Fkproveedor = product.Fkproveedor.ToString();
            return productViewModel;
        }

        public static CarItemSale ConvertToCarItem(this ProductViewModel product)
        {
            CarItemSale car = new CarItemSale();
            car.Code =int.Parse( product.Id);
            car.Name = product.Name;
            car.Price = decimal.Parse(product.Saleprice);
            car.Quantity = int.Parse(product.Stock);
            return car;
        }


        public static CarItemPurchase ConvertToCarItemPurchase(this ProductViewModel product)
        {
            CarItemPurchase car = new CarItemPurchase();
            car.Code = int.Parse(product.Id);
            car.Name = product.Name;
            car.Price = decimal.Parse(product.Purchaseprice);
            car.Quantity = int.Parse(product.Stock);
            return car;
        }
    }
}
