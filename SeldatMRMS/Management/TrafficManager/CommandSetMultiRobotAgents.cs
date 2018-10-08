using Newtonsoft.Json.Linq;
using SeldatMRMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeldatMRMS.Management.TrafficManager
{
	public class CommandSetMultiRobotAgents
	{
		public const int MULTIROBOT_REGISTRATION_ADD_ONE_ROBOTGENT = 7000;
		public const int MULTIROBOT_REGISTRATION_CANCEL_ONE_ROBOTGENT = 7001;
		public const int MULTIROBOT_REGISTRATION_ADD_LIST_ROBOTGENT = 7002;
		public const int MULTIROBOT_REGISTRATION_CANCEL_LIST_ROBOTGENT = 7003;
		public const int MULTIROBOT_REGISTRATION_GET_LIST_ROBOTGENT = 7004;

		//"{  \"robots\":[{\"name\":\"R-12\",\"ip\":\"192.168.0.15\" },{\"name\":\"R-13\",\"ip\":\"192.168.0.14\"  }]}";
		public static JObject addRobotAgent(String name, String IP)
		{
			dynamic product = new JObject();
			product.name = name;
			product.ip = IP;
			return product;
		}
		public static String addRobotAgentList()
		{
			dynamic product = new JObject();
			dynamic pArrayList = new JArray();
			for(int index=0;index<RegistrationAgent.robotAgentRegisteredList.Count;index++)
			{
				String name = RegistrationAgent.robotAgentRegisteredList.ElementAt(index).Value.NameID;
				String ip = RegistrationAgent.robotAgentRegisteredList.ElementAt(index).Value.IpAddress;
				pArrayList.Add(addRobotAgent(name,ip));
			}
			product.robot = pArrayList;
			return product.ToString();
		}
		public static JObject addADocking(StationModel pstation)
		{
			dynamic product = new JObject();
			dynamic docking = new JObject();
			dynamic checkin = new JObject();
			dynamic checkout = new JObject();
			docking.key = pstation.props.NameID;
			checkin.key = pstation.checkInPoint.properties.key;
			checkout.key = pstation.checkOutPoint.properties.key;
			docking.checkin = checkin;
			docking.checkout = checkout;
			product.docking = docking;
			return product.ToString();
		}
		public static JObject addAPutAway(StationModel pstation)
		{
			dynamic product = new JObject();
			dynamic putaway = new JObject();
			dynamic checkin = new JObject();
			dynamic checkout = new JObject();
			putaway.key = pstation.props.NameID;
			checkin.key = pstation.checkInPoint.properties.key;
			checkout.key = pstation.checkOutPoint.properties.key;
			putaway.checkin = checkin;
			putaway.checkout = checkout;
			product.putaway = putaway;
			return product.ToString();
		}

		public static JObject addASimpleHighWay(PathModel path)
		{
			dynamic product = new JObject();
			dynamic highway = new JObject();
			dynamic startat = new JObject();
			dynamic endat = new JObject();
			dynamic distance = new JObject();
			highway.key = path.properties.Nameobj;
			startat.key = path.nodeConnected.startpoint_station.checkOutPoint.properties.key;
			endat.key = path.nodeConnected.endpoint_station.checkInPoint.properties.key;
			distance.slow = 6.0;
			distance.stop = 3.0;
			distance.intersection = 2.0;
			highway.startat = startat;
			highway.endat = endat;
			highway.distance = distance;
			product.highway = highway;
			return product.ToString();
		}
		public static String addAnAreaTrafficMap(int area)
		{
			dynamic product = new JObject();
			dynamic JArraydocking = new JArray();
			dynamic JArrayputaway = new JArray();
			dynamic JArrayhighway = new JArray();
			foreach (StationModel s in RegistrationAgent.stationRegistrationList)
			{
				if (s.props.typeName == "DOCKING")
				{
					JArraydocking.Add(addADocking(s));
				}
				else if (s.props.typeName == "PUTAWAY")
				{
					JArrayputaway.Add(addAPutAway(s));
				}
			}
			foreach (PathModel p in RegistrationAgent.pathRegistrationList)
			{
				JArrayhighway.Add(addASimpleHighWay(p));
			}

			product.area = area;
			product.docking = JArraydocking;
			product.putaway = JArrayputaway;
			product.highway = JArrayhighway;
			return product.ToString();
		}
	}
}
/*
{
  "Area": [
    {
      "Area": 0,
      "Docking":[ {
        "key": "12212",
        "checkin": {
          "key": "12212"
        },
        "checkout": {
          "key": "12212"
        }
      }],
      "PutAway":[ {
        "key": "12212",
        "checkin": {
          "key": "12212"
        },
        "checkout": {
          "key": "12212"
        }
      }],
      "highway": [
        {
          "Area": 0,
          "key": "12212",
          "startAt": {
            "key": "12212",
            "Limit": ""
          },
          "endAt": {
            "key": "12212",
            "Limit": ""
          },
          "distance": {
            "slow": 6,
            "stop": 3,
            "intersection": 2
          }
        }
      ]
    }
  ]
}
 */
