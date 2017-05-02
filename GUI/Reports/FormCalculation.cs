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
namespace GUI.Reports
{
    public partial class FormCalculation : Form
    {
        ShoppingSale shopping=null;
        public FormCalculation(ShoppingSale ptotal)
        {
            InitializeComponent();
            shopping = ptotal;
            txtTotal.Text = decimal.Round(shopping.Total, 2).ToString();
        }
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            decimal cambio = decimal.Parse(txtQuantity.Text) - decimal.Parse(txtTotal.Text);
            txtCambio.Text = decimal.Round(cambio, 2).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            shopping._Pago = Convert.ToDecimal ( txtQuantity.Text.ToString());
            shopping._Cambio = Convert.ToDecimal(txtCambio.Text.ToString());
            FormReport report = new FormReport(shopping);
            report.Show(); 
        }
    }
}
