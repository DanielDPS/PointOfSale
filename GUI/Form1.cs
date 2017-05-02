using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MVP.Presenters;
using MVP.Views;
using Models;
using DataAccess;
using Service;
namespace GUI
{
    public partial class Form1 : Form,IUserListView
    {
        private PresenterUser presenterUser;
        private User userr;
        public Form1()
        {
            InitializeComponent();
            presenterUser = new PresenterUser(new MYSQLUserRepository(), this);
            userr = new User();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userr.Username = textBox1.Text;
            userr.Password = textBox2.Text;
            presenterUser.GetUserPresenter();
        }

        public User user
        {
            get { return userr; }
        }
        public void ErrorUser(string error)
        {
            MessageBox.Show(error);
        }
        public void SuccessUser(User gUser)
        {
            SessionUser.Instance.Currentuser = gUser;
            FormMenu frmMenu = new FormMenu();
            frmMenu.Show();
            this.Hide();
        }
    }
}
