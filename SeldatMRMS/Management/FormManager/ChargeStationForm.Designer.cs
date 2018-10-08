namespace SeldatMRMS.Management.FormManager
{
    partial class ChargeStationForm
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
            this.gb_RobotStatus = new System.Windows.Forms.GroupBox();
            this.lbNameValue = new System.Windows.Forms.Label();
            this.lbNameKey = new System.Windows.Forms.Label();
            this.lb_BatteryKey = new System.Windows.Forms.Label();
            this.lb_Battery = new System.Windows.Forms.Label();
            this.lb_StatusKey = new System.Windows.Forms.Label();
            this.lb_Status = new System.Windows.Forms.Label();
            this.lbLocationValue = new System.Windows.Forms.Label();
            this.lbLocationKey = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.gb_RobotStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_RobotStatus
            // 
            this.gb_RobotStatus.BackColor = System.Drawing.Color.MediumAquamarine;
            this.gb_RobotStatus.Controls.Add(this.lbNameValue);
            this.gb_RobotStatus.Controls.Add(this.lbNameKey);
            this.gb_RobotStatus.Controls.Add(this.lb_BatteryKey);
            this.gb_RobotStatus.Controls.Add(this.lb_Battery);
            this.gb_RobotStatus.Controls.Add(this.lb_StatusKey);
            this.gb_RobotStatus.Controls.Add(this.lb_Status);
            this.gb_RobotStatus.Controls.Add(this.lbLocationValue);
            this.gb_RobotStatus.Controls.Add(this.lbLocationKey);
            this.gb_RobotStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_RobotStatus.Location = new System.Drawing.Point(12, 12);
            this.gb_RobotStatus.Name = "gb_RobotStatus";
            this.gb_RobotStatus.Size = new System.Drawing.Size(277, 127);
            this.gb_RobotStatus.TabIndex = 1;
            this.gb_RobotStatus.TabStop = false;
            this.gb_RobotStatus.Text = "Charger Status";
            // 
            // lbNameValue
            // 
            this.lbNameValue.AutoSize = true;
            this.lbNameValue.Location = new System.Drawing.Point(122, 24);
            this.lbNameValue.Name = "lbNameValue";
            this.lbNameValue.Size = new System.Drawing.Size(57, 20);
            this.lbNameValue.TabIndex = 0;
            this.lbNameValue.Text = "label1";
            // 
            // lbNameKey
            // 
            this.lbNameKey.AutoSize = true;
            this.lbNameKey.Location = new System.Drawing.Point(6, 24);
            this.lbNameKey.Name = "lbNameKey";
            this.lbNameKey.Size = new System.Drawing.Size(28, 20);
            this.lbNameKey.TabIndex = 0;
            this.lbNameKey.Text = "ID";
            // 
            // lb_BatteryKey
            // 
            this.lb_BatteryKey.AutoSize = true;
            this.lb_BatteryKey.Location = new System.Drawing.Point(122, 84);
            this.lb_BatteryKey.Name = "lb_BatteryKey";
            this.lb_BatteryKey.Size = new System.Drawing.Size(57, 20);
            this.lb_BatteryKey.TabIndex = 0;
            this.lb_BatteryKey.Text = "label1";
            // 
            // lb_Battery
            // 
            this.lb_Battery.AutoSize = true;
            this.lb_Battery.Location = new System.Drawing.Point(6, 84);
            this.lb_Battery.Name = "lb_Battery";
            this.lb_Battery.Size = new System.Drawing.Size(67, 20);
            this.lb_Battery.TabIndex = 0;
            this.lb_Battery.Text = "Battery";
            // 
            // lb_StatusKey
            // 
            this.lb_StatusKey.AutoSize = true;
            this.lb_StatusKey.Location = new System.Drawing.Point(122, 64);
            this.lb_StatusKey.Name = "lb_StatusKey";
            this.lb_StatusKey.Size = new System.Drawing.Size(57, 20);
            this.lb_StatusKey.TabIndex = 0;
            this.lb_StatusKey.Text = "label1";
            // 
            // lb_Status
            // 
            this.lb_Status.AutoSize = true;
            this.lb_Status.Location = new System.Drawing.Point(6, 64);
            this.lb_Status.Name = "lb_Status";
            this.lb_Status.Size = new System.Drawing.Size(62, 20);
            this.lb_Status.TabIndex = 0;
            this.lb_Status.Text = "Status";
            // 
            // lbLocationValue
            // 
            this.lbLocationValue.AutoSize = true;
            this.lbLocationValue.Location = new System.Drawing.Point(122, 44);
            this.lbLocationValue.Name = "lbLocationValue";
            this.lbLocationValue.Size = new System.Drawing.Size(69, 20);
            this.lbLocationValue.TabIndex = 0;
            this.lbLocationValue.Text = "12/21.0";
            // 
            // lbLocationKey
            // 
            this.lbLocationKey.AutoSize = true;
            this.lbLocationKey.Location = new System.Drawing.Point(6, 44);
            this.lbLocationKey.Name = "lbLocationKey";
            this.lbLocationKey.Size = new System.Drawing.Size(111, 20);
            this.lbLocationKey.TabIndex = 0;
            this.lbLocationKey.Text = "Temperature";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 145);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 47);
            this.button1.TabIndex = 2;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(154, 145);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 47);
            this.button2.TabIndex = 3;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ChargeStationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 209);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gb_RobotStatus);
            this.Name = "ChargeStationForm";
            this.Text = "Charger";
            this.Load += new System.EventHandler(this.ChargeStationForm_Load);
            this.gb_RobotStatus.ResumeLayout(false);
            this.gb_RobotStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_RobotStatus;
        private System.Windows.Forms.Label lbNameKey;
        private System.Windows.Forms.Label lb_BatteryKey;
        private System.Windows.Forms.Label lb_Battery;
        private System.Windows.Forms.Label lb_StatusKey;
        private System.Windows.Forms.Label lb_Status;
        private System.Windows.Forms.Label lbLocationValue;
        private System.Windows.Forms.Label lbLocationKey;
        private System.Windows.Forms.Label lbNameValue;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}