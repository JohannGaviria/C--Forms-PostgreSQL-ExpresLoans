using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace expressLoan.Clases
{
    internal class SaldoManager
    {
        public static string CargarSaldo(int usuarioId)
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
                        cmd.Parameters.AddWithValue("usuario_id", usuarioId);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            return result.ToString();
                        }
                        else
                        {
                            return "Sin saldo";
                        }
                    }
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show("Error al cargar el saldo: " + ex.Message);
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("No se pudo establecer la conexión a la base de datos.");
                return null;
            }
        }

        public static void CargarHistorialSaldo(int usuarioId, DataGridView dgvHistorial)
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
                        cmd.Parameters.AddWithValue("id_usuario", usuarioId);

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
