using SeldatMRMS.Management.OrderManager;
using System;

namespace SeldatMRMS.Management.TrafficManager
{
    public class AreaManager
	{	
		public ReadyArea readyArea;
		public Orders orders;
		public AreaManager(Orders orders)
		{


		}
		public void updateRobotToReadyArea(RobotAgent robotagent)
		{
			//readyArea.addRobotDepend(robotagent);

		}
		public void addRobotToReadyArea(RobotAgent robotagent)
		{
		}
		public void messegageFromOrders(String msg)
		{
			//readyArea.orderedRequests(msg);
		}
	}
}
