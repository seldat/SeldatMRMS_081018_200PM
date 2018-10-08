namespace SeldatMRMS.RobotView
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_remove = new System.Windows.Forms.Button();
            this.btn_finish = new System.Windows.Forms.Button();
            this.comboBox_palletnum = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col_palletpos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dockingArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_limitedAreaPalletUp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_linepalletdown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_limitedAreaPalletDown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_remove);
            this.groupBox1.Controls.Add(this.btn_finish);
            this.groupBox1.Controls.Add(this.comboBox_palletnum);
            this.groupBox1.Location = new System.Drawing.Point(12, 303);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 91);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Pallet No.";
            // 
            // btn_remove
            // 
            this.btn_remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_remove.Location = new System.Drawing.Point(336, 22);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Size = new System.Drawing.Size(113, 53);
            this.btn_remove.TabIndex = 2;
            this.btn_remove.Text = "Remove";
            this.btn_remove.UseVisualStyleBackColor = true;
            this.btn_remove.Click += new System.EventHandler(this.btn_remove_Click);
            // 
            // btn_finish
            // 
            this.btn_finish.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_finish.Location = new System.Drawing.Point(217, 22);
            this.btn_finish.Name = "btn_finish";
            this.btn_finish.Size = new System.Drawing.Size(113, 53);
            this.btn_finish.TabIndex = 4;
            this.btn_finish.Text = "Finish";
            this.btn_finish.UseVisualStyleBackColor = true;
            this.btn_finish.Click += new System.EventHandler(this.btn_finish_Click);
            // 
            // comboBox_palletnum
            // 
            this.comboBox_palletnum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_palletnum.FormattingEnabled = true;
            this.comboBox_palletnum.Items.AddRange(new object[] {
            "3A1",
            "10A1",
            "3B1",
            "10B1",
            "3C1",
            "10C1"});
            this.comboBox_palletnum.Location = new System.Drawing.Point(100, 22);
            this.comboBox_palletnum.Name = "comboBox_palletnum";
            this.comboBox_palletnum.Size = new System.Drawing.Size(91, 26);
            this.comboBox_palletnum.TabIndex = 2;
            this.comboBox_palletnum.Text = "3A1";
            this.comboBox_palletnum.SelectedIndexChanged += new System.EventHandler(this.comboBox_palletnum_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_palletpos,
            this.col_dockingArea,
            this.col_limitedAreaPalletUp,
            this.col_linepalletdown,
            this.col_limitedAreaPalletDown});
            this.dataGridView1.Location = new System.Drawing.Point(12, 7);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(646, 290);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // col_palletpos
            // 
            this.col_palletpos.HeaderText = "Pallet No.";
            this.col_palletpos.Name = "col_palletpos";
            // 
            // col_dockingArea
            // 
            this.col_dockingArea.HeaderText = "Docking Area";
            this.col_dockingArea.Name = "col_dockingArea";
            // 
            // col_limitedAreaPalletUp
            // 
            this.col_limitedAreaPalletUp.HeaderText = "Limited Pallet Up Area";
            this.col_limitedAreaPalletUp.Name = "col_limitedAreaPalletUp";
            // 
            // col_linepalletdown
            // 
            this.col_linepalletdown.HeaderText = "Put-Away Area";
            this.col_linepalletdown.Name = "col_linepalletdown";
            // 
            // col_limitedAreaPalletDown
            // 
            this.col_limitedAreaPalletDown.HeaderText = "Limited Pallet Down Area";
            this.col_limitedAreaPalletDown.Name = "col_limitedAreaPalletDown";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 400);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_remove;
        private System.Windows.Forms.Button btn_finish;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_palletnum;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_palletpos;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_dockingArea;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_limitedAreaPalletUp;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_linepalletdown;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_limitedAreaPalletDown;
	}
}