using expressLoan.Clases;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static expressLoan.frmBalance;
using static expressLoan.frmLogin;

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
            lblSaldoNum.Text = SaldoManager.CargarSaldo(UserSession.UserId);
            MostrarPrestamosPedientes(dgvPrestamosPedientes);
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

        private void btnSaldo_Click(object sender, EventArgs e)
        {
            frmBalance frmBalance = new frmBalance();
            frmBalance.Show();
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

        private static void MostrarPrestamosPedientes(DataGridView dgvPrestamosPedientes)
        {
            Conexion.Conexion conexion = new Conexion.Conexion();
            NpgsqlConnection conn = conexion.connection();

            if (conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string query = @"SELECT p.id, c.nombre AS nombre_cliente, p.monto, p.fecha_pago
                             FROM prestamos p
                             INNER JOIN clientes c ON p.cliente_id = c.id
                             WHERE p.usuario_id = @usuario_id AND p.estado = 'Pendiente' 
                             ORDER BY p.fecha_prestamo DESC 
                             LIMIT 8";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario_id", UserSession.UserId);

                        NpgsqlDataReader reader = cmd.ExecuteReader();

                        // Limpiar filas existentes y definir columnas si es necesario
                        dgvPrestamosPedientes.Rows.Clear();
                        dgvPrestamosPedientes.Columns.Clear();
                        dgvPrestamosPedientes.Columns.Add("id", "ID");
                        dgvPrestamosPedientes.Columns.Add("nombre", "Nombre");
                        dgvPrestamosPedientes.Columns.Add("monto", "Monto");
                        dgvPrestamosPedientes.Columns.Add("fecha", "Fecha");

                        while (reader.Read())
                        {
                            // Agregar fila al DataGridView
                            dgvPrestamosPedientes.Rows.Add(reader["id"], reader["nombre_cliente"], reader["monto"], reader["fecha_pago"]);
                        }

                        // Establecer el modo de ajuste automático de columnas
                        dgvPrestamosPedientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show("Error al cargar los préstamos pendientes: " + ex.Message);
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
