using KnightAgeTool.src.model;
using MySql.Data.MySqlClient;
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
using static System.Runtime.CompilerServices.RuntimeHelpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using Button = System.Windows.Forms.Button;
using TextBox = System.Windows.Forms.TextBox;

namespace KnightAgeTool.src
{
    public partial class Giftcode : Form
    {

        private string databaseName = "";

        private DataBaseManager database;

        private DataBaseManager database2;

        private ItemView itemView;

        private AddGift addGiftView;

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
            using (SelectConditionForm form = new SelectConditionForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    string id = form.IdValue;
                    string type = form.TypeValue;
                    string code = form.CodeValue;

                    // Xây dựng câu query SELECT
                    string query = "SELECT id, CODE, amount, start, end, need_active, items_reward, players_entered FROM gift_code WHERE 1=1";

                    List<MySqlParameter> parameters = new List<MySqlParameter>();

                    if (!string.IsNullOrEmpty(id))
                    {
                        query += " AND id = @id";
                        parameters.Add(new MySqlParameter("@id", id));
                    }

                    if (!string.IsNullOrEmpty(type))
                    {
                        query += " AND type_gift = @type_gift";
                        parameters.Add(new MySqlParameter("@type_gift", type));
                    }

                    if (!string.IsNullOrEmpty(code))
                    {
                        query += " AND CODE = @code";
                        parameters.Add(new MySqlParameter("@code", code));
                    }

                    try
                    {
                        DataTable table = database.ExecuteQuery(query, parameters.ToArray());

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

                        if (table.Rows.Count == 0)
                        {
                            MessageBox.Show("Không tìm thấy dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi truy vấn dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

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

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var confirmForm = new Form())
            {
                confirmForm.Text = "XÁC NHẬN XÓA TOÀN BỘ";
                confirmForm.StartPosition = FormStartPosition.CenterParent;
                confirmForm.Size = new Size(400, 150);
                confirmForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                confirmForm.BackColor = Color.Black;
                confirmForm.ForeColor = Color.White;
                confirmForm.ControlBox = false;

                Label lbl = new Label()
                {
                    Text = "Bạn có chắc muốn xóa toàn bộ dữ liệu bảng giftcode?",
                    AutoSize = false,
                    Size = new Size(360, 40),
                    Location = new Point(20, 10),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };
                confirmForm.Controls.Add(lbl);

                System.Windows.Forms.Button btnOK = new System.Windows.Forms.Button()
                {
                    Text = "OK",
                    DialogResult = DialogResult.OK,
                    Location = new Point(100, 70),
                    BackColor = Color.Red,
                    ForeColor = Color.White
                };
                confirmForm.Controls.Add(btnOK);

                System.Windows.Forms.Button btnCancel = new System.Windows.Forms.Button()
                {
                    Text = "HỦY",
                    DialogResult = DialogResult.Cancel,
                    Location = new Point(200, 70),
                    BackColor = Color.Gray,
                    ForeColor = Color.White
                };
                confirmForm.Controls.Add(btnCancel);

                confirmForm.AcceptButton = btnOK;
                confirmForm.CancelButton = btnCancel;

                if (confirmForm.ShowDialog() == DialogResult.OK)
                {
                    TruncateGiftcodeTable();
                    MessageBox.Show("Đã xóa toàn bộ dữ liệu bảng giftcode!", "XÓA THÀNH CÔNG", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGiftcodes();
                }
            }
        }

        private void TruncateGiftcodeTable()
        {
            try
            {
                database.ExecuteNonQuery("TRUNCATE TABLE gift_code");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi truncate bảng gift_code:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadGiftcodes()
        {
            string query = "SELECT id, CODE, amount, start, end, need_active, items_reward, players_entered FROM gift_code";
            DataTable table = database.ExecuteQuery(query);

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

        private void button4_Click(object sender, EventArgs e)
        {

            if (addGiftView != null && !addGiftView.IsDisposed)
            {
                addGiftView.Close();
            }

            var addGift = new AddGift(database);
            addGift.Show();

            this.addGiftView = addGift;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (Form confirmForm = new Form())
            {
                confirmForm.Text = "XÁC NHẬN XÓA GIFT CODE";
                confirmForm.StartPosition = FormStartPosition.CenterParent;
                confirmForm.Size = new Size(420, 300);
                confirmForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                confirmForm.BackColor = Color.Black;
                confirmForm.ForeColor = Color.White;
                confirmForm.ControlBox = false;

                // Label hướng dẫn
                Label lblType = new Label()
                {
                    Text = "Chọn loại dữ liệu để xóa:",
                    AutoSize = false,
                    Size = new Size(360, 30),
                    Location = new Point(30, 20),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };
                confirmForm.Controls.Add(lblType);

                // ComboBox chọn loại
                System.Windows.Forms.ComboBox comboType = new System.Windows.Forms.ComboBox()
                {
                    Location = new Point(30, 55),
                    Width = 340,
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    BackColor = Color.FromArgb(37, 37, 38),
                    ForeColor = Color.White
                };
                comboType.Items.AddRange(new string[] { "ID", "CODE", "TYPE" });
                confirmForm.Controls.Add(comboType);

                // Label nhập giá trị
                Label lblValue = new Label()
                {
                    Text = "Nhập giá trị cần xóa:",
                    AutoSize = false,
                    Size = new Size(360, 30),
                    Location = new Point(30, 95),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };
                confirmForm.Controls.Add(lblValue);

                // TextBox nhập giá trị
                TextBox inputBox = new TextBox()
                {
                    Location = new Point(30, 130),
                    Width = 340,
                    BackColor = Color.FromArgb(37, 37, 38),
                    ForeColor = Color.White
                };
                confirmForm.Controls.Add(inputBox);

                // Nút OK
                Button btnOK = new Button()
                {
                    Text = "OK",
                    DialogResult = DialogResult.OK,
                    Location = new Point(100, 200),
                    BackColor = Color.Red,
                    ForeColor = Color.White
                };
                confirmForm.Controls.Add(btnOK);

                // Nút Hủy
                Button btnCancel = new Button()
                {
                    Text = "HỦY",
                    DialogResult = DialogResult.Cancel,
                    Location = new Point(200, 200),
                    BackColor = Color.Gray,
                    ForeColor = Color.White
                };
                confirmForm.Controls.Add(btnCancel);

                confirmForm.AcceptButton = btnOK;
                confirmForm.CancelButton = btnCancel;

                if (confirmForm.ShowDialog() == DialogResult.OK)
                {
                    string selectedType = comboType.SelectedItem?.ToString();
                    string input = inputBox.Text.Trim();

                    if (string.IsNullOrEmpty(selectedType) || string.IsNullOrEmpty(input))
                    {
                        MessageBox.Show("Vui lòng chọn loại và nhập giá trị để xóa.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    try
                    {
                        switch (selectedType)
                        {
                            case "ID":
                                if (!int.TryParse(input, out int id))
                                {
                                    MessageBox.Show("ID phải là số nguyên.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                if (!CheckGiftcodeExists("id", input))
                                {
                                    MessageBox.Show("Không tìm thấy giftcode có ID này.", "Không tồn tại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                DeleteById(id);
                                break;

                            case "CODE":
                                if (!CheckGiftcodeExists("CODE", input))
                                {
                                    MessageBox.Show("Không tìm thấy CODE này.", "Không tồn tại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                DeleteByCode(input);
                                break;

                            case "TYPE":
                                if (!CheckGiftcodeExists("type_gift", input))
                                {
                                    MessageBox.Show("Không có dòng nào có TYPE này.", "Không tồn tại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                DeleteByType(input);
                                break;

                            default:
                                MessageBox.Show("Loại xóa không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private bool CheckGiftcodeExists(string column, string value)
        {
            string query = $"SELECT COUNT(*) FROM gift_code WHERE {column} = @value";
            using (MySqlCommand cmd = new MySqlCommand(query, database.GetConnection()))
            {
                cmd.Parameters.AddWithValue("@value", value);
                var result = cmd.ExecuteScalar();
                return Convert.ToInt32(result) > 0;
            }
        }


        private void DeleteById(int id)
        {
            try
            {
                string query = "DELETE FROM gift_code WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, database.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show($"Đã xóa giftcode ID = {id}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGiftcodes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteByCode(string code)
        {
            try
            {
                string query = "DELETE FROM gift_code WHERE CODE = @code";
                using (MySqlCommand cmd = new MySqlCommand(query, database.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show($"Đã xóa giftcode CODE = \"{code}\"", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGiftcodes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteByType(string type)
        {
            try
            {
                string query = "DELETE FROM gift_code WHERE type_gift = @type";
                using (MySqlCommand cmd = new MySqlCommand(query, database.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show($"Đã xóa tất cả giftcode có TYPE = \"{type}\"", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGiftcodes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
