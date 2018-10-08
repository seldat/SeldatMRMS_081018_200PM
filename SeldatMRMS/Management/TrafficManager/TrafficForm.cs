using SeldatMRMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SeldatMRMS.Management.TrafficManager
{
    public partial class TrafficForm : Form
	{

		public class ATrafficGroup
		{
			public StationModel station;
			public PathModel checkInConnectedToPath;
			public PathModel checkOutConnectedToPath;
		}
		public List<ATrafficGroup> aTrafficGroup = new List<ATrafficGroup>();
		public TrafficForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{

		}

		private void TrafficForm_Load(object sender, EventArgs e)
		{
			if (RegistrationAgent.stationRegistrationList.Count > 0)
			{
				DataTable dt = new DataTable();
				dt.Columns.Add("Area", typeof(string));
				DataGridViewComboBoxColumn pArea = new DataGridViewComboBoxColumn();
				pArea.HeaderText = "Area";
				DataGridViewComboBoxColumn pcheckin = new DataGridViewComboBoxColumn();
				pcheckin.HeaderText = "CHECK-IN";
				DataGridViewComboBoxColumn pcheckout = new DataGridViewComboBoxColumn();
				pcheckout.HeaderText = "CHECK-OUT";
				foreach (StationModel s in RegistrationAgent.stationRegistrationList)
				{
					pArea.Items.Add(s.props.NameID);
				}
				foreach (PathModel p in RegistrationAgent.pathRegistrationList)
				{
					pcheckout.Items.Add(p.properties.roadName);
					pcheckin.Items.Add(p.properties.roadName);
				}
				dataGridView1.Columns.Add(pArea);
				dataGridView1.Columns.Add(pcheckin);
				dataGridView1.Columns.Add(pcheckout);
			}
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			for (int index = 0; index < dataGridView1.RowCount; index++)
			{
				String stationName = dataGridView1[index, 0].Value.ToString();
				String checkinName = dataGridView1[index, 1].Value.ToString();
				String checkoutName = dataGridView1[index, 2].Value.ToString();
				StationModel   pStation=null;
				PathModel pCheckIn=null;
				PathModel pCheckOut=null;
				foreach (StationModel st in RegistrationAgent.stationRegistrationList)
				{
					if (st.FindName(stationName))
					{
						pStation = st;
						break;
					}
				}
				foreach (PathModel pci in RegistrationAgent.pathRegistrationList)
				{
					if (pci.FindName(checkinName))
					{
						pCheckIn = pci;
						break;
					}
				}
				foreach (PathModel pco in RegistrationAgent.pathRegistrationList)
				{
					if (pco.FindName(checkoutName))
					{
						pCheckOut = pco;
						break;
					}
				}
				aTrafficGroup.Add(new ATrafficGroup() { station = pStation, checkInConnectedToPath = pCheckIn, checkOutConnectedToPath = pCheckOut });
			}
		}
	}
}
