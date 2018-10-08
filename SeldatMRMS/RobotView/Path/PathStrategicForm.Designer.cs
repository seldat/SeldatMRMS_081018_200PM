namespace SeldatMRMS.RobotView
{
	partial class PathStrategicForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txt_path_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_path_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_path_step = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_path_startpos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_path_endposition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_path_edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txt_path_remove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txt_path_name,
            this.txt_path_type,
            this.txt_path_step,
            this.txt_path_startpos,
            this.txt_path_endposition,
            this.txt_path_edit,
            this.txt_path_remove});
            this.dataGridView1.Location = new System.Drawing.Point(6, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(734, 279);
            this.dataGridView1.TabIndex = 0;
            // 
            // txt_path_name
            // 
            this.txt_path_name.HeaderText = "Name";
            this.txt_path_name.Name = "txt_path_name";
            // 
            // txt_path_type
            // 
            this.txt_path_type.HeaderText = "Type";
            this.txt_path_type.Name = "txt_path_type";
            // 
            // txt_path_step
            // 
            this.txt_path_step.HeaderText = "Unit Step";
            this.txt_path_step.Name = "txt_path_step";
            // 
            // txt_path_startpos
            // 
            this.txt_path_startpos.HeaderText = "Start Position";
            this.txt_path_startpos.Name = "txt_path_startpos";
            // 
            // txt_path_endposition
            // 
            this.txt_path_endposition.HeaderText = "End Position";
            this.txt_path_endposition.Name = "txt_path_endposition";
            // 
            // txt_path_edit
            // 
            this.txt_path_edit.HeaderText = "Edit";
            this.txt_path_edit.Name = "txt_path_edit";
            // 
            // txt_path_remove
            // 
            this.txt_path_remove.HeaderText = "Remove";
            this.txt_path_remove.Name = "txt_path_remove";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(751, 288);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(743, 262);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(743, 262);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(494, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(628, 331);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(78, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Load";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(96, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(86, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Load";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // PathStrategicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 359);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Name = "PathStrategicForm";
            this.Text = "PathStrategicForm";
            this.Load += new System.EventHandler(this.PathStrategicForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn txt_path_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn txt_path_type;
		private System.Windows.Forms.DataGridViewTextBoxColumn txt_path_step;
		private System.Windows.Forms.DataGridViewTextBoxColumn txt_path_startpos;
		private System.Windows.Forms.DataGridViewTextBoxColumn txt_path_endposition;
		private System.Windows.Forms.DataGridViewButtonColumn txt_path_edit;
		private System.Windows.Forms.DataGridViewButtonColumn txt_path_remove;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
	}
}