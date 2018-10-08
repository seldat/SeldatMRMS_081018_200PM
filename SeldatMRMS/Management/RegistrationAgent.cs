using SeldatMRMS.Management.OrderManager;
using SeldatMRMS.Management.TrafficManager;
using SeldatMRMS.Model;
using SeldatMRMS.RobotView;
using System;
using System.Collections.Generic;

namespace SeldatMRMS.Management
{
    class RegistrationAgent
	{
		public struct TrafficModelInAnArea
		{
			public int key;
		
		}
        public static MainWindow mainWindowPointer;
		public static Interface interfacePointer;
		public static MultiRobotTraffic MultiRobotPointer;
        public static GroupModel groupModelPointer = new GroupModel();
        public static RobotView3D robotview3dPointer = new RobotView3D();
		public static Dictionary<String, RobotAgent> robotAgentRegisteredList = new Dictionary<String, RobotAgent>(); // long type : ID 
		public static Dictionary<String, HalfPoint> HalfPointRegisteredList = new Dictionary<String, HalfPoint>(); // long type : ID 
		public static SortedDictionary<String, Area> areaList = new SortedDictionary<String, Area>(); // <AreaID>,<Area>
		//public static List<TrafficModelInAnArea> stationRegistrationList = new List<TrafficModelInAnArea>();



		public static List<StationModel> stationRegistrationList = new List<StationModel>();
		public static List<ChargerModel> chargerRegistrationList = new List<ChargerModel>();
		public static List<ReadyModel> readyRegistrationList = new List<ReadyModel>();

		public static List<PathModel> pathRegistrationList = new List<PathModel>();
		public static List<HighwayModel> highwayRegistrationList = new List<HighwayModel>();

		public static List<CheckinModel> checkinRegistrationList = new List<CheckinModel>();
		public static List<CheckoutModel> checkoutRegistrationList = new List<CheckoutModel>();

	}
}
