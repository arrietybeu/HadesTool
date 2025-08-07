using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace KnightAgeTool.src.model
{
    public class DataBaseManager
    {

        private MySqlConnection connection;
        private bool isConnected = false;
        private string host;
        private string user;
        private string pass;
        private string database_name;
        private int port;

        public DataBaseManager(string host, int port, string user, string pass, string database)
        {
            this.host = host;
            this.user = user;
            this.pass = pass;
            this.database_name = database;
            this.port = port;

            string connectionString = $"server={host};port={port};user={user};database={database};password={pass};";
            this.connection = new MySqlConnection(connectionString);
        }
        public bool Connect()
        {
            try
            {
                connection.Open();
                isConnected = true;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
                return false;
            }
        }

        public void ExecuteNonQuery(string query)
        {
            try
            {
                if (!isConnected)
                {
                    Connect();
                }

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi truy vấn: " + ex.Message);
            }
        }

        public void ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            try
            {
                if (!isConnected)
                {
                    Connect();
                }

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi truy vấn: " + ex.Message);
            }
        }

        public int ExecuteNonQueryHe(string query, Dictionary<string, object> parameters)
        {
            try
            {
                if (!isConnected)
                {
                    Connect();
                }

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi truy vấn: " + ex.Message);
                return -1; // hoặc bạn có thể trả về 0 nếu muốn mặc định không thành công
            }
        }



        public void CloseConnection()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                isConnected = false;
            }
        }
        public MySqlConnection GetConnection()
        {
            return connection;
        }

        public bool IsConnected()
        {
            return isConnected;
        }

        public string GetDatabaseName()
        {
            return database_name;
        }

        public string GetHost()
        {
            return host;
        }

        public string GetUser()
        {
            return user;
        }

        public string GetPass()
        {
            return pass;
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();

            try
            {
                if (!isConnected)
                {
                    Connect();
                }

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable); // Lấy dữ liệu từ query và đổ vào DataTable
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực hiện truy vấn: " + ex.Message);
            }

            return dataTable;
        }

        public DataTable ExecuteQuery(string query, params MySqlParameter[] parameters)
        {
            if (!isConnected) Connect();

            using (var cmd = new MySqlCommand(query, connection))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

    }

}
