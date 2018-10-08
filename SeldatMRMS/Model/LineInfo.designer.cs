namespace SeldatMRMS.Model
{
    partial class LineInfo
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
            this.button1 = new System.Windows.Forms.Button();
            this.btn_generate = new System.Windows.Forms.Button();
            this.txt_numberofLines = new System.Windows.Forms.TextBox();
            this.dGV_LineInfo = new System.Windows.Forms.DataGridView();
            this.txt_numberofPallets = new System.Windows.Forms.TextBox();
            this.btn_update = new System.Windows.Forms.Button();
            this.rdB_increase = new System.Windows.Forms.RadioButton();
            this.rdB_decrease = new System.Windows.Forms.RadioButton();
            this.txt_theBeginPosition = new System.Windows.Forms.TextBox();
            this.txt_step = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.txt_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_XAxis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_YAxis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_LineInfo)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(165, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_generate
            // 
            this.btn_generate.Location = new System.Drawing.Point(3, 238);
            this.btn_generate.Name = "btn_generate";
            this.btn_generate.Size = new System.Drawing.Size(75, 23);
            this.btn_generate.TabIndex = 3;
            this.btn_generate.Text = "Generate";
            this.btn_generate.UseVisualStyleBackColor = true;
            this.btn_generate.Click += new System.EventHandler(this.btn_generate_Click);
            // 
            // txt_numberofLines
            // 
            this.txt_numberofLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_numberofLines.Location = new System.Drawing.Point(3, 16);
            this.txt_numberofLines.Name = "txt_numberofLines";
            this.txt_numberofLines.Size = new System.Drawing.Size(182, 20);
            this.txt_numberofLines.TabIndex = 4;
            this.txt_numberofLines.TextChanged += new System.EventHandler(this.txt_numberofLines_TextChanged);
            // 
            // dGV_LineInfo
            // 
            this.dGV_LineInfo.AllowUserToAddRows = false;
            this.dGV_LineInfo.AllowUserToDeleteRows = false;
            this.dGV_LineInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGV_LineInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_LineInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txt_name,
            this.Column1,
            this.Column2,
            this.LA,
            this.txt_XAxis,
            this.txt_YAxis,
            this.txt_position});
            this.dGV_LineInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGV_LineInfo.Location = new System.Drawing.Point(3, 3);
            this.dGV_LineInfo.Name = "dGV_LineInfo";
            this.dGV_LineInfo.Size = new System.Drawing.Size(568, 439);
            this.dGV_LineInfo.TabIndex = 5;
            this.dGV_LineInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_LineInfo_CellContentClick);
            // 
            // txt_numberofPallets
            // 
            this.txt_numberofPallets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_numberofPallets.Location = new System.Drawing.Point(3, 16);
            this.txt_numberofPallets.Name = "txt_numberofPallets";
            this.txt_numberofPallets.Size = new System.Drawing.Size(182, 20);
            this.txt_numberofPallets.TabIndex = 6;
            this.txt_numberofPallets.TextChanged += new System.EventHandler(this.txt_numberofPallets_TextChanged);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(84, 3);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 23);
            this.btn_update.TabIndex = 9;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // rdB_increase
            // 
            this.rdB_increase.AutoSize = true;
            this.rdB_increase.Checked = true;
            this.rdB_increase.Location = new System.Drawing.Point(3, 3);
            this.rdB_increase.Name = "rdB_increase";
            this.rdB_increase.Size = new System.Drawing.Size(66, 17);
            this.rdB_increase.TabIndex = 12;
            this.rdB_increase.TabStop = true;
            this.rdB_increase.Text = "Increase";
            this.rdB_increase.UseVisualStyleBackColor = true;
            this.rdB_increase.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rdB_decrease
            // 
            this.rdB_decrease.AutoSize = true;
            this.rdB_decrease.Location = new System.Drawing.Point(75, 3);
            this.rdB_decrease.Name = "rdB_decrease";
            this.rdB_decrease.Size = new System.Drawing.Size(71, 17);
            this.rdB_decrease.TabIndex = 13;
            this.rdB_decrease.TabStop = true;
            this.rdB_decrease.Text = "Decrease";
            this.rdB_decrease.UseVisualStyleBackColor = true;
            this.rdB_decrease.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // txt_theBeginPosition
            // 
            this.txt_theBeginPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_theBeginPosition.Location = new System.Drawing.Point(3, 16);
            this.txt_theBeginPosition.Name = "txt_theBeginPosition";
            this.txt_theBeginPosition.Size = new System.Drawing.Size(182, 20);
            this.txt_theBeginPosition.TabIndex = 14;
            this.txt_theBeginPosition.TextChanged += new System.EventHandler(this.txt_theBeginningPosition_TextChanged);
            // 
            // txt_step
            // 
            this.txt_step.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_step.Location = new System.Drawing.Point(3, 16);
            this.txt_step.Name = "txt_step";
            this.txt_step.Size = new System.Drawing.Size(182, 20);
            this.txt_step.TabIndex = 16;
            this.txt_step.Text = "1.0";
            this.txt_step.TextChanged += new System.EventHandler(this.txt_step_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(780, 501);
            this.tableLayoutPanel1.TabIndex = 18;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.groupBox5, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_generate, 0, 5);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(194, 284);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_step);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 97);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(188, 41);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Unit step (metter)";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.rdB_increase);
            this.flowLayoutPanel1.Controls.Add(this.rdB_decrease);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 191);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(188, 41);
            this.flowLayoutPanel1.TabIndex = 22;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txt_theBeginPosition);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 144);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(188, 41);
            this.groupBox5.TabIndex = 22;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "The begin Position:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_numberofLines);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 41);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Number of Lines:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_numberofPallets);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(188, 41);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Number of Pallets:";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.dGV_LineInfo, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(203, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(574, 495);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.button2);
            this.flowLayoutPanel2.Controls.Add(this.btn_update);
            this.flowLayoutPanel2.Controls.Add(this.button1);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 448);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(568, 44);
            this.flowLayoutPanel2.TabIndex = 6;
            // 
            // txt_name
            // 
            this.txt_name.HeaderText = "Line";
            this.txt_name.Name = "txt_name";
            this.txt_name.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "LX";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "LY";
            this.Column2.Name = "Column2";
            // 
            // LA
            // 
            this.LA.HeaderText = "LA";
            this.LA.Name = "LA";
            // 
            // txt_XAxis
            // 
            this.txt_XAxis.HeaderText = "PX";
            this.txt_XAxis.Name = "txt_XAxis";
            // 
            // txt_YAxis
            // 
            this.txt_YAxis.HeaderText = "PY";
            this.txt_YAxis.Name = "txt_YAxis";
            // 
            // txt_position
            // 
            this.txt_position.HeaderText = "Position";
            this.txt_position.Name = "txt_position";
            this.txt_position.ReadOnly = true;
            // 
            // LineInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 501);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.Name = "LineInfo";
            this.Text = "Line";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_LineInfo)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_generate;
        private System.Windows.Forms.TextBox txt_numberofLines;
        private System.Windows.Forms.DataGridView dGV_LineInfo;
        private System.Windows.Forms.TextBox txt_numberofPallets;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.RadioButton rdB_increase;
        private System.Windows.Forms.RadioButton rdB_decrease;
        private System.Windows.Forms.TextBox txt_theBeginPosition;
        private System.Windows.Forms.TextBox txt_step;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn LA;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_XAxis;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_YAxis;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_position;
    }
}

