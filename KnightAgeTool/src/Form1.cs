using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using KnightAgeTool.src.model;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace KnightAgeTool.src
{
    public partial class Form1 : Form
    {

        DataBaseManager database;


        DataBaseManager database1;
        public Form1()
        {
            InitializeComponent();
            panel1.MouseDown += new MouseEventHandler(panel1_MouseDown);
            label1.MouseDown += new MouseEventHandler(panel1_MouseDown);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            panel1.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);// rgb(37, 37, 38)
            button1.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            button2.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            button3.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            groupBox1.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            comboBox1.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            HostBox.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            UserBox.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            PasswordBox.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            DatabaseBox.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            comboBox2.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            PortBox.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void ReleaseCapture();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string host = HostBox.Text;
                string user = UserBox.Text;
                string pass = PasswordBox.Text;
                string database_name = DatabaseBox.Text;
                string database = comboBox2.Text;
                int port = (int)PortBox.Value;

                if (string.IsNullOrWhiteSpace(host) || string.IsNullOrWhiteSpace(user)
                    || string.IsNullOrWhiteSpace(database_name) || string.IsNullOrWhiteSpace(database))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin vào tất cả các ô.");
                    return;
                }

                this.database = new DataBaseManager(host, port, user, pass, database_name);
                this.database1 = new DataBaseManager(host, port, user, pass, database);

                if (this.database.Connect())
                {
                    this.Hide();

                    using (Giftcode giftcodoe = new Giftcode(this.database, database1))
                    {
                        giftcodoe.StartPosition = FormStartPosition.CenterParent;
                        giftcodoe.ShowDialog();
                    }

                    this.Close();// close form 1
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        private string[] tableArray;

        private void getNameDatabase()
        {
            string connectionString = $"server={HostBox.Text};port={PortBox.Value};user={UserBox.Text};database={DatabaseBox.Text};password={PasswordBox.Text};";
            List<string> databaseNames = new List<string>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SHOW DATABASES;";
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            databaseNames.Add(reader[0].ToString());
                        }
                    }

                    foreach (string dbName in databaseNames)
                    {
                        DatabaseBox.Items.Add(dbName);
                    }

                    MessageBox.Show("Connect Thanh Cong!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách database: " + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.getNameDatabase();
        }

        private void DatabaseBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void HostBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
