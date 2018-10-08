using HelixToolkit.Wpf;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Media.Media3D;

namespace SeldatMRMS.RobotView
{
    public class RobotParams
	{
		public enum ConnectionError
		{
			CONNECTION_TO_ROBOT_CONNECTED = 400,
			CONNECTION_TO_ROBOT_DISCONNECTED = 401,
			CONNECTION_TO_ROBOT_RECIEVE_TIMEOUT = 402,
			CONNECTION_TO_ROBOT_SEND_TIMEOUT = 403,
		}
	}

	public class CurveParams
	{
		public CurveParams() { }
		public String Nameobj;
		public LinesVisual3D curveVisual3D;
		public System.Windows.Point startpoint;
		public System.Windows.Point middlepoint;
		public System.Windows.Point endpoint;
		public double R;
		public double dw;
		public double dv;
		public double startdir;
		public double enddir;
	}

	public class LineParams
	{
		public String Nameobj;
		public LinesVisual3D lineVisual3D;
		public System.Windows.Point startpoint;
		public System.Windows.Point endpoint;
		public double unitstep=1;
		public double startdir=1;
		public double enddir=1;
	}
	class GlobalVariables
    {
        public const int MAP_WIDTH = 1504;
        public const int MAP_HEIGHT = 1506;
        public const int MAP_KT = 1;
        public static int[,] matrix={};

       
        public const int SELECTED_CONTROL_ROBOT = 10011;
        public const int SELECTED_CONTROL_FOCUSCAMERA = 10012;

        public const int MODE_SETTING_MAP = 20000;
        public const int MODE_SETTING_ROBOT = 20000;

        public const int SET_PROPERTIES_GRID = 30000;
        public const int SET_PROPERTIES_ROBOT = 30001;
        public const int SET_PROPERTIES_MAP = 30002;
        public const int SET_PROPERTIES_INFORMATION = 30003;


       
        public static double P1_ESTIMATE_X;
        public static double P1_ESTIMATE_Y;



        public static double P1_NAGVIGATION_X;
        public static double P1_NAGVIGATION_Y;
        public static double P2_NAGVIGATION_X;
        public static double P2_NAGVIGATION_Y;


		public class PathStrategicLocation
		{
			public static Point starpoint;
			public static Point endpoint;
			public static CurveParams pcurparam;
		}

        public static double P1_MEASURE_X;
        public static double P1_MEASURE_Y;

       // Units
        private struct PixelUnitFactor
        {
            public const double Px = 1.0;
            public const double Inch = 96.0;
            public const double Cm = 37.7952755905512;
            public const double Pt = 1.33333333333333;
        }
        public double CmToPx(double cm)
        {
            return cm * PixelUnitFactor.Cm;
        }

        public double PxToCm(double px)
        {
            return px / PixelUnitFactor.Cm;
        }
        public static double MEASUREMENT_UNITMETTERINPIXEL = 0.0;
        public static double MEASUREMENT_UNITASQUARE_LENGTH=0.0;
        public static double MEASUREMENT_UNITASQUARE_METER = 0.0;
        public static double ROBOT_SCALED = 1.0;
        public static double GRIDLINE_WIDTH = 0;
        public static double GRIDLINE_LENGTH=0;
        public static double MAP_WIDTHPIXEL =0;
        public static double MAP_HEIGHTPIXEL = 0;
        public static double MAP_RECTZ = 0;
        public static double ROBOT_ORGIN_ROBOT_X = 1.772;
        public static double ROBOT_ORGIN_ROBOT_Y = 0.0;

        public static double ROBOT_ESTIMATED_ANGLE=0.0;
        public static Point3D ROBOT_ESTIMATED_NEWLOCATION =new Point3D(0,0,0);

        public static double ROBOT_NAVIGATION_ANGLE = 0.0;
        public static Point3D ROBOT_NAVIGATION_NEWLOCATION = new Point3D(0, 0, 0);

        // TCPIP CLIENT 
        public static int TCPIP_REQUEST_ROBOT_RECENTSTATE = 4000;
        public static int TCPIP_REQUEST_ROBOT_STARTPOS = 4001;
        public static int TCPIP_REQUEST_ROBOT_GOALPOS = 4002;
        public static int TCPIP_REQUEST_ROBOT_INITPOS = 4003;
		


        public static double ConvertUnitLengthtoMeter(double v)
        {
            return v * MEASUREMENT_UNITASQUARE_METER / MEASUREMENT_UNITASQUARE_LENGTH;
        }
        public static double ConvertMetertoUnitLength(double v)
        {
            return v * MEASUREMENT_UNITASQUARE_LENGTH / MEASUREMENT_UNITASQUARE_METER;
        }

		//public const string MODELROBOT3D_V1 = "C:\\Users\\li\\Desktop\\SeldatMRMS_30_05\\SeldatMRMS_26_06\\SeldatMRMS_working_100718_1\\SeldatMRMS\\SeldatMRMS\\bin\\Debug\\Resources\\8400001A_small5M2.stl";
		//public const string MODELROBOT3D_V2 = "C:\\Users\\li\\Desktop\\SeldatMRMS_30_05\\SeldatMRMS_26_06\\SeldatMRMS_working_100718_1\\SeldatMRMS\\SeldatMRMS\\bin\\Debug\\Resources\\ROBOT P4 updated 14-Mar.stl";

		public static String getPathRobot3DModel()
		{
            //8400001A_small5M2.stl
            String robot3DPath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Resources\\8400001A_small5M2.stl";
           // String robot3DPath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+ "\\Resources\\ROBOT P4 updated 14-Mar.stl";
			//MessageBox.Show(robot3DPath);
			return robot3DPath;
		}
		//public const string MODELROBOT3D_V1 = "C:\\Users\\luat.tran\\source\\repos\\SeldatMRMS\\SeldatMRMS\\RobotView\\Media\\FULLFRAME.stl";
		//public const string MODELROBOT3D_V2 = "C:\\Users\\luat.tran\\source\\repos\\SeldatMRMS\\SeldatMRMS\\RobotView\\Media\\ROBOT P4 updated 14-Mar.stl";

		//FULLFRAME.stl
		// 

		public String datetime_LogFile_Name = DateTime.Today.ToLongDateString();
		// process

		public const int PROCESS_START_READY =50000;

        public const int PROCESS_START_GOTO_A_POINT = 50001;
        public const int PROCESS_WAIT_GOTO_A_POINT = 50002;
        public const int PROCESS_FINISHED_GOTO_A_POINT = 50003;

        public const int PROCESS_START_DETECTLINE_UP = 50004;
        public const int PROCESS_WAIT_DETECTLINE_UP = 50005;
        public const int PROCESS_END_DETECTLINE_UP = 50006;

        public const int PROCESS_START_GOTO_B_POINT = 50007;
        public const int PROCESS_WAIT_GOTO_B_POINT = 50008;
        public const int PROCESS_FINISHED_GOTO_B_POINT = 50009;

        public const int PROCESS_START_DETECTLINE_DOWN = 50010;
        public const int PROCESS_WAIT_DETECTLINE_DOWN = 50011;
        public const int PROCESS_END_DETECTLINE_DOWN = 50012;

        public const double POINTA_X=100;
        public const double POINTA_Y=-64;
        public const double POINTA_Theta =0;


//8.50744927228369 / 0.911512422030406 / -0.958152299345318


        public const double POINTB_X=0;
        public const double POINTB_Y=0;
        public const double POINTB_Theta=0;

      //  public const double POINTB_X=-160.29202651935;
      //  public const double POINTB_Y=-7.0058180013307;
       // public const double POINTB_Theta=0.0325929025722339;

        public static long PROCESS_ROBOT = PROCESS_START_READY;
        public static Boolean PROCESS_FLAG_PALLET =false;
        public static Boolean PROCESS_FLAG = false;
        

		public static string EncodeTransmissionTimestamp()
		{
			long shortTicks = (DateTime.Now.Ticks - 631139040000000000L) / 10000L;
			return shortTicks + "";
			//return Convert.ToBase64String(BitConverter.GetBytes(shortTicks)).Substring(0, 7);
		}

	}
}
