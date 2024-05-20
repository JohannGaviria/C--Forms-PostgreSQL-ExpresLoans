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

            Conexion.Conexion conexion = new Conexion.Conexion();
            NpgsqlConnection conn = conexion.connection();

            if (conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    // Transacción para asegurar la integridad de las inserciones
                    using (var transaction = conn.BeginTransaction())
                    {
                        // Inserción en la tabla 'saldos'
                        string insertSaldosQuery = "INSERT INTO saldos (usuario_id, saldo) VALUES (@usuario_id, @saldo)";
                       
                        using (NpgsqlCommand cmd = new NpgsqlCommand(insertSaldosQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@usuario_id", UserSession.UserId);
                            cmd.Parameters.AddWithValue("@saldo", txtSaldo.Text);
                            cmd.ExecuteNonQuery();
                        }

                        // Inserción en la tabla 'historial_saldo'
                        string insertHistorialQuery = "INSERT INTO historial_saldo (id_usuario, fecha, tipo_movimiento, monto) VALUES (@id_usuario, CURRENT_TIMESTAMP, @tipo_movimiento, @monto)";
                        using (NpgsqlCommand cmd = new NpgsqlCommand(insertHistorialQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@id_usuario", UserSession.UserId);
                            cmd.Parameters.AddWithValue("@tipo_movimiento", "Depósito");
                            cmd.Parameters.AddWithValue("@monto", txtSaldo.Text);
                            cmd.ExecuteNonQuery();
                        }

                        // Confirmar la transacción
                        transaction.Commit();
                    }

                    MessageBox.Show("Saldo Agregado");

                    CargarSaldo();
                    CargarHistorialSaldo();

                    if (currentModal != null)
                    {
                        this.Controls.Remove(currentModal);
                        currentModal = null;
                    }
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show("Error al ingresar el saldo: " + ex.Message);
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
            // Validar que el saldo sea numérico, opcionalmente con decimales
            return Regex.IsMatch(saldo, @"^\d+(\.\d{1,2})?$");
        }

        // Método para mostrar mensajes de error
        private void MostrarError(Control control, string mensaje)
        {
            epSaldo.SetError(control, mensaje);
        }

        private void frmBalance_Load(object sender, EventArgs e)
        {
            CargarSaldo();
            CargarHistorialSaldo();
        }

        private void CargarSaldo()
        {
            Conexion.Conexion conexion = new Conexion.Conexion();
            NpgsqlConnection conn = conexion.connection();

            if (conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string query = "SELECT SUM(CAST(saldo AS numeric)) FROM saldos WHERE usuario_id = @usuario_id";
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
                    MessageBox.Show("Error al cargar el saldo: " + ex.Message);
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

        private void CargarHistorialSaldo()
        {
            Conexion.Conexion conexion = new Conexion.Conexion();
            NpgsqlConnection conn = conexion.connection();

            if (conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string query = "SELECT fecha, tipo_movimiento, monto FROM historial_saldo WHERE id_usuario = @id_usuario";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_usuario", UserSession.UserId);

                        NpgsqlDataReader reader = cmd.ExecuteReader();

                        // Limpiar filas existentes y definir columnas si es necesario
                        dgvHistorial.Rows.Clear();
                        if (dgvHistorial.Columns.Count == 0)
                        {
                            dgvHistorial.Columns.Add("fecha", "Fecha");
                            dgvHistorial.Columns.Add("tipo_movimiento", "Tipo de Movimiento");
                            dgvHistorial.Columns.Add("monto", "Monto");
                        }

                        while (reader.Read())
                        {
                            // Agregar fila al DataGridView
                            dgvHistorial.Rows.Add(reader["fecha"], reader["tipo_movimiento"], reader["monto"]);
                        }
                        dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


                    }
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show("Error al cargar el historial de saldo: " + ex.Message);
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
