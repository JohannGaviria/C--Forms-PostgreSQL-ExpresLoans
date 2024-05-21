using expressLoan.Clases;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static expressLoan.frmLogin;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using OfficeOpenXml;

namespace expressLoan
{
    public partial class frmBalance : Form
    {
        private GroupBox currentModal;

        public static class SaldoSession
        {
            public static string Saldo { get; set; }
        }

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

            decimal saldoAIngresar = decimal.Parse(txtSaldo.Text);

            Conexion.Conexion conexion = new Conexion.Conexion();
            NpgsqlConnection conn = conexion.connection();

            if (conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    // Transacción para asegurar la integridad de las operaciones
                    using (var transaction = conn.BeginTransaction())
                    {
                        // Verificar si ya existe un saldo para el usuario
                        string querySaldoExistente = "SELECT saldo FROM saldos WHERE usuario_id = @usuario_id";
                        object result;
                        using (NpgsqlCommand cmd = new NpgsqlCommand(querySaldoExistente, conn))
                        {
                            cmd.Parameters.AddWithValue("@usuario_id", UserSession.UserId);
                            result = cmd.ExecuteScalar();
                        }

                        if (result != null)
                        {
                            // El usuario ya tiene un saldo, actualizarlo
                            decimal saldoExistente = decimal.Parse(result.ToString());
                            decimal nuevoSaldo = saldoExistente + saldoAIngresar;

                            string updateSaldoQuery = "UPDATE saldos SET saldo = @nuevo_saldo WHERE usuario_id = @usuario_id";
                            using (NpgsqlCommand cmd = new NpgsqlCommand(updateSaldoQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@nuevo_saldo", nuevoSaldo.ToString());
                                cmd.Parameters.AddWithValue("@usuario_id", UserSession.UserId);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            // El usuario no tiene saldo, crear un nuevo registro
                            string insertSaldosQuery = "INSERT INTO saldos (usuario_id, saldo) VALUES (@usuario_id, @saldo)";
                            using (NpgsqlCommand cmd = new NpgsqlCommand(insertSaldosQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@usuario_id", UserSession.UserId);
                                cmd.Parameters.AddWithValue("@saldo", saldoAIngresar.ToString());
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // Inserción en la tabla 'historial_saldo'
                        string insertHistorialQuery = "INSERT INTO historial_saldo (id_usuario, fecha, tipo_movimiento, monto) VALUES (@id_usuario, CURRENT_TIMESTAMP, @tipo_movimiento, @monto)";
                        using (NpgsqlCommand cmd = new NpgsqlCommand(insertHistorialQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@id_usuario", UserSession.UserId);
                            cmd.Parameters.AddWithValue("@tipo_movimiento", "Ingreso");
                            cmd.Parameters.AddWithValue("@monto", saldoAIngresar.ToString());
                            cmd.ExecuteNonQuery();
                        }

                        // Confirmar la transacción
                        transaction.Commit();
                    }

                    MessageBox.Show("Saldo Agregado");

                    lblSaldoNum.Text = SaldoManager.CargarSaldo(UserSession.UserId);
                    SaldoManager.CargarHistorialSaldo(UserSession.UserId, dgvHistorial);

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

            decimal saldoARetirar = decimal.Parse(txtSaldo.Text);

            Conexion.Conexion conexion = new Conexion.Conexion();
            NpgsqlConnection conn = conexion.connection();

            if (conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    // Transacción para asegurar la integridad de las operaciones
                    using (var transaction = conn.BeginTransaction())
                    {
                        // Verificar si ya existe un saldo para el usuario
                        string querySaldoExistente = "SELECT saldo FROM saldos WHERE usuario_id = @usuario_id";
                        object result;
                        using (NpgsqlCommand cmd = new NpgsqlCommand(querySaldoExistente, conn))
                        {
                            cmd.Parameters.AddWithValue("@usuario_id", UserSession.UserId);
                            result = cmd.ExecuteScalar();
                        }

                        if (result != null)
                        {
                            decimal saldoExistente = decimal.Parse(result.ToString());

                            if (saldoExistente >= saldoARetirar)
                            {
                                decimal nuevoSaldo = saldoExistente - saldoARetirar;

                                string updateSaldoQuery = "UPDATE saldos SET saldo = @nuevo_saldo WHERE usuario_id = @usuario_id";
                                using (NpgsqlCommand cmd = new NpgsqlCommand(updateSaldoQuery, conn))
                                {
                                    cmd.Parameters.AddWithValue("@nuevo_saldo", nuevoSaldo.ToString());
                                    cmd.Parameters.AddWithValue("@usuario_id", UserSession.UserId);
                                    cmd.ExecuteNonQuery();
                                }

                                // Inserción en la tabla 'historial_saldo'
                                string insertHistorialQuery = "INSERT INTO historial_saldo (id_usuario, fecha, tipo_movimiento, monto) VALUES (@id_usuario, CURRENT_TIMESTAMP, @tipo_movimiento, @monto)";
                                using (NpgsqlCommand cmd = new NpgsqlCommand(insertHistorialQuery, conn))
                                {
                                    cmd.Parameters.AddWithValue("@id_usuario", UserSession.UserId);
                                    cmd.Parameters.AddWithValue("@tipo_movimiento", "Retiro");
                                    cmd.Parameters.AddWithValue("@monto", saldoARetirar.ToString());
                                    cmd.ExecuteNonQuery();
                                }

                                // Confirmar la transacción
                                transaction.Commit();

                                MessageBox.Show("Saldo Retirado");
                            }
                            else
                            {
                                MessageBox.Show("Saldo insuficiente para realizar la retirada.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("No hay saldo disponible para retirar.");
                        }

                        lblSaldoNum.Text = SaldoManager.CargarSaldo(UserSession.UserId);
                        SaldoManager.CargarHistorialSaldo(UserSession.UserId, dgvHistorial);

                        if (currentModal != null)
                        {
                            this.Controls.Remove(currentModal);
                            currentModal = null;
                        }
                    }
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show("Error al retirar el saldo: " + ex.Message);
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
            lblSaldoNum.Text = SaldoManager.CargarSaldo(UserSession.UserId);
            SaldoManager.CargarHistorialSaldo(UserSession.UserId, dgvHistorial);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarHistorialAExcel(dgvHistorial);
        }

        private void ExportarHistorialAExcel(DataGridView dgvHistorial)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = "HistorialSaldo.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (ExcelPackage pck = new ExcelPackage())
                    {
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("HistorialSaldo");

                        // Add the headers
                        for (int col = 0; col < dgvHistorial.Columns.Count; col++)
                        {
                            ws.Cells[1, col + 1].Value = dgvHistorial.Columns[col].HeaderText;
                        }

                        // Add the rows
                        for (int row = 0; row < dgvHistorial.Rows.Count; row++)
                        {
                            for (int col = 0; col < dgvHistorial.Columns.Count; col++)
                            {
                                ws.Cells[row + 2, col + 1].Value = dgvHistorial.Rows[row].Cells[col].Value?.ToString();
                            }
                        }

                        // Save the file
                        FileInfo fi = new FileInfo(sfd.FileName);
                        pck.SaveAs(fi);

                        MessageBox.Show("Exportación exitosa", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
