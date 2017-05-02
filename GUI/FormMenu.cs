using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.Products;
using Models;
using GUI.Sale;
using GUI.Purchase;
namespace GUI
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();           
        }
        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProducts frmProducts = new FormProducts();
           frmProducts.Show();
        }

        private void btnLeave_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSale frmSale = new FormSale();
            frmSale.Show();
        }

        private void toBuyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPurchase frmPurchase = new FormPurchase();
            frmPurchase.Show();
        }

    }
}
