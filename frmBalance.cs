using expressLoan.Clases;
using Npgsql;
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
using static expressLoan.frmLogin;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace expressLoan
{
    public partial class frmBalance : Form
    {
        private GroupBox currentModal;

        public frmBalance()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            epSaldo = new ErrorProvider();
            epSaldo.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        private void frmBalance_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void lblVolver_Click(object sender, EventArgs e)
        {
            frmHome frmHome = new frmHome();
            frmHome.Show();
            this.Hide();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (currentModal != null)
            {
                this.Controls.Remove(currentModal);
                currentModal = null;
            }

            currentModal = CustomControls.CreateCustomGroupBox("gbAgregar", "Agregar Saldo", "Saldo a Ingresar", this, OnAceptarAgregar);
            this.Controls.Add(currentModal);
            currentModal.BringToFront();
        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {
            if (currentModal != null)
            {
                this.Controls.Remove(currentModal);
                currentModal = null;
            }

            currentModal = CustomControls.CreateCustomGroupBox("gbRetirar", "Retirar Saldo", "Saldo a Retirar", this, OnAceptarRetirar);
            this.Controls.Add(currentModal);
            currentModal.BringToFront();
        }

        private void OnAceptarAgregar(object sender, EventArgs e)
        {
            // Limpiar los mensajes de error previos
            epSaldo.Clear();

            TextBox txtSaldo = sender as TextBox;
            if (!ValidarSaldo(txtSaldo.Text))
            {
                MostrarError(txtSaldo, "Ingrese un número de saldo válido (solo dígitos)");
                return;
            }

            MessageBox.Show("Saldo Agregado");

            if (currentModal != null)
            {
                this.Controls.Remove(currentModal);
                currentModal = null;
            }
        }

        private void OnAceptarRetirar(object sender, EventArgs e)
        {
            // Limpiar los mensajes de error previos
            epSaldo.Clear();

            TextBox txtSaldo = sender as TextBox;
            if (!ValidarSaldo(txtSaldo.Text))
            {
                MostrarError(txtSaldo, "Ingrese un número de saldo válido (solo dígitos)");
                return;
            }

            MessageBox.Show("Saldo Retirado");

            if (currentModal != null)
            {
                this.Controls.Remove(currentModal);
                currentModal = null;
            }
        }

        private bool ValidarSaldo(string saldo)
        {
            // Validar que el número de celular tenga 10 dígitos y sea numérico
            return Regex.IsMatch(saldo, @"^\d{4}$");
        }

        // Método para mostrar mensajes de error
        private void MostrarError(Control control, string mensaje)
        {
            epSaldo.SetError(control, mensaje);
        }

        private void frmBalance_Load(object sender, EventArgs e)
        {
            Conexion.Conexion conexion = new Conexion.Conexion();
            NpgsqlConnection conn = conexion.connection();

            if (conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string query = "SELECT saldo FROM saldos WHERE usuario_id = @usuario_id";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("usuario_id", UserSession.UserId);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            lblSaldoNum.Text = result.ToString();
                        }
                        else
                        {
                            lblSaldoNum.Text = "Sin saldo";
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
    }
}
