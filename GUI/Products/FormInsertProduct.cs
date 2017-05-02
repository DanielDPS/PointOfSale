using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;
using Models;
using MVP.Presenters;
using MVP.Views;
using Service;
namespace GUI.Products
{
    public partial class FormInsertProduct : Form,IAddProductView
    {
        private PresenterAddProduct presenterAddProduct;
       public Action refresh;
        public FormInsertProduct()
        {
            InitializeComponent();
            presenterAddProduct = new PresenterAddProduct(new MYSQLProductRepository(), this);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
                presenterAddProduct.AddProductPresenter();
                refresh();
                this.Close(); 
        }
        public Product Product
        {
            get {
                return  new Product 
                {Name=txtName.Text,
                    Description=txtDescription.Text,
                    Purchaseprice=decimal.Parse(txtPurchaseprice.Text),
                    Saleprice =decimal.Parse(txtSaleprice.Text),
                    Stock=int.Parse(txtStock.Text),
                    Fkproveedor=int.Parse(cbProviders.Text) };
                }
        }
        public void SuccessAddProduct(string message)
        {
            MessageBox.Show(message);
        }
        public void ErrorAddProduct(string error)
        {
            MessageBox.Show(error);
        }
    }
}
