using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using MVP.Views;
using DataAccess;
using MVP.Presenters;
using Service.Views;
using Service.Responses;
using Service;
namespace GUI.Products
{
    public partial class FormProducts : Form,IProductListView,IGetProductByName
    {
        private PresenterLoadProduct presenterProduct;
        private PresenterGetProductByName presenterGetProduct;
        public FormProducts()
        {
            InitializeComponent();
            presenterGetProduct = new PresenterGetProductByName(new MYSQLProductRepository(), this);
            presenterProduct = new PresenterLoadProduct(new MYSQLProductRepository(),this);
            presenterProduct.LoadProductPresenter();
        }
        public void SuccessLoadProduct(IEnumerable<ProductViewModel> products)
        {
            dgvProducts.DataSource = products;
        }
        public void ErrorLoadProduct(string error)
        {
            MessageBox.Show(error, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormInsertProduct frmInsertProduct = new FormInsertProduct();
            frmInsertProduct.refresh = presenterProduct.LoadProductPresenter;
            frmInsertProduct.Show();
        }
        private void dgvProducts_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ProductViewModel product = dgvProducts.Rows[e.RowIndex].DataBoundItem as ProductViewModel;
            FormUpdateProduct frmUpdateProduct = new FormUpdateProduct(product);
            frmUpdateProduct.refresh = presenterProduct.LoadProductPresenter;
            frmUpdateProduct.Show();
        }
        private void dgvProducts_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProductViewModel product = dgvProducts.Rows[dgvProducts.CurrentRow.Index].DataBoundItem as ProductViewModel;
            FormDeleteProduct frmDeleteProduct = new FormDeleteProduct(product);
            frmDeleteProduct.refresh = presenterProduct.LoadProductPresenter;
            frmDeleteProduct.Show();
        }
        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            presenterGetProduct.GetProductByNamePresenter();
        }
        public string Productname
        {
            get { return txtSearchProduct.Text; }
        }
        public void SuccessProduct(IEnumerable<ProductViewModel> products)
        {
            dgvProducts.DataSource = products.ToList<ProductViewModel>();
        }
        public void ErrorProduct(string error)
        {
            MessageBox.Show(error);
        }
    }
}
