using KnightAgeTool.src.database;
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

        public Giftcode(DataBaseManager database)
        {
            this.database = database;

            this.databaseName = this.database.GetDatabaseName();

            InitializeComponent();

            panel1.MouseDown += new MouseEventHandler(panel1_MouseDown);
            label3.MouseDown += new MouseEventHandler(panel1_MouseDown);
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void Giftcode_Load(object sender, EventArgs e)
        {
            label3.Text = "Database: " + this.databaseName;

            this.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            panel1.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);// rgb(37, 37, 38)
            //button1.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            //button2.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            //button3.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            groupBox1.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            //comboBox1.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
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
    }
}
