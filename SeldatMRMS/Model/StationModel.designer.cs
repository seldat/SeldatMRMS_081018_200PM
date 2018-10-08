namespace SeldatMRMS.Model
{
    partial class StationModel
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
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.connectToAgent = new System.Windows.Forms.Button();
            this.btn_lineInfo = new System.Windows.Forms.Button();
            this.dGV_properties = new System.Windows.Forms.DataGridView();
            this.txt_properties = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timerCheckConnection = new System.Windows.Forms.Timer(this.components);
            this.txt_console = new System.Windows.Forms.Label();
            this.timerConnectRosSocket = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_update
            // 
            this.btn_update.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_update.Location = new System.Drawing.Point(3, 3);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(183, 41);
            this.btn_update.TabIndex = 0;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.Location = new System.Drawing.Point(192, 50);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(183, 41);
            this.btn_cancel.TabIndex = 1;
            this.btn_cancel.Text = "Close";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // connectToAgent
            // 
            this.connectToAgent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectToAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.connectToAgent.Location = new System.Drawing.Point(192, 3);
            this.connectToAgent.Name = "connectToAgent";
            this.connectToAgent.Size = new System.Drawing.Size(183, 41);
            this.connectToAgent.TabIndex = 20;
            this.connectToAgent.Text = "Connect";
            this.connectToAgent.UseVisualStyleBackColor = true;
            this.connectToAgent.Click += new System.EventHandler(this.connectToAgent_Click);
            // 
            // btn_lineInfo
            // 
            this.btn_lineInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_lineInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_lineInfo.Location = new System.Drawing.Point(3, 50);
            this.btn_lineInfo.Name = "btn_lineInfo";
            this.btn_lineInfo.Size = new System.Drawing.Size(183, 41);
            this.btn_lineInfo.TabIndex = 35;
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
            this.dGV_properties.TabIndex = 35;
            this.dGV_properties.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_properties_CellContentClick);
            this.dGV_properties.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_properties_CellEndEdit);
            // 
            // txt_properties
            // 
            this.txt_properties.HeaderText = "";
            this.txt_properties.Name = "txt_properties";
            // 
            // txt_value
            // 
            this.txt_value.HeaderText = "";
            this.txt_value.Name = "txt_value";
            // 
            // timerCheckConnection
            // 
            this.timerCheckConnection.Interval = 1000;
            this.timerCheckConnection.Tick += new System.EventHandler(this.timerCheckConnection_Tick);
            // 
            // txt_console
            // 
            this.txt_console.AutoSize = true;
            this.txt_console.Location = new System.Drawing.Point(12, 469);
            this.txt_console.Name = "txt_console";
            this.txt_console.Size = new System.Drawing.Size(16, 13);
            this.txt_console.TabIndex = 36;
            this.txt_console.Text = "...";
            // 
            // timerConnectRosSocket
            // 
            this.timerConnectRosSocket.Interval = 1000;
            this.timerConnectRosSocket.Tick += new System.EventHandler(this.timerConnectRosSocket_Tick);
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
            this.tableLayoutPanel1.TabIndex = 57;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.connectToAgent, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_cancel, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_lineInfo, 0, 1);
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
            // StationModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 461);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.txt_console);
            this.Name = "StationModel";
            this.Text = "Station properties";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StationModel_FormClosed);
            this.Load += new System.EventHandler(this.Station_Load);
            this.Shown += new System.EventHandler(this.btn_lineInfo_Click);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public System.Windows.Forms.Button btn_update;
        public System.Windows.Forms.Button btn_cancel;
        public System.Windows.Forms.Button connectToAgent;
        #endregion
        public System.Windows.Forms.Button btn_lineInfo;
        private System.Windows.Forms.DataGridView dGV_properties;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_properties;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt_value;
        private System.Windows.Forms.Timer timerCheckConnection;
        private System.Windows.Forms.Label txt_console;
        private System.Windows.Forms.Timer timerConnectRosSocket;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}