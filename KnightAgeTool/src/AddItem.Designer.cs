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
            button4 = new Button();
            button3 = new Button();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            label4 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            lstSuggest = new ListBox();
            txtSearch = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveBorder;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(pictureBox2);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(457, 23);
            panel1.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Silver;
            label3.Location = new Point(3, 3);
            label3.Name = "label3";
            label3.Size = new Size(56, 15);
            label3.TabIndex = 7;
            label3.Text = "Add Item";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(432, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(22, 22);
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(lstSuggest);
            groupBox1.Controls.Add(txtSearch);
            groupBox1.Controls.Add(label1);
            groupBox1.ForeColor = Color.Silver;
            groupBox1.Location = new Point(10, 38);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(436, 401);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Item";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // button4
            // 
            button4.ForeColor = Color.Silver;
            button4.Location = new Point(244, 353);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(80, 22);
            button4.TabIndex = 46;
            button4.Text = "DELETE";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.ForeColor = Color.Silver;
            button3.Location = new Point(330, 353);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(80, 22);
            button3.TabIndex = 45;
            button3.Text = "ADD ITEM";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 194);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(415, 135);
            dataGridView1.TabIndex = 44;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button1
            // 
            button1.ForeColor = Color.Silver;
            button1.Location = new Point(79, 103);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(111, 23);
            button1.TabIndex = 43;
            button1.Text = "Add Options";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.ForeColor = Color.Silver;
            button2.Location = new Point(110, 147);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(80, 22);
            button2.TabIndex = 42;
            button2.Text = "Insert";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Silver;
            label4.Location = new Point(16, 107);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 40;
            label4.Text = "Chỉ số:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(79, 64);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(111, 23);
            textBox1.TabIndex = 39;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Silver;
            label2.Location = new Point(16, 72);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 38;
            label2.Text = "Số lượng:";
            // 
            // lstSuggest
            // 
            lstSuggest.FormattingEnabled = true;
            lstSuggest.ItemHeight = 15;
            lstSuggest.Location = new Point(223, 20);
            lstSuggest.Margin = new Padding(3, 2, 3, 2);
            lstSuggest.Name = "lstSuggest";
            lstSuggest.Size = new Size(198, 154);
            lstSuggest.TabIndex = 37;
            lstSuggest.SelectedIndexChanged += lstSuggest_SelectedIndexChanged;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(79, 28);
            txtSearch.Margin = new Padding(3, 2, 3, 2);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(111, 23);
            txtSearch.TabIndex = 36;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(16, 36);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 19;
            label1.Text = "ID item:";
            // 
            // AddItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(458, 450);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "AddItem";
            Text = "AddItem";
            Load += AddItem_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
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
        private Label label4;
        private Button button2;
        private Button button1;
        private DataGridView dataGridView1;
        private Button button4;
        private Button button3;
    }
}