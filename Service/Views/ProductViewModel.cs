using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Views
{
    public class ProductViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Purchaseprice { get; set; }
        public string Saleprice { get; set; }
        public string Stock { get; set; }
        public string Fkproveedor { get; set; }
    }
}
