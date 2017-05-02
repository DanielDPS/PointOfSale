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
using DataAccess;
using MVP.Views;
using Models;
using MVP.Presenters;
namespace GUI.Products
{
    public partial class FormUpdateProduct : Form,IUpdateProductView
    {
        private PresenterUpdateProduct presenterUpdateProduct;
        ProductViewModel productVM;
        public Action refresh;
        public FormUpdateProduct(ProductViewModel prod)
        {
            InitializeComponent();
            productVM = prod;
            txtName.Text = productVM.Name;
            txtDescription.Text = productVM.Description;
            txtPurchaseprice.Text = productVM.Purchaseprice;
            txtSaleprice.Text = productVM.Saleprice;
            txtStock.Text = productVM.Stock;
            cbProviders.Text = productVM.Fkproveedor;
            presenterUpdateProduct = new PresenterUpdateProduct(new MYSQLProductRepository(), this);
        }

        public Product Product
        {
            get
            {
                return new Product
                    {
                        Id= int.Parse(productVM.Id),
                        Name =txtName.Text,
                        Description = txtDescription.Text,
                        Purchaseprice=decimal.Parse(txtPurchaseprice.Text),
                        Saleprice= decimal.Parse(txtSaleprice.Text),
                        Stock = int.Parse(txtStock.Text),
                        Fkproveedor = int.Parse(cbProviders.Text)
                    };
            }
        }
        public void SuccessUpdate(string message)
        {
            MessageBox.Show(message);
        }
        public void ErrorUpdate(string error)
        {
            MessageBox.Show(error);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            presenterUpdateProduct.UpdateProductPresenter();
            refresh();
            this.Close();
        }
    }
}
