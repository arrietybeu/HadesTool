namespace KnightAgeTool.src
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            groupBox1 = new GroupBox();
            label9 = new Label();
            comboBox2 = new ComboBox();
            DatabaseBox = new ComboBox();
            PasswordBox = new ComboBox();
            UserBox = new ComboBox();
            HostBox = new ComboBox();
            comboBox1 = new ComboBox();
            PortBox = new NumericUpDown();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PortBox).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonShadow;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(422, 28);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(400, 0);
            label2.Name = "label2";
            label2.Size = new Size(20, 23);
            label2.TabIndex = 1;
            label2.Text = "X";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(3, 5);
            label1.Name = "label1";
            label1.Size = new Size(206, 19);
            label1.TabIndex = 0;
            label1.Text = "Database Connection Properties";
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(323, 357);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(86, 31);
            button1.TabIndex = 3;
            button1.Text = "Thoát";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(231, 357);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(86, 31);
            button2.TabIndex = 2;
            button2.Text = "Connect";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = SystemColors.ButtonHighlight;
            button3.Location = new Point(9, 357);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(123, 31);
            button3.TabIndex = 0;
            button3.Text = "Select Database";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(comboBox2);
            groupBox1.Controls.Add(DatabaseBox);
            groupBox1.Controls.Add(PasswordBox);
            groupBox1.Controls.Add(UserBox);
            groupBox1.Controls.Add(HostBox);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(PortBox);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.ForeColor = SystemColors.ButtonHighlight;
            groupBox1.Location = new Point(3, 36);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(415, 409);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Connect to MySQL:";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(16, 275);
            label9.Name = "label9";
            label9.Size = new Size(75, 20);
            label9.TabIndex = 17;
            label9.Text = "Database:";
            // 
            // comboBox2
            // 
            comboBox2.FlatStyle = FlatStyle.Flat;
            comboBox2.ForeColor = SystemColors.ButtonHighlight;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(114, 272);
            comboBox2.Margin = new Padding(3, 4, 3, 4);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(293, 28);
            comboBox2.TabIndex = 16;
            comboBox2.Text = "louisgoku_res";
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // DatabaseBox
            // 
            DatabaseBox.FlatStyle = FlatStyle.Flat;
            DatabaseBox.ForeColor = SystemColors.ButtonHighlight;
            DatabaseBox.FormattingEnabled = true;
            DatabaseBox.Location = new Point(114, 236);
            DatabaseBox.Margin = new Padding(3, 4, 3, 4);
            DatabaseBox.Name = "DatabaseBox";
            DatabaseBox.Size = new Size(293, 28);
            DatabaseBox.TabIndex = 15;
            DatabaseBox.Text = "louisgoku_user";
            DatabaseBox.SelectedIndexChanged += DatabaseBox_SelectedIndexChanged;
            // 
            // PasswordBox
            // 
            PasswordBox.FlatStyle = FlatStyle.Flat;
            PasswordBox.ForeColor = SystemColors.ButtonHighlight;
            PasswordBox.FormattingEnabled = true;
            PasswordBox.Items.AddRange(new object[] { "jakengu" });
            PasswordBox.Location = new Point(114, 197);
            PasswordBox.Margin = new Padding(3, 4, 3, 4);
            PasswordBox.Name = "PasswordBox";
            PasswordBox.Size = new Size(293, 28);
            PasswordBox.TabIndex = 14;
            PasswordBox.Text = "jakengu";
            // 
            // UserBox
            // 
            UserBox.FlatStyle = FlatStyle.Flat;
            UserBox.ForeColor = SystemColors.ButtonHighlight;
            UserBox.FormattingEnabled = true;
            UserBox.Items.AddRange(new object[] { "jakioccho" });
            UserBox.Location = new Point(114, 159);
            UserBox.Margin = new Padding(3, 4, 3, 4);
            UserBox.Name = "UserBox";
            UserBox.Size = new Size(293, 28);
            UserBox.TabIndex = 13;
            UserBox.Text = "jakioccho";
            // 
            // HostBox
            // 
            HostBox.FlatStyle = FlatStyle.Flat;
            HostBox.ForeColor = SystemColors.ButtonHighlight;
            HostBox.FormattingEnabled = true;
            HostBox.Items.AddRange(new object[] { "14.225.208.142" });
            HostBox.Location = new Point(114, 79);
            HostBox.Margin = new Padding(3, 4, 3, 4);
            HostBox.Name = "HostBox";
            HostBox.Size = new Size(293, 28);
            HostBox.TabIndex = 12;
            HostBox.Text = "14.225.208.142";
            HostBox.SelectedIndexChanged += HostBox_SelectedIndexChanged;
            // 
            // comboBox1
            // 
            comboBox1.FlatStyle = FlatStyle.Flat;
            comboBox1.ForeColor = SystemColors.ButtonHighlight;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "TCP/IP" });
            comboBox1.Location = new Point(114, 40);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(293, 28);
            comboBox1.TabIndex = 11;
            comboBox1.Text = "TCP/IP";
            // 
            // PortBox
            // 
            PortBox.ForeColor = SystemColors.ControlLightLight;
            PortBox.Location = new Point(114, 117);
            PortBox.Margin = new Padding(3, 4, 3, 4);
            PortBox.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            PortBox.Name = "PortBox";
            PortBox.Size = new Size(294, 27);
            PortBox.TabIndex = 10;
            PortBox.Value = new decimal(new int[] { 3306, 0, 0, 0 });
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(16, 240);
            label8.Name = "label8";
            label8.Size = new Size(75, 20);
            label8.TabIndex = 9;
            label8.Text = "Database:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(16, 201);
            label7.Name = "label7";
            label7.Size = new Size(73, 20);
            label7.TabIndex = 8;
            label7.Text = "Password:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 163);
            label6.Name = "label6";
            label6.Size = new Size(41, 20);
            label6.TabIndex = 7;
            label6.Text = "User:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 120);
            label5.Name = "label5";
            label5.Size = new Size(38, 20);
            label5.TabIndex = 6;
            label5.Text = "Port:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 83);
            label4.Name = "label4";
            label4.Size = new Size(43, 20);
            label4.TabIndex = 5;
            label4.Text = "Host:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 44);
            label3.Name = "label3";
            label3.Size = new Size(47, 20);
            label3.TabIndex = 4;
            label3.Text = "Type: ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            ClientSize = new Size(422, 458);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PortBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label2;
        private GroupBox groupBox1;
        private NumericUpDown PortBox;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private ComboBox DatabaseBox;
        private ComboBox PasswordBox;
        private ComboBox UserBox;
        private ComboBox HostBox;
        private ComboBox comboBox1;
        private Label label9;
        private ComboBox comboBox2;
    }
}