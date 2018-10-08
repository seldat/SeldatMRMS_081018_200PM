using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SeldatMRMS.RobotView.Path
{
    public partial class GroupPaths : Form
	{
		class PathObject
		{
			public bool flag_lineparam = false;
			public LineParams lineParams;
			public CurveParams curveParams;
		}
		String contents;
		List<LineParams> lineList = new List<LineParams>();
		List<CurveParams> curveList = new List<CurveParams>();
		List<PathObject> pathObjectList = new List<PathObject>();
		public GroupPaths()
		{
			InitializeComponent();
		}

		public bool openpath()
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
				lineList.Clear();
				curveList.Clear();
				return true;

			}
			else if (pwarming == DialogResult.No)
			{
			}
			return false;
		}

		private void btn_openlistpath_Click(object sender, EventArgs e)
		{
			if (openpath())
			{
				JObject results = JObject.Parse(contents);
				foreach (var result in results["Line"])
				{
					string _Name = (string)result["name"];
					listBox_singlepath.Items.Add(_Name);
					dynamic startPoint = result["startPoint"];

					System.Windows.Point sp = new System.Windows.Point((double)startPoint.X, (double)startPoint.Y);
					dynamic endPoint = result["endPoint"];
					System.Windows.Point ep = new System.Windows.Point((double)endPoint.X, (double)endPoint.Y);
					double _startdir = (double)result["startdir"];
					double _enddir = (double)result["enddir"];
					double _unitstep = (double)result["unitStep"];
					LineParams lineparam = new LineParams() { Nameobj = _Name, startpoint = sp, endpoint = ep, startdir = _startdir, enddir = _enddir, unitstep = _unitstep };
					lineList.Add(lineparam);
				}
				foreach (var result in results["Curve"])
				{
					string Name = (string)result["name"];
					listBox_singlepath.Items.Add(Name);
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
					CurveParams curveparam=new CurveParams(){ Nameobj = Name, startpoint = sp,middlepoint = mp, endpoint = ep, startdir = _startdir, enddir = _enddir,R = R,dw = dw,dv = dv };
					curveList.Add(curveparam);
				}
			}
		}

		private void btn_addpath_Click(object sender, EventArgs e)
		{
			string curItem = listBox_singlepath.SelectedItem.ToString();
			listBox_groupPath.Items.Add(curItem);
		}

		private void btn_remove_Click(object sender, EventArgs e)
		{
			listBox_groupPath.Items.Remove(listBox_groupPath.Items[listBox_groupPath.SelectedIndex]);
		}
		public void MoveUpOrDownSelectedItem(ListBox LisBox, bool MoveUp)
		{
			if (LisBox.SelectedIndex > 0 && MoveUp)
			{
				// add a duplicate item up in the listbox
				LisBox.Items.Insert(LisBox.SelectedIndex - 1, LisBox.SelectedItem);
				// make it the current item
				LisBox.SelectedIndex = (LisBox.SelectedIndex - 2);
				// delete the old occurrence of this item
				LisBox.Items.RemoveAt(LisBox.SelectedIndex + 2);
			}
			if ((LisBox.SelectedIndex != -1) && (LisBox.SelectedIndex < LisBox.Items.Count - 1) && MoveUp == false)
			{
				// add a duplicate item down in the listbox
				int IndexToRemove = LisBox.SelectedIndex;
				LisBox.Items.Insert(LisBox.SelectedIndex + 2, LisBox.SelectedItem);
				// make it the current item
				LisBox.SelectedIndex = (LisBox.SelectedIndex + 2);
				// delete the old occurrence of this item
				LisBox.Items.RemoveAt(IndexToRemove);
			}
		}

		private void btn_moveup_Click(object sender, EventArgs e)
		{
			MoveUpOrDownSelectedItem(listBox_groupPath, true);
		}

		private void btn_movedown_Click(object sender, EventArgs e)
		{
			MoveUpOrDownSelectedItem(listBox_groupPath,false);
		}

		private void btn_new_Click(object sender, EventArgs e)
		{
			lineList.Clear();
			curveList.Clear();
			listBox_groupPath.Items.Clear();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			foreach (var listBoxItem in listBox_groupPath.Items)
			{
				String namepath = listBoxItem.ToString();
				MessageBox.Show(""+namepath);
				LineParams templineparams = findLineParam(namepath);
				if (templineparams != null)
				{
					MessageBox.Show("line");
					pathObjectList.Add(new PathObject() { flag_lineparam = true, lineParams = templineparams, curveParams=null });
				}
				CurveParams tempcurveparams = findCurveParam(namepath);
				if (tempcurveparams != null)
				{
					MessageBox.Show("curve");
					pathObjectList.Add(new PathObject() { flag_lineparam =false, curveParams = tempcurveparams,lineParams=null });
				}

			}


			if (pathObjectList.Count > 0)
			{
				System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
				if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					using (StreamWriter sw = File.CreateText(System.IO.Path.GetFullPath(saveFileDialog.FileName)))
					{

						sw.WriteLine("// X, Y, Z, W");
						for (int i = 0; i < pathObjectList.Count; i++)
						{
							String path = "";
							CreateRobotPathPlan createpath = new CreateRobotPathPlan();
							if (pathObjectList[i].flag_lineparam)
							{
								createpath.linePathPlan(pathObjectList[i].lineParams);
								path += createpath.TextLine();
							}
							else
							{
								createpath.CurvePathPlan(pathObjectList[i].curveParams);
								path += createpath.TextCurveLine();
							}
							sw.Write(path);
						}
					}

				}
			}
		}
		private LineParams findLineParam(String Name)
		{
			LineParams lineparam = null; 
			for (int i = 0; i < lineList.Count; i++)
			{
				if (lineList[i].Nameobj.Equals(Name))
				{
					lineparam = lineList[i];
					break;
				}
			}
			return lineparam;
		}
		private CurveParams findCurveParam(String Name)
		{
			CurveParams curveparam = null;
			for (int i = 0; i < curveList.Count; i++)
			{
				if (curveList[i].Nameobj.Equals(Name))
				{
					curveparam = curveList[i];
					break;
				}
			}
			return curveparam;
		}

        private void GroupPaths_Load(object sender, EventArgs e)
        {

        }
    }
}
