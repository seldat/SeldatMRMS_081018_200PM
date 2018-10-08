namespace SeldatMRMS.Management
{
	partial class IpScanner
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
            this.dataGridView_ipscan = new System.Windows.Forms.DataGridView();
            this.txt_ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_ping = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_hostname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_scan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ipscan)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_ipscan
            // 
            this.dataGridView_ipscan.AllowUserToAddRows = false;
            this.dataGridView_ipscan.AllowUserToDeleteRows = false;
            this.dataGridView_ipscan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_ipscan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ipscan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txt_ip,
            this.txt_ping,
            this.txt_hostname});
            this.dataGridView_ipscan.Location = new System.Drawing.Point(12, 33);
            this.dataGridView_ipscan.Name = "dataGridView_ipscan";
            this.dataGridView_ipscan.Size = new System.Drawing.Size(346, 247);
            this.dataGridView_ipscan.TabIndex = 0;
            // 
            // txt_ip
            // 
            this.txt_ip.HeaderText = "IP";
            this.txt_ip.Name = "txt_ip";
            // 
            // txt_ping
            // 
            this.txt_ping.HeaderText = "Ping";
            this.txt_ping.Name = "txt_ping";
            // 
            // txt_hostname
            // 
            this.txt_hostname.HeaderText = "Hostname";
            this.txt_hostname.Name = "txt_hostname";
            // 
            // btn_scan
            // 
            this.btn_scan.Location = new System.Drawing.Point(12, 4);
            this.btn_scan.Name = "btn_scan";
            this.btn_scan.Size = new System.Drawing.Size(75, 23);
            this.btn_scan.TabIndex = 1;
            this.btn_scan.Text = "Scan";
            this.btn_scan.UseVisualStyleBackColor = true;
            this.btn_scan.Click += new System.EventHandler(this.btn_scan_Click);
            // 
            // IpScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 292);
            this.Controls.Add(this.btn_scan);
            this.Controls.Add(this.dataGridView_ipscan);
            this.Name = "IpScanner";
            this.Text = "IP Scanner";
            this.Load += new System.EventHandler(this.IpScanner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ipscan)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView_ipscan;
		private System.Windows.Forms.DataGridViewTextBoxColumn txt_ip;
		private System.Windows.Forms.DataGridViewTextBoxColumn txt_ping;
		private System.Windows.Forms.DataGridViewTextBoxColumn txt_hostname;
		private System.Windows.Forms.Button btn_scan;
	}
}