namespace SeldatMRMS.Model
{
	partial class PathProperties
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
			this.btn_cancel = new System.Windows.Forms.Button();
			this.txt_path_roadName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btn_cancel
			// 
			this.btn_cancel.Location = new System.Drawing.Point(91, 66);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_cancel.TabIndex = 1;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = true;
			// 
			// txt_path_roadName
			// 
			this.txt_path_roadName.Location = new System.Drawing.Point(59, 27);
			this.txt_path_roadName.Name = "txt_path_roadName";
			this.txt_path_roadName.Size = new System.Drawing.Size(100, 20);
			this.txt_path_roadName.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Enabled = false;
			this.label1.Location = new System.Drawing.Point(13, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Name";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 66);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 10;
			this.button1.Text = "Update";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// PathEditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(178, 101);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txt_path_roadName);
			this.Controls.Add(this.btn_cancel);
			this.Name = "PathEditForm";
			this.Text = "PathEditForm";
			this.Load += new System.EventHandler(this.PathEditForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.Windows.Forms.Button btn_update;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.TextBox txt_path_roadName;
		private System.Windows.Forms.Label label1;
		#endregion

		private System.Windows.Forms.Button button1;
	}
}