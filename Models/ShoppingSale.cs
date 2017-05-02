using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ShoppingSale
    {
        private List<CarItemSale> items;
        private decimal _Subtotal;
        private decimal _Iva;
        private decimal _Total;
        public decimal _Pago {get;set;}
        public decimal _Cambio{get;set;}
        public ShoppingSale()
        {
            items = new List<CarItemSale>();
        }

        public void AddSale(CarItemSale product, int stock)
        {
            int index = items.FindIndex(temp => temp.Code.Equals(product.Code));
            if (items.Count ==0 || index <0)
            {
                if (stock >= product.Quantity)
                    items.Add(product);
                else if (stock == 0)
                    return;
                else
                    return;              
            }
            else 
            {
                CarItemSale itemSale = items[index];
                int sum = itemSale.Quantity + product.Quantity;
                if (sum > stock)
                    return;
                else
                    itemSale.Quantity += product.Quantity;

            }
        }
        public IEnumerable<CarItemSale> ListSale
        {
            get { return items; }
        }
        public void RemoveSale(int index)
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
            foreach (CarItemSale product in items)
            {
                decimal sub = product.Price * product.Quantity;
                acumulator += sub;
                
            }
            return acumulator;
        }


    }
}
