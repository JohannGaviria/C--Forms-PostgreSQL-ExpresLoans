using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace expressLoan.Conexion
{
    internal class Conexion
    {
        NpgsqlConnection conn = new NpgsqlConnection();

        static string host = "localhost";
        static string db = "expreessloan";
        static string user = "postgres";
        static string password = "password";
        static string port = "5432";

        string connectionString = $"Host={host};Database={db};Username={user};Password={password};Port={port};";

        public NpgsqlConnection connection()
        {
            try
            {
                conn.ConnectionString = connectionString;
                conn.Open();
            }

            catch (NpgsqlException e)
            {
                MessageBox.Show("No se pudo establecer la conexion: " + e.ToString());
            }

            return conn;
        }
    }
}
