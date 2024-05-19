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
    public partial class frmLogin : Form
    {
        public static class UserSession
        {
            public static int UserId { get; set; }
            public static string Nombre { get; set; }
            public static string Email { get; set; }
            public static string Celular { get; set; }
        }

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

            // Verificar si los campos están llenos
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            if (!ValidarEmail(txtEmail.Text))
            {
                MostrarError(txtEmail, "Ingrese un email válido");
                return;
            }

            Conexion.Conexion conexion = new Conexion.Conexion();
            NpgsqlConnection conn = conexion.connection();

            if (conn.State == System.Data.ConnectionState.Open)
            {
                string email = txtEmail.Text;
                string contrasena = HashContrasena(txtContrasena.Text); // Cifrar la contraseña

                try
                {
                    string query = "SELECT id, nombre, email, celular, contrasena FROM usuarios WHERE email = @Email";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("email", email);

                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string contrasenaAlmacenada = reader["contrasena"].ToString();
                                if (VerificarContrasena(txtContrasena.Text, contrasenaAlmacenada))
                                {
                                    // Guardar los datos del usuario en UserSession
                                    UserSession.UserId = Convert.ToInt32(reader["id"]);
                                    UserSession.Nombre = reader["nombre"].ToString();
                                    UserSession.Email = reader["email"].ToString();
                                    UserSession.Celular = reader["celular"].ToString();

                                    MessageBox.Show("Inicio de sesión exitoso!");

                                    frmHome admin = new frmHome();
                                    admin.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Nombre de usuario o contraseña incorrectos.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Nombre de usuario o contraseña incorrectos.");
                            }
                        }
                    }
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show("Error al iniciar sesión: " + ex.Message);
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

        // Método para verificar la contraseña cifrada
        private bool VerificarContrasena(string contrasenaIngresada, string contrasenaAlmacenada)
        {
            return HashContrasena(contrasenaIngresada) == contrasenaAlmacenada;
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
