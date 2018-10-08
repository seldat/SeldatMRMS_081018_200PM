using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SeldatMRMS.RobotView.Path
{
    class ExportPaths
	{
		public static void savedata(List<SetCurveParams> SetCurveParamsList, List<SetLineParams> SetLineParamsList)
		{
			dynamic product = new JObject();
			dynamic productCurveArray = new JArray();
			for (int i = 0; i < SetCurveParamsList.Count; i++)
			{
				productCurveArray.Add(SetCurveParamsList[i].createJsonstring());
			}
			dynamic productLineArray = new JArray();
			for (int i = 0; i < SetLineParamsList.Count; i++)
			{
				productLineArray.Add(SetLineParamsList[i].createJsonstring());
			}
			product.Date = DateTime.Now.ToString("DD:mm:yy HH:mm:ss");
			product.Line = productLineArray;
			product.Curve = productCurveArray;
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
				File.WriteAllText(saveFileDialog.FileName + ".pm", product.ToString());

		}
	}
}
