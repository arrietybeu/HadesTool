namespace KnightAgeTool.src
{
    partial class EditOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditOptions));
            panel1 = new Panel();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            txtSearch = new TextBox();
            lstSuggest = new ListBox();
            label2 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            ID = new DataGridViewTextBoxColumn();
            PARAM = new DataGridViewTextBoxColumn();
            display = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveBorder;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(pictureBox2);
            panel1.Location = new Point(1, -1);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(913, 29);
            panel1.TabIndex = 10;
            panel1.Paint += panel1_Paint;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Silver;
            label3.Location = new Point(3, 4);
            label3.Name = "label3";
            label3.Size = new Size(93, 20);
            label3.TabIndex = 7;
            label3.Text = "Add Options";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(885, 0);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(25, 29);
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ID, PARAM, display });
            dataGridView1.Location = new Point(14, 53);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(492, 205);
            dataGridView1.TabIndex = 11;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(14, 276);
            label1.Name = "label1";
            label1.Size = new Size(93, 20);
            label1.TabIndex = 20;
            label1.Text = "Tìm Options:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(106, 265);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(126, 27);
            txtSearch.TabIndex = 37;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lstSuggest
            // 
            lstSuggest.FormattingEnabled = true;
            lstSuggest.Location = new Point(512, 53);
            lstSuggest.Name = "lstSuggest";
            lstSuggest.Size = new Size(389, 204);
            lstSuggest.TabIndex = 38;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Silver;
            label2.Location = new Point(14, 319);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 39;
            label2.Text = "Param:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(106, 308);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(126, 27);
            textBox1.TabIndex = 40;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.ForeColor = Color.Silver;
            button1.Location = new Point(274, 262);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(94, 33);
            button1.TabIndex = 41;
            button1.Text = "ADD";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.ForeColor = Color.Silver;
            button2.Location = new Point(274, 302);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(94, 33);
            button2.TabIndex = 42;
            button2.Text = "DELETE";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.ForeColor = Color.Silver;
            button3.Location = new Point(807, 305);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(94, 33);
            button3.TabIndex = 43;
            button3.Text = "DONE";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.Width = 50;
            // 
            // PARAM
            // 
            PARAM.HeaderText = "PARAM";
            PARAM.MinimumWidth = 6;
            PARAM.Name = "PARAM";
            PARAM.Width = 80;
            // 
            // display
            // 
            display.HeaderText = "DISPLAY";
            display.MinimumWidth = 6;
            display.Name = "display";
            display.Width = 350;
            // 
            // EditOptions
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(913, 369);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(lstSuggest);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "EditOptions";
            Text = "EditOptions";
            Load += EditOptions_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label3;
        private PictureBox pictureBox2;
        private DataGridView dataGridView1;
        private Label label1;
        private TextBox txtSearch;
        private ListBox lstSuggest;
        private Label label2;
        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn PARAM;
        private DataGridViewTextBoxColumn display;
    }
}