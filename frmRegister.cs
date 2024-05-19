using expressLoan.Conexion;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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

            // Verificar si los campos están llenos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtContrasena.Text) || string.IsNullOrWhiteSpace(txtCelular.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            // Validar campos
            if (!ValidarNombreCompleto(txtNombre.Text))
            {
                MostrarError(txtNombre, "Ingrese un nombre válido");
                return;
            }

            if (!ValidarEmail(txtEmail.Text))
            {
                MostrarError(txtEmail, "Ingrese un email válido");
                return;
            }

            if (!ValidarContrasena(txtContrasena.Text))
            {
                MostrarError(txtContrasena, "La contraseña debe tener al menos 8 caracteres");
                return;
            }

            if (!ValidarNumeroCelular(txtCelular.Text))
            {
                MostrarError(txtCelular, "Ingrese un número de celular válido (solo dígitos)");
                return;
            }

            Conexion.Conexion conexion = new Conexion.Conexion();
            NpgsqlConnection conn = conexion.connection();

            if (conn.State == System.Data.ConnectionState.Open)
            {
                string nombre = txtNombre.Text;
                string email = txtEmail.Text;
                string contrasena = HashContrasena(txtContrasena.Text);
                string celular = txtCelular.Text;

                try
                {
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO usuarios (nombre, email, contrasena, celular) VALUES (@nombre, @email, @contrasena, @celular)";
                        cmd.Parameters.AddWithValue("nombre", nombre);
                        cmd.Parameters.AddWithValue("email", email);
                        cmd.Parameters.AddWithValue("contrasena", contrasena);
                        cmd.Parameters.AddWithValue("celular", celular);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Registro exitoso!");

                        frmLogin login = new frmLogin();

                        login.Show();

                        this.Hide();
                    }
                }
                catch (NpgsqlException ex)
                {
                    if (ex.Message.Contains("idx_email"))
                    {
                        MessageBox.Show("El email ya está en uso. Por favor, intente con otro email.");
                    }
                    else
                    {
                        MessageBox.Show("Error al registrar: " + ex.Message);
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("No se pudo establecer la conexión a la base de datos.");
            }

        }

        // Método para cifrar la contraseña utilizando SHA-256
        private string HashContrasena(string contrasena)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(contrasena));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
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
