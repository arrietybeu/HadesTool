using KnightAgeTool.src.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace KnightAgeTool.src
{
    public partial class ItemView : Form
    {
        private string itemJson = "";
        private int idGiftCode = 0;
        private string code = "";
        private DataBaseManager itemDb;
        public ItemView(int idGiftCode, string code, string itemJson, DataBaseManager itemDb)
        {
            InitializeComponent();

            this.itemDb = itemDb;

            this.idGiftCode = idGiftCode;
            this.code = code;
            this.itemJson = itemJson;

            panel1.MouseDown += new MouseEventHandler(panel1_MouseDown);
            label3.MouseDown += new MouseEventHandler(panel1_MouseDown);

            dataGridView1.EnableHeadersVisualStyles = false;
        }

        private void ItemView_Load(object sender, EventArgs e)
        {
            try
            {
                label3.Text = $"ItemView ID: {this.idGiftCode}, CODE: {code}";

                this.BackColor = Color.FromArgb(45, 45, 48);
                panel1.BackColor = Color.FromArgb(37, 37, 38);
                groupBox1.BackColor = Color.FromArgb(37, 37, 38);

                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 64);

                dataGridView1.RowsDefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);
                dataGridView1.RowsDefaultCellStyle.ForeColor = Color.White;
                dataGridView1.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 70, 75);
                dataGridView1.RowsDefaultCellStyle.SelectionForeColor = Color.White;

                dataGridView1.GridColor = Color.FromArgb(55, 55, 60);
                dataGridView1.BackgroundColor = Color.FromArgb(37, 37, 38);
                dataGridView1.BorderStyle = BorderStyle.None;

                dataGridView1.Columns.Clear();

                // Thêm cột icon đầu tiên
                DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
                imageCol.Name = "icon";
                imageCol.HeaderText = "Icon";
                imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dataGridView1.Columns.Add(imageCol);

                // Các cột còn lại
                dataGridView1.Columns.Add("temp_id", "Item ID");
                dataGridView1.Columns.Add("item_name", "Name");
                dataGridView1.Columns.Add("quantity", "Quantity");
                dataGridView1.Columns.Add("options", "Options");

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    if (col is DataGridViewButtonColumn btnCol)
                    {
                        btnCol.DefaultCellStyle.BackColor = Color.FromArgb(60, 60, 64);
                        btnCol.DefaultCellStyle.ForeColor = Color.White;
                        btnCol.FlatStyle = FlatStyle.Flat;
                    }
                }

                var items = JsonSerializer.Deserialize<List<ItemData>>(itemJson);

                foreach (var item in items)
                {
                    var (itemName, iconId) = GetItemInfo(item.TempId);
                    Image icon = LoadItemIcon(iconId);

                    string optionText = string.Join("; ", item.Options.Select(o => $"[{o.Id}:{o.Param}]"));
                    dataGridView1.Rows.Add(icon, item.TempId, itemName, item.Quantity, optionText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private (string Name, int IconId) GetItemInfo(int itemId)
        {
            string query = $"SELECT name, icon_id FROM item_template WHERE id = {itemId} LIMIT 1";
            var table = itemDb.ExecuteQuery(query);

            if (table.Rows.Count > 0)
            {
                string name = table.Rows[0]["name"].ToString();
                int iconId = Convert.ToInt32(table.Rows[0]["icon_id"]);
                return (name, iconId);
            }

            return ("Unknown", -1);
        }

        private Image LoadItemIcon(int iconId)
        {
            try
            {
                string path = Path.Combine("images", "icon", $"{iconId}.png");
                if (File.Exists(path))
                {
                    using (var bmpTemp = new Bitmap(path))
                    {
                        return new Bitmap(bmpTemp);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi khi tải icon: " + e.Message);
            }

            return null;
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
