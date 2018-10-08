namespace SeldatMRMS.Model
{
	partial class GroupPathModels
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
            this.list_pathmodel = new System.Windows.Forms.ListBox();
            this.btn_remove = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.dg_highway = new System.Windows.Forms.DataGridView();
            this.txt_highwayname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_paths = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.listB_group = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg_highway)).BeginInit();
            this.SuspendLayout();
            // 
            // list_pathmodel
            // 
            this.list_pathmodel.FormattingEnabled = true;
            this.list_pathmodel.Location = new System.Drawing.Point(7, 10);
            this.list_pathmodel.Name = "list_pathmodel";
            this.list_pathmodel.Size = new System.Drawing.Size(130, 251);
            this.list_pathmodel.TabIndex = 0;
            this.list_pathmodel.SelectedIndexChanged += new System.EventHandler(this.list_pathmodel_SelectedIndexChanged);
            // 
            // btn_remove
            // 
            this.btn_remove.Location = new System.Drawing.Point(429, 110);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Size = new System.Drawing.Size(75, 23);
            this.btn_remove.TabIndex = 2;
            this.btn_remove.Text = "Remove";
            this.btn_remove.UseVisualStyleBackColor = true;
            this.btn_remove.Click += new System.EventHandler(this.btn_remove_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(148, 67);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 3;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(148, 38);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 6;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // dg_highway
            // 
            this.dg_highway.AllowUserToAddRows = false;
            this.dg_highway.AllowUserToDeleteRows = false;
            this.dg_highway.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_highway.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_highway.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txt_highwayname,
            this.txt_paths});
            this.dg_highway.Location = new System.Drawing.Point(229, 139);
            this.dg_highway.Name = "dg_highway";
            this.dg_highway.Size = new System.Drawing.Size(276, 121);
            this.dg_highway.TabIndex = 7;
            // 
            // txt_highwayname
            // 
            this.txt_highwayname.HeaderText = "HighWay";
            this.txt_highwayname.Name = "txt_highwayname";
            // 
            // txt_paths
            // 
            this.txt_paths.HeaderText = "Paths";
            this.txt_paths.Name = "txt_paths";
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(148, 9);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(75, 23);
            this.btn_refresh.TabIndex = 8;
            this.btn_refresh.Text = "Refresh";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // listB_group
            // 
            this.listB_group.FormattingEnabled = true;
            this.listB_group.Location = new System.Drawing.Point(229, 9);
            this.listB_group.Name = "listB_group";
            this.listB_group.Size = new System.Drawing.Size(275, 95);
            this.listB_group.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(429, 266);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Remove";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GroupPathModels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 295);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listB_group);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.dg_highway);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_remove);
            this.Controls.Add(this.list_pathmodel);
            this.Name = "GroupPathModels";
            this.Text = "Group";
            this.Load += new System.EventHandler(this.GroupPathModels_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_highway)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox list_pathmodel;
		private System.Windows.Forms.Button btn_remove;
		private System.Windows.Forms.Button btn_save;
		private System.Windows.Forms.Button btn_add;
		private System.Windows.Forms.DataGridView dg_highway;
		private System.Windows.Forms.Button btn_refresh;
		private System.Windows.Forms.ListBox listB_group;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGridViewTextBoxColumn txt_highwayname;
		private System.Windows.Forms.DataGridViewTextBoxColumn txt_paths;
	}
}