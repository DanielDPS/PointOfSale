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
using MVP.Presenters;
using MVP.Views;
using Service.Factories;
using Models;
using Service.Views;
namespace GUI.Purchase
{
    public partial class FormPurchase : Form,IGetProvidersView,IGetProductByFk,IAddPurchase
    {
        PresenterGetProviders PresenterProviders;
        PresenterProductByFk PresenterGetProductByFk;
        PresenterAddPurchase addPurchase;
        ShoppingCar shoppingcar;
        CarItemPurchase carItem;
        public FormPurchase()
        {
            InitializeComponent();
            PresenterProviders = new PresenterGetProviders(new MYSQLProviderRepository(), this);
            PresenterProviders.PresenterProviders();
           
         
            addPurchase = new PresenterAddPurchase(new MYSQLPurchaseRepository(), this);
            shoppingcar = new ShoppingCar();
            carItem = new CarItemPurchase();
        }
        public void SuccessProvider(IEnumerable<ProviderViewModel> providers)
        {
            cbProvider.DataSource = providers;
            cbProvider.DisplayMember = "Name";
            cbProvider.ValueMember = "Id";
        }
        public void ErrorProvider(string error)
        {
            MessageBox.Show(error);
        }
        private void cbProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProvider.SelectedItem != null)
            {
                PresenterGetProductByFk = new PresenterProductByFk(new MYSQLProductRepository(), this);
                PresenterGetProductByFk.GetProductByFk();

            }
            else
                return;
        }

        public int Fkprovider
        {
            get {

                ProviderViewModel provider = cbProvider.SelectedItem as ProviderViewModel;
                return int.Parse( provider.Id);      
            }
        }
        public void SuccessProductList(IEnumerable<ProductViewModel> products)
        {
            cbProducts.DataSource = products;
            cbProducts.DisplayMember = "Name";
            cbProducts.ValueMember = "Id";
        }

        public void ErrorProductList(string error)
        {
            MessageBox.Show(error);
        }
        void RefreshData()
        {
            dgvPurchases.DataSource = null;
            dgvPurchases.DataSource = shoppingcar.ListPurchase;
            txtSubtotal.Text = shoppingcar.Subtotal.ToString();
            txtIva.Text = shoppingcar.Iva.ToString();
            txtTotal.Text = shoppingcar.Total.ToString();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductViewModel productViewModell = (ProductViewModel) cbProducts.SelectedItem;
            carItem = productViewModell.ConvertToCarItemPurchase();
            carItem.Quantity = int.Parse(txtQuantity.Text);
            shoppingcar.AddPurchase(carItem,int.Parse( productViewModell.Stock));
            RefreshData();
        }

        public Models.Purchase purchase
        {
            get { return shoppingcar.ConvertToPurchase(); }
        }

        public void SuccessPurchase(string message)
        {
            MessageBox.Show(message,"Information!",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        public void ErrorPurchase(string error)
        {
            MessageBox.Show(error,"Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            addPurchase.AddPurchase();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPurchases.Rows.Count > 0)
            {
                shoppingcar.RemovePurchase(dgvPurchases.CurrentCell.RowIndex);
                RefreshData();
            }
            else
                MessageBox.Show("No records to delete", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
