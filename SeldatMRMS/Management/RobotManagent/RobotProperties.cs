using System;
using System.Windows.Forms;

namespace SeldatMRMS.Management
{
    public partial class RobotProperties : Form
    {
		MainWindow content;
		RobotAgent pRobotAgent;
        public RobotProperties(MainWindow content, RobotAgent pRobotAgent)
        {
            InitializeComponent();
			this.content = content;
			this.pRobotAgent = pRobotAgent;
			this.content.IsEnabled = false;
		}

		private void RobotConfigEditForm_Load(object sender, EventArgs e)
		{
            setProperties();
           /* txt_robotconfig_nameobj.Text = pRobotAgent.NameObj;
			txt_robotconfig_ipaddress.Text = pRobotAgent.IpAddress;
			txt_robotconfig_hostname.Text = pRobotAgent.Hostname;
			txt_robotconfig_port.Text = pRobotAgent.Port+"";
			txt_AreaID.Text = pRobotAgent.AreaID + "";
			txt_robotconfig_criticalenergy.Text = pRobotAgent.CriticalEnergyAt+"";
			txt_robotconfig_goodenergy.Text = pRobotAgent.GoodEnergyAt+"";
			txt_robotconfig_initialposX.Text = pRobotAgent.InitialPostion.X+"";
			txt_robotconfig_initialposY.Text = pRobotAgent.InitialPostion.Y+"";
			txt_robotconfig_headingangle.Text = pRobotAgent.InitialHeadingAngle+"";*/
		}

        private void setProperties()
        {
            dGV_properties.Rows.Add("Name",pRobotAgent.NameID);
            dGV_properties.Rows.Add("Label", "");
            dGV_properties.Rows.Add("IP", "192.168.1.");
            dGV_properties.Rows.Add("Port", "9090");
            dGV_properties.Rows.Add("Critical Energy At(%)", "23.9");
            dGV_properties.Rows.Add("Good Energy At(%)", "25.0");
            dGV_properties.Rows.Add("Area ID", "0");
        }
        public void setName(String name)
        {
            dGV_properties.Rows[0].Cells[1].Value = name;
        }
        public String getName()
        {
            return (String)dGV_properties.Rows[0].Cells[1].Value;
        }
        public void setLabel(String label)
        {
            dGV_properties.Rows[1].Cells[1].Value = label;
        }
        public String  getLabel()
        {
            return (String)dGV_properties.Rows[1].Cells[1].Value;
        }
        public void setIP(String ip)
        {
            dGV_properties.Rows[2].Cells[1].Value = ip;
        }
        public String getIP()
        {
            return (String)dGV_properties.Rows[2].Cells[1].Value;
        }
        public void setPort(Int32 port)
        {
            dGV_properties.Rows[3].Cells[1].Value = port;
        }
        public String getPort()
        {
            return (String)dGV_properties.Rows[3].Cells[1].Value;
        }
        public void setCriticalEngery(double value)
        {
            dGV_properties.Rows[4].Cells[1].Value = value;
        }
        public String getCriticalEngery()
        {
            return (String)dGV_properties.Rows[4].Cells[1].Value;
        }

        public void setGoodEngery(double value)
        {
            dGV_properties.Rows[5].Cells[1].Value = value;
        }
        public String getGoodEngery()
        {
           return (String)dGV_properties.Rows[5].Cells[1].Value;
        }
        public void setAreaID(int areaID)
        {
            dGV_properties.Rows[6].Cells[1].Value = areaID;
        }
        public String getAreaID()
        {
            return (String)dGV_properties.Rows[6].Cells[1].Value;
        }
        private void btn_update_Click(object sender, EventArgs e)
		{
			try
			{
				pRobotAgent.NameID =getName();
				pRobotAgent.AreaID = Convert.ToInt32(getAreaID());
				//pRobotAgent.Hostname = txt_robotconfig_hostname.Text;
				pRobotAgent.IpAddress = getIP();
				pRobotAgent.Port = Convert.ToInt32(getPort());
				pRobotAgent.CriticalEnergyAt = Convert.ToDouble(getCriticalEngery());
				pRobotAgent.GoodEnergyAt = Convert.ToDouble(getGoodEngery());
				//pRobotAgent.InitialPostion.X = Convert.ToDouble(txt_robotconfig_initialposX.Text);
				//pRobotAgent.InitialPostion.Y = Convert.ToDouble(txt_robotconfig_initialposY.Text);
				//pRobotAgent.InitialHeadingAngle = Convert.ToDouble(txt_robotconfig_headingangle.Text);
				RegistrationAgent.interfacePointer.updatePropertiesInformationrobot(pRobotAgent);
				this.content.updateRobotAgentProperties(pRobotAgent);
				this.Close();
			}
			catch { MessageBox.Show("Error Format Data "); }
		}

		private void RobotConfigEditForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.content.IsEnabled = true;
		}

		private void btn_cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void txt_robotconfig_ipaddress_TextChanged(object sender, EventArgs e)
		{
			
				
		}

        private void RobotProperties_Enter(object sender, EventArgs e)
        {
            //btn_update
        }

        private void dGV_properties_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dGV_properties_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
