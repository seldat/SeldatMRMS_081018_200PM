namespace SeldatMRMS.RobotView.Path
{
	partial class GroupPaths
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
            this.listBox_singlepath = new System.Windows.Forms.ListBox();
            this.btn_addpath = new System.Windows.Forms.Button();
            this.btn_movedown = new System.Windows.Forms.Button();
            this.listBox_groupPath = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btn_openlistpath = new System.Windows.Forms.Button();
            this.btn_moveup = new System.Windows.Forms.Button();
            this.btn_remove = new System.Windows.Forms.Button();
            this.btn_new = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox_singlepath
            // 
            this.listBox_singlepath.FormattingEnabled = true;
            this.listBox_singlepath.Location = new System.Drawing.Point(12, 38);
            this.listBox_singlepath.Name = "listBox_singlepath";
            this.listBox_singlepath.Size = new System.Drawing.Size(137, 186);
            this.listBox_singlepath.TabIndex = 0;
            // 
            // btn_addpath
            // 
            this.btn_addpath.Location = new System.Drawing.Point(163, 95);
            this.btn_addpath.Name = "btn_addpath";
            this.btn_addpath.Size = new System.Drawing.Size(111, 23);
            this.btn_addpath.TabIndex = 1;
            this.btn_addpath.Text = "Add";
            this.btn_addpath.UseVisualStyleBackColor = true;
            this.btn_addpath.Click += new System.EventHandler(this.btn_addpath_Click);
            // 
            // btn_movedown
            // 
            this.btn_movedown.Location = new System.Drawing.Point(163, 152);
            this.btn_movedown.Name = "btn_movedown";
            this.btn_movedown.Size = new System.Drawing.Size(111, 23);
            this.btn_movedown.TabIndex = 2;
            this.btn_movedown.Text = "Move Down";
            this.btn_movedown.UseVisualStyleBackColor = true;
            this.btn_movedown.Click += new System.EventHandler(this.btn_movedown_Click);
            // 
            // listBox_groupPath
            // 
            this.listBox_groupPath.FormattingEnabled = true;
            this.listBox_groupPath.Location = new System.Drawing.Point(286, 38);
            this.listBox_groupPath.Name = "listBox_groupPath";
            this.listBox_groupPath.Size = new System.Drawing.Size(129, 186);
            this.listBox_groupPath.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(232, 241);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Save a group";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(106, 241);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(111, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Cancel";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btn_openlistpath
            // 
            this.btn_openlistpath.Location = new System.Drawing.Point(163, 38);
            this.btn_openlistpath.Name = "btn_openlistpath";
            this.btn_openlistpath.Size = new System.Drawing.Size(111, 23);
            this.btn_openlistpath.TabIndex = 6;
            this.btn_openlistpath.Text = "Open Path List";
            this.btn_openlistpath.UseMnemonic = false;
            this.btn_openlistpath.UseVisualStyleBackColor = true;
            this.btn_openlistpath.Click += new System.EventHandler(this.btn_openlistpath_Click);
            // 
            // btn_moveup
            // 
            this.btn_moveup.Location = new System.Drawing.Point(163, 123);
            this.btn_moveup.Name = "btn_moveup";
            this.btn_moveup.Size = new System.Drawing.Size(111, 23);
            this.btn_moveup.TabIndex = 7;
            this.btn_moveup.Text = "Move up";
            this.btn_moveup.UseVisualStyleBackColor = true;
            this.btn_moveup.Click += new System.EventHandler(this.btn_moveup_Click);
            // 
            // btn_remove
            // 
            this.btn_remove.Location = new System.Drawing.Point(163, 181);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Size = new System.Drawing.Size(111, 23);
            this.btn_remove.TabIndex = 8;
            this.btn_remove.Text = "Remove";
            this.btn_remove.UseVisualStyleBackColor = true;
            this.btn_remove.Click += new System.EventHandler(this.btn_remove_Click);
            // 
            // btn_new
            // 
            this.btn_new.Location = new System.Drawing.Point(163, 66);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(111, 23);
            this.btn_new.TabIndex = 9;
            this.btn_new.Text = "New";
            this.btn_new.UseVisualStyleBackColor = true;
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // GroupPaths
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 276);
            this.Controls.Add(this.btn_new);
            this.Controls.Add(this.btn_remove);
            this.Controls.Add(this.btn_moveup);
            this.Controls.Add(this.btn_openlistpath);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.listBox_groupPath);
            this.Controls.Add(this.btn_movedown);
            this.Controls.Add(this.btn_addpath);
            this.Controls.Add(this.listBox_singlepath);
            this.Name = "GroupPaths";
            this.Text = "GroupPaths";
            this.Load += new System.EventHandler(this.GroupPaths_Load);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox listBox_singlepath;
		private System.Windows.Forms.Button btn_addpath;
		private System.Windows.Forms.Button btn_movedown;
		private System.Windows.Forms.ListBox listBox_groupPath;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button btn_openlistpath;
		private System.Windows.Forms.Button btn_moveup;
		private System.Windows.Forms.Button btn_remove;
		private System.Windows.Forms.Button btn_new;
	}
}