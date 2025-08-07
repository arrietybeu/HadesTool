using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnightAgeTool.src
{
    public partial class SelectConditionForm : Form
    {
        public string IdValue => textBoxId.Text.Trim();
        public string TypeValue => textBoxType.Text.Trim();
        public string CodeValue => textBoxCode.Text.Trim();

        public SelectConditionForm()
        {
            InitializeComponent();
            InitUI();
        }

        private void SelectConditionForm_Load(object sender, EventArgs e)
        {

        }

        private void InitUI()
        {
            this.Text = "Chọn điều kiện lọc";
            this.Size = new Size(400, 250);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(45, 45, 48);
            this.ForeColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            Label labelId = new Label() { Text = "ID:", Location = new Point(30, 20), AutoSize = true };
            textBoxId = new TextBox() { Location = new Point(100, 20), Width = 240, BackColor = Color.FromArgb(37, 37, 38), ForeColor = Color.White };

            Label labelType = new Label() { Text = "Type:", Location = new Point(30, 60), AutoSize = true };
            textBoxType = new TextBox() { Location = new Point(100, 60), Width = 240, BackColor = Color.FromArgb(37, 37, 38), ForeColor = Color.White };

            Label labelCode = new Label() { Text = "Code:", Location = new Point(30, 100), AutoSize = true };
            textBoxCode = new TextBox() { Location = new Point(100, 100), Width = 240, BackColor = Color.FromArgb(37, 37, 38), ForeColor = Color.White };

            Button buttonOk = new Button()
            {
                Text = "OK",
                Location = new Point(150, 150),
                BackColor = Color.FromArgb(37, 37, 38),
                ForeColor = Color.White,
                DialogResult = DialogResult.OK
            };

            this.Controls.Add(labelId);
            this.Controls.Add(textBoxId);
            this.Controls.Add(labelType);
            this.Controls.Add(textBoxType);
            this.Controls.Add(labelCode);
            this.Controls.Add(textBoxCode);
            this.Controls.Add(buttonOk);

            this.AcceptButton = buttonOk;
        }

        private TextBox textBoxId;
        private TextBox textBoxType;
        private TextBox textBoxCode;
    }
}
