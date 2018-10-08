namespace SeldatMRMS.RobotView
{
	partial class CurveInfo
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
			this.radio_180_neg_degree = new System.Windows.Forms.RadioButton();
			this.radio_90_neg_degree = new System.Windows.Forms.RadioButton();
			this.radio_180degree = new System.Windows.Forms.RadioButton();
			this.radio_90degree = new System.Windows.Forms.RadioButton();
			this.radio_0degree = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txt_dv = new System.Windows.Forms.TextBox();
			this.radio_dr_negative = new System.Windows.Forms.RadioButton();
			this.radio_dr_positive = new System.Windows.Forms.RadioButton();
			this.trackBar_distance = new System.Windows.Forms.TrackBar();
			this.btn_ok = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.txt_temp = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txt_dr = new System.Windows.Forms.TextBox();
			this.txt_radius = new System.Windows.Forms.TextBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_distance)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radio_180_neg_degree);
			this.groupBox1.Controls.Add(this.radio_90_neg_degree);
			this.groupBox1.Controls.Add(this.radio_180degree);
			this.groupBox1.Controls.Add(this.radio_90degree);
			this.groupBox1.Controls.Add(this.radio_0degree);
			this.groupBox1.Location = new System.Drawing.Point(12, 76);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(293, 89);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Direction";
			this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// radio_180_neg_degree
			// 
			this.radio_180_neg_degree.AutoSize = true;
			this.radio_180_neg_degree.Location = new System.Drawing.Point(189, 49);
			this.radio_180_neg_degree.Name = "radio_180_neg_degree";
			this.radio_180_neg_degree.Size = new System.Drawing.Size(90, 17);
			this.radio_180_neg_degree.TabIndex = 8;
			this.radio_180_neg_degree.TabStop = true;
			this.radio_180_neg_degree.Text = "- 180 degrees";
			this.radio_180_neg_degree.UseVisualStyleBackColor = true;
			// 
			// radio_90_neg_degree
			// 
			this.radio_90_neg_degree.AutoSize = true;
			this.radio_90_neg_degree.Location = new System.Drawing.Point(88, 48);
			this.radio_90_neg_degree.Name = "radio_90_neg_degree";
			this.radio_90_neg_degree.Size = new System.Drawing.Size(81, 17);
			this.radio_90_neg_degree.TabIndex = 7;
			this.radio_90_neg_degree.TabStop = true;
			this.radio_90_neg_degree.Text = "-90 degrees";
			this.radio_90_neg_degree.UseVisualStyleBackColor = true;
			// 
			// radio_180degree
			// 
			this.radio_180degree.AutoSize = true;
			this.radio_180degree.Location = new System.Drawing.Point(189, 20);
			this.radio_180degree.Name = "radio_180degree";
			this.radio_180degree.Size = new System.Drawing.Size(84, 17);
			this.radio_180degree.TabIndex = 5;
			this.radio_180degree.TabStop = true;
			this.radio_180degree.Text = "180 degrees";
			this.radio_180degree.UseVisualStyleBackColor = true;
			// 
			// radio_90degree
			// 
			this.radio_90degree.AutoSize = true;
			this.radio_90degree.Location = new System.Drawing.Point(88, 19);
			this.radio_90degree.Name = "radio_90degree";
			this.radio_90degree.Size = new System.Drawing.Size(78, 17);
			this.radio_90degree.TabIndex = 4;
			this.radio_90degree.TabStop = true;
			this.radio_90degree.Text = "90 degrees";
			this.radio_90degree.UseVisualStyleBackColor = true;
			// 
			// radio_0degree
			// 
			this.radio_0degree.AutoSize = true;
			this.radio_0degree.Checked = true;
			this.radio_0degree.Location = new System.Drawing.Point(7, 19);
			this.radio_0degree.Name = "radio_0degree";
			this.radio_0degree.Size = new System.Drawing.Size(67, 17);
			this.radio_0degree.TabIndex = 3;
			this.radio_0degree.TabStop = true;
			this.radio_0degree.Text = "0 degree";
			this.radio_0degree.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.txt_dv);
			this.groupBox2.Controls.Add(this.radio_dr_negative);
			this.groupBox2.Controls.Add(this.radio_dr_positive);
			this.groupBox2.Location = new System.Drawing.Point(12, 16);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(293, 45);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Velocity";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "dv(m)";
			// 
			// txt_dv
			// 
			this.txt_dv.Location = new System.Drawing.Point(47, 19);
			this.txt_dv.Name = "txt_dv";
			this.txt_dv.Size = new System.Drawing.Size(88, 20);
			this.txt_dv.TabIndex = 6;
			this.txt_dv.Text = "0";
			this.txt_dv.TextChanged += new System.EventHandler(this.txt_dv_TextChanged);
			// 
			// radio_dr_negative
			// 
			this.radio_dr_negative.AutoSize = true;
			this.radio_dr_negative.Location = new System.Drawing.Point(224, 19);
			this.radio_dr_negative.Name = "radio_dr_negative";
			this.radio_dr_negative.Size = new System.Drawing.Size(46, 17);
			this.radio_dr_negative.TabIndex = 1;
			this.radio_dr_negative.TabStop = true;
			this.radio_dr_negative.Text = "dr<0";
			this.radio_dr_negative.UseVisualStyleBackColor = true;
			// 
			// radio_dr_positive
			// 
			this.radio_dr_positive.AutoSize = true;
			this.radio_dr_positive.Checked = true;
			this.radio_dr_positive.Location = new System.Drawing.Point(162, 19);
			this.radio_dr_positive.Name = "radio_dr_positive";
			this.radio_dr_positive.Size = new System.Drawing.Size(46, 17);
			this.radio_dr_positive.TabIndex = 0;
			this.radio_dr_positive.TabStop = true;
			this.radio_dr_positive.Text = "dr>0";
			this.radio_dr_positive.UseVisualStyleBackColor = true;
			// 
			// trackBar_distance
			// 
			this.trackBar_distance.Location = new System.Drawing.Point(10, 19);
			this.trackBar_distance.Maximum = 99;
			this.trackBar_distance.Name = "trackBar_distance";
			this.trackBar_distance.Size = new System.Drawing.Size(279, 45);
			this.trackBar_distance.TabIndex = 2;
			this.trackBar_distance.Scroll += new System.EventHandler(this.trackBar_distance_Scroll);
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(27, 405);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 23);
			this.btn_ok.TabIndex = 3;
			this.btn_ok.Text = "OK";
			this.btn_ok.UseVisualStyleBackColor = true;
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(108, 405);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 4;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(189, 405);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 5;
			this.button3.Text = "Apply";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.txt_temp);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.txt_dr);
			this.groupBox3.Controls.Add(this.txt_radius);
			this.groupBox3.Location = new System.Drawing.Point(12, 273);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(293, 97);
			this.groupBox3.TabIndex = 6;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Evaluation";
			// 
			// txt_temp
			// 
			this.txt_temp.Location = new System.Drawing.Point(68, 47);
			this.txt_temp.Name = "txt_temp";
			this.txt_temp.Size = new System.Drawing.Size(71, 20);
			this.txt_temp.TabIndex = 12;
			this.txt_temp.Text = "0";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(150, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "ω (rad/s)";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(5, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Radius (m)";
			// 
			// txt_dr
			// 
			this.txt_dr.Location = new System.Drawing.Point(202, 21);
			this.txt_dr.Name = "txt_dr";
			this.txt_dr.Size = new System.Drawing.Size(86, 20);
			this.txt_dr.TabIndex = 7;
			this.txt_dr.Text = "NaN";
			// 
			// txt_radius
			// 
			this.txt_radius.Location = new System.Drawing.Point(68, 21);
			this.txt_radius.Name = "txt_radius";
			this.txt_radius.Size = new System.Drawing.Size(71, 20);
			this.txt_radius.TabIndex = 6;
			this.txt_radius.Text = "0";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.label4);
			this.groupBox4.Controls.Add(this.trackBar_distance);
			this.groupBox4.Location = new System.Drawing.Point(11, 171);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(293, 96);
			this.groupBox4.TabIndex = 7;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Direction";
			this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(122, 67);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(70, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "distance from";
			// 
			// CurveInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(315, 463);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.btn_ok);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "CurveInfo";
			this.Text = "CurveInfo";
			this.Load += new System.EventHandler(this.CurveInfo_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_distance)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radio_dr_negative;
		private System.Windows.Forms.RadioButton radio_dr_positive;
		private System.Windows.Forms.RadioButton radio_180_neg_degree;
		private System.Windows.Forms.RadioButton radio_90_neg_degree;
		private System.Windows.Forms.RadioButton radio_180degree;
		private System.Windows.Forms.RadioButton radio_90degree;
		private System.Windows.Forms.RadioButton radio_0degree;
		private System.Windows.Forms.TextBox txt_dv;
		private System.Windows.Forms.TrackBar trackBar_distance;
		private System.Windows.Forms.Button btn_ok;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox txt_radius;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txt_dr;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txt_temp;
	}
}