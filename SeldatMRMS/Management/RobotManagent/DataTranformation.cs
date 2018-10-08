using Newtonsoft.Json.Linq;
using System;

namespace SeldatMRMS.Management.RobotManagent
{
    public class DataTranformation
	{
		public class Coord3D
		{
			public Coord3D(double x, double y, double angle) { this.X = x;this.Y = y;this.Angle = angle; }
			public double X;
			public double Y;
			public double Angle;
		}
		public class PosPallet
		{
			public PosPallet(double max, double min) { this.Xmax = max; this.Xmin = min; }
			public double Xmax;
			public double Xmin;
		}

		public  static Coord3D[] dockingCoordinations = { new Coord3D(-9.88,0.17,180.0),
														 new Coord3D(-9.88,-1.75,180)};

		public static Coord3D[] checkindockingCoordinations = { new Coord3D(-9.25,-5.4,180.0),
														 new Coord3D(-9.88,-0.17,180)};

	//	public static PosPallet[] posPalletdocking = { new PosPallet(-13.5,-13.8),
	//													 new PosPallet(-15.3,-15.8)};
        public static PosPallet[] posPalletdocking = { new PosPallet(-13.0,-13.0),
                                                         new PosPallet(-14.0,-14.0)};

       // public static PosPallet[] posPalletputaway = { new PosPallet(13.0,11.5),
       //                                                 new PosPallet(13.5,13.0)};

        public static PosPallet[] posPalletputaway = { new PosPallet(11.0,11.0),
                                                        new PosPallet(12.5,12.5)};

        public  static Coord3D[] putawayCoordinations = { new Coord3D(7.72,-1.46,0.0),
														 new Coord3D(7.72,0.45,0.0)};

		public static Coord3D[] checkinputawayCoordinations = { new Coord3D(6.0,2.0,0.0),
														 new Coord3D(7.72,0.45,0.0)};

		public static Coord3D[] readyCoordinations = { new Coord3D(7.48,-6.5,0.0),
														 new Coord3D(7.72,0.45,0.0)};
		public static Coord3D[] readyCoordinationsinLines = { new Coord3D(7.48, -6.5, 0.0) };
														 

		public static String jsonDockingLine(int areaId, int agentId, int lposdk)
		{
			dynamic product = new JObject();
			dynamic dockArea = new JObject();
			dynamic linedk = new JObject();
			linedk.X = dockingCoordinations[lposdk].X;
			linedk.Y = dockingCoordinations[lposdk].Y;
			linedk.Angle = dockingCoordinations[lposdk].Angle;
			dockArea.line = linedk;
			product.robotId = 0;
			product.area = areaId;
			product.agent = agentId;

			product.docking = dockArea;
			Console.WriteLine("data "+product.ToString());
			return product.ToString();
		}
        public static String jsonDockingPallet(int areaId, int agentId, int lposdk, int palletnumsdk)
        {
            dynamic product = new JObject();
            dynamic dockArea = new JObject();
           // dynamic linedk = new JObject();
            dynamic posPallet = new JObject();
            posPallet.Xmax = posPalletdocking[palletnumsdk].Xmax;
            posPallet.Xmin = posPalletdocking[palletnumsdk].Xmin;
            dockArea.pallet = posPallet;
            product.robotId = 0;
            product.area = areaId;
            product.agent = agentId;
            product.docking = dockArea;
            Console.WriteLine("data " + product.ToString());
            return product.ToString();
        }
        public static String jsoncheckinDockingCoordinations(int pos)
		{
			dynamic product = new JObject();
			dynamic checkin = new JObject();
			dynamic docking = new JObject();
			checkin.X = checkindockingCoordinations[pos].X;
			checkin.Y = checkindockingCoordinations[pos].Y;
			checkin.Angle = checkindockingCoordinations[pos].Angle;
			docking.checkin = checkin;
			product.docking = docking;
			Console.WriteLine("data " + product.ToString());
			return product.ToString();
		}
		public static String jsoncheckinPutAwayCoordinations(int pos)
		{
			dynamic product = new JObject();
			dynamic checkin = new JObject();
			dynamic putaway = new JObject();
			checkin.X = checkinputawayCoordinations[pos].X;
			checkin.Y = checkinputawayCoordinations[pos].Y;
			checkin.Angle = checkinputawayCoordinations[pos].Angle;
			putaway.checkin = checkin;
			product.putaway = putaway;
			Console.WriteLine("data " + product.ToString());
			return product.ToString();
		}
		public static String jsonFrontReadyAreaCoordinations(int pos)
		{
			dynamic product = new JObject();
			dynamic ready = new JObject();
			ready.X = readyCoordinations[pos].X;
			ready.Y = readyCoordinations[pos].Y;
			ready.Angle = readyCoordinations[pos].Angle;
			product.ready = ready;
			return product.ToString();
		}
		public static String jsonPutAwayLine(int areaId, int agentID, int lpospw)
		{
			dynamic product = new JObject();
			dynamic putawayArea = new JObject();
			dynamic linepw = new JObject();
			linepw.X = putawayCoordinations[lpospw].X;
			linepw.Y = putawayCoordinations[lpospw].Y;
			linepw.Angle = putawayCoordinations[lpospw].Angle;
			putawayArea.line = linepw;
			product.area = areaId;
            product.agent = agentID;
            product.putaway = putawayArea;
			Console.WriteLine("data " + product.ToString());
			return product.ToString();
		}
        public static String jsonPutAwayPallet(int areaId, int agentID, int lpospw, int palletnumspw)
        {
            dynamic product = new JObject();
            dynamic putawayArea = new JObject();
            dynamic posPallet = new JObject();
            posPallet.Xmax = posPalletputaway[palletnumspw].Xmax;
            posPallet.Xmin = posPalletputaway[palletnumspw].Xmin;
            putawayArea.pallet = posPallet;
            product.agent = agentID;
            product.area = areaId;
            product.putaway = putawayArea;
            Console.WriteLine("data " + product.ToString());
            return product.ToString();
        }
    }
}
