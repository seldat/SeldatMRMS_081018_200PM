﻿using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeldatMRMS.Management
{
    public partial class IpScanner : Form
	{
		static int upCount = 0;
		static object lockObj = new object();
		const bool resolveNames = true;
		public IpScanner()
		{
			InitializeComponent();
		}

		private void btn_scan_Click(object sender, EventArgs e)
		{
			dataGridView_ipscan.Rows.Clear();
			Task t = Task.Run(() =>
			{
				string ipBase = getIPAddress();
				string[] ipParts = ipBase.Split('.');
				ipBase = ipParts[0] + "." + ipParts[1] + "." + ipParts[2] + ".";
				for (int i = 1; i < 255; i++)
				{
					string ip = ipBase + i.ToString();

					Ping p = new Ping();
					p.PingCompleted += new PingCompletedEventHandler(p_PingCompleted);
					p.SendAsync(ip, 100, ip);
				}
				Console.ReadLine();
			});
		}
		void p_PingCompleted(object sender, PingCompletedEventArgs e)
		{
			string ip = (string)e.UserState;
			if (e.Reply != null && e.Reply.Status == IPStatus.Success)
			{
				if (resolveNames)
				{
					string name;
					try
					{
						IPHostEntry hostEntry = Dns.GetHostEntry(ip);
						name = hostEntry.HostName;
					}
					catch (SocketException ex)
					{
						name = "?";
					}
					Console.WriteLine("{0} ({1}) is up: ({2} ms)", ip, name, e.Reply.RoundtripTime);
					this.Invoke((MethodInvoker)delegate
					{
						dataGridView_ipscan.Rows.Add(ip, e.Reply.RoundtripTime +" ms", name);
					});
					//.Rows.Add("five", "six", "seven", "eight");
				}
				else
				{
					Console.WriteLine("{0} is up: ({1} ms)", ip, e.Reply.RoundtripTime);
				}
				lock (lockObj)
				{
					upCount++;
				}
			}
			else if (e.Reply == null)
			{
				Console.WriteLine("Pinging {0} failed. (Null Reply object?)", ip);
			}

			
		}

		public static string getIPAddress()
		{
			IPHostEntry host;
			string localIP = "";
			host = Dns.GetHostEntry(Dns.GetHostName());
			foreach (IPAddress ip in host.AddressList)
			{
				if (ip.AddressFamily == AddressFamily.InterNetwork)
				{
					localIP = ip.ToString();
				}
			}
			return localIP;
		}

        private void IpScanner_Load(object sender, EventArgs e)
        {

        }
    }
}
