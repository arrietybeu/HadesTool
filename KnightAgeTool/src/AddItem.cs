using KnightAgeTool.src.model;
using Microsoft.VisualBasic.Devices;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace KnightAgeTool.src
{
    public partial class AddItem : Form
    {

        private EditOptions _options;

        public static string jsonOptions;
        public AddItem()
        {
            InitializeComponent();

            panel1.MouseDown += new MouseEventHandler(panel1_MouseDown);
            label3.MouseDown += new MouseEventHandler(panel1_MouseDown);
        }

        private void AddItem_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            panel1.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);// rgb(37, 37, 38)
            lstSuggest.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            txtSearch.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            button2.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);

            textBox1.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            button1.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);

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

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.Columns.Clear();

            txtSearch.ForeColor = Color.White;
            textBox1.ForeColor = Color.White;
            lstSuggest.ForeColor = Color.White;

            lstSuggest.DrawMode = DrawMode.OwnerDrawFixed;
            lstSuggest.ItemHeight = 36;

            foreach (var item in Form1.AllItems)
                lstSuggest.Items.Add(item);


            txtSearch.TextChanged += (s, e) =>
            {
                string keyword = txtSearch.Text.ToLower();

                var filtered = Form1.AllItems
                .Where(i => i.Name.ToLower().Contains(keyword)
                || i.id.ToString().Contains(keyword)).ToList();

                lstSuggest.Items.Clear();
                foreach (var item in filtered)
                    lstSuggest.Items.Add(item);

            };

            lstSuggest.Click += (s, e) =>
            {
                if (lstSuggest.SelectedItem is ItemInfo item)
                {
                    txtSearch.Text = item.id.ToString();

                    //MessageBox.Show($"Đã chọn: {item.Name} (ID: {item.Id})");
                }
            };

            lstSuggest.DrawItem += (s, e) =>
            {
                e.DrawBackground();
                if (e.Index >= 0)
                {
                    var item = (ItemInfo)lstSuggest.Items[e.Index];
                    Image icon = LoadItemIcon(item.IconId);

                    if (icon != null)
                        e.Graphics.DrawImage(icon, e.Bounds.Left + 5, e.Bounds.Top + 2, 32, 32);

                    using (Brush brush = new SolidBrush(Color.White))
                    {
                        e.Graphics.DrawString($"{item.Name} (ID: {item.id})", e.Font, brush, e.Bounds.Left + 45, e.Bounds.Top + 10);
                    }
                }
                e.DrawFocusRectangle();
            };

            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter && lstSuggest.Visible && lstSuggest.Items.Count > 0)
                {
                    var item = lstSuggest.Items[0] as ItemInfo;
                    if (item != null)
                    {
                        txtSearch.Text = item.id.ToString();

                        //MessageBox.Show($"Đã chọn: {item.Name} (ID: {item.Id})");
                        e.Handled = true;
                    }
                }
            };

            lstSuggest.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter && lstSuggest.Visible && lstSuggest.Items.Count > 0)
                {
                    var item = lstSuggest.Items[0] as ItemInfo;
                    if (item != null)
                    {
                        txtSearch.Text = item.id.ToString();

                        //MessageBox.Show($"Đã chọn: {item.Name} (ID: {item.Id})");
                        e.Handled = true;
                    }
                }
            };

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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load icon: " + ex.Message);
            }

            return null;
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSearch.Text.Trim(), out int itemId))
            {
                MessageBox.Show("ID item không hợp lệ.");
                return;
            }

            if (!int.TryParse(textBox1.Text.Trim(), out int quantity))
            {
                MessageBox.Show("Số lượng không hợp lệ.");
                return;
            }

            string optionsJson = jsonOptions ?? "[]";

            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("item_id", "Item ID");
                dataGridView1.Columns.Add("quantity", "Quantity");
                dataGridView1.Columns.Add("options", "Options JSON");
            }

            dataGridView1.Rows.Add(itemId, quantity, optionsJson);

            jsonOptions = "";
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void selectOptions_TextChanged(object sender, EventArgs e)
        {

        }

        private void lstSuggest_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_options != null && !_options.IsDisposed)
            {
                _options.Close();
            }

            EditOptions view = new EditOptions();
            view.Show();

            this._options = view;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        dataGridView1.Rows.Remove(row);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var result = new List<object>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                if (!int.TryParse(row.Cells["item_id"].Value?.ToString(), out int temp_id) ||
                    !int.TryParse(row.Cells["quantity"].Value?.ToString(), out int quantity))
                {
                    continue;
                }

                string optionsJson = row.Cells["options"].Value?.ToString() ?? "[]";

                var options = new List<Dictionary<string, int>>();
                try
                {
                    options = JsonSerializer.Deserialize<List<Dictionary<string, int>>>(optionsJson);
                }
                catch
                {
                }

                var itemObj = new
                {
                    temp_id = temp_id,
                    quantity = quantity,
                    options = options
                };

                result.Add(itemObj);
            }

            string jsonOutput = JsonSerializer.Serialize(result, new JsonSerializerOptions
            {
                WriteIndented = false
            });

            MessageBox.Show(jsonOutput);

            AddGift.itemsReward = jsonOutput;


            this.Close();
        }
    }
}
