using System.Runtime.InteropServices;
using System.Windows.Forms;
using KnightAgeTool.src;
using KnightAgeTool.src.model;

namespace KnightAgeTool
{
    public partial class DrawMap : Form
    {
        private Image originalImage;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void ReleaseCapture();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        private bool isTay = false;

        private DataBaseManager database;

        private string databaseName = "";

        public DrawMap(DataBaseManager database)
        {
            this.database = database;

            this.databaseName = this.database.GetDatabaseName();
            InitializeComponent();

            pictureBox2.MouseDown += pictureBox2_MouseDown;

            pictureBox2.MouseUp += pictureBox2_MouseUp;

            // keo tha form panel
            panel1.MouseDown += panel1_MouseDown;

            // an text o panel co the keo tha
            label3.MouseDown += panel1_MouseDown;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = "Project: " + this.databaseName;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string file = $"images/dock-close.png";
            if (File.Exists(file))
            {
                pictureBox2.Image = Image.FromFile(file);
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            }

            Application.Exit();
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                this.originalImage = pictureBox2.Image;

                string file = $"images/dock-close.png";
                if (File.Exists(file))
                {
                    pictureBox2.Image = Image.FromFile(file);
                    pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (originalImage != null)
                {
                    pictureBox2.Image = originalImage;
                }
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void newToolStripButton_Click_1(object sender, EventArgs e)
        {
            FormCreateData formCreateData = new FormCreateData();
            formCreateData.StartPosition = FormStartPosition.CenterScreen;
            formCreateData.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (this.isTay)
            {
                isTay = false;
                this.Cursor = Cursors.Default;
                return;
            }
            this.isTay = true;
            string imagePath = $"images/22/tay.png";
            if (File.Exists(imagePath))
            {
                Bitmap bmp = new Bitmap(imagePath);
                IntPtr ptr = bmp.GetHicon();
                Cursor eraserCursor = new Cursor(ptr);
                this.Cursor = eraserCursor;
            }
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vui lòng liên hệ đến Béo Toán Học\nZalo: 0327068593", "Support", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
