using SeldatMRMS.Communication;
using System;

namespace SeldatMRMS.Management.TrafficManager
{
    public class MultiRobotTraffic
	{
		public struct ParamsRosSocket
		{
			public int publication_servertoMultirules;
			public int publication_trafficInfoRequest;
		}
		private RosSocket rosSocket;
		private ParamsRosSocket paramsRosSocket;
		public MultiRobotTraffic()
		{
		
		}
		public void connection(RosSocket rosSocket)
		{
			this.rosSocket = rosSocket;
			int subscription_multirulestoserver = rosSocket.Subscribe("/multirulestoserver", "std_msgs/String", multirulestoserverHandler);
			paramsRosSocket.publication_servertoMultirules = rosSocket.Advertise("/servertoMultirules", "std_msgs/String");
			int subscription_trafficInfoResponse = rosSocket.Subscribe("/trafficInfoResponse", "std_msgs/String", trafficInfoResponseHandler);
			paramsRosSocket.publication_trafficInfoRequest = rosSocket.Advertise("/trafficInfoRequest", "std_msgs/String");

		}
		private void multirulestoserverHandler(Communication.Message message)
		{
			StandardString standardString = (StandardString)message;
			String data = standardString.data;
		}
		private void trafficInfoResponseHandler(Communication.Message message)
		{
			StandardString standardString = (StandardString)message;
			String data = standardString.data;
		}
	}
}
