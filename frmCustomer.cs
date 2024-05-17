using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace expressLoan
{
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void frmCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void lblVolver_Click(object sender, EventArgs e)
        {
            frmHome frmHome = new frmHome();
            frmHome.Show();
            this.Hide();
        }

    }
}
