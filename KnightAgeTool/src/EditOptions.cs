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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace KnightAgeTool.src
{
    public partial class EditOptions : Form
    {
        public EditOptions()
        {
            InitializeComponent();

            panel1.MouseDown += new MouseEventHandler(panel1_MouseDown);
            label3.MouseDown += new MouseEventHandler(panel1_MouseDown);
        }

        private void EditOptions_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);


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

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            panel1.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);// rgb(37, 37, 38)
            lstSuggest.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);

            txtSearch.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            textBox1.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            button1.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            button2.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            button3.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);

            txtSearch.ForeColor = Color.White;
            textBox1.ForeColor = Color.White;
            lstSuggest.ForeColor = Color.White;

            lstSuggest.ItemHeight = 10;

            foreach (var item in Form1.options)
                lstSuggest.Items.Add(item);


            txtSearch.TextChanged += (s, e) =>
            {
                string keyword = txtSearch.Text.ToLower();

                var filtered = Form1.options
                .Where(i => i.name.ToLower().Contains(keyword)
                || i.id.ToString().Contains(keyword)).ToList();

                lstSuggest.Items.Clear();
                foreach (var item in filtered)
                    lstSuggest.Items.Add(item);

            };

            lstSuggest.Click += (s, e) =>
            {
                if (lstSuggest.SelectedItem is OptionInfo item)
                {
                    txtSearch.Text = item.id.ToString();
                }
            };

            lstSuggest.DrawItem += (s, e) =>
            {
                e.DrawBackground();
                if (e.Index >= 0)
                {
                    var item = (OptionInfo)lstSuggest.Items[e.Index];

                    using (Brush brush = new SolidBrush(Color.White))
                    {
                        e.Graphics.DrawString($"{item.name} (ID: {item.id})", e.Font, brush, e.Bounds.Left + 45, e.Bounds.Top + 10);
                    }
                }
                e.DrawFocusRectangle();
            };

            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter && lstSuggest.Visible && lstSuggest.Items.Count > 0)
                {
                    var item = lstSuggest.Items[0] as OptionInfo;
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
                    var item = lstSuggest.Items[0] as OptionInfo;
                    if (item != null)
                    {
                        txtSearch.Text = item.id.ToString();

                        //MessageBox.Show($"Đã chọn: {item.Name} (ID: {item.Id})");
                        e.Handled = true;
                    }
                }
            };
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSearch.Text.Trim(), out int id))
            {
                MessageBox.Show("ID không hợp lệ.");
                return;
            }

            if (!int.TryParse(textBox1.Text.Trim(), out int param))
            {
                MessageBox.Show("Param không hợp lệ.");
                return;
            }

            var option = Form1.options.FirstOrDefault(o => o.id == id);
            if (option == null)
            {
                MessageBox.Show("Không tìm thấy option với ID đã nhập.");
                return;
            }

            string displayText = option.name.Replace("#", param.ToString());

            if (!dataGridView1.Columns.Contains("display"))
            {
                dataGridView1.Columns.Add("display", "Tên hiển thị");
            }


            dataGridView1.Rows.Add(id, param, displayText);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<OptionInfo> options = new List<OptionInfo>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                if (int.TryParse(row.Cells["id"].Value?.ToString(), out int id) &&
                    int.TryParse(row.Cells["param"].Value?.ToString(), out int param))
                {
                    options.Add(new OptionInfo { id = id, param = param });
                }
            }

            string json = JsonSerializer.Serialize(options, new JsonSerializerOptions { WriteIndented = true });
            MessageBox.Show(json);
            AddItem.jsonOptions = json;

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
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
    }
}
