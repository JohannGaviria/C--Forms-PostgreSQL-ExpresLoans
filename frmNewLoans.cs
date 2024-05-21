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

namespace expressLoan
{
    public partial class frmNewLoans : Form
    {
        public frmNewLoans()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            epRegistroPrestamo = new ErrorProvider();
            epRegistroPrestamo.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            cbNumeroCelular.CheckedChanged += new EventHandler(cbNumeroCelular_CheckedChanged);
            cbCorreoElectronico.CheckedChanged += new EventHandler(cbCorreoElectronico_CheckedChanged);

            rbPrestamoFijo.CheckedChanged += new EventHandler(rbPrestamoFijo_CheckedChanged);
            rbPrestamoInteres.CheckedChanged += new EventHandler(rbPrestamoInteres_CheckedChanged);
        }

        private void frmNewLoans_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void lblVolver_Click(object sender, EventArgs e)
        {
            frmHome frmHome = new frmHome();
            frmHome.Show();
            this.Hide();
        }

        private void frmNewLoans_Load(object sender, EventArgs e)
        {
            lblSaldoNum.Text = SaldoManager.CargarSaldo(UserSession.UserId);
        }

        private void btnRegistrarPrestamo_Click(object sender, EventArgs e)
        {
            // Limpiar los mensajes de error previos
            epRegistroPrestamo.Clear();

            // Verificar si los campos están llenos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtMonto.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.");
                return;
            }

            // Validar campos
            if (!ValidarNombre(txtNombre.Text))
            {
                MostrarError(txtNombre, "Ingrese un nombre válido");
                return;
            }

            if (!cbNumeroCelular.Checked && !cbCorreoElectronico.Checked)
            {
                MessageBox.Show("Por favor, seleccione al menos un tipo de contacto (número de celular o correo electrónico).");
                return;
            }

            if (cbNumeroCelular.Checked && !ValidarNumeroCelular(txtNumeroCelular.Text))
            {
                MostrarError(txtNumeroCelular, "Ingrese un número de celular válido (solo dígitos)");
                return;
            }

            if (cbCorreoElectronico.Checked && !ValidarEmail(txtEmail.Text))
            {
                MostrarError(txtEmail, "Ingrese un email válido");
                return;
            }

            if (!ValidarMonto(txtMonto.Text))
            {
                MostrarError(txtMonto, "Ingrese un monto válido");
                return;
            }

            if (!rbPrestamoFijo.Checked && !rbPrestamoInteres.Checked)
            {
                MessageBox.Show("Por favor, seleccione un tipo de préstamo (fijo o con interés).");
                return;
            }

            if (rbPrestamoFijo.Checked && !ValidarPrestamoFijo(txtPrestamoFijo.Text))
            {
                MostrarError(txtPrestamoFijo, "Ingrese un préstamo fijo válido (solo dígitos, opcionalmente con decimales)");
                return;
            }

            if (rbPrestamoInteres.Checked && !ValidarPrestamoInteres(txtPrestamoInteres.Text))
            {
                MostrarError(txtPrestamoInteres, "Ingrese un préstamo con interés válido (ej: 10.5%)");
                return;
            }

            if (!ValidarFechaPago(dtpFechaPago.Value))
            {
                MostrarError(dtpFechaPago, "Ingrese una fecha de pago válida");
                return;
            }

            decimal saldoPrestar = decimal.Parse(txtMonto.Text);

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

                            if (saldoExistente >= saldoPrestar)
                            {
                                decimal nuevoSaldo = saldoExistente - saldoPrestar;

                                string updateSaldoQuery = "UPDATE saldos SET saldo = @nuevo_saldo WHERE usuario_id = @usuario_id";
                                using (NpgsqlCommand cmd = new NpgsqlCommand(updateSaldoQuery, conn))
                                {
                                    cmd.Parameters.AddWithValue("@nuevo_saldo", nuevoSaldo.ToString());
                                    cmd.Parameters.AddWithValue("@usuario_id", UserSession.UserId);
                                    cmd.ExecuteNonQuery();
                                }

                                string insertHistorialQuery = "INSERT INTO historial_saldo (id_usuario, fecha, tipo_movimiento, monto) VALUES (@id_usuario, CURRENT_TIMESTAMP, @tipo_movimiento, @monto)";
                                using (NpgsqlCommand cmd = new NpgsqlCommand(insertHistorialQuery, conn))
                                {
                                    cmd.Parameters.AddWithValue("@id_usuario", UserSession.UserId);
                                    cmd.Parameters.AddWithValue("@tipo_movimiento", "Presto");
                                    cmd.Parameters.AddWithValue("@monto", txtMonto.Text);
                                    cmd.ExecuteNonQuery();
                                }

                                string insertClientQuery = "INSERT INTO clientes (usuario_id, nombre, numero_celular, correo_electronico) VALUES (@usuario_id, @nombre, @numero_celular, @correo_electronico) RETURNING id";
                                int clienteId;
                                using (NpgsqlCommand cmd = new NpgsqlCommand(insertClientQuery, conn))
                                {
                                    cmd.Parameters.AddWithValue("@usuario_id", UserSession.UserId);
                                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                                    cmd.Parameters.AddWithValue("@numero_celular", cbNumeroCelular.Checked ? (object)txtNumeroCelular.Text : DBNull.Value);
                                    cmd.Parameters.AddWithValue("@correo_electronico", cbCorreoElectronico.Checked ? (object)txtEmail.Text : DBNull.Value);
                                    clienteId = (int)cmd.ExecuteScalar();
                                }

                                string insertLoanQuery = "INSERT INTO prestamos (usuario_id, cliente_id, monto, prestamo_fijo, prestamo_interes, fecha_prestamo, fecha_pago, estado) VALUES (@usuario_id, @cliente_id, @monto, @prestamo_fijo, @prestamo_interes, CURRENT_TIMESTAMP, @fecha_pago, @estado)";
                                using (NpgsqlCommand cmd = new NpgsqlCommand(insertLoanQuery, conn))
                                {
                                    cmd.Parameters.AddWithValue("@usuario_id", UserSession.UserId);
                                    cmd.Parameters.AddWithValue("@cliente_id", clienteId);
                                    cmd.Parameters.AddWithValue("@monto", txtMonto.Text);
                                    cmd.Parameters.AddWithValue("@prestamo_fijo", rbPrestamoFijo.Checked ? (object)txtPrestamoFijo.Text : DBNull.Value);
                                    cmd.Parameters.AddWithValue("@prestamo_interes", rbPrestamoInteres.Checked ? (object)txtPrestamoInteres.Text : DBNull.Value);
                                    cmd.Parameters.AddWithValue("@fecha_pago", dtpFechaPago.Value);
                                    cmd.Parameters.AddWithValue("@estado", "Pendiente");
                                    cmd.ExecuteNonQuery();
                                }

                                // Commit the transaction
                                transaction.Commit();

                                MessageBox.Show("Registro del préstamo exitoso!");
                                ReiniciarFormulario();
                            }
                            else
                            {
                                MessageBox.Show("Saldo insuficiente para prestar.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("No hay saldo disponible para prestar.");
                        }
                        lblSaldoNum.Text = SaldoManager.CargarSaldo(UserSession.UserId);
                    }
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show("Error al registrar el préstamo: " + ex.Message);
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


        private void cbNumeroCelular_CheckedChanged(object sender, EventArgs e)
        {
            lblNumeroCelular.Visible = cbNumeroCelular.Checked;
            txtNumeroCelular.Visible = cbNumeroCelular.Checked;
        }

        private void cbCorreoElectronico_CheckedChanged(object sender, EventArgs e)
        {
            lblEmail.Visible = cbCorreoElectronico.Checked;
            txtEmail.Visible = cbCorreoElectronico.Checked;
        }

        private void rbPrestamoFijo_CheckedChanged(object sender, EventArgs e)
        {
            lblPrestamoFijo.Visible = rbPrestamoFijo.Checked;
            txtPrestamoFijo.Visible = rbPrestamoFijo.Checked;
        }

        private void rbPrestamoInteres_CheckedChanged(object sender, EventArgs e)
        {
            lblPrestamoInteres.Visible = rbPrestamoInteres.Checked;
            txtPrestamoInteres.Visible = rbPrestamoInteres.Checked;
        }


        private bool ValidarNombre(string nombre)
        {
            // Validar que el nombre completo tenga al menos un espacio y no contenga caracteres especiales
            return nombre.Trim().Contains(" ") && !Regex.IsMatch(nombre, "[^a-zA-Z ]");
        }

        private bool ValidarNumeroCelular(string numeroCelular)
        {
            // Validar que el número de celular tenga 10 dígitos y sea numérico
            return Regex.IsMatch(numeroCelular, @"^\d{10}$");
        }

        private bool ValidarEmail(string email)
        {
            // Validar el formato del email usando expresión regular
            return Regex.IsMatch(email, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        }

        private bool ValidarMonto(string monto)
        {
            // Validar que el saldo sea numérico, opcionalmente con decimales
            return Regex.IsMatch(monto, @"^\d+(\.\d{1,2})?$");
        }

        private bool ValidarPrestamoFijo(string prestamoFijo)
        {
            // Validar que el saldo sea numérico, opcionalmente con decimales
            return Regex.IsMatch(prestamoFijo, @"^\d+(\.\d{1,2})?$");
        }

        private bool ValidarPrestamoInteres(string prestamoInteres)
        {
            // Validar que el interés no supere el 100% y contenga el %
            return Regex.IsMatch(prestamoInteres, @"^(100(\.0{1,2})?|0*?\d{1,2}(\.\d{1,2})?)%$");
        }

        private bool ValidarFechaPago(DateTime fechaPago)
        {
            // Validar que la fecha no sea anterior a hoy
            return fechaPago.Date >= DateTime.Today;
        }

        // Método para mostrar mensajes de error
        private void MostrarError(Control control, string mensaje)
        {
            epRegistroPrestamo.SetError(control, mensaje);
        }

        private void ReiniciarFormulario()
        {
            // Limpiar campos de texto
            txtNombre.Clear();
            txtNumeroCelular.Clear();
            txtEmail.Clear();
            txtMonto.Clear();
            txtPrestamoFijo.Clear();
            txtPrestamoInteres.Clear();

            // Restablecer controles de contacto
            cbNumeroCelular.Checked = false;
            cbCorreoElectronico.Checked = false;
            lblNumeroCelular.Visible = false;
            txtNumeroCelular.Visible = false;
            lblEmail.Visible = false;
            txtEmail.Visible = false;

            // Restablecer controles de préstamo
            rbPrestamoFijo.Checked = false;
            rbPrestamoInteres.Checked = false;
            lblPrestamoFijo.Visible = false;
            txtPrestamoFijo.Visible = false;
            lblPrestamoInteres.Visible = false;
            txtPrestamoInteres.Visible = false;

            // Restablecer fecha de pago al día de hoy
            dtpFechaPago.Value = DateTime.Today;

            // Limpiar mensajes de error
            epRegistroPrestamo.Clear();
        }

    }
}
