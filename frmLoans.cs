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
using static expressLoan.frmLogin;

namespace expressLoan
{
    public partial class frmLoans : Form
    {
        public frmLoans()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void frmLoans_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void lblVolver_Click(object sender, EventArgs e)
        {
            frmHome frmHome = new frmHome();
            frmHome.Show();
            this.Hide();
        }

        private void frmLoans_Load(object sender, EventArgs e)
        {
            MostrarPrestamosPedientes(dgvPrestamos);
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
                             ORDER BY p.fecha_prestamo DESC";

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
