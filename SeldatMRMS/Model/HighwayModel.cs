using SeldatMRMS.Management;
using System;
using System.Collections.Generic;

namespace SeldatMRMS.Model
{
    public class HighwayModel
	{
		public struct Properties
		{
			public String NameID;
            public String NameKey;
            public String label;
			public String roadName;
			public List<PathModel> pathModelRoadNameList;
		}
		public Properties properties;
		public HighwayModel(String name)
		{
            properties.NameID = name;
		}
		public void addPathModel(String name)
		{
			if (RegistrationAgent.pathRegistrationList.Count > 0)
			{
				foreach (PathModel pm in RegistrationAgent.pathRegistrationList)
				{
					if (pm.FindName(name))
					{
						properties.pathModelRoadNameList.Add(pm);
						break;
					}
				}
			}
		}
        public void setText(String text)
        {
            properties.label = text;
            properties.NameKey = properties.NameID + " --- " + properties.label;
        }
        public void removePathModel(String name)
		{
			properties.pathModelRoadNameList.RemoveAt(findPathsExist(name));
		}
		public bool find(String name)
		{
			if (name.Equals(properties.roadName))
			{
				return true;
			}
			return false;
		}
		public int findPathsExist(String name)
		{
			int isexistat = -1;
			int cnt = 0;
			if (properties.pathModelRoadNameList.Count > 0)
			{
				foreach (PathModel p in properties.pathModelRoadNameList)
				{
					if (name.Equals(p.properties.roadName))
					{
						isexistat = cnt;
						break;
					}
					cnt++;
				}
			}
			return isexistat;
		}

	}
}
