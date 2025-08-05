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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace KnightAgeTool.src
{
    public partial class AddItem : Form
    {
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

            txtSearch.ForeColor = Color.White;
            lstSuggest.ForeColor = Color.White;


            lstSuggest.Visible = false;
            lstSuggest.DrawMode = DrawMode.OwnerDrawFixed;
            lstSuggest.ItemHeight = 36;

            //MessageBox.Show("Số lượng item: " + Form1.AllItems.Count);

            txtSearch.TextChanged += (s, e) =>
            {
                string keyword = txtSearch.Text.ToLower();

                var filtered = Form1.AllItems
                    .Where(i => i.Name.ToLower().Contains(keyword) || i.Id.ToString().Contains(keyword))
                    .Take(10)
                    .ToList();

                lstSuggest.Items.Clear();
                foreach (var item in filtered)
                    lstSuggest.Items.Add(item);

                lstSuggest.Visible = lstSuggest.Items.Count > 0;
            };

            lstSuggest.Click += (s, e) =>
            {
                if (lstSuggest.SelectedItem is ItemInfo item)
                {
                    //txtSearch.Text = item.Name;
                    txtSearch.Text = item.Id.ToString();

                    lstSuggest.Visible = false;
                    MessageBox.Show($"Đã chọn: {item.Name} (ID: {item.Id})");
                    // TODO: xử lý logic sau khi chọn item
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
                        e.Graphics.DrawString($"{item.Name} (ID: {item.Id})", e.Font, brush, e.Bounds.Left + 45, e.Bounds.Top + 10);
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
                        txtSearch.Text = item.Id.ToString();
                        lstSuggest.Visible = false;

                        MessageBox.Show($"Đã chọn: {item.Name} (ID: {item.Id})");
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
                        txtSearch.Text = item.Id.ToString();
                        lstSuggest.Visible = false;

                        MessageBox.Show($"Đã chọn: {item.Name} (ID: {item.Id})");
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
    }
}
