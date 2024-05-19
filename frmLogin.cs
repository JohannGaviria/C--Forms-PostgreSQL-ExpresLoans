using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace expressLoan
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            epLogin = new ErrorProvider();
            epLogin.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            txtContrasena.UseSystemPasswordChar = true;
        }

        private void lblTexto_Click(object sender, EventArgs e)
        {
            frmRegister frmRegister = new frmRegister();
            frmRegister.Show();
            this.Hide();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Limpiar los mensajes de error previos
            epLogin.Clear();

            // Validar campos
            if (!ValidarEmail(txtEmail.Text))
                MostrarError(txtEmail, "Ingrese un email válido");

            if (!ValidarContrasena(txtContrasena.Text))
                MostrarError(txtContrasena, "La contraseña debe tener al menos 8 caracteres");
        }

        private bool ValidarEmail(string email)
        {
            // Validar el formato del email usando expresión regular
            return Regex.IsMatch(email, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        }

        private bool ValidarContrasena(string password)
        {
            // Validar que la contraseña tenga al menos 8 caracteres
            return password.Length >= 8;
        }

        // Método para mostrar mensajes de error
        private void MostrarError(Control control, string mensaje)
        {
            epLogin.SetError(control, mensaje);
        }
    }
}
