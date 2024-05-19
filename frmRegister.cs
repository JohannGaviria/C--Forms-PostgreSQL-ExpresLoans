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
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            epRegistro = new ErrorProvider();
            epRegistro.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            txtContrasena.UseSystemPasswordChar = true;
        }

        private void lblTexto_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            this.Hide();
        }

        private void frmRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Limpiar los mensajes de error previos
            epRegistro.Clear();

            // Validar campos
            if (!ValidarNombreCompleto(txtNombre.Text))
                MostrarError(txtNombre, "Ingrese un nombre válido");

            if (!ValidarEmail(txtEmail.Text))
                MostrarError(txtEmail, "Ingrese un email válido");

            if (!ValidarContrasena(txtContrasena.Text))
                MostrarError(txtContrasena, "La contraseña debe tener al menos 8 caracteres");

            if (!ValidarNumeroCelular(txtCelular.Text))
                MostrarError(txtCelular, "Ingrese un número de celular válido");
        }

        // Métodos de validación
        private bool ValidarNombreCompleto(string nombreCompleto)
        {
            // Validar que el nombre completo tenga al menos un espacio y no contenga caracteres especiales
            return nombreCompleto.Trim().Contains(" ") && !Regex.IsMatch(nombreCompleto, "[^a-zA-Z ]");
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

        private bool ValidarNumeroCelular(string numeroCelular)
        {
            // Validar que el número de celular tenga 10 dígitos y sea numérico
            return Regex.IsMatch(numeroCelular, @"^\d{10}$");
        }

        // Método para mostrar mensajes de error
        private void MostrarError(Control control, string mensaje)
        {
            epRegistro.SetError(control, mensaje);
        }
    }
}
