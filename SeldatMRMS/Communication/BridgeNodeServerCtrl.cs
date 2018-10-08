using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeldatMRMS.Communication
{
	class BridgeNodeServerCtrl
	{
		List<string> _names = new List<string>();
		TcpListener serverSocket;
		private Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		public BridgeNodeServerCtrl() { serverSocket = new TcpListener(19000); }
		public TcpClient SetupServer()
		{
			TcpClient clientSocket = default(TcpClient);
			int counter = 0;
			serverSocket.Start();
			counter = 0;
			counter += 1;
			clientSocket = serverSocket.AcceptTcpClient();
			return clientSocket;

		}
		public void close()
		{
			serverSocket.Stop();
			Console.WriteLine(" >> " + "exit");
			Console.ReadLine();
		}
	
	}

}
