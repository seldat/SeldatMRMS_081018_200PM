namespace SeldatMRMS.Model
{
    partial class CheckoutModel
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
            this.btn_lineInfo = new System.Windows.Forms.Button();
            this.dGV_properties = new System.Windows.Forms.DataGridView();
            this.txt_properties = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.connectToAgent = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_lineInfo
            // 
            this.btn_lineInfo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_lineInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_lineInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_lineInfo.Location = new System.Drawing.Point(3, 50);
            this.btn_lineInfo.Name = "btn_lineInfo";
            this.btn_lineInfo.Size = new System.Drawing.Size(183, 41);
            this.btn_lineInfo.TabIndex = 54;
            this.btn_lineInfo.Text = "Line";
            this.btn_lineInfo.UseVisualStyleBackColor = true;
            this.btn_lineInfo.Click += new System.EventHandler(this.btn_lineInfo_Click);
            // 
            // dGV_properties
            // 
            this.dGV_properties.AllowUserToAddRows = false;
            this.dGV_properties.AllowUserToDeleteRows = false;
            this.dGV_properties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGV_properties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_properties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txt_properties,
            this.txt_value});
            this.dGV_properties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGV_properties.Location = new System.Drawing.Point(3, 3);
            this.dGV_properties.Name = "dGV_properties";
            this.dGV_properties.Size = new System.Drawing.Size(378, 355);
            this.dGV_properties.TabIndex = 55;
            // 
            // txt_properties
            // 
            this.txt_properties.HeaderText = "";
            this.txt_properties.Name = "txt_properties";
            this.txt_properties.ReadOnly = true;
            // 
            // txt_value
            // 
            this.txt_value.HeaderText = "";
            this.txt_value.Name = "txt_value";
            // 
            // connectToAgent
            // 
            this.connectToAgent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectToAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.connectToAgent.Location = new System.Drawing.Point(192, 3);
            this.connectToAgent.Name = "connectToAgent";
            this.connectToAgent.Size = new System.Drawing.Size(183, 41);
            this.connectToAgent.TabIndex = 53;
            this.connectToAgent.Text = "Connect";
            this.connectToAgent.UseVisualStyleBackColor = true;
            // 
            // btn_update
            // 
            this.btn_update.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_update.Location = new System.Drawing.Point(3, 3);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(183, 41);
            this.btn_update.TabIndex = 51;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.Location = new System.Drawing.Point(192, 50);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(183, 41);
            this.btn_cancel.TabIndex = 52;
            this.btn_cancel.Text = "Close";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dGV_properties, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(384, 461);
            this.tableLayoutPanel1.TabIndex = 56;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.connectToAgent, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_lineInfo, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_cancel, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_update, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 364);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(378, 94);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // CheckoutModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 461);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CheckoutModel";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Checkout";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CheckoutModel_FormClosed);
            this.Load += new System.EventHandler(this.CheckoutModel_Load);
            this.Shown += new System.EventHandler(this.CheckoutModel_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btn_lineInfo;
        private System.Windows.Forms.DataGridView dGV_properties;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_properties;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_value;
        public System.Windows.Forms.Button connectToAgent;
        public System.Windows.Forms.Button btn_update;
        public System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}