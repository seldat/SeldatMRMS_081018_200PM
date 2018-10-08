using System;
using System.Linq;
using System.Windows.Media.Media3D;

namespace SeldatMRMS.Management.TrafficManager
{
    public class ReadyArea
	{
		public struct Properties
		{
			public String name;
			public String areaID;
		}
		public struct StatusFlag
		{
			public bool alive;
			public bool flagOrdered;
			public bool flagGoBack;

		}
		public class LimitedArea
		{
			public LimitedArea(double min, double max, String ipCharger) { this.max = max; this.min = min; this.ipCharger = ipCharger; }
			public String ipCharger;
			public double max;
			public double min;
		}
		public static LimitedArea[] limitedAreainReady = { new LimitedArea(13.0,14.0,"192.168.0.200"),  // khoản vị trí robot đậu
														 new LimitedArea(15.2,16.3,"192.168.0.201")};


		public struct RobotInOrder // danh sách robot
		{
			public RobotAgent robotagent;
			public int status;
			public bool flagReady { get; set; }
			public bool flagCheckin { get; set; }
			public bool flagCheckout { get; set; }
		}

		public ReadyArea(String name,String areaID)
		{
			properties.name = name;
			properties.areaID = areaID;
			lawctrl.distanceRemovedFlagOrder = 1.0;
			timerToCheckRobotsFree = new System.Timers.Timer(5000);
			timerToCheckRobotsFree.Elapsed += OnTimedEvent;
			timerToCheckRobotsFree.Start();
			statusFlag.flagOrdered = false;
		}
		private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
		{
				if (RegistrationAgent.areaList.Count > 0)
				{
                    if (RegistrationAgent.areaList[properties.areaID].CheckPalletInDockingArea())
					{
                        supervise();
					}
				}
		}

		public struct LawControl
		{
			public double distanceRemovedFlagOrder; // khoan cach an toàn xóa cờ oder để set up một oder khác
			public Point3D landMark; // toa độ móc để xóa cờ order
		}

		private System.Timers.Timer timerToCheckRobotsFree;
		public LawControl lawctrl;
		public StatusFlag statusFlag;
		public Properties properties;
        RobotAgent robotAgentOrdered;

        public void updateLandMarkPoint(Point3D loc)
		{
			lawctrl.landMark = loc;
		}

		private double calDistance(Point3D pR1, Point3D pR2)
		{
			return Math.Sqrt(Math.Pow((pR2.X - pR1.X), 2) + Math.Pow((pR2.Y - pR1.Y), 2));
		}
		public bool ResetFlagOrderToReadyArea(Point3D loc)
		{
			if (statusFlag.flagOrdered) // kiem tra khoan cách order để xóa cờ order
			{
				double dis = calDistance(lawctrl.landMark, loc);
				if (dis <= lawctrl.distanceRemovedFlagOrder)
				{
					statusFlag.flagOrdered = false;
                    return true;
				}
			}
			return false;
		}
		public void supervise()
		{
			if (!statusFlag.flagOrdered)
			{
                    robotAgentOrdered = null;
                    for (int index = 0; index < limitedAreainReady.Length; index++)
					{
						for (int pos = 0; pos < RegistrationAgent.robotAgentRegisteredList.Count; pos++)
						{
                            RobotAgent robotAgent = RegistrationAgent.robotAgentRegisteredList.ElementAt(pos).Value;
                            if (robotAgent.statusFlag.atReadyArea==true && robotAgent.statusFlag.flagProcess == false)
							{
                                    robotAgentOrdered = robotAgent;
                                    robotAgent.statusFlag.flagProcess = true;
                                    statusFlag.flagOrdered = true;
                                    robotAgent.requestRobotGotoCheckInDocking();
									break;
							}
						}
					}
			}
            else
            {
                //reset statusFlag.flagOrdered=false;
                ResetFlagOrderToReadyArea(robotAgentOrdered.robotInfo.loc);
            }
		}
		
	}
}
