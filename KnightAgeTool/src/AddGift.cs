using KnightAgeTool.src.model;
using MySqlX.XDevAPI.Common;
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

namespace KnightAgeTool.src
{
    public partial class AddGift : Form
    {
        private DataBaseManager database;

        private AddItem itemView = null;

        public static string itemsReward = "[]";
        public AddGift(DataBaseManager dataBaseManager)
        {
            InitializeComponent();
            this.database = dataBaseManager;

            panel1.MouseDown += new MouseEventHandler(panel1_MouseDown);
            label3.MouseDown += new MouseEventHandler(panel1_MouseDown);


        }

        private void AddGift_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            panel1.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);// rgb(37, 37, 38)
            groupBox1.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            button1.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            button2.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            comboBox1.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);

            codeBox.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            amountBox.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            typeBox.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);

            EndDataTime.FillColor = Color.FromArgb(37, 37, 38);
            EndDataTime.ForeColor = Color.White;
            EndDataTime.BorderColor = Color.Gray;

            StartDataTime.FillColor = Color.FromArgb(37, 37, 38);
            StartDataTime.ForeColor = Color.White;
            StartDataTime.BorderColor = Color.Gray;

            StartDataTime.Format = DateTimePickerFormat.Custom;
            StartDataTime.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            StartDataTime.ShowUpDown = true;

            EndDataTime.Format = DateTimePickerFormat.Custom;
            EndDataTime.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            EndDataTime.ShowUpDown = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (itemView != null && !itemView.IsDisposed)
            {
                itemView.Close();
            }

            AddItem view = new AddItem();
            view.Show();

            this.itemView = view;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string baseCode = codeBox.Text.Trim();
                int amountPerCode = int.Parse(amountBox.Text.Trim());
                long start = new DateTimeOffset(StartDataTime.Value).ToUnixTimeMilliseconds();
                long end = new DateTimeOffset(EndDataTime.Value).ToUnixTimeMilliseconds();
                int typeGift = int.Parse(typeBox.Text.Trim());
                int needActive = checkBox1.Checked ? 1 : 0;

                // Lấy số lượng giftcode từ comboBox1
                if (!int.TryParse(comboBox1.Text.Trim(), out int totalGiftCodes))
                {
                    MessageBox.Show("Vui lòng chọn số lượng giftcode hợp lệ từ danh sách.");
                    return;
                }

                if (string.IsNullOrEmpty(baseCode))
                {
                    MessageBox.Show("Vui lòng nhập CODE.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(itemsReward))
                {
                    MessageBox.Show("Chưa có phần thưởng (items_reward).");
                    return;
                }

                string sql = @"INSERT INTO gift_code 
            (CODE, amount, start, end, need_active, items_reward, players_entered, type_gift) 
            VALUES 
            (@code, @amount, @start, @end, @need_active, @items_reward, '[]', @type_gift)";

                if (totalGiftCodes <= 1)
                {
                    // Chỉ insert đúng 1 code như người dùng nhập
                    var parameters = new Dictionary<string, object>
            {
                {"@code", baseCode },
                {"@amount", amountPerCode },
                {"@start", start },
                {"@end", end },
                {"@need_active", needActive },
                {"@items_reward", itemsReward },
                {"@type_gift", typeGift }
            };

                    database.ExecuteNonQuery(sql, parameters);
                }
                else
                {
                    HashSet<string> generatedCodes = new HashSet<string>();

                    for (int i = 0; i < totalGiftCodes; i++)
                    {
                        string code;
                        int retryCount = 0;
                        const int maxRetries = 20;

                        do
                        {
                            code = GenerateRandomCode(6);
                            retryCount++;

                            if (retryCount > maxRetries)
                            {
                                MessageBox.Show("Không thể tạo đủ mã giftcode không trùng. Thử lại sau.");
                                return;
                            }

                        } while (generatedCodes.Contains(code) || IsCodeExistsInDatabase(code));

                        generatedCodes.Add(code);

                        var parameters = new Dictionary<string, object>{{"@code", code }
                            ,{"@amount", amountPerCode }
                            ,{"@start", start }, {"@end", end },{"@need_active", needActive },
                            {"@items_reward", itemsReward },{"@type_gift", typeGift }};

                        database.ExecuteNonQuery(sql, parameters);
                    }

                    if (checkBox2.Checked)
                    {
                        SaveGiftcodesToSheet(generatedCodes.ToList());
                    }

                }

                MessageBox.Show($"Thêm thành công {totalGiftCodes} giftcode!");
                //this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private string GenerateRandomCode(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        private bool IsCodeExistsInDatabase(string code)
        {
            string query = "SELECT COUNT(*) FROM gift_code WHERE CODE = @code";
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@code", code } };

            var cc = database.ExecuteNonQueryHe(query, parameters);
            return Convert.ToInt32(cc) > 0;
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SaveGiftcodesToSheet(List<string> codes)
        {
            if (codes == null || codes.Count == 0)
                return;

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"giftcodes_{DateTime.Now:yyyyMMdd_HHmmss}.csv");

            using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                writer.WriteLine("GiftCode"); 
                foreach (var code in codes)
                {
                    writer.WriteLine(code);
                }
            }

            MessageBox.Show($"Đã lưu giftcode ra file:\n{filePath}");
        }

    }
}
