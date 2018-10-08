using SeldatMRMS.Management.RobotManagent;
using SeldatMRMS.Management.TrafficManager;
using SeldatMRMS.RobotView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeldatMRMS.Management.OrderManager
{
	public partial class Orders : Form
	{
		//Dictionary<string, OrderItem> orderList;
		public delegate void RequestToReadyArea(String msg);
		public RequestToReadyArea requestToReadyArea;
		public Orders()
		{
			InitializeComponent();
		}
		public void addReadyAreaDepends(ReadyArea readyArea)
		{
			//readyArea.onRequestANewOrder += RequestOrder;
			//readyArea.onFinishAnOrder += OrderFinished;
		}
		private void Orders_Load(object sender, EventArgs e)
		{
			//orderList = new Dictionary<string, OrderItem>();
			//timerOrder.Enabled = true;
			timerOrder.Enabled = true;
			timerOrder.Interval = 2000;
		}



        /// <summary>
        /// Kiem tra list Docking, list PutAway va list Robot, sau do lap Order.
        /// Moi lan lap danh sach cach nhau 1 phut.
        /// </summary>
        public String RequestDockingOderItem(int area, string robotID)
        {
			MessageBox.Show("request");
			String data = "";
			data = DataTranformation.jsonDockingCoordinations(0, 0,0);
			try
			{
				int numberOfArea = RegistrationAgent.areaList.Count;
				string areaID = area.ToString();
				string listLineDockingKey = RegistrationAgent.areaList[areaID].FindWorkingLineDocking(); //"working-" or "pending-" or "none-"
				if (listLineDockingKey != "none")
				{
					int agentID = Int32.Parse(listLineDockingKey.Split('-')[0]);
					int lposdk = Int32.Parse(listLineDockingKey.Split('-')[1]);
					List<int> temp = new List<int>();
					if (RegistrationAgent.areaList[areaID].LIST_LINE_DOCKING.ContainsKey(listLineDockingKey) &&
						RegistrationAgent.areaList[areaID].LIST_LINE_DOCKING[listLineDockingKey].GetPallet(temp))
					{
						List<int> palletnumsdk = temp;
						MessageBox.Show("DOCKING:" + agentID + "-" + lposdk + "-" + palletnumsdk[0]);
						data = DataTranformation.jsonDockingCoordinations(agentID, lposdk, palletnumsdk[0]);
						//requestToReadyArea(DataTranformation.jsonDockingCoordinations(agentID, lposdk, palletnumsdk));
						//Line sẽ tự set biến ordered = true sau khi gọi hàm GetPallet thành công lần đầu
						return data;
					}

				}
			}
			catch
			{
			}
            return data;
        }

        public String RequestPutAwayOderItem(int area, string robotID)
        {
			String data = "";
			data = DataTranformation.jsonPutAwayCoordinations(0, 0, 0);
			try
			{
				int numberOfArea = RegistrationAgent.areaList.Count;
				string areaID = area.ToString();
				string listLinePutAwayKey = RegistrationAgent.areaList[areaID].FindWorkingLinePutAway();
				if (listLinePutAwayKey != "none")
				{
					int agentID = Int32.Parse(listLinePutAwayKey.Split('-')[0]);
					int lpospw = Int32.Parse(listLinePutAwayKey.Split('-')[1]);
					List<int> temp = new List<int>();
					if (RegistrationAgent.areaList[areaID].LIST_LINE_PUTAWAY.ContainsKey(listLinePutAwayKey) &&
						RegistrationAgent.areaList[areaID].LIST_LINE_PUTAWAY[listLinePutAwayKey].GetPallet(temp))
					{
						List<int> palletnumspw = temp;
						data = DataTranformation.jsonPutAwayCoordinations(agentID, lpospw, palletnumspw[0]);
						MessageBox.Show("PUTAWAY:" + agentID + "-" + lpospw + "-" + palletnumspw[0]);
						//requestToReadyArea(DataTranformation.jsonDockingCoordinations(agentID, lposdk, palletnumsdk));
						//Line sẽ tự set biến ordered = true sau khi gọi hàm GetPallet thành công lần đầu
						return data;
					}

				}
			}
			catch { }
            return data;
        }





        //public void CapNhatListView(int AreaID, Area.OrderItem order)
        //{
        //	try
        //	{
        //		if (RegistrationAgent.areaList[AreaID.ToString()].orderList.Count != 0)
        //		{
        //			for (int scanOrder = 0; scanOrder < 1; scanOrder++)
        //			{
        //				int lposdk = Int32.Parse(order.dockinfo.Split('-')[1]);
        //				List<int> palletnumsdk = order.takeDocking;
        //				int lpospw = Int32.Parse(order.putinfo.Split('-')[1]);
        //				List<int> palletnumspw = order.putPutaway;
        //				requestToReadyArea(DataTranformation.jsonDockingCoordinations(lposdk, palletnumsdk, lpospw, palletnumspw));
        //				/////////////////////////////////////////////////////////
        //				/////////////////////////////////////////////////////////
        //				/////////////////////////////////////////////////////////
        //				ListViewItem item = new ListViewItem(AreaID.ToString());//1
        //				item.SubItems.Add(order.robotID);//2
        //				string tempDock = "";
        //				string tempPut = "";
        //				for (int x = 0; x < order.takeDocking.Count; x++)
        //				{
        //					tempDock += "[" + order.takeDocking[x] + "]";
        //				}
        //				item.SubItems.Add(order.dockinfo + ":" + tempDock);//3
        //				for (int x = 0; x < order.putPutaway.Count; x++)
        //				{
        //					tempPut += "[" + order.putPutaway[x] + "]";
        //				}
        //				item.SubItems.Add(order.putinfo + ":" + tempPut);//4

        //				item.SubItems.Add(order.orderStatus);//5
        //				listView1.Items.Add(item);
        //			}
        //		}
        //		else
        //		{
        //			Console.WriteLine("There is no Order!");
        //		}
        //	}
        //	catch
        //	{
        //		MessageBox.Show("Error!");
        //	}
        //}



        private void reset_Click(object sender, EventArgs e)
		{
			//orderList.Clear();
			//RegistrationAgent.areaList["0"].listLineQualifiedDocking["5-0"].ordered = false;
			//RegistrationAgent.areaList["0"].listLineAvailablePutAway["4-1"].available = true;
			//listView1.Items.RemoveAt(0);
		}

        private void button1_Click(object sender, EventArgs e)
        {
            RegistrationAgent.areaList.ElementAt(0).Value.SetFinished("5-0-4-1", RegistrationAgent.robotAgentRegisteredList.ElementAt(0).Value.NameObj);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // if (!RequestDockingOderItem(0, "robot" + DateTime.Now.Ticks))
            {
                MessageBox.Show("Khong lay duoc docking!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // if (!RequestPutAwayOderItem(0, "robot" + DateTime.Now.Ticks))
            {
                MessageBox.Show("Khong lay duoc putaway!");
            }
        }
    }
}
