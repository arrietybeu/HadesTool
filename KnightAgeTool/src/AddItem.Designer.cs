namespace KnightAgeTool.src
{
    partial class AddItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddItem));
            panel1 = new Panel();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            groupBox1 = new GroupBox();
            textBox1 = new TextBox();
            label2 = new Label();
            lstSuggest = new ListBox();
            txtSearch = new TextBox();
            label1 = new Label();
            label4 = new Label();
            textBox2 = new TextBox();
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
            panel1.Size = new Size(954, 31);
            panel1.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Silver;
            label3.Location = new Point(3, 4);
            label3.Name = "label3";
            label3.Size = new Size(71, 20);
            label3.TabIndex = 7;
            label3.Text = "Add Item";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(926, 0);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(25, 29);
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(lstSuggest);
            groupBox1.Controls.Add(txtSearch);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 51);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(929, 640);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Item";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(113, 460);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(329, 27);
            textBox1.TabIndex = 39;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Silver;
            label2.Location = new Point(35, 463);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 38;
            label2.Text = "Số lượng:";
            // 
            // lstSuggest
            // 
            lstSuggest.FormattingEnabled = true;
            lstSuggest.Location = new Point(462, 162);
            lstSuggest.Name = "lstSuggest";
            lstSuggest.Size = new Size(322, 464);
            lstSuggest.TabIndex = 37;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(113, 402);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(329, 27);
            txtSearch.TabIndex = 36;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(35, 405);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 19;
            label1.Text = "ID item:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Silver;
            label4.Location = new Point(35, 513);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 40;
            label4.Text = "Số lượng:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(113, 513);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(329, 27);
            textBox2.TabIndex = 41;
            // 
            // AddItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(953, 703);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddItem";
            Text = "AddItem";
            Load += AddItem_Load;
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
        private TextBox txtSearch;
        private ListBox lstSuggest;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label4;
    }
}