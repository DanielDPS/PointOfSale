﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Views;
namespace MVP.Views
{
    public interface IProductListView
    {
        void SuccessLoadProduct(IEnumerable<ProductViewModel> products);
        void ErrorLoadProduct(string error);
    }
}
