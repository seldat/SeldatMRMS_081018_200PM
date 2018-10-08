using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeldatMRMS
{
	class CommandSet
	{
		public static byte[] CMDPACKET = { };
		public static byte HEADER1 = 0xFB;
		public static byte HEADER2 = 0xBF;
		public static byte END = 0xFE;
		public const byte AMOUNTBYTE_1 = 1; // 1 byte for a data
		public const byte AMOUNTBYTE_2 = 2;
		public const byte AMOUNTBYTE_3 = 3; // need 3 bytes for an data

		public const byte DATATYPE_1 = 1; // 1 : Integer
		public const byte DATATYPE_2 = 2;

		public const byte DATALENGTH_1 = 1; // need 3 bytes for an data
		public const byte DATALENGTH_3 = 3;
		public const byte DATALENGTH_9 = 9; // need 3 bytes for an data


		// STATES CLIENT REQUESTS

		public const int CLIENT_REQUESTED_CMD_MANUALCTRL_STOP = 1100;
		public const int CLIENT_REQUESTED_CMD_MANUALCTRL_FORWARD = 1101;
		public const int CLIENT_REQUESTED_CMD_MANUALCTRL_BACKWARDWARD = 1102;
		public const int CLIENT_REQUESTED_CMD_MANUALCTRL_RESET = 1103;
		public const int CLIENT_REQUESTED_CMD_MANUALCTRL_ROTATIONCW = 1104;
		public const int CLIENT_REQUESTED_CMD_MANUALCTRL_ROTATIONCCW = 1105;

		public const int CLIENT_REQUESTED_CMD_LINEDETECTION_STOP = 1200;
		public const int CLIENT_REQUESTED_CMD_LINEDETECTION_RUN = 1201;
		public const int CLIENT_REQUESTED_CMD_LINEDETECTION_UPPALLET = 1203;
		public const int CLIENT_REQUESTED_CMD_LINEDETECTION_DOWNPALLET = 1204;

		public const int CLIENT_REQUESTED_CMD_LINEDETECTION_DETECTRF = 1205;
		public const int CLIENT_REQUESTED_CMD_LINEDETECTION_OUTLINE = 1206;
		public const int CLIENT_REQUESTED_CMD_LINEDETECTION_DETECTPALLET = 1207;

		public const int CLIENT_REQUESTED_CMD_NAVIGATION_STOP = 1300;
		public const int CLIENT_REQUESTED_CMD_NAVIGATION_START = 1301;
		public const int CLIENT_REQUESTED_CMD_NAVIGATION_SETGOALPOS = 1302;
		public const int CLIENT_REQUESTED_CMD_NAVIGATION_ESTIMPOS = 1303;
		public const int CLIENT_REQUESTED_CMD_NAVIGATION_AMCLPOS_INF = 1304;
		public const int CLIENT_REQUESTED_CMD_NAVIGATION_AMCLPOS_FIN = 1305;
		public const int CLIENT_REQUESTED__POWERON = 1308;
		public const int CLIENT_REQUESTED__POWEROFF = 1309;


		public const int CLIENT_REQUESTED_CMD_PUBLISH_CURRENTTOPICSLIST = 1400;
		public const int CLIENT_REQUESTED_CMD_PUBLISH_ALLINFORMS = 1401;
		public const int CLIENT_REQUESTED_CMD_PUBLISH_FRONTENCODER = 1402;
		public const int CLIENT_REQUESTED_CMD_PUBLISH_SPINENCODER = 1403;
		public const int CLIENT_REQUESTED_CMD_PUBLISH_GYRO = 1404;
		public const int CLIENT_REQUESTED_CMD_PUBLISH_ANYTOPIC = 1405;
		public const int CLIENT_REQUESTED_CMD_PUBLISH_CURRENTSTATE = 1406;

		public const int CLIENT_REQUESTED_CMD_STATE_WAITREADY = 1500;
		public const int CLIENT_REQUESTED_CMD_STATE_ERROR = 1501;

		public static String PalletService(String hostname, int cmd, System.Windows.Forms.DataGridView datagridview)
		{
			if (datagridview.RowCount - 1 < 0)
			{
				MessageBox.Show("Dont have Package to Control !!");
				return "";
			}

			Random _ack = new Random();
			dynamic product = new JObject();
			product.command = cmd;
			product.hostname = hostname;
			product.date = DateTime.Now;
			dynamic package = new JObject();
			dynamic info = new JObject();
			info.worktime = datagridview.RowCount-1;
			dynamic pallets = new JArray();
			dynamic _tmps = new JObject();
			for (int i = 0; i < datagridview.RowCount-1 ; i++)
			{
				dynamic aPallet = new JObject();
				dynamic _dockingArea = new JObject();
				dynamic _limitedPalletUp = new JObject();
				dynamic _putawayArea = new JObject();
				dynamic _limitedPalletDown = new JObject();
				System.Windows.Forms.DataGridViewRow row = (System.Windows.Forms.DataGridViewRow)datagridview.Rows[i];
				String v1 = row.Cells[0].Value.ToString();
				String v2 = row.Cells[1].Value.ToString();
				String v3 = row.Cells[2].Value.ToString();
				String v4 = row.Cells[3].Value.ToString();
				String v5 = row.Cells[4].Value.ToString();

				string[] dockingStr = v2.Split(',');
				_dockingArea.X= Convert.ToDouble(dockingStr[0]);
				_dockingArea.Y= Convert.ToDouble(dockingStr[1]);
				_dockingArea.Angle = Convert.ToDouble(dockingStr[2]);

				string[] limitedPalletUp = v3.Split(',');
				_limitedPalletUp.Infpos = Convert.ToDouble(limitedPalletUp[0]);
				_limitedPalletUp.Sufpos = Convert.ToDouble(limitedPalletUp[1]);
				_limitedPalletUp.Angle = Convert.ToDouble(limitedPalletUp[2]);

				string[] putawayStr = v4.Split(',');
				_putawayArea.X = Convert.ToDouble(putawayStr[0]);
				_putawayArea.Y = Convert.ToDouble(putawayStr[1]);
				_putawayArea.Angle = Convert.ToDouble(putawayStr[2]);

				string[] limitedPalletDown = v5.Split(',');
				_limitedPalletDown.Infpos = Convert.ToDouble(limitedPalletDown[0]);
				_limitedPalletDown.Sufpos = Convert.ToDouble(limitedPalletDown[1]);
				_limitedPalletDown.Angle = Convert.ToDouble(limitedPalletDown[2]);

				aPallet.name = v1;
				aPallet.docking = _dockingArea;
				aPallet.palletup = _limitedPalletUp;
				aPallet.putaway = _putawayArea;
				aPallet.palletdown = _limitedPalletDown;

				pallets.Add(aPallet);
			}
			info.pallets = pallets;
			info.station = _tmps;
			package.info = info;

			product.package = package;
			Console.WriteLine(product.ToString());
			return product.ToString();
		}
		public JObject pathJson(string pathname,List<System.Windows.Point> pos, List<System.Windows.Point> angle)
		{
			dynamic path = new JObject();
			dynamic ValueX = new JArray();
			dynamic ValueY = new JArray();
			dynamic ValueW= new JArray();
			dynamic ValueZ = new JArray();
			path.Name = pathname;
			for (int i = 0; i <pos.Count; i++)
			{
				ValueX.Add(pos[i].X);
				ValueY.Add(pos[i].Y);
				ValueW.Add(angle[i].X);
				ValueZ.Add(angle[i].Y);
			}
			path.X = ValueX;
			path.Y = ValueY;
			path.Z = ValueZ;
			path.W = ValueW;
			return path;		
		}
		public static void pathservice(int cmd, string hostname, List<List<System.Windows.Point>> pp)
		{
			dynamic product = new JObject();
			dynamic paths = new JArray();
			product.command = cmd;
			product.hostname = hostname;
			product.date = DateTime.Now;
		}
		public static String CommandPackage(int cmd,int control,String hostname)
        {
            dynamic product = new JObject();
            product.command = cmd;
			product.control= control;
			product.date = DateTime.Now.ToString("DD:mm:yy HH:mm:ss"); ;
			product.hostname= hostname;
			return product.ToString();
        }
        public static String CommandPackage_Estimate(double x, double y, double th)
        {
            Random _ack = new Random();
            dynamic product = new JObject();
            product.id = 1234;
            product.ack = _ack.Next(100, 1000);
            product.date = "2017-19-05 8:24AM";
            product.command = CLIENT_REQUESTED_CMD_NAVIGATION_ESTIMPOS;
            dynamic _info = new JObject();
            /*dynamic station = new JObject();
            station.sta_posx = i;
            station.sta_posy = i;*/
            _info.posEstX = x;
            _info.posEstY = y;
            _info.posEst_angle = th;
            product.estimate = _info;
            return product.ToString();
        }



    }
}
