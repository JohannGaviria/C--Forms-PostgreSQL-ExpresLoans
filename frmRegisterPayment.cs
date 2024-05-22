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
    public partial class frmRegisterPayment : Form
    {
        public frmRegisterPayment()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void frmRegisterPayment_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void lblVolver_Click(object sender, EventArgs e)
        {
            frmHome frmHome = new frmHome();
            frmHome.Show();
            this.Hide();
        }

        private void frmRegisterPayment_Load(object sender, EventArgs e)
        {
            MostrarPrestamos(dgvPrestamos);
        }

        private void btnPago_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una fila en el DataGridView
            if (dgvPrestamos.SelectedRows.Count > 0)
            {
                // Obtener el ID del préstamo seleccionado
                int prestamoId = Convert.ToInt32(dgvPrestamos.SelectedRows[0].Cells["id"].Value);

                // Confirmar el pago
                DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea registrar el pago de este préstamo?", "Confirmar Pago", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    // Conectar a la base de datos
                    Conexion.Conexion conexion = new Conexion.Conexion();
                    NpgsqlConnection conn = conexion.connection();

                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        try
                        {
                            using (var transaction = conn.BeginTransaction())
                            {
                                // Obtener los detalles del préstamo
                                string selectPrestamoQuery = "SELECT prestamo_fijo, prestamo_interes FROM prestamos WHERE id = @prestamo_id";
                                decimal montoPagar = 0;
                                using (NpgsqlCommand cmd = new NpgsqlCommand(selectPrestamoQuery, conn))
                                {
                                    cmd.Parameters.AddWithValue("@prestamo_id", prestamoId);
                                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            // Determinar el monto a pagar según el tipo de préstamo
                                            if (!reader.IsDBNull(0)) // Si es préstamo fijo
                                            {
                                                montoPagar = Convert.ToDecimal(reader.GetString(0));
                                            }
                                            else if (!reader.IsDBNull(1)) // Si es préstamo con interés
                                            {
                                                decimal montoBase = Convert.ToDecimal(dgvPrestamos.SelectedRows[0].Cells["monto"].Value);
                                                decimal porcentajeInteres = Convert.ToDecimal(reader.GetString(1));
                                                montoPagar = montoBase + (montoBase * (porcentajeInteres / 100));
                                            }
                                        }
                                    }
                                }

                                // Actualizar el estado del préstamo
                                string updatePrestamoQuery = "UPDATE prestamos SET estado = 'Pagado' WHERE id = @prestamo_id";
                                using (NpgsqlCommand cmd = new NpgsqlCommand(updatePrestamoQuery, conn))
                                {
                                    cmd.Parameters.AddWithValue("@prestamo_id", prestamoId);
                                    cmd.ExecuteNonQuery();
                                }

                                // Registrar el pago en el historial de saldo
                                string insertHistorialQuery = "INSERT INTO historial_saldo (id_usuario, fecha, tipo_movimiento, monto) VALUES (@id_usuario, CURRENT_TIMESTAMP, @tipo_movimiento, @monto)";
                                using (NpgsqlCommand cmd = new NpgsqlCommand(insertHistorialQuery, conn))
                                {
                                    cmd.Parameters.AddWithValue("@id_usuario", UserSession.UserId);
                                    cmd.Parameters.AddWithValue("@tipo_movimiento", "Pago");
                                    cmd.Parameters.AddWithValue("@monto", montoPagar.ToString()); // Convertir a string para varchar
                                    cmd.ExecuteNonQuery();
                                }

                                // Actualizar el saldo del usuario
                                string updateSaldoQuery = "UPDATE saldos SET saldo = (CAST(saldo AS DECIMAL) + @monto)::VARCHAR WHERE usuario_id = @usuario_id";
                                using (NpgsqlCommand cmd = new NpgsqlCommand(updateSaldoQuery, conn))
                                {
                                    cmd.Parameters.AddWithValue("@monto", montoPagar);
                                    cmd.Parameters.AddWithValue("@usuario_id", UserSession.UserId);
                                    cmd.ExecuteNonQuery();
                                }

                                // Commit the transaction
                                transaction.Commit();

                                MessageBox.Show("Pago registrado exitosamente.");
                                MostrarPrestamos(dgvPrestamos);
                            }
                        }
                        catch (NpgsqlException ex)
                        {
                            MessageBox.Show("Error al registrar el pago: " + ex.Message);
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
            else
            {
                MessageBox.Show("Por favor, seleccione un préstamo para registrar el pago.");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Verificar si se ha ingresado un término de búsqueda
            if (!string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                // Llamar a la función para buscar clientes por ID o nombre
                BuscarPrestamo(txtBuscar.Text);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un término de búsqueda.");
            }
        }

        private void BuscarPrestamo(string terminoBusqueda)
        {
            Conexion.Conexion conexion = new Conexion.Conexion();
            NpgsqlConnection conn = conexion.connection();

            if (conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string query = @"SELECT p.id, c.nombre AS nombre_cliente, p.monto, p.estado, p.fecha_pago
                                     FROM prestamos p
                                     INNER JOIN clientes c ON p.cliente_id = c.id
                                     WHERE (CAST(p.id AS TEXT) = @termino_busqueda OR c.nombre ILIKE @termino_busqueda) 
                                     AND p.usuario_id = @usuario_id";


                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@termino_busqueda", $"%{terminoBusqueda}%");
                        cmd.Parameters.AddWithValue("@usuario_id", UserSession.UserId);

                        NpgsqlDataReader reader = cmd.ExecuteReader();

                        // Limpiar filas existentes y definir columnas si es necesario
                        dgvPrestamos.Rows.Clear();
                        dgvPrestamos.Columns.Clear();
                        dgvPrestamos.Columns.Add("id", "ID");
                        dgvPrestamos.Columns.Add("nombre", "Nombre");
                        dgvPrestamos.Columns.Add("monto", "Monto");
                        dgvPrestamos.Columns.Add("estado", "Estado");
                        dgvPrestamos.Columns.Add("fecha", "Fecha");

                        while (reader.Read())
                        {
                            // Agregar fila al DataGridView
                            dgvPrestamos.Rows.Add(reader["id"], reader["nombre_cliente"], reader["monto"], reader["estado"], reader["fecha_pago"]);
                        }

                        // Establecer el modo de ajuste automático de columnas
                        dgvPrestamos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        if (dgvPrestamos.Rows.Count == 0)
                        {
                            MessageBox.Show("No se encontraron resultados para la búsqueda.");
                        }
                    }
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show("Error al realizar la búsqueda: " + ex.Message);
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

        private static void MostrarPrestamos(DataGridView dgvPrestamos)
        {
            Conexion.Conexion conexion = new Conexion.Conexion();
            NpgsqlConnection conn = conexion.connection();

            if (conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string query = @"SELECT p.id, c.nombre AS nombre_cliente, p.monto, p.estado, p.fecha_pago
                                    FROM prestamos p
                                    INNER JOIN clientes c ON p.cliente_id = c.id
                                    WHERE p.usuario_id = @usuario_id
                                    ORDER BY CASE WHEN p.estado = 'Pendiente' THEN 0 ELSE 1 END, p.fecha_prestamo ASC";


                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario_id", UserSession.UserId);

                        NpgsqlDataReader reader = cmd.ExecuteReader();

                        // Limpiar filas existentes y definir columnas si es necesario
                        dgvPrestamos.Rows.Clear();
                        dgvPrestamos.Columns.Clear();
                        dgvPrestamos.Columns.Add("id", "ID");
                        dgvPrestamos.Columns.Add("nombre", "Nombre");
                        dgvPrestamos.Columns.Add("monto", "Monto");
                        dgvPrestamos.Columns.Add("estado", "Estado");
                        dgvPrestamos.Columns.Add("fecha", "Fecha");

                        while (reader.Read())
                        {
                            // Agregar fila al DataGridView
                            dgvPrestamos.Rows.Add(reader["id"], reader["nombre_cliente"], reader["monto"], reader["estado"], reader["fecha_pago"]);
                        }

                        // Establecer el modo de ajuste automático de columnas
                        dgvPrestamos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show("Error al cargar los préstamos: " + ex.Message);
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
