namespace KnightAgeTool.src
{
    partial class AddGift
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddGift));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Panel();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            groupBox1 = new GroupBox();
            StartDataTime = new Guna.UI2.WinForms.Guna2DateTimePicker();
            EndDataTime = new Guna.UI2.WinForms.Guna2DateTimePicker();
            button2 = new Button();
            typeBox = new ComboBox();
            label8 = new Label();
            button1 = new Button();
            label7 = new Label();
            checkBox1 = new CheckBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            amountBox = new ComboBox();
            label2 = new Label();
            codeBox = new ComboBox();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveBorder;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(pictureBox2);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(581, 31);
            panel1.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Silver;
            label3.Location = new Point(3, 4);
            label3.Name = "label3";
            label3.Size = new Size(98, 20);
            label3.TabIndex = 7;
            label3.Text = "Add Giftcode";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(553, -2);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(25, 29);
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(StartDataTime);
            groupBox1.Controls.Add(EndDataTime);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(typeBox);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(amountBox);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(codeBox);
            groupBox1.Controls.Add(label1);
            groupBox1.ForeColor = Color.Silver;
            groupBox1.Location = new Point(12, 38);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(556, 400);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Arriety";
            // 
            // StartDataTime
            // 
            StartDataTime.Checked = true;
            StartDataTime.CustomizableEdges = customizableEdges5;
            StartDataTime.Font = new Font("Segoe UI", 9F);
            StartDataTime.Format = DateTimePickerFormat.Long;
            StartDataTime.Location = new Point(133, 173);
            StartDataTime.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            StartDataTime.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            StartDataTime.Name = "StartDataTime";
            StartDataTime.ShadowDecoration.CustomizableEdges = customizableEdges6;
            StartDataTime.Size = new Size(375, 28);
            StartDataTime.TabIndex = 34;
            StartDataTime.Value = new DateTime(2025, 8, 5, 0, 36, 50, 641);
            // 
            // EndDataTime
            // 
            EndDataTime.Checked = true;
            EndDataTime.CustomizableEdges = customizableEdges7;
            EndDataTime.Font = new Font("Segoe UI", 9F);
            EndDataTime.Format = DateTimePickerFormat.Long;
            EndDataTime.Location = new Point(133, 220);
            EndDataTime.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            EndDataTime.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            EndDataTime.Name = "EndDataTime";
            EndDataTime.ShadowDecoration.CustomizableEdges = customizableEdges8;
            EndDataTime.Size = new Size(375, 28);
            EndDataTime.TabIndex = 33;
            EndDataTime.Value = new DateTime(2025, 8, 5, 0, 36, 50, 641);
            // 
            // button2
            // 
            button2.Location = new Point(424, 339);
            button2.Name = "button2";
            button2.Size = new Size(84, 29);
            button2.TabIndex = 32;
            button2.Text = "ADD ITEM";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // typeBox
            // 
            typeBox.FlatStyle = FlatStyle.Flat;
            typeBox.ForeColor = SystemColors.ButtonHighlight;
            typeBox.FormattingEnabled = true;
            typeBox.Location = new Point(133, 126);
            typeBox.Margin = new Padding(3, 4, 3, 4);
            typeBox.Name = "typeBox";
            typeBox.Size = new Size(375, 28);
            typeBox.TabIndex = 31;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(25, 134);
            label8.Name = "label8";
            label8.Size = new Size(43, 20);
            label8.TabIndex = 30;
            label8.Text = "Type:";
            // 
            // button1
            // 
            button1.Location = new Point(133, 263);
            button1.Name = "button1";
            button1.Size = new Size(375, 29);
            button1.TabIndex = 29;
            button1.Text = "ADD ITEM";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(25, 272);
            label7.Name = "label7";
            label7.Size = new Size(42, 20);
            label7.TabIndex = 28;
            label7.Text = "Item:";
            label7.Click += label7_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(25, 344);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(310, 24);
            checkBox1.TabIndex = 27;
            checkBox1.Text = "Yêu cầu kích hoạt nhân vật mới được nhập";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 345);
            label6.Name = "label6";
            label6.Size = new Size(0, 20);
            label6.TabIndex = 26;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 228);
            label5.Name = "label5";
            label5.Size = new Size(37, 20);
            label5.TabIndex = 23;
            label5.Text = "End:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 181);
            label4.Name = "label4";
            label4.Size = new Size(43, 20);
            label4.TabIndex = 22;
            label4.Text = "Start:";
            // 
            // amountBox
            // 
            amountBox.FlatStyle = FlatStyle.Flat;
            amountBox.ForeColor = SystemColors.ButtonHighlight;
            amountBox.FormattingEnabled = true;
            amountBox.Location = new Point(133, 76);
            amountBox.Margin = new Padding(3, 4, 3, 4);
            amountBox.Name = "amountBox";
            amountBox.Size = new Size(375, 28);
            amountBox.TabIndex = 21;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 84);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 20;
            label2.Text = "Số lượng: ";
            // 
            // codeBox
            // 
            codeBox.FlatStyle = FlatStyle.Flat;
            codeBox.ForeColor = SystemColors.ButtonHighlight;
            codeBox.FormattingEnabled = true;
            codeBox.Location = new Point(133, 27);
            codeBox.Margin = new Padding(3, 4, 3, 4);
            codeBox.Name = "codeBox";
            codeBox.Size = new Size(375, 28);
            codeBox.TabIndex = 19;
            codeBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 35);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 18;
            label1.Text = "CODE: ";
            // 
            // AddGift
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(580, 450);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddGift";
            Text = "AddGift";
            Load += AddGift_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label3;
        private PictureBox pictureBox2;
        private GroupBox groupBox1;
        private Label label1;
        private ComboBox codeBox;
        private Label label2;
        private Label label4;
        private ComboBox amountBox;
        private Label label5;
        private Label label6;
        private CheckBox checkBox1;
        private Label label7;
        private Button button1;
        private Label label8;
        private ComboBox typeBox;
        private Button button2;
        private Guna.UI2.WinForms.Guna2DateTimePicker EndDataTime;
        private Guna.UI2.WinForms.Guna2DateTimePicker StartDataTime;
    }
}