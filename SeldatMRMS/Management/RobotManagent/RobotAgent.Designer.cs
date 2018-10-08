namespace SeldatMRMS.Management
{
    partial class RobotAgent
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
            this.components = new System.ComponentModel.Container();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.dGV_properties = new System.Windows.Forms.DataGridView();
            this.txt_poperties = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_header = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timerConnectRosSocket = new System.Windows.Forms.Timer(this.components);
            this.timerCheckConnection = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(226, 3);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 17;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(145, 3);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 23);
            this.btn_update.TabIndex = 16;
            this.btn_update.Text = "update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click_1);
            // 
            // dGV_properties
            // 
            this.dGV_properties.AllowUserToAddRows = false;
            this.dGV_properties.AllowUserToDeleteRows = false;
            this.dGV_properties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGV_properties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_properties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txt_poperties,
            this.txt_header});
            this.dGV_properties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGV_properties.Location = new System.Drawing.Point(3, 3);
            this.dGV_properties.Name = "dGV_properties";
            this.dGV_properties.Size = new System.Drawing.Size(304, 350);
            this.dGV_properties.TabIndex = 40;
            this.dGV_properties.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_properties_CellContentClick);
            this.dGV_properties.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_properties_CellEndEdit);
            // 
            // txt_poperties
            // 
            this.txt_poperties.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.txt_poperties.HeaderText = "";
            this.txt_poperties.Name = "txt_poperties";
            this.txt_poperties.ReadOnly = true;
            this.txt_poperties.Width = 19;
            // 
            // txt_header
            // 
            this.txt_header.HeaderText = "";
            this.txt_header.Name = "txt_header";
            // 
            // timerConnectRosSocket
            // 
            this.timerConnectRosSocket.Interval = 1000;
            this.timerConnectRosSocket.Tick += new System.EventHandler(this.timerConnectRosSocket_Tick);
            // 
            // timerCheckConnection
            // 
            this.timerCheckConnection.Interval = 1000;
            this.timerCheckConnection.Tick += new System.EventHandler(this.timerCheckConnection_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dGV_properties, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(310, 391);
            this.tableLayoutPanel1.TabIndex = 41;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btn_cancel);
            this.flowLayoutPanel1.Controls.Add(this.btn_update);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 359);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(304, 29);
            this.flowLayoutPanel1.TabIndex = 41;
            // 
            // RobotAgent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 391);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RobotAgent";
            this.Load += new System.EventHandler(this.RobotAgent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.DataGridView dGV_properties;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_poperties;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_header;
        private System.Windows.Forms.Timer timerConnectRosSocket;
        private System.Windows.Forms.Timer timerCheckConnection;
        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}