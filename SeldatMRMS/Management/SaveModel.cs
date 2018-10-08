using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SeldatMRMS.Management
{
    public class SaveModel
	{
		public static void savedata()
		{	
				dynamic product = new JObject();
				dynamic product_point = new JArray();
                for (int i = 0; i < RegistrationAgent.HalfPointRegisteredList.Count; i++)
				{
					product_point.Add(RegistrationAgent.HalfPointRegisteredList.ElementAt(i).Value.createJsonstring());
					//Console.WriteLine(pif.phalfpoint_manager[i].createJsonstring());
				}
				dynamic product_path = new JArray();
				for (int i = 0; i < RegistrationAgent.pathRegistrationList.Count; i++)
				{
					product_path.Add(RegistrationAgent.pathRegistrationList[i].createJsonstring());
				}
                dynamic product_station = new JArray();
				for (int i = 0; i < RegistrationAgent.stationRegistrationList.Count; i++)
				{
                    product_station.Add(RegistrationAgent.stationRegistrationList[i].createJsonstring());
				}
				dynamic product_robotconfig= new JArray();
				for (int i = 0; i < RegistrationAgent.robotAgentRegisteredList.Count; i++)
				{
					product_robotconfig.Add(RegistrationAgent.robotAgentRegisteredList.ElementAt(i).Value.createJsonstring());
					//Console.WriteLine(pif.phalfpoint_manager[i].createJsonstring());
				}

			    product.haftpoints = product_point;
				product.paths = product_path;
				product.stations = product_station;
				product.robotconfig = product_robotconfig;
                product.groupPath = RegistrationAgent.groupModelPointer.createJsonstring();
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
					File.WriteAllText(saveFileDialog.FileName+".mdl", product.ToString());
			
		}
	}
}
