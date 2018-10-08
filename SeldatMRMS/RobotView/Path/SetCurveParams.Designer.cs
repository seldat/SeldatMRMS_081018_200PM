namespace SeldatMRMS.RobotView
{
	partial class SetCurveParams
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
			this.txt_angleStartPoint = new System.Windows.Forms.TextBox();
			this.trackBar_angleStartPoint = new System.Windows.Forms.TrackBar();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txt_dv = new System.Windows.Forms.TextBox();
			this.radio_dr_negative = new System.Windows.Forms.RadioButton();
			this.radio_dr_positive = new System.Windows.Forms.RadioButton();
			this.trackBar_distance = new System.Windows.Forms.TrackBar();
			this.btn_ok = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.btn_save = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txt_dr = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txt_radius = new System.Windows.Forms.TextBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.txt_AngleEndPoint = new System.Windows.Forms.TextBox();
			this.trackBar_angleEndPoint = new System.Windows.Forms.TrackBar();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.btn_getStartPoint = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txt_startpointY = new System.Windows.Forms.TextBox();
			this.txt_startpointX = new System.Windows.Forms.TextBox();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.btn_endStartPoint = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txt_endpointY = new System.Windows.Forms.TextBox();
			this.txt_endpointX = new System.Windows.Forms.TextBox();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txt_namepath = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_angleStartPoint)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_distance)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_angleEndPoint)).BeginInit();
			this.groupBox6.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txt_angleStartPoint);
			this.groupBox1.Controls.Add(this.trackBar_angleStartPoint);
			this.groupBox1.Location = new System.Drawing.Point(12, 214);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(293, 89);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Direction Start Point";
			// 
			// txt_angleStartPoint
			// 
			this.txt_angleStartPoint.Enabled = false;
			this.txt_angleStartPoint.Location = new System.Drawing.Point(97, 53);
			this.txt_angleStartPoint.Name = "txt_angleStartPoint";
			this.txt_angleStartPoint.Size = new System.Drawing.Size(100, 20);
			this.txt_angleStartPoint.TabIndex = 10;
			this.txt_angleStartPoint.Text = "0";
			this.txt_angleStartPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// trackBar_angleStartPoint
			// 
			this.trackBar_angleStartPoint.Location = new System.Drawing.Point(8, 19);
			this.trackBar_angleStartPoint.Maximum = 180;
			this.trackBar_angleStartPoint.Minimum = -180;
			this.trackBar_angleStartPoint.Name = "trackBar_angleStartPoint";
			this.trackBar_angleStartPoint.Size = new System.Drawing.Size(278, 45);
			this.trackBar_angleStartPoint.TabIndex = 9;
			this.trackBar_angleStartPoint.Scroll += new System.EventHandler(this.trackBar_angleStartPoint_Scroll);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.txt_dv);
			this.groupBox2.Controls.Add(this.radio_dr_negative);
			this.groupBox2.Controls.Add(this.radio_dr_positive);
			this.groupBox2.Location = new System.Drawing.Point(12, 170);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(293, 42);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Velocity";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "dv(m)";
			// 
			// txt_dv
			// 
			this.txt_dv.Location = new System.Drawing.Point(47, 15);
			this.txt_dv.Name = "txt_dv";
			this.txt_dv.Size = new System.Drawing.Size(88, 20);
			this.txt_dv.TabIndex = 6;
			this.txt_dv.Text = "3";
			this.txt_dv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
			this.radio_dr_negative.CheckedChanged += new System.EventHandler(this.radio_dr_negative_CheckedChanged);
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
			this.radio_dr_positive.CheckedChanged += new System.EventHandler(this.radio_dr_positive_CheckedChanged);
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
			this.btn_ok.Location = new System.Drawing.Point(42, 561);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 23);
			this.btn_ok.TabIndex = 3;
			this.btn_ok.Text = "OK";
			this.btn_ok.UseVisualStyleBackColor = true;
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(123, 561);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 4;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// btn_save
			// 
			this.btn_save.Location = new System.Drawing.Point(204, 561);
			this.btn_save.Name = "btn_save";
			this.btn_save.Size = new System.Drawing.Size(75, 23);
			this.btn_save.TabIndex = 5;
			this.btn_save.Text = "Save";
			this.btn_save.UseVisualStyleBackColor = true;
			this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.txt_dr);
			this.groupBox3.Location = new System.Drawing.Point(12, 503);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(293, 53);
			this.groupBox3.TabIndex = 6;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Evaluation";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(26, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "ω (rad/s)";
			// 
			// txt_dr
			// 
			this.txt_dr.Enabled = false;
			this.txt_dr.Location = new System.Drawing.Point(99, 21);
			this.txt_dr.Name = "txt_dr";
			this.txt_dr.Size = new System.Drawing.Size(98, 20);
			this.txt_dr.TabIndex = 7;
			this.txt_dr.Text = "NaN";
			this.txt_dr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(25, 67);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Radius (m)";
			// 
			// txt_radius
			// 
			this.txt_radius.Enabled = false;
			this.txt_radius.Location = new System.Drawing.Point(99, 64);
			this.txt_radius.Name = "txt_radius";
			this.txt_radius.Size = new System.Drawing.Size(98, 20);
			this.txt_radius.TabIndex = 6;
			this.txt_radius.Text = "0";
			this.txt_radius.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.trackBar_distance);
			this.groupBox4.Controls.Add(this.label2);
			this.groupBox4.Controls.Add(this.txt_radius);
			this.groupBox4.Location = new System.Drawing.Point(12, 404);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(293, 96);
			this.groupBox4.TabIndex = 7;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Radius";
			this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.txt_AngleEndPoint);
			this.groupBox5.Controls.Add(this.trackBar_angleEndPoint);
			this.groupBox5.Location = new System.Drawing.Point(12, 309);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(293, 89);
			this.groupBox5.TabIndex = 8;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Direction End Point";
			this.groupBox5.Enter += new System.EventHandler(this.groupBox5_Enter);
			// 
			// txt_AngleEndPoint
			// 
			this.txt_AngleEndPoint.Enabled = false;
			this.txt_AngleEndPoint.Location = new System.Drawing.Point(99, 59);
			this.txt_AngleEndPoint.Name = "txt_AngleEndPoint";
			this.txt_AngleEndPoint.Size = new System.Drawing.Size(100, 20);
			this.txt_AngleEndPoint.TabIndex = 1;
			this.txt_AngleEndPoint.Text = "0";
			this.txt_AngleEndPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// trackBar_angleEndPoint
			// 
			this.trackBar_angleEndPoint.Location = new System.Drawing.Point(10, 19);
			this.trackBar_angleEndPoint.Maximum = 180;
			this.trackBar_angleEndPoint.Minimum = -180;
			this.trackBar_angleEndPoint.Name = "trackBar_angleEndPoint";
			this.trackBar_angleEndPoint.Size = new System.Drawing.Size(278, 45);
			this.trackBar_angleEndPoint.TabIndex = 0;
			this.trackBar_angleEndPoint.Scroll += new System.EventHandler(this.trackBar_rotEndPoint_Scroll);
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.btn_getStartPoint);
			this.groupBox6.Controls.Add(this.label5);
			this.groupBox6.Controls.Add(this.label4);
			this.groupBox6.Controls.Add(this.txt_startpointY);
			this.groupBox6.Controls.Add(this.txt_startpointX);
			this.groupBox6.Location = new System.Drawing.Point(12, 63);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(293, 54);
			this.groupBox6.TabIndex = 9;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Start Point";
			this.groupBox6.Enter += new System.EventHandler(this.groupBox6_Enter);
			// 
			// btn_getStartPoint
			// 
			this.btn_getStartPoint.Location = new System.Drawing.Point(231, 20);
			this.btn_getStartPoint.Name = "btn_getStartPoint";
			this.btn_getStartPoint.Size = new System.Drawing.Size(52, 23);
			this.btn_getStartPoint.TabIndex = 11;
			this.btn_getStartPoint.Text = "GET";
			this.btn_getStartPoint.UseVisualStyleBackColor = true;
			this.btn_getStartPoint.Click += new System.EventHandler(this.btn_getStartPoint_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(129, 25);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(14, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Y";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(36, 25);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(14, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "X";
			// 
			// txt_startpointY
			// 
			this.txt_startpointY.Location = new System.Drawing.Point(149, 22);
			this.txt_startpointY.Name = "txt_startpointY";
			this.txt_startpointY.Size = new System.Drawing.Size(70, 20);
			this.txt_startpointY.TabIndex = 8;
			this.txt_startpointY.Text = "0";
			this.txt_startpointY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txt_startpointY.TextChanged += new System.EventHandler(this.txt_startpointY_TextChanged);
			// 
			// txt_startpointX
			// 
			this.txt_startpointX.Location = new System.Drawing.Point(53, 22);
			this.txt_startpointX.Name = "txt_startpointX";
			this.txt_startpointX.Size = new System.Drawing.Size(70, 20);
			this.txt_startpointX.TabIndex = 7;
			this.txt_startpointX.Text = "0";
			this.txt_startpointX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txt_startpointX.TextChanged += new System.EventHandler(this.txt_startpointX_TextChanged);
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.btn_endStartPoint);
			this.groupBox7.Controls.Add(this.label6);
			this.groupBox7.Controls.Add(this.label7);
			this.groupBox7.Controls.Add(this.txt_endpointY);
			this.groupBox7.Controls.Add(this.txt_endpointX);
			this.groupBox7.Location = new System.Drawing.Point(12, 116);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(293, 54);
			this.groupBox7.TabIndex = 10;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "End Point";
			// 
			// btn_endStartPoint
			// 
			this.btn_endStartPoint.Location = new System.Drawing.Point(231, 21);
			this.btn_endStartPoint.Name = "btn_endStartPoint";
			this.btn_endStartPoint.Size = new System.Drawing.Size(52, 23);
			this.btn_endStartPoint.TabIndex = 15;
			this.btn_endStartPoint.Text = "GET";
			this.btn_endStartPoint.UseVisualStyleBackColor = true;
			this.btn_endStartPoint.Click += new System.EventHandler(this.btn_endStartPoint_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(129, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(14, 13);
			this.label6.TabIndex = 14;
			this.label6.Text = "Y";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(36, 24);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(14, 13);
			this.label7.TabIndex = 13;
			this.label7.Text = "X";
			// 
			// txt_endpointY
			// 
			this.txt_endpointY.Location = new System.Drawing.Point(149, 21);
			this.txt_endpointY.Name = "txt_endpointY";
			this.txt_endpointY.Size = new System.Drawing.Size(70, 20);
			this.txt_endpointY.TabIndex = 12;
			this.txt_endpointY.Text = "0";
			this.txt_endpointY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txt_endpointY.TextChanged += new System.EventHandler(this.txt_endpointY_TextChanged);
			// 
			// txt_endpointX
			// 
			this.txt_endpointX.Location = new System.Drawing.Point(53, 21);
			this.txt_endpointX.Name = "txt_endpointX";
			this.txt_endpointX.Size = new System.Drawing.Size(70, 20);
			this.txt_endpointX.TabIndex = 11;
			this.txt_endpointX.Text = "0";
			this.txt_endpointX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txt_endpointX.TextChanged += new System.EventHandler(this.txt_endpointX_TextChanged);
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.label8);
			this.groupBox8.Controls.Add(this.txt_namepath);
			this.groupBox8.Location = new System.Drawing.Point(12, 0);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(293, 57);
			this.groupBox8.TabIndex = 12;
			this.groupBox8.TabStop = false;
			this.groupBox8.Enter += new System.EventHandler(this.groupBox8_Enter);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(16, 23);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(35, 13);
			this.label8.TabIndex = 10;
			this.label8.Text = "Name";
			// 
			// txt_namepath
			// 
			this.txt_namepath.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_namepath.Location = new System.Drawing.Point(59, 18);
			this.txt_namepath.Name = "txt_namepath";
			this.txt_namepath.Size = new System.Drawing.Size(224, 24);
			this.txt_namepath.TabIndex = 8;
			this.txt_namepath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txt_namepath.TextChanged += new System.EventHandler(this.txt_namepath_TextChanged);
			// 
			// SetCurveParams
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(321, 592);
			this.Controls.Add(this.groupBox8);
			this.Controls.Add(this.groupBox7);
			this.Controls.Add(this.groupBox6);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.btn_save);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.btn_ok);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "SetCurveParams";
			this.Text = "CurveInfo";
			this.Load += new System.EventHandler(this.CurveInfo_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_angleStartPoint)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_distance)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_angleEndPoint)).EndInit();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radio_dr_negative;
		private System.Windows.Forms.RadioButton radio_dr_positive;
		private System.Windows.Forms.TextBox txt_dv;
		private System.Windows.Forms.TrackBar trackBar_distance;
		private System.Windows.Forms.Button btn_ok;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button btn_save;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox txt_radius;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txt_dr;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.TextBox txt_AngleEndPoint;
		private System.Windows.Forms.TrackBar trackBar_angleEndPoint;
		private System.Windows.Forms.TrackBar trackBar_angleStartPoint;
		private System.Windows.Forms.TextBox txt_angleStartPoint;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.TextBox txt_startpointY;
		private System.Windows.Forms.TextBox txt_startpointX;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txt_endpointY;
		private System.Windows.Forms.TextBox txt_endpointX;
		private System.Windows.Forms.Button btn_getStartPoint;
		private System.Windows.Forms.Button btn_endStartPoint;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txt_namepath;
	}
}