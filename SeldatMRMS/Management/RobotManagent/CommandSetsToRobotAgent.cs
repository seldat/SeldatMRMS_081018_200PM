using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeldatMRMS.Management
{
    public class CommandSetsToRobotAgent
	{
		public class RobotStatus
		{
			public const int ROBOT_STATUS_IDLE = 1000;
			public const int ROBOT_STATUS_READY = 1001;
			public const int ROBOT_STATUS_ORDERED = 1002;
			public const int ROBOT_STATUS_WORKING = 1003;
			public const int ROBOT_STATUS_FINISH = 1004;
			public const int ROBOT_STATUS_CANCELED = 1005;
			public const int ROBOT_STATUS_CHARGING = 1006;
		}
		public const int SERVER_CALLBACK_CMD_ROBOTINFO  = 1300;
		public const int SERVER_CALLBACK_CMD_ROBOTPARAM = 1301;
		public const int SERVER_CALLBACK_SPEED_STOP = 0;
		public const int SERVER_CALLBACK_SPEED_NORMAL = 100;

		public const String ZONE_HANDLER_INSIDEREADY = "Ready";
        public const String ZONE_HANDLER_CHECKOUT_DOCKING = "Docking_Highway2";
        public const String ZONE_HANDLER_CHECKOUT_PUTAWAY= "Put_away_Ready/Highway1";

        public const int STATE_FINISH_PALLETUP = 5023; //50007; 
        public const int STATE_FINISH_PALLETDOWN = 5035;//50014;
        public const int STATE_FINISH_GOTOLINE_READYAREA = 5056;//500141;***
        public const int STATE_FINISH_DETECTLINE_TO_READYAREA = 5072;//5001413; ****
        public const int STATE_FINISH_GOTO_CHECKINPUTAWAY = 5025;//500129;
        public const int STATE_FINISH_GOTO_CHECKINDOCKING = 5013;//500031;
        public const int STATE_FINISH_GOTO_LINEPUTAWAY = 5028;//50010;
        public const int STATE_FINISH_GOTO_LINEDOCKING = 5016;//50003;
        public const int STATE_SELFDRIVING_WAIT_PALLETUP = 5022;//50006;
        public const int STATE_SELFDRIVING_WAIT_PALLETDOWN = 5034;//50013;
        public const int STATE_SELFDRIVING_START_BATTERYCHARGING = 5049;//5001211;
        public const int STATE_SELFDRIVING_FINISH_BATTERYCHARGING = 5051;//5001411;
        public const int STATE_SELFDRIVING_REQUEST_CHARGEBATTERY = 5078;



        public static String CommandPackage(int cmd, int control)
		{
			dynamic product = new JObject();
			product.command = cmd;
			product.control = control;
			product.date = DateTime.Now.ToString("DD:mm:yy HH:mm:ss");
			return product.ToString();
		}
		public String CreateJsonRegisterRobotToTraffic(Dictionary<String,RobotAgent> rlist)
		{
			dynamic product = new JObject();
			dynamic robotList = new JObject();
			for (int i = 0; i < rlist.Count; i++)
			{
				dynamic robot = new JObject();
				robot.name = rlist.ElementAt(i).Key;
				robot.ip = rlist.ElementAt(i).Value.IpAddress;
				robotList.Add(robot);
			}
			product.list = robotList;
			return product.ToString();
		}

	}
}
