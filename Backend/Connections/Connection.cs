using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Backend.Connections
{
    class Connection : IConnection
    {
        private static string GetConnectionString()
        {
            string server = "localhost"; // IP del servidor
            string port = "3306"; // Puerto
            string user = "root"; // Usuario
            string password = "root"; // Contraseña
            string database = "sireti"; // Base de datos
            string allow = "true";
            return String.Format("Server={0}; Database={4}; Uid={2}; Pwd={3}; Allow User Variables={5};", server, port, user, password, database, allow);
        }

        private static MySqlCommand FormatCommand(string sqlCommand, string[] columns, object[] keys)
        {
            var executable = new MySqlCommand();
            int min = Math.Min(columns.Length, keys.Length);
            for (int i = 0; i < min; i++)
            {
                executable.Parameters.AddWithValue("@" + columns[i], keys[i]);
            }
            return executable;
        }

        public long Execute(string sqlCommand, string[] columns, object[] keys)
        {
            var connection = new MySqlConnection();
            long lastInserted = 0;

            try
            {
                var adapter = new MySqlDataAdapter();
                var executable = FormatCommand(sqlCommand, columns, keys);
                var dataSet = new DataSet();

                connection.ConnectionString = GetConnectionString();
                connection.Open();
                executable.Connection = connection;
                executable.CommandText = sqlCommand;
                executable.ExecuteNonQuery();
                lastInserted = executable.LastInsertedId;
            }
            finally
            {
                connection.Close();
            }

            return lastInserted;
        }

        public DataTable GetData(string sqlCommand, string[] columns, object[] keys)
        {
            DataTable dataTable = null;
            var connection = new MySqlConnection();

            try
            {
                var adapter = new MySqlDataAdapter();
                var executable = FormatCommand(sqlCommand, columns, keys);
                var dataSet = new DataSet();

                connection.ConnectionString = GetConnectionString();
                connection.Open();
                executable.CommandText = sqlCommand;

                adapter.SelectCommand = executable;
                adapter.SelectCommand.Connection = connection;
                adapter.Fill(dataSet);
                dataTable = dataSet.Tables[0];
            }
            finally
            {
                connection.Close();
            }

            return dataTable;
        }
    }

    public class NewConnection : INewConnection
    {
        public IConnection Create()
        {
            return new Connection();
        }
    }
}
