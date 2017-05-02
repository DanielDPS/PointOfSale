using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;
using Microsoft.Reporting.WinForms;
using Models;
namespace GUI.Reports
{
    public partial class FormReport : Form
    {
        ShoppingSale shoppingsale=null;
        public FormReport(ShoppingSale entersale)
        {
            InitializeComponent();
            shoppingsale = entersale;

            MessageBox.Show(shoppingsale.Total.ToString());
        }
        
        private void FormReport_Load(object sender, EventArgs e)
        {
            List<ReportParameter> parameters = new List<ReportParameter>();
            parameters.Add(new ReportParameter("Cambio",Convert.ToString(shoppingsale._Cambio)));
            this.reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
