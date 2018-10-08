using Newtonsoft.Json.Linq;
using System.IO;
using System.Windows.Forms;

namespace SeldatMRMS.RobotView.Path
{
    public class ImportPaths
	{
		public delegate void ImportLines(SetLineParams plineparam);
		public ImportLines importLines;
		public delegate void ImportCurves(SetCurveParams pcurveParams);
		public ImportCurves importCurves;

		private string contents;
		public ImportPaths() {

		}
		public bool loadFileModel()
		{

			OpenFileDialog theDialog = new OpenFileDialog();
			if (theDialog.ShowDialog() == DialogResult.OK)
			{
				StreamReader reader = new StreamReader(theDialog.FileName);
				while (!reader.EndOfStream)
				{
					contents = reader.ReadToEnd();
				}
				reader.Close();
			}
			theDialog.Dispose();
			DialogResult pwarming = MessageBox.Show("Do you want to load new Paths System?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (pwarming == DialogResult.Yes)
			{
				//code for Yes

			}
			else if (pwarming == DialogResult.No)
			{
				return false;
			}
			return true;

		}
		public void loadPathSystem()
		{
				JObject results = JObject.Parse(contents);
				foreach (var result in results["Line"])
				{
					string _Name = (string)result["name"];
					dynamic startPoint = result["startPoint"];

					System.Windows.Point sp=new System.Windows.Point((double)startPoint.X, (double)startPoint.Y);
					dynamic endPoint = result["endPoint"];
					System.Windows.Point ep = new System.Windows.Point((double)endPoint.X, (double)endPoint.Y);
					double _startdir = (double)result["startdir"];
					double _enddir = (double)result["enddir"];
					double _unitstep = (double)result["unitStep"];
					loadLine(new SetLineParams() { Name=_Name,startpos=sp,endpos=ep,_startdir=_startdir,_enddir=_enddir,_unitstep=_unitstep});

				}
				foreach (var result in results["Curve"])
				{
					string Name = (string)result["name"];
					dynamic startPoint = result["startPoint"];
					System.Windows.Point sp = new System.Windows.Point((double)startPoint.X, (double)startPoint.Y);
					dynamic middlePoint = result["middlePoint"];
					System.Windows.Point mp = new System.Windows.Point((double)middlePoint.X, (double)middlePoint.Y);
					dynamic endPoint = result["endPoint"];
					System.Windows.Point ep = new System.Windows.Point((double)endPoint.X, (double)endPoint.Y);
					double _startdir = (double)result["startdir"];
					double _enddir = (double)result["enddir"];
					double R = (double)result["radius"];
					double dv = (double)result["dv"];
					double dw = (double)result["dw"];
					loadCurve(new SetCurveParams() { Name = Name, startpos = sp,middlepos=mp, endpos = ep, _startdir = _startdir, _enddir = _enddir,radius=R,_dw=dw,_dv=dv });

				}

		}
		public void loadLine(SetLineParams plineparam)
		{
			//plineparam.Show();
			plineparam.setparams();
			importLines(plineparam);
		}
		public void loadCurve(SetCurveParams curveParams)
		{
			curveParams.setparams();
			importCurves(curveParams);
		}
	}
}
;
