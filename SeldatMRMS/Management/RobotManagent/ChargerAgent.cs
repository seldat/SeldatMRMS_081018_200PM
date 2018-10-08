using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Sockets;
using System.Timers;

namespace SeldatMRMS.Management.RobotManagent
{
    class ChargerAgent
	{
		public struct Properties
		{
			public String status;
			public String battery;
			public String temperature;
			public String id;
			public String address;
			public int port;

		}
		public const String CMD_CHARGER_STATUS_NOCHARGE = "c6000e";
		public const String CMD_CHARGER_START = "c6001e";
		public const String CMD_CHARGER_START_WAITINGCHARGE = "c6002e";
		public const String CMD_CHARGER_START_RESET = "c6003e";
		public string cmdctrl = "c6000e";
		TcpClient tcpipClient;
		Timer timerInterruptRequestData;
		public Properties properties;
		public ChargerAgent() {
			tcpipClient = new TcpClient();
			tcpipClient.ReceiveTimeout = 500;
			tcpipClient.SendTimeout = 500;
		}
		public void setNewConnection(String address, int port)
		{
			properties.address = address;
			properties.port = port;
			properties.address = "null";
			properties.battery = "null";
			properties.temperature = "null";
			properties.id= "null";

		}
		public bool requestPackage(String cmd)
		{
			bool finished = false;
			String data;
			try
			{
				tcpipClient.Connect(properties.address, properties.port);
				StreamWriter writer = new StreamWriter(tcpipClient.GetStream());
				StreamReader reader = new StreamReader(tcpipClient.GetStream());
				Byte[] datacmd = System.Text.Encoding.ASCII.GetBytes(cmd);
				tcpipClient.GetStream().Write(datacmd, 0, datacmd.Length);
				data = reader.ReadLine();
				parseData(data);
				writer.Close();
				reader.Close();
				tcpipClient.Close();
				finished = true;
			}
			catch { }
			return finished;
		}
		public void parseData(String txt)
		{
			dynamic stuff = JObject.Parse(txt);
			properties.status= Convert.ToInt32(stuff.status);
		}
	}
}
