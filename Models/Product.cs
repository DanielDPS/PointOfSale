using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Purchaseprice { get; set; }
        public decimal Saleprice { get; set; }
        public int Stock { get; set; }
        public int Fkproveedor { get; set; }
    }
}
