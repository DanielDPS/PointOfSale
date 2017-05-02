using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ShoppingCar
    {

        List<CarItemPurchase> items;
        private decimal _Subtotal;
        private decimal _Iva;
        private decimal _Total;
        public ShoppingCar()
        {
            items = new List<CarItemPurchase>();
        }

        public void AddPurchase (CarItemPurchase product,int stock)
        {
            int index = items.FindIndex(temp => temp.Code.Equals(product.Code));
            if (items.Count ==0 || index <0)
            {
                if (stock >= product.Quantity)
                {
                    items.Add(product);
                }
                else if (stock == 0)
                {
                    return;
                }
                else
                {
                    return;
                }
            }
            else
            {
                CarItemPurchase prods = items[index];
                int sum = prods.Quantity + product.Quantity;
                if (stock < sum)
                    return;
                else
                    prods.Quantity += product.Quantity;

            }


        }
        public IEnumerable<CarItemPurchase> ListPurchase
        {
            get { return items; }
        }
        public void RemovePurchase(int index)
        {
            items.RemoveAt(index);
        }

        public decimal Subtotal
        {
            get { return _Subtotal = getSubtotal(); }
        }
        public decimal Iva
        {
            get { return _Iva = Subtotal * 0.16m; }
        }
        public decimal Total
        {
            get { return _Total = Subtotal + Iva; }
        }
        private decimal getSubtotal()
        {
            decimal acumulator = 0;
            foreach (CarItemPurchase product in items)
            {
                decimal sub = product.Price * product.Quantity;
                acumulator += sub;
                
            }
            return acumulator;
        }
    }
}
