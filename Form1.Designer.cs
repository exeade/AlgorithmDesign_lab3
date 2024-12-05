namespace lab3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pictureBox1 = new PictureBox();
            dataGridView1 = new DataGridView();
            Key = new DataGridViewTextBoxColumn();
            First_name = new DataGridViewTextBoxColumn();
            Last_name = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            showRecs_button = new Button();
            firstName_label = new Label();
            lastName_label = new Label();
            firstName_textBox = new TextBox();
            lastName_textBox = new TextBox();
            key_textBox = new TextBox();
            key_label = new Label();
            panel_textBox3 = new Panel();
            panel_textBox2 = new Panel();
            panel_textBox1 = new Panel();
            addRec_button = new CustomButton();
            genRecs_button = new CustomButton();
            editRec_Button = new CustomButton();
            deleteRec_button = new CustomButton();
            delRecs_button = new CustomButton();
            findRec_button = new CustomButton();
            genNumber_panel = new Panel();
            genNumber_textBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            genNumber_panel.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-26, -20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Padding = new Padding(5, 10, 5, 10);
            pictureBox1.Size = new Size(1108, 943);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.BackgroundColor = Color.FromArgb(25, 1, 190);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(228, 250, 255);
            dataGridViewCellStyle1.Font = new Font("Georgia", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(14, 0, 105);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(67, 50, 252);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeight = 50;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Key, First_name, Last_name });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(78, 94, 167);
            dataGridViewCellStyle2.Font = new Font("Century", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(228, 250, 255);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(165, 143, 229);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(55, 42, 89);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.White;
            dataGridView1.ImeMode = ImeMode.NoControl;
            dataGridView1.Location = new Point(8, 12);
            dataGridView1.Margin = new Padding(0);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(509, 778);
            dataGridView1.TabIndex = 3;
            // 
            // Key
            // 
            Key.HeaderText = "KEY";
            Key.MaxInputLength = 4;
            Key.MinimumWidth = 6;
            Key.Name = "Key";
            Key.ReadOnly = true;
            Key.Width = 122;
            // 
            // First_name
            // 
            First_name.HeaderText = "FIRST NAME";
            First_name.MaxInputLength = 35;
            First_name.MinimumWidth = 6;
            First_name.Name = "First_name";
            First_name.ReadOnly = true;
            First_name.Width = 194;
            // 
            // Last_name
            // 
            Last_name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Last_name.HeaderText = "LAST NAME";
            Last_name.MaxInputLength = 35;
            Last_name.MinimumWidth = 6;
            Last_name.Name = "Last_name";
            Last_name.ReadOnly = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(228, 250, 255);
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(517, 64);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(8, 12, 8, 8);
            panel1.Size = new Size(525, 798);
            panel1.TabIndex = 4;
            // 
            // showRecs_button
            // 
            showRecs_button.BackColor = Color.FromArgb(14, 0, 105);
            showRecs_button.Cursor = Cursors.Hand;
            showRecs_button.FlatStyle = FlatStyle.Flat;
            showRecs_button.Font = new Font("Century", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            showRecs_button.ForeColor = Color.FromArgb(228, 250, 255);
            showRecs_button.Location = new Point(517, 39);
            showRecs_button.Name = "showRecs_button";
            showRecs_button.Size = new Size(525, 44);
            showRecs_button.TabIndex = 20;
            showRecs_button.Text = "SHOW RECORDS";
            showRecs_button.UseVisualStyleBackColor = false;
            showRecs_button.Click += ShowRecs_button_Click;
            showRecs_button.MouseDown += ShowRecs_button_MouseDown;
            showRecs_button.MouseEnter += ShowRecs_button_MouseEnter;
            showRecs_button.MouseLeave += ShowRecs_button_MouseLeave;
            showRecs_button.MouseUp += ShowRecs_button_MouseUp;
            // 
            // firstName_label
            // 
            firstName_label.BackColor = Color.FromArgb(78, 94, 167);
            firstName_label.Font = new Font("Century", 18.2F, FontStyle.Bold);
            firstName_label.ForeColor = Color.FromArgb(228, 250, 255);
            firstName_label.Location = new Point(21, 138);
            firstName_label.Name = "firstName_label";
            firstName_label.Padding = new Padding(5, 9, 5, 9);
            firstName_label.Size = new Size(213, 53);
            firstName_label.TabIndex = 5;
            firstName_label.Text = "First Name:";
            // 
            // lastName_label
            // 
            lastName_label.BackColor = Color.FromArgb(78, 94, 167);
            lastName_label.Font = new Font("Century", 18F, FontStyle.Bold);
            lastName_label.ForeColor = Color.FromArgb(228, 250, 255);
            lastName_label.Location = new Point(23, 211);
            lastName_label.Name = "lastName_label";
            lastName_label.Padding = new Padding(5, 9, 5, 9);
            lastName_label.Size = new Size(211, 55);
            lastName_label.TabIndex = 6;
            lastName_label.Text = "Last Name:";
            // 
            // firstName_textBox
            // 
            firstName_textBox.BackColor = Color.FromArgb(228, 250, 255);
            firstName_textBox.BorderStyle = BorderStyle.None;
            firstName_textBox.Font = new Font("Century", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            firstName_textBox.ForeColor = Color.FromArgb(3, 0, 42);
            firstName_textBox.Location = new Point(265, 151);
            firstName_textBox.MaxLength = 30;
            firstName_textBox.Name = "firstName_textBox";
            firstName_textBox.Size = new Size(220, 28);
            firstName_textBox.TabIndex = 7;
            firstName_textBox.KeyPress += FirstName_textBox_KeyPress;
            // 
            // lastName_textBox
            // 
            lastName_textBox.BackColor = Color.FromArgb(228, 250, 255);
            lastName_textBox.BorderStyle = BorderStyle.None;
            lastName_textBox.Font = new Font("Century", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lastName_textBox.ForeColor = Color.FromArgb(3, 0, 42);
            lastName_textBox.Location = new Point(265, 225);
            lastName_textBox.MaxLength = 30;
            lastName_textBox.Name = "lastName_textBox";
            lastName_textBox.Size = new Size(220, 28);
            lastName_textBox.TabIndex = 8;
            lastName_textBox.KeyPress += LastName_textBox_KeyPress;
            // 
            // key_textBox
            // 
            key_textBox.BackColor = Color.FromArgb(228, 250, 255);
            key_textBox.BorderStyle = BorderStyle.None;
            key_textBox.Font = new Font("Century", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            key_textBox.ForeColor = Color.FromArgb(3, 0, 42);
            key_textBox.Location = new Point(265, 78);
            key_textBox.MaxLength = 4;
            key_textBox.Name = "key_textBox";
            key_textBox.Size = new Size(220, 28);
            key_textBox.TabIndex = 10;
            key_textBox.TextChanged += Key_textBox_TextChanged_1;
            key_textBox.KeyPress += Key_textBox_KeyPress;
            // 
            // key_label
            // 
            key_label.BackColor = Color.FromArgb(78, 94, 167);
            key_label.Font = new Font("Century", 18F, FontStyle.Bold);
            key_label.ForeColor = Color.FromArgb(228, 250, 255);
            key_label.Location = new Point(21, 64);
            key_label.Name = "key_label";
            key_label.Padding = new Padding(5, 9, 5, 9);
            key_label.Size = new Size(213, 55);
            key_label.TabIndex = 9;
            key_label.Text = "Key:";
            // 
            // panel_textBox3
            // 
            panel_textBox3.BackColor = Color.FromArgb(228, 250, 255);
            panel_textBox3.Location = new Point(257, 211);
            panel_textBox3.Name = "panel_textBox3";
            panel_textBox3.Size = new Size(236, 55);
            panel_textBox3.TabIndex = 11;
            // 
            // panel_textBox2
            // 
            panel_textBox2.BackColor = Color.FromArgb(228, 250, 255);
            panel_textBox2.Location = new Point(257, 138);
            panel_textBox2.Name = "panel_textBox2";
            panel_textBox2.Size = new Size(236, 53);
            panel_textBox2.TabIndex = 12;
            // 
            // panel_textBox1
            // 
            panel_textBox1.BackColor = Color.FromArgb(228, 250, 255);
            panel_textBox1.Location = new Point(257, 64);
            panel_textBox1.Name = "panel_textBox1";
            panel_textBox1.Size = new Size(236, 55);
            panel_textBox1.TabIndex = 12;
            // 
            // addRec_button
            // 
            addRec_button.Cursor = Cursors.Hand;
            addRec_button.FlatStyle = FlatStyle.Flat;
            addRec_button.Font = new Font("Georgia", 15.6F, FontStyle.Bold);
            addRec_button.ForeColor = Color.FromArgb(0, 54, 130);
            addRec_button.Location = new Point(21, 403);
            addRec_button.Name = "addRec_button";
            addRec_button.Size = new Size(225, 122);
            addRec_button.TabIndex = 13;
            addRec_button.Text = "ADD RECORD";
            addRec_button.UseVisualStyleBackColor = true;
            addRec_button.Click += AddRec_button_Click;
            addRec_button.MouseEnter += AddRec_button_MouseEnter;
            // 
            // genRecs_button
            // 
            genRecs_button.Cursor = Cursors.Hand;
            genRecs_button.FlatStyle = FlatStyle.Flat;
            genRecs_button.Font = new Font("Georgia", 15.6F, FontStyle.Bold);
            genRecs_button.ForeColor = Color.FromArgb(0, 54, 130);
            genRecs_button.Location = new Point(21, 746);
            genRecs_button.Name = "genRecs_button";
            genRecs_button.Size = new Size(472, 45);
            genRecs_button.TabIndex = 14;
            genRecs_button.Text = "GENERATE RECORDS";
            genRecs_button.UseVisualStyleBackColor = true;
            genRecs_button.Click += GenRecs_button_Click;
            genRecs_button.MouseEnter += GenRecs_button_MouseEnter;
            // 
            // editRec_Button
            // 
            editRec_Button.Cursor = Cursors.Hand;
            editRec_Button.FlatStyle = FlatStyle.Flat;
            editRec_Button.Font = new Font("Georgia", 15.6F, FontStyle.Bold);
            editRec_Button.ForeColor = Color.FromArgb(0, 54, 130);
            editRec_Button.Location = new Point(265, 403);
            editRec_Button.Name = "editRec_Button";
            editRec_Button.Size = new Size(228, 122);
            editRec_Button.TabIndex = 15;
            editRec_Button.Text = "EDIT RECORD";
            editRec_Button.UseVisualStyleBackColor = true;
            editRec_Button.Click += EditRec_Button_Click;
            editRec_Button.MouseHover += EditRec_Button_MouseHover;
            // 
            // deleteRec_button
            // 
            deleteRec_button.Cursor = Cursors.Hand;
            deleteRec_button.FlatStyle = FlatStyle.Flat;
            deleteRec_button.Font = new Font("Georgia", 15.6F, FontStyle.Bold);
            deleteRec_button.ForeColor = Color.FromArgb(0, 54, 130);
            deleteRec_button.Location = new Point(21, 544);
            deleteRec_button.Name = "deleteRec_button";
            deleteRec_button.Size = new Size(225, 118);
            deleteRec_button.TabIndex = 16;
            deleteRec_button.Text = "DELETE \r\nRECORD";
            deleteRec_button.UseVisualStyleBackColor = true;
            deleteRec_button.Click += DeleteRec_button_Click;
            deleteRec_button.MouseEnter += DeleteRec_button_MouseEnter;
            // 
            // delRecs_button
            // 
            delRecs_button.Cursor = Cursors.Hand;
            delRecs_button.FlatStyle = FlatStyle.Flat;
            delRecs_button.Font = new Font("Georgia", 15.6F, FontStyle.Bold);
            delRecs_button.ForeColor = Color.FromArgb(0, 54, 130);
            delRecs_button.Location = new Point(21, 682);
            delRecs_button.Name = "delRecs_button";
            delRecs_button.Size = new Size(472, 45);
            delRecs_button.TabIndex = 17;
            delRecs_button.Text = "DELETE ALL RECORDS";
            delRecs_button.UseVisualStyleBackColor = true;
            delRecs_button.Click += DelAllRecs_button_Click;
            delRecs_button.MouseEnter += DelRecs_button_MouseEnter;
            // 
            // findRec_button
            // 
            findRec_button.Cursor = Cursors.Hand;
            findRec_button.FlatStyle = FlatStyle.Flat;
            findRec_button.Font = new Font("Georgia", 15.6F, FontStyle.Bold);
            findRec_button.ForeColor = Color.FromArgb(0, 54, 130);
            findRec_button.Location = new Point(265, 544);
            findRec_button.Name = "findRec_button";
            findRec_button.Size = new Size(228, 118);
            findRec_button.TabIndex = 18;
            findRec_button.Text = "FIND RECORD";
            findRec_button.UseVisualStyleBackColor = true;
            findRec_button.Click += FindRec_Button_Click;
            findRec_button.MouseEnter += FindRec_button_MouseEnter;
            // 
            // genNumber_panel
            // 
            genNumber_panel.BackColor = Color.FromArgb(228, 250, 255);
            genNumber_panel.Controls.Add(genNumber_textBox);
            genNumber_panel.Location = new Point(21, 810);
            genNumber_panel.Name = "genNumber_panel";
            genNumber_panel.Size = new Size(472, 52);
            genNumber_panel.TabIndex = 12;
            // 
            // genNumber_textBox
            // 
            genNumber_textBox.BackColor = Color.FromArgb(228, 250, 255);
            genNumber_textBox.BorderStyle = BorderStyle.None;
            genNumber_textBox.Font = new Font("Georgia", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            genNumber_textBox.ForeColor = Color.FromArgb(0, 54, 130);
            genNumber_textBox.Location = new Point(5, 17);
            genNumber_textBox.MaxLength = 4;
            genNumber_textBox.Name = "genNumber_textBox";
            genNumber_textBox.Size = new Size(459, 27);
            genNumber_textBox.TabIndex = 19;
            genNumber_textBox.TextChanged += GenNumber_textBox_TextChanged;
            genNumber_textBox.KeyPress += GenNumber_textBox_KeyPress;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(1068, 897);
            Controls.Add(showRecs_button);
            Controls.Add(genNumber_panel);
            Controls.Add(findRec_button);
            Controls.Add(delRecs_button);
            Controls.Add(deleteRec_button);
            Controls.Add(editRec_Button);
            Controls.Add(genRecs_button);
            Controls.Add(addRec_button);
            Controls.Add(key_textBox);
            Controls.Add(firstName_textBox);
            Controls.Add(panel_textBox1);
            Controls.Add(panel_textBox2);
            Controls.Add(lastName_textBox);
            Controls.Add(panel_textBox3);
            Controls.Add(key_label);
            Controls.Add(lastName_label);
            Controls.Add(firstName_label);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "DBMS[tiny]";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            genNumber_panel.ResumeLayout(false);
            genNumber_panel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private DataGridView dataGridView1;
        private Panel panel1;
        private Label firstName_label;
        private Label lastName_label;
        private TextBox firstName_textBox;
        private TextBox lastName_textBox;
        private TextBox key_textBox;
        private Label key_label;
        private Panel panel_textBox3;
        private Panel panel_textBox2;
        private Panel panel_textBox1;
        private CustomButton addRec_button;
        private CustomButton genRecs_button;
        private CustomButton editRec_Button;
        private CustomButton deleteRec_button;
        private CustomButton delRecs_button;
        private CustomButton findRec_button;
        private DataGridViewTextBoxColumn Key;
        private DataGridViewTextBoxColumn First_name;
        private DataGridViewTextBoxColumn Last_name;
        private Panel genNumber_panel;
        private TextBox genNumber_textBox;
        private Button showRecs_button;
    }
}
