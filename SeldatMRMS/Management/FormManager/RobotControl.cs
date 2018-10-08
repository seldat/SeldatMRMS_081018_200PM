using System;
using System.Windows.Forms;

namespace SeldatMRMS.Management.FormManager
{
    public partial class RobotControl : Form
    {
        RobotAgent robotAgent;
        public RobotControl(RobotAgent robotAgent)
        {
            this.robotAgent = robotAgent;
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_GetLineDk_Click(object sender, EventArgs e)
        {
            if (robotAgent != null)
            {
                if (robotAgent.robotInfo.alive)
                    robotAgent.processFinishStates(CommandSetsToRobotAgent.STATE_FINISH_GOTO_CHECKINDOCKING);
            }
        }

		private void RobotControl_Load(object sender, EventArgs e)
		{
            timer_scan.Start();
		}

        private void btn_RequestDk_Click(object sender, EventArgs e)
        {
            if (robotAgent != null)
            {
                robotAgent.processFinishStates(CommandSetsToRobotAgent.STATE_FINISH_PALLETDOWN);
            }
        }

        private void btn_GetPalletDk_Click(object sender, EventArgs e)
        {
            if (robotAgent != null)
            {
                if (robotAgent.robotInfo.alive)
                    robotAgent.processFinishStates(CommandSetsToRobotAgent.STATE_FINISH_GOTO_LINEDOCKING);
            }
        }

        private void btn_RequestPw_Click(object sender, EventArgs e)
        {
            if (robotAgent != null)
            {
                if (robotAgent.robotInfo.alive)
                    robotAgent.processFinishStates(CommandSetsToRobotAgent.STATE_FINISH_PALLETUP);
            }
        }

        private void btn_GetLinePw_Click(object sender, EventArgs e)
        {
            if (robotAgent != null)
            {
                if (robotAgent.robotInfo.alive)
                    robotAgent.processFinishStates(CommandSetsToRobotAgent.STATE_FINISH_GOTO_CHECKINPUTAWAY);
            }
        }

        private void btn_GetPalletPw_Click(object sender, EventArgs e)
        {
            if (robotAgent != null)
            {
                if (robotAgent.robotInfo.alive)
                    robotAgent.processFinishStates(CommandSetsToRobotAgent.STATE_FINISH_GOTO_LINEPUTAWAY);
            }
        }

        private void btn_ResetDk_Click(object sender, EventArgs e)
        {
            RegistrationAgent.areaList["0"].DOCKING_LINE_LIST.Clear();
        }

        private void btn_ResetPw_Click(object sender, EventArgs e)
        {
            RegistrationAgent.areaList["0"].PUTAWAY_LINE_LIST.Clear();
        }

        private void btn_Run_Click(object sender, EventArgs e)
        {

        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {

        }

        private void btn_StartCharge_Click(object sender, EventArgs e)
        {

        }

        private void btn_StopCharge_Click(object sender, EventArgs e)
        {
            robotAgent.stopCharge();
        }

        private void btn_forctoedetectline_Click(object sender, EventArgs e)
        {
            robotAgent.serverRequestRobotDetectLine("request");
        }

        private void timer_scan_Tick(object sender, EventArgs e)
        {
            lbNameValue.Text = ""+robotAgent.NameID;
            lbLocationValue.Text = "" + robotAgent.robotInfo.loc.X.ToString("0.0") + robotAgent.robotInfo.loc.Y.ToString("0.0");
            lb_BatteryKey.Text = "" + robotAgent.robotInfo.batteryPercentage.ToString("0.00");
            lb_OnRoad.Text = "" + robotAgent.robotInfo.atRoadName;

            lbHeadingValue.Text = "" + robotAgent.robotInfo.heading;

        }
        
    }
}
