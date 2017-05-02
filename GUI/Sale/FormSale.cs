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
using GUI.Reports;
using MVP.Views;
using Models;
using Service.Factories;
using Service.Views;
using MVP.Presenters;

namespace GUI.Sale
{
    public partial class FormSale : Form,IProductListView,IAddSaleView
    {
        private PresenterLoadProduct presenterLoadProducts;
        private PresenterAddSale presenterAddSale;
        private CarItemSale carItemSale;
        private ShoppingSale shoppingSale;
        public FormSale()
        {
            InitializeComponent();
            presenterAddSale = new PresenterAddSale(new MYSQLSaleRepository(), this);
            presenterLoadProducts = new PresenterLoadProduct(new MYSQLProductRepository(), this);
            presenterLoadProducts.LoadProductPresenter();
            carItemSale = new CarItemSale();
            shoppingSale = new ShoppingSale();
        }
        public void SuccessLoadProduct(IEnumerable<ProductViewModel> products)
        {
            cbproducts.DataSource = products;
            cbproducts.DisplayMember = "Name";
            cbproducts.ValueMember = "Id";
        }
        public void ErrorLoadProduct(string error)
        {
            MessageBox.Show(error);
        }
        void RefreshData()
        {
            dgvProducts.DataSource = null;
            dgvProducts.DataSource = shoppingSale.ListSale;
            txtSubtotal.Text = decimal.Round(shoppingSale.Subtotal, 2).ToString();
            txtIva.Text = decimal.Round(shoppingSale.Iva, 2).ToString();
            txtTotal.Text = decimal.Round(shoppingSale.Total, 2).ToString();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductViewModel  productViewModel = cbproducts.SelectedItem as ProductViewModel;
            carItemSale = productViewModel.ConvertToCarItem();
            carItemSale.Quantity = int.Parse(txtQuantity.Text);
            carItemSale.Fkuser = SessionUser.Instance.Currentuser.Id;
            shoppingSale.AddSale(carItemSale,int.Parse(productViewModel.Stock));
            RefreshData();
        }
        private void btnAccept_Click(object sender, EventArgs e)
        {
            FormCalculation frmCalculation = new FormCalculation(shoppingSale);
            frmCalculation.Show();
            //presenterAddSale.AddSalePresenter();
        }
        public Models.Sale sale
        {
            get { return shoppingSale.ConvertToSale(); }
        }
        public void SuccessSale(string message)
        {
            MessageBox.Show(message, "Good!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void ErrorSale(string error)
        {
            MessageBox.Show(error,"Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.Rows.Count > 0)
            {
                shoppingSale.RemoveSale(dgvProducts.CurrentCell.RowIndex);
                RefreshData();

            }else
                MessageBox.Show("No records to delete", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
