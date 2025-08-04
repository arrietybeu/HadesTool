using KnightAgeTool.src.model;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace KnightAgeTool.src
{
    public partial class Giftcode : Form
    {

        private string databaseName = "";

        private DataBaseManager database;

        private DataBaseManager database2;

        private ItemView itemView;

        public Giftcode(DataBaseManager database, DataBaseManager database2)
        {
            this.database = database;
            this.database2 = database2;

            this.databaseName = this.database.GetDatabaseName();

            InitializeComponent();

            panel1.MouseDown += new MouseEventHandler(panel1_MouseDown);
            label3.MouseDown += new MouseEventHandler(panel1_MouseDown);
            dataGridView1.EnableHeadersVisualStyles = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void Giftcode_Load(object sender, EventArgs e)
        {
            label3.Text = "Database: " + this.databaseName;

            this.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            panel1.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);// rgb(37, 37, 38)
            button2.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            button3.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            button4.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            button5.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);

            groupBox1.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 64);

            // Dòng dữ liệu
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);
            dataGridView1.RowsDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 70, 75);
            dataGridView1.RowsDefaultCellStyle.SelectionForeColor = Color.White;

            // Border & grid
            dataGridView1.GridColor = Color.FromArgb(55, 55, 60);
            dataGridView1.BackgroundColor = Color.FromArgb(37, 37, 38);
            dataGridView1.BorderStyle = BorderStyle.None;

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                if (col is DataGridViewButtonColumn btnCol)
                {
                    btnCol.DefaultCellStyle.BackColor = Color.FromArgb(60, 60, 64);
                    btnCol.DefaultCellStyle.ForeColor = Color.White;
                    btnCol.FlatStyle = FlatStyle.Flat;
                }
            }

            //HostBox.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            //UserBox.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            //PasswordBox.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            //DatabaseBox.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            //PortBox.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void ReleaseCapture();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "SELECT id, CODE, amount, start, end, need_active, items_reward, players_entered FROM gift_code";
            DataTable table = database.ExecuteQuery(query);
            //MessageBox.Show("Load thanh cong: " + database.GetDatabaseName());

            dataGridView1.Rows.Clear();

            foreach (DataRow row in table.Rows)
            {
                dataGridView1.Rows.Add(
                    row["id"],
                    row["CODE"],
                    row["amount"],
                    row["start"],
                    row["end"],
                    row["need_active"],
                    row["items_reward"],
                    row["players_entered"]
                );
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                if (itemView != null && !itemView.IsDisposed)
                {
                    itemView.Close();
                }

                var row = dataGridView1.Rows[e.RowIndex];

                int idGiftCode = Convert.ToInt32(row.Cells[0].Value);
                string code = row.Cells[1].Value.ToString();
                string itemsRewardJson = row.Cells[6].Value.ToString();

                ItemView view = new ItemView(idGiftCode, code, itemsRewardJson, database2);
                view.Show();

                this.itemView = view;
            }
            else
            {
                MessageBox.Show("Mầy đã click vào ô dữ liệu: " + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
        }
    }
}
