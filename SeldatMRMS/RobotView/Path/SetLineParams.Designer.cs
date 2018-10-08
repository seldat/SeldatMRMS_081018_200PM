namespace SeldatMRMS.RobotView.Path
{
	partial class SetLineParams
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
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.txt_AngleEndPoint = new System.Windows.Forms.TextBox();
			this.trackBar_angleEndPoint = new System.Windows.Forms.TrackBar();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txt_angleStartPoint = new System.Windows.Forms.TextBox();
			this.trackBar_angleStartPoint = new System.Windows.Forms.TrackBar();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.btn_endStartPoint = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txt_endpointY = new System.Windows.Forms.TextBox();
			this.txt_endpointX = new System.Windows.Forms.TextBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.btn_getStartPoint = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txt_startpointY = new System.Windows.Forms.TextBox();
			this.txt_startpointX = new System.Windows.Forms.TextBox();
			this.btn_save = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.btn_ok = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txt_namepath = new System.Windows.Forms.TextBox();
			this.txt_unitstep = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_angleEndPoint)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_angleStartPoint)).BeginInit();
			this.groupBox7.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.txt_AngleEndPoint);
			this.groupBox5.Controls.Add(this.trackBar_angleEndPoint);
			this.groupBox5.Location = new System.Drawing.Point(23, 321);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(293, 89);
			this.groupBox5.TabIndex = 11;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Direction End Point";
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
			this.trackBar_angleEndPoint.Scroll += new System.EventHandler(this.trackBar_angleEndPoint_Scroll);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txt_angleStartPoint);
			this.groupBox1.Controls.Add(this.trackBar_angleStartPoint);
			this.groupBox1.Location = new System.Drawing.Point(23, 226);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(293, 89);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Direction Start Point";
			this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
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
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.btn_endStartPoint);
			this.groupBox7.Controls.Add(this.label6);
			this.groupBox7.Controls.Add(this.label7);
			this.groupBox7.Controls.Add(this.txt_endpointY);
			this.groupBox7.Controls.Add(this.txt_endpointX);
			this.groupBox7.Location = new System.Drawing.Point(23, 166);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(293, 54);
			this.groupBox7.TabIndex = 12;
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
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.btn_getStartPoint);
			this.groupBox6.Controls.Add(this.label5);
			this.groupBox6.Controls.Add(this.label4);
			this.groupBox6.Controls.Add(this.txt_startpointY);
			this.groupBox6.Controls.Add(this.txt_startpointX);
			this.groupBox6.Location = new System.Drawing.Point(23, 113);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(293, 54);
			this.groupBox6.TabIndex = 11;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Start Point";
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
			// btn_save
			// 
			this.btn_save.Location = new System.Drawing.Point(217, 431);
			this.btn_save.Name = "btn_save";
			this.btn_save.Size = new System.Drawing.Size(75, 23);
			this.btn_save.TabIndex = 18;
			this.btn_save.Text = "Save";
			this.btn_save.UseVisualStyleBackColor = true;
			this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(136, 431);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 17;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(55, 431);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 23);
			this.btn_ok.TabIndex = 16;
			this.btn_ok.Text = "OK";
			this.btn_ok.UseVisualStyleBackColor = true;
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.txt_namepath);
			this.groupBox2.Location = new System.Drawing.Point(23, 17);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(293, 54);
			this.groupBox2.TabIndex = 19;
			this.groupBox2.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 10;
			this.label1.Text = "Name";
			// 
			// txt_namepath
			// 
			this.txt_namepath.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_namepath.Location = new System.Drawing.Point(53, 19);
			this.txt_namepath.Name = "txt_namepath";
			this.txt_namepath.Size = new System.Drawing.Size(230, 24);
			this.txt_namepath.TabIndex = 8;
			this.txt_namepath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txt_namepath.TextChanged += new System.EventHandler(this.txt_namepath_TextChanged);
			// 
			// txt_unitstep
			// 
			this.txt_unitstep.Location = new System.Drawing.Point(155, 84);
			this.txt_unitstep.Name = "txt_unitstep";
			this.txt_unitstep.Size = new System.Drawing.Size(70, 20);
			this.txt_unitstep.TabIndex = 20;
			this.txt_unitstep.Text = "1";
			this.txt_unitstep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(98, 87);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 13);
			this.label2.TabIndex = 21;
			this.label2.Text = "Unit Step";
			// 
			// SetLineParams
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(339, 487);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txt_unitstep);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.btn_save);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.groupBox7);
			this.Controls.Add(this.btn_ok);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox6);
			this.Controls.Add(this.groupBox1);
			this.Name = "SetLineParams";
			this.Text = "InsertPoint";
			this.Load += new System.EventHandler(this.SetLineParams_Load_1);
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_angleEndPoint)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_angleStartPoint)).EndInit();
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.TextBox txt_AngleEndPoint;
		private System.Windows.Forms.TrackBar trackBar_angleEndPoint;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txt_angleStartPoint;
		private System.Windows.Forms.TrackBar trackBar_angleStartPoint;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.Button btn_endStartPoint;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txt_endpointY;
		private System.Windows.Forms.TextBox txt_endpointX;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Button btn_getStartPoint;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txt_startpointY;
		private System.Windows.Forms.TextBox txt_startpointX;
		private System.Windows.Forms.Button btn_save;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button btn_ok;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txt_namepath;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txt_unitstep;
		private System.Windows.Forms.Label label2;
	}
}