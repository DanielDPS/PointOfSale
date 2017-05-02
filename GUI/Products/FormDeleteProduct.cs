using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service.Views;
using Models;
using DataAccess;
using MVP.Presenters;
using MVP.Views;

namespace GUI.Products
{
    public partial class FormDeleteProduct : Form,IDeleteProduct
    {
        private PresenterDeleteProduct presenterDeleteProduct;
        ProductViewModel productVM;
        public Action refresh;
        public FormDeleteProduct(ProductViewModel prod)
        {
            InitializeComponent();
            productVM = prod;
            txtName.Text = productVM.Name;
            txtDescription.Text = productVM.Description;
            txtPurchaseprice.Text = productVM.Purchaseprice;
            txtSaleprice.Text = productVM.Saleprice;
            txtStock.Text = productVM.Stock;
            cbProviders.Text = productVM.Fkproveedor;
            presenterDeleteProduct = new PresenterDeleteProduct(new MYSQLProductRepository(), this);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            presenterDeleteProduct.DeleteProductPresenter();
            refresh();
            this.Close();
        }
        public int Idproduct
        {
            get { return int.Parse( productVM.Id); }
        }

        public void SuccessDelete(string message)
        {
            MessageBox.Show(message);
        }

        public void ErrorDelete(string error)
        {
            MessageBox.Show(error);
        }
    }
}
