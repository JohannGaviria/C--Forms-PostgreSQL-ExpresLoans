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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace expressLoan
{
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            cbNumeroCelular.CheckedChanged += new EventHandler(cbNumeroCelular_CheckedChanged);
            cbCorreoElectronico.CheckedChanged += new EventHandler(cbCorreoElectronico_CheckedChanged);
        }
        private void frmCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            MostrarClientes(dgvClientes);
        }

        private void lblVolver_Click(object sender, EventArgs e)
        {
            frmHome frmHome = new frmHome();
            frmHome.Show();
            this.Hide();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una fila en el DataGridView
            if (dgvClientes.SelectedRows.Count > 0)
            {
                // Obtener el ID del cliente seleccionado
                int clienteId = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["id"].Value);

                // Mostrar el GroupBox de edición con los datos del cliente seleccionado
                MostrarDatosCliente(clienteId);
                gbDatosClientes.Visible = true;
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente para editar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una fila en el DataGridView
            if (dgvClientes.SelectedRows.Count > 0)
            {
                // Obtener el ID del cliente seleccionado
                int clienteId = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["id"].Value);

                // Mostrar un mensaje de confirmación antes de eliminar el cliente
                DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este cliente?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Llamar a la función para eliminar el cliente de la base de datos
                    EliminarCliente(clienteId);

                    // Actualizar el DataGridView para reflejar los cambios
                    MostrarClientes(dgvClientes);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente para eliminar.");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Verificar si se ha ingresado un término de búsqueda
            if (!string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                // Llamar a la función para buscar clientes por ID o nombre
                BuscarCliente(txtBuscar.Text);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un término de búsqueda.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ReiniciarFormulario();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una fila en el DataGridView
            if (dgvClientes.SelectedRows.Count > 0)
            {
                // Obtener el ID del cliente seleccionado
                int clienteId = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["id"].Value);

                // Actualizar los datos del cliente en la base de datos
                ActualizarCliente(clienteId);
                ReiniciarFormulario();
                MostrarClientes(dgvClientes);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente para actualizar.");
            }
        }

        private void ReiniciarFormulario()
        {
            // Limpiar los campos de texto
            txtNombre.Clear();
            txtNumeroCelular.Clear();
            txtEmail.Clear();

            // Ocultar el GroupBox de edición
            gbDatosClientes.Visible = false;
        }

        private void ActualizarCliente(int clienteId)
        {
            // Obtener los nuevos datos del cliente desde los campos de texto
            string nuevoNombre = txtNombre.Text;
            string nuevoNumeroCelular = txtNumeroCelular.Text;
            string nuevoEmail = txtEmail.Text;

            // Realizar la actualización en la base de datos
            Conexion.Conexion conexion = new Conexion.Conexion();
            NpgsqlConnection conn = conexion.connection();

            if (conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string query = "UPDATE clientes SET nombre = @nombre, numero_celular = @numero_celular, correo_electronico = @correo_electronico WHERE id = @cliente_id";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nuevoNombre);
                        cmd.Parameters.AddWithValue("@numero_celular", nuevoNumeroCelular);
                        cmd.Parameters.AddWithValue("@correo_electronico", nuevoEmail);
                        cmd.Parameters.AddWithValue("@cliente_id", clienteId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cliente actualizado correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el cliente.");
                        }
                    }
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show("Error al actualizar el cliente: " + ex.Message);
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

        private void MostrarDatosCliente(int clienteId)
        {
            Conexion.Conexion conexion = new Conexion.Conexion();
            NpgsqlConnection conn = conexion.connection();

            if (conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string query = "SELECT nombre, numero_celular, correo_electronico FROM clientes WHERE id = @cliente_id";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@cliente_id", clienteId);

                        NpgsqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            // Obtener los datos del cliente desde el resultado de la consulta
                            string nombre = reader.GetString(0);
                            string numeroCelular = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                            string email = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);

                            // Mostrar los datos en los campos de texto correspondientes
                            txtNombre.Text = nombre;
                            txtNumeroCelular.Text = numeroCelular;
                            txtEmail.Text = email;

                            cbNumeroCelular.Checked = !string.IsNullOrEmpty(numeroCelular);
                            cbCorreoElectronico.Checked = !string.IsNullOrEmpty(email);

                        }
                        else
                        {
                            MessageBox.Show("Cliente no encontrado.");
                        }
                    }
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show("Error al cargar los datos del cliente: " + ex.Message);
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

        private void EliminarCliente(int clienteId)
        {
            Conexion.Conexion conexion = new Conexion.Conexion();
            NpgsqlConnection conn = conexion.connection();

            if (conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    // Eliminar préstamos asociados al cliente
                    string deleteLoansQuery = "DELETE FROM prestamos WHERE cliente_id = @cliente_id";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(deleteLoansQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@cliente_id", clienteId);
                        cmd.ExecuteNonQuery();
                    }

                    // Luego eliminar el cliente
                    string deleteClientQuery = "DELETE FROM clientes WHERE id = @cliente_id";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(deleteClientQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@cliente_id", clienteId);
                        cmd.ExecuteNonQuery();
                    }

                    // Actualizar la vista de clientes después de la eliminación
                    MostrarClientes(dgvClientes);
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show("Error al eliminar el cliente: " + ex.Message);
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


        private void BuscarCliente(string terminoBusqueda)
        {
            Conexion.Conexion conexion = new Conexion.Conexion();
            NpgsqlConnection conn = conexion.connection();

            if (conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string query = @"
                                    SELECT * 
                                    FROM clientes 
                                    WHERE (CAST(id AS TEXT) = @termino_busqueda OR nombre ILIKE @termino_busqueda) 
                                    AND usuario_id = @usuario_id";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@termino_busqueda", $"%{terminoBusqueda}%");
                        cmd.Parameters.AddWithValue("@usuario_id", UserSession.UserId);

                        NpgsqlDataReader reader = cmd.ExecuteReader();

                        dgvClientes.Rows.Clear();
                        dgvClientes.Columns.Clear();
                        dgvClientes.Columns.Add("id", "ID");
                        dgvClientes.Columns.Add("nombre", "Nombre");
                        dgvClientes.Columns.Add("celular", "Celular");
                        dgvClientes.Columns.Add("email", "Email");

                        while (reader.Read())
                        {
                            // Agregar fila al DataGridView
                            dgvClientes.Rows.Add(reader["id"], reader["nombre"], reader["numero_celular"], reader["correo_electronico"]);
                        }

                        // Establecer el modo de ajuste automático de columnas
                        dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        if (dgvClientes.Rows.Count == 0)
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

        private static void MostrarClientes(DataGridView dgvClientes)
        {
            Conexion.Conexion conexion = new Conexion.Conexion();
            NpgsqlConnection conn = conexion.connection();

            if (conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string query = "SELECT * FROM clientes WHERE usuario_id = @usuario_id";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario_id", UserSession.UserId);

                        NpgsqlDataReader reader = cmd.ExecuteReader();

                        // Limpiar filas existentes y definir columnas si es necesario
                        dgvClientes.Rows.Clear();
                        dgvClientes.Columns.Clear();
                        dgvClientes.Columns.Add("id", "ID");
                        dgvClientes.Columns.Add("nombre", "Nombre");
                        dgvClientes.Columns.Add("celular", "Celular");
                        dgvClientes.Columns.Add("email", "Email");

                        while (reader.Read())
                        {
                            // Agregar fila al DataGridView
                            dgvClientes.Rows.Add(reader["id"], reader["nombre"], reader["numero_celular"], reader["correo_electronico"]);
                        }

                        // Establecer el modo de ajuste automático de columnas
                        dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show("Error al cargar los clientes: " + ex.Message);
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
