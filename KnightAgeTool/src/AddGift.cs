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

namespace KnightAgeTool.src
{
    public partial class AddGift : Form
    {
        private DataBaseManager database;
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
            comboBox2.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            comboBox3.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            comboBox4.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
            comboBox5.BackColor = System.Drawing.Color.FromArgb(37, 37, 38);
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

        }
    }
}
