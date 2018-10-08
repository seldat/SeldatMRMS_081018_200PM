using SeldatMRMS.Communication;
using SeldatMRMS.Management.OrderManager;
using SeldatMRMS.Management.RobotManagent;
using SeldatMRMS.Management.TrafficManager;
using SeldatMRMS.RobotView;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace SeldatMRMS.Management
{
    public partial class TasksManagement : Form
    {
        private List<ChargerAgent> chargerAgentList = new List<ChargerAgent>();
        private BridgeNodeServerCtrl bridgeNodeServerCtrl;
        public RobotView3D probot3dmap;

        public Orders orders;
        public ReadyArea readyArea;
        private DateTimePicker dateTimePicker;



        public TasksManagement()
        {
            InitializeComponent();
            timerInterruptAllRobotAgentStatus.Start();

            createLogFolder();
            //	probot3dmap = new RobotView3D();
            //	probot3dmap.Show();
            RegistrationAgent.robotview3dPointer.loadAWareHouseMap();
            RegistrationAgent.robotview3dPointer.Show();
            orders = new Orders();
            readyArea = new ReadyArea("Ready", "0");
            readyArea.updateLandMarkPoint(new Point3D(9.54, -6.05, 0));
            orders.addReadyAreaDepends(readyArea);

        }
        private void createLogFolder()
        {
            string subPath = Properties.Resources.NAME_LOGFOLDER; // your code goes here
            String m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + subPath;
            bool exists = System.IO.Directory.Exists(m_exePath);
            if (!exists)
                System.IO.Directory.CreateDirectory(m_exePath);

        }
        private void DateTimePicker1_ValueChanged(Object sender, EventArgs e)
        {

            MessageBox.Show("You are in the DateTimePicker.ValueChanged event." + dateTimePicker.Value);

        }
        public void addANewRobotAgent(RobotAgent _pr)
        {

            _pr.setRobotView3D(probot3dmap);
            _pr.requestParams();
        }
        public void UpdateRobotAgentProperties(RobotAgent _pr)
        {

        }
        public void updateRobotInfoToTaskManager(RobotAgent.RobotInfo robotInfo)
        {
            UpdateAtDataGridViewRobotManage(robotInfo);
        }

        public void deleteObjectChargerAgent(int pos)
        {
            chargerAgentList.RemoveAt(pos);
        }
        public void deleteObjectRobotAgent(int pos)
        {

        }
        public void updateNewDataGridViewRobotManage(RobotAgent.RobotInfo robotInfo)
        {
            /*try
			{
				this.Invoke((MethodInvoker)delegate
				{
					DataGridViewRow row = (DataGridViewRow)dataGridViewRobotManager.Rows[0].Clone();
					row.Cells[0].Value = (String)robotInfo.robotName;
					row.Cells[1].Value = robotInfo.alive;
					row.Cells[2].Value = (String)robotInfo.statusconnection;
					row.Cells[2].Value = Convert.ToString(robotInfo.batteryPercentage);
					dataGridViewRobotManager.Rows.Add(row);
				});
			}
			catch { }*/

        }
        public void UpdateAtDataGridViewRobotManage(RobotAgent.RobotInfo robotInfo)
        {
            /*try
			{
				this.Invoke((MethodInvoker)delegate
				{
					
					dataGridViewRobotManager[0, robotInfo.posInGridView].Value = (String)robotInfo.robotName;
					dataGridViewRobotManager[1, robotInfo.posInGridView].Value = robotInfo.alive;
					dataGridViewRobotManager[2, robotInfo.posInGridView].Value = (String)robotInfo.statusconnection;
					dataGridViewRobotManager[3, robotInfo.posInGridView].Value = Convert.ToString(robotInfo.batteryPercentage);
				});
			}
			catch { }*/
        }

        public void close()
        {
            bridgeNodeServerCtrl.close();
        }
        private void TasksManagement_Load(object sender, EventArgs e)
        {

        }

        private void rTb_log_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //new ChargerAgent().ResponseCharger_noevent(ChargerAgent.CMD_CHARGER_START);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //new ChargerAgent().ResponseCharger_noevent(ChargerAgent.CMD_CHARGER_STATUS_NOCHARGE);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {


        }

        private void button5_Click(object sender, EventArgs e)
        {

            //Console.WriteLine(chargerAgentList[0].ResponseCharger("c6000e"));
        }




        private void button6_Click(object sender, EventArgs e)
        {




        }


        private void timerInterruptAllRobotAgentStatus_Tick(object sender, EventArgs e)
        {


        }

        private void timerInterruptAllChargerStatus_Tick(object sender, EventArgs e)
        {
        }
        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void TasksManagement_Shown(object sender, EventArgs e)
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (this.readyArea.statusFlag.flagOrdered)
                    this.readyArea.statusFlag.flagOrdered = false;
            }
            catch { }
            /*RobotAgent r = RegistrationAgent.robotAgentRegisteredList.ElementAt(0).Value;
			String cmddk = this.orders.RequestDockingOderItem(0, r.NameObj);
			if (cmddk.Length > 0)
			{
				MessageBox.Show(""+cmddk);
				r.sendPackageStringType(r.paramsRosSocket.publication_serverRobotGotToDockingArea, cmddk);
			}*/

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            /*RobotAgent r = RegistrationAgent.robotAgentRegisteredList.ElementAt(0).Value;
			String[] cmddk = this.orders.RequestPutAwayOderItem(0, r.NameObj);
			if (cmddk[0].Length > 0)
			{
				MessageBox.Show("" + cmddk[0]);
				r.sendPackageStringType(r.paramsRosSocket.publication_serverRobotGotToPutAwayArea, cmddk[0]);
			}*/
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            RobotAgent r = RegistrationAgent.robotAgentRegisteredList.ElementAt(0).Value;
            String msg = DataTranformation.jsoncheckinDockingCoordinations(0);
            r.sendPackageStringType(r.paramsRosSocket.publication_serverRobotGotToCheckInDockingArea, msg);

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            RobotAgent r = RegistrationAgent.robotAgentRegisteredList.ElementAt(0).Value;
            String msg = DataTranformation.jsoncheckinPutAwayCoordinations(0);
            r.sendPackageStringType(r.paramsRosSocket.publication_serverRobotGotToCheckInPutAwayArea, msg);

        }
    }
}
