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
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void frmHome_Load(object sender, EventArgs e)
        {

        }

        private void frmHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnNuevoPrestamo_Click(object sender, EventArgs e)
        {
            frmNewLoans frmNewLoans = new frmNewLoans();
            frmNewLoans.Show();
            this.Hide();
        }

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            frmRegisterPayment frmRegisterPayment = new frmRegisterPayment();
            frmRegisterPayment.Show();
            this.Hide();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            frmCustomer frmCustomer = new frmCustomer();
            frmCustomer.Show();
            this.Hide();
        }

        private void btnPagosRecientes_Click(object sender, EventArgs e)
        {
            frmPayments frmPayments = new frmPayments();
            frmPayments.Show();
            this.Hide();
        }

        private void btnPrestamosPedientes_Click(object sender, EventArgs e)
        {
            frmLoans frmLoans = new frmLoans();
            frmLoans.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSaldo_Click(object sender, EventArgs e)
        {
            frmBalance frmBalance = new frmBalance();
            frmBalance.Show();
            this.Hide();
        }
    }

}
