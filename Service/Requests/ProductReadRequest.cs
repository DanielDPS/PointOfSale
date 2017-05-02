using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Requests
{
    public class ProductReadRequest
    {
        public int  IdProduct { get; set; }
        public int IdProvider { get; set; }
        public string Name { get; set; }
    }
}
