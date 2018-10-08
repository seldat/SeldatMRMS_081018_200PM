using HelixToolkit.Wpf;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using SeldatMRMS.Management;
using SeldatMRMS.RobotView.Path;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace SeldatMRMS.RobotView
{

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class RobotView3D : Window
	{
		//SettingForm psettingform = new SettingForm();
		public enum STATECTRL_MOUSEDOWN
		{
			STATECTRL_NORMAL,
			STATECTRL_ESTIMATE_P1,
			STATECTRL_ESTIMATE_P2,
			STATECTRL_NAVIGATION_P1,
			STATECTRL_NAVIGATION_P2,
			STATECTRL_MEASUREMENT_P1,
			STATECTRL_MEASUREMENT_P2,
			STATECTRL_PATHSTRATEGIC_LINE_P1,
			STATECTRL_PATHSTRATEGIC_LINE_P2,
			STATECTRL_PATHSTRATEGIC_EDITTING,
			STATECTRL_PATHSTRATEGIC_CURVE_P1,
			STATECTRL_PATHSTRATEGIC_CURVE_P2,
			STATECTRL_PATHSTRATEGIC_CURVE_SETTING,
			STATECTRL_PATHSTRATEGIC_CURVE_SETTING_APPLIED,

		}
		public enum STATECTRL_MOUSEMOVE
		{
			STATECTRL_MOVE_NORMAL,
			STATECTRL_MOVE_ESTIMATE,
			STATECTRL_MOVE_NAVIGATION,
			STATECTRL_MOVE_MEASUREMENT,
			STATECTRL_MOVE_PATHSTRATEGIC,

		}
		public enum SELECTEDCONTROL
		{
			SELECTED_CONTROL_ESTIMATE_GETPOINT1,
			SELECTED_CONTROL_ESTIMATE_GETPOINT2,
			SELECTED_CONTROL_NAVIGATION_GETPOINT1,
			SELECTED_CONTROL_NAVIGATION_GETPOINT2,
			SELECTED_CONTROL_MEASURE_GETPOINT1,
			SELECTED_CONTROL_MEASURE_GETPOINT2,
			SELECTED_CONTROL_PATHSTRATEGIC_LINE_GETPOINT1,
			SELECTED_CONTROL_PATHSTRATEGIC_LINE_GETPOINT2,
			SELECTED_CONTROL_PATHSTRATEGIC_LINE_OPENFORMSETTING,
			SELECTED_CONTROL_PATHSTRATEGIC_LINE_SETTING,
			SELECTED_CONTROL_PATHSTRATEGIC_LINE_EDTTING,
			SELECTED_CONTROL_PATHSTRATEGIC_LINE_GROUP,
			SELECTED_CONTROL_PATHSTRATEGIC_LINE_SETTING_APPLIED,
			SELECTED_CONTROL_PATHSTRATEGIC_LINE_SETTING_CANCLLED,

			SELECTED_CONTROL_PATHSTRATEGIC_CURVE_GETPOINT1,
			SELECTED_CONTROL_PATHSTRATEGIC_CURVE_GETPOINT2,
			SELECTED_CONTROL_PATHSTRATEGIC_CURVE_OPENFORMSETTING,
			SELECTED_CONTROL_PATHSTRATEGIC_CURVE_SETTING,
			SELECTED_CONTROL_PATHSTRATEGIC_CURVE_EDTTING,
			SELECTED_CONTROL_PATHSTRATEGIC_CURVE_GROUP,
			SELECTED_CONTROL_PATHSTRATEGIC_CURVE_SETTING_APPLIED,
			SELECTED_CONTROL_PATHSTRATEGIC_CURVE_SETTING_CANCLLED,
			SELECTED_CONTROL_SETTING,
			SELECTED_CONTROL_NORMAL,
		}
		public enum SETMAPPROPERTIES
		{
			SET_PROPERTIES_GRID,
			SET_PROPERTIES_MAP,
			SET_PROPERTIES_ROBOT,
			SET_PROPERTIES_INFORMATION,
		}
		public STATECTRL_MOUSEDOWN statectrl_mousedown = STATECTRL_MOUSEDOWN.STATECTRL_NORMAL;
		public STATECTRL_MOUSEMOVE statectrl_mousemove = STATECTRL_MOUSEMOVE.STATECTRL_MOVE_NORMAL;
		public SELECTEDCONTROL selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_NORMAL;
		ControlRobotInterface pmodelcontrol;

		Thread p;
		public List<SetCurveParams> setCurveParamsList = new List<SetCurveParams>();
		public List<SetLineParams> setLineParamsList = new List<SetLineParams>();
		public List<RobotAgent> robotAgentList = new List<RobotAgent>();
		public SetCurveParams pcurinfo;
		public SetLineParams plineinfo;
		public ImportPaths importPaths;
		MapSettingF psettingform;
		public RobotView3D()
		{
			InitializeComponent();
			pmodelcontrol = new ControlRobotInterface();
			MainView3D.MouseWheel += new MouseWheelEventHandler(MainView3D_MouseWheel);
			//MainView3D.DefaultCamera = new PerspectiveCamera();
			//MainView3D.DefaultCamera.Position = new Point3D(0, 0, 100);
			Console.WriteLine(MainView3D.Camera.Position.X + " " + MainView3D.Camera.Position.Y + " " + MainView3D.Camera.Position.Z);
			//this.Topmost = true;
		}
		public Robot3D setRobotAgenttoLayer(RobotAgent robotAgent,String robotname)
		{
			Robot3D robot3DModel=null;
			Dispatcher.Invoke((Action)(() =>
			{
					ModelVisual3D layer = new ModelVisual3D();
					robot3DModel = new Robot3D(robotname, layer);
					RobotLayer.Children.Add(robot3DModel.contentlayer);
					robotAgent.robotInfo.robot3DModel = robot3DModel;
			}));
			return robot3DModel;
		}
		public void updatePos(RobotAgent robotAgent, Point3D loc, double angle)
		{
            try
            {
               // MessageBox.Show("okfine");
                Task.Run(() =>
                     Dispatcher.Invoke((Action)(() =>
                     {
                         robotAgent.robotInfo.robot3DModel.updatePos(loc, angle);
                     }))
                 );
            }
            catch { }
		}
		private void btn_setting_Click(object sender, RoutedEventArgs e)
		{
			selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_SETTING;
			selectModes(null);
		}

		public void loadAWareHouseMap()
		{
			psettingform = new MapSettingF();
			psettingform.Log += setcontrols;
			psettingform.doneSetParams();
			psettingform.done();
		}
		public void selectModes(object pobject)
		{
			RayMeshGeometry3DHitTestResult mesh = null;
			if (pobject != null)
				mesh = (RayMeshGeometry3DHitTestResult)pobject;
			switch (selectedctrlmode)
			{
				case SELECTEDCONTROL.SELECTED_CONTROL_NORMAL:
					pArrowLayer.Children.Clear();
					pMeasureLineLayer.Children.Clear();
					pNavigationLayer.Children.Clear();
					txt_valueControls.Text = "";

					break;
				case SELECTEDCONTROL.SELECTED_CONTROL_MEASURE_GETPOINT1:

					RayMeshGeometry3DHitTestResult mesh_measure_getpoint1 = (RayMeshGeometry3DHitTestResult)pobject;
					GlobalVariables.P1_MEASURE_X = mesh_measure_getpoint1.PointHit.X;
					GlobalVariables.P1_MEASURE_Y = mesh_measure_getpoint1.PointHit.Y;
					break;
				case SELECTEDCONTROL.SELECTED_CONTROL_MEASURE_GETPOINT2:
					RayMeshGeometry3DHitTestResult mesh_measure_getpoint2 = (RayMeshGeometry3DHitTestResult)pobject;
					if (mesh_measure_getpoint2 != null)
					{
						pMeasureLineLayer.Children.Clear();
						double measure_getpoint2X = mesh_measure_getpoint2.PointHit.X;
						double measure_getpoint2Y = mesh_measure_getpoint2.PointHit.Y;

						double dist = 0;

						LinesVisual3D pmeasureLine = new LinesVisual3D();
						Point3DCollection points = new Point3DCollection();

						double angle12 = retrieveAngleTwoPoints(new Point3D(GlobalVariables.P1_MEASURE_X, GlobalVariables.P1_MEASURE_Y, 0), new Point3D(measure_getpoint2X, measure_getpoint2Y, 0));
						double R = GlobalVariables.ConvertMetertoUnitLength(2);
						Point3D pB = new Point3D(GlobalVariables.P1_MEASURE_X+R*Math.Sin(angle12), GlobalVariables.P1_MEASURE_Y + R * Math.Cos(angle12),0);
						Point3D pC = new Point3D(GlobalVariables.P1_MEASURE_X, GlobalVariables.P1_MEASURE_Y, 0);
						LinesVisual3D plBC = new LinesVisual3D();
						Point3DCollection ppBC = new Point3DCollection();
						ppBC.Add(pB);
						ppBC.Add(pC);
						plBC.Points = ppBC;

						Console.WriteLine("Angle P1 P2 "+angle12);
						points.Add(new Point3D(GlobalVariables.P1_MEASURE_X, GlobalVariables.P1_MEASURE_Y, 0));
						points.Add(new Point3D(measure_getpoint2X, measure_getpoint2Y, 0));
						pmeasureLine.Color = Colors.Red;
						pmeasureLine.Thickness = 10;
						pmeasureLine.Points = points;
						dist = Math.Sqrt(Math.Pow((measure_getpoint2X - GlobalVariables.P1_MEASURE_X), 2) + Math.Pow((measure_getpoint2Y - GlobalVariables.P1_MEASURE_Y), 2));
						/* if (GlobalVariables.MEASUREMENT_UNITASQUARE != 0)
						 {
							// txt_valueControls.Text = "Dist= " + (GlobalVariables.MEASUREMENT_UNITASQUARE * dist).ToString("0.000") + " (m)";
						 }
						 else
						 {
						   //  txt_valueControls.Text = "Dist= " + dist.ToString("0.000") + " (Squares)";
						 }*/
						txt_valueControls.Text = "Dist= " + GlobalVariables.ConvertUnitLengthtoMeter(dist).ToString("0.000") + " (m)";
						RectangleVisual3D p = new RectangleVisual3D();
						//pMeasureLineLayer.Children.Add(plBC);
						pMeasureLineLayer.Children.Add(pmeasureLine);
						
					}
					break;
				case SELECTEDCONTROL.SELECTED_CONTROL_SETTING:

					MapSettingF psettingform = new MapSettingF();
					psettingform.Log += setcontrols;
					psettingform.Show();
					break;
				case SELECTEDCONTROL.SELECTED_CONTROL_ESTIMATE_GETPOINT1:
					RayMeshGeometry3DHitTestResult mesh_estimate_getpoint1 = (RayMeshGeometry3DHitTestResult)pobject;
					GlobalVariables.P1_ESTIMATE_X = mesh_estimate_getpoint1.PointHit.X;
					GlobalVariables.P1_ESTIMATE_Y = mesh_estimate_getpoint1.PointHit.Y;
					break;
				case SELECTEDCONTROL.SELECTED_CONTROL_ESTIMATE_GETPOINT2:
					RayMeshGeometry3DHitTestResult mesh_estimate_getpoint2 = (RayMeshGeometry3DHitTestResult)pobject;
					if (mesh_estimate_getpoint2 != null)
					{
						pArrowLayer.Children.Clear();
						ArrowVisual3D p = new ArrowVisual3D();
						p.Fill = new SolidColorBrush(Colors.Red);
						p.Point1 = new Point3D(GlobalVariables.P1_ESTIMATE_X, GlobalVariables.P1_ESTIMATE_Y, 0);
						p.Point2 = new Point3D(mesh_estimate_getpoint2.PointHit.X, mesh_estimate_getpoint2.PointHit.Y, 0);
						double xDiff = mesh_estimate_getpoint2.PointHit.X - GlobalVariables.P1_ESTIMATE_X;
						double yDiff = mesh_estimate_getpoint2.PointHit.Y - GlobalVariables.P1_ESTIMATE_Y;
						double angle = Math.Atan2(yDiff, xDiff) * 180.0 / Math.PI;
						GlobalVariables.ROBOT_ESTIMATED_ANGLE = angle;
						GlobalVariables.ROBOT_ESTIMATED_NEWLOCATION.X = p.Point1.X;
						GlobalVariables.ROBOT_ESTIMATED_NEWLOCATION.Y = p.Point1.Y;
						txt_moveMouse_pointY.Text = "Angle: " + angle.ToString("0.00");
						pArrowLayer.Children.Add(p);

					}
					break;

				case SELECTEDCONTROL.SELECTED_CONTROL_NAVIGATION_GETPOINT1:
					RayMeshGeometry3DHitTestResult mesh_navi_getpoint1 = (RayMeshGeometry3DHitTestResult)pobject;
					GlobalVariables.P1_NAGVIGATION_X = mesh_navi_getpoint1.PointHit.X;
					GlobalVariables.P1_NAGVIGATION_Y = mesh_navi_getpoint1.PointHit.Y;
					break;
				case SELECTEDCONTROL.SELECTED_CONTROL_NAVIGATION_GETPOINT2:
					RayMeshGeometry3DHitTestResult mesh_navi_getpoint2 = (RayMeshGeometry3DHitTestResult)pobject;
					if (mesh_navi_getpoint2 != null)
					{
						pArrowLayer.Children.Clear();
						ArrowVisual3D p = new ArrowVisual3D();

						p.Fill = new SolidColorBrush(Colors.Gold);
						GlobalVariables.P2_NAGVIGATION_X = mesh_navi_getpoint2.PointHit.X;
						GlobalVariables.P2_NAGVIGATION_Y = mesh_navi_getpoint2.PointHit.Y;
						p.Point1 = new Point3D(GlobalVariables.P1_NAGVIGATION_X, GlobalVariables.P1_NAGVIGATION_Y, 0);
						p.Point2 = new Point3D(mesh_navi_getpoint2.PointHit.X, mesh_navi_getpoint2.PointHit.Y, 0);
						double xDiff = mesh_navi_getpoint2.PointHit.X - GlobalVariables.P1_NAGVIGATION_X;
						double yDiff = mesh_navi_getpoint2.PointHit.Y - GlobalVariables.P1_NAGVIGATION_Y;
						double angle = Math.Atan2(yDiff, xDiff) * 180.0 / Math.PI;
						GlobalVariables.ROBOT_NAVIGATION_ANGLE = angle;
						GlobalVariables.ROBOT_NAVIGATION_NEWLOCATION.X = p.Point1.X;
						GlobalVariables.ROBOT_NAVIGATION_NEWLOCATION.Y = p.Point1.Y;
						txt_moveMouse_pointY.Text = "Angle: " + angle.ToString("0.00");
						pArrowLayer.Children.Add(p);

					}
					break;

				case SELECTEDCONTROL.SELECTED_CONTROL_PATHSTRATEGIC_LINE_GETPOINT1:
					plineinfo.setStartPoint(new System.Windows.Point(mesh.PointHit.X, mesh.PointHit.Y));
					setRectanlge(pPathSetting, plineinfo.startpos, Colors.Red);
					selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_NORMAL;
					break;
				case SELECTEDCONTROL.SELECTED_CONTROL_PATHSTRATEGIC_LINE_GETPOINT2:
					plineinfo.setEndPoint(new System.Windows.Point(mesh.PointHit.X, mesh.PointHit.Y));
					setRectanlge(pPathSetting, plineinfo.endpos, Colors.Blue);
					selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_NORMAL;
					break;
				case SELECTEDCONTROL.SELECTED_CONTROL_PATHSTRATEGIC_LINE_SETTING:
					pPathSetting.Children.Clear();
					setRectanlge(pPathSetting, plineinfo.startpos, Colors.Red);
					setRectanlge(pPathSetting, plineinfo.endpos, Colors.Blue);
					setArrow(pPathSetting, plineinfo.endpos, plineinfo.lineParam.enddir, Colors.Blue);
					setArrow(pPathSetting, plineinfo.startpos, plineinfo.lineParam.startdir, Colors.Red);
					CreateRobotPathPlan line = new CreateRobotPathPlan();
					line.linePathPlan( plineinfo.lineParam);
					plineinfo.lineParam.lineVisual3D = drawLineVidual3D(pPathLayer, line.CoordinationXY_lineplan, Colors.Yellow);
					pPathSetting.Children.Add(plineinfo.lineParam.lineVisual3D);
					break;
				case SELECTEDCONTROL.SELECTED_CONTROL_PATHSTRATEGIC_LINE_OPENFORMSETTING:
					if (plineinfo != null)
					{
						plineinfo.Close();
						plineinfo = null;
					}
					plineinfo = new SetLineParams();
					plineinfo.loadChangedLineParams += loadChangedLineParams;
					plineinfo.getLineStartPoint += getLineP1;
					plineinfo.getLineEndPoint += getLineP2;
					plineinfo.setLineStartPoint += setLineP1;
					plineinfo.setLineEndPoint += setLineP2;
					plineinfo.changedLineParamsFinhed += changedLineParamsFinhed;
					plineinfo.lineParamsCancelled += lineParamsCancelled;
					plineinfo.lineParam.lineVisual3D = new LinesVisual3D();
					plineinfo.Show();

					break;
				case SELECTEDCONTROL.SELECTED_CONTROL_PATHSTRATEGIC_LINE_SETTING_APPLIED:
					pPathSetting.Children.Clear();
					setRectanlge(pPathLayer, plineinfo.startpos, Colors.Red);
					setRectanlge(pPathLayer, plineinfo.endpos, Colors.Blue);
					setArrow(pPathLayer, plineinfo.endpos, plineinfo.lineParam.enddir, Colors.Blue);
					setArrow(pPathLayer, plineinfo.startpos, plineinfo.lineParam.startdir, Colors.Red);
					CreateRobotPathPlan lineapplied = new CreateRobotPathPlan();
					lineapplied.linePathPlan(plineinfo.lineParam);
					plineinfo.lineParam.lineVisual3D = drawLineVidual3D(pPathLayer, lineapplied.CoordinationXY_lineplan, Colors.Yellow);
					plineinfo.lineParam.lineVisual3D.SetName(plineinfo.Name);
					pPathLayer.Children.Add(plineinfo.lineParam.lineVisual3D);
					setLineParamsList.Add(plineinfo);
					selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_NORMAL;
					break;
				case SELECTEDCONTROL.SELECTED_CONTROL_PATHSTRATEGIC_LINE_SETTING_CANCLLED:
					pPathSetting.Children.Clear();
					plineinfo = null;
					selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_NORMAL;
					break;
				case SELECTEDCONTROL.SELECTED_CONTROL_PATHSTRATEGIC_CURVE_GETPOINT1:
					pcurinfo.setStartPoint(new System.Windows.Point(mesh.PointHit.X, mesh.PointHit.Y));
					setRectanlge(pPathSetting, pcurinfo.startpos, Colors.Red);
					selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_NORMAL;
					break;
				case SELECTEDCONTROL.SELECTED_CONTROL_PATHSTRATEGIC_CURVE_GETPOINT2:
					pcurinfo.setEndPoint(new System.Windows.Point(mesh.PointHit.X, mesh.PointHit.Y));
					setRectanlge(pPathSetting, pcurinfo.endpos, Colors.Blue);
					selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_NORMAL;

					break;
				case SELECTEDCONTROL.SELECTED_CONTROL_PATHSTRATEGIC_CURVE_OPENFORMSETTING:
					if (pcurinfo != null)
					{
						pcurinfo.Close();
						pcurinfo = null;
					}
					pcurinfo = new SetCurveParams();
					pcurinfo.loadChangedCurveParams += loadChangedCurveParams;
					pcurinfo.changedCurveParamsFinhed += changedCurveParamsFinhed;
					pcurinfo.getCurveStartPoint += getCurveP1;
					pcurinfo.getCurveEndPoint += getCurveP2;
					pcurinfo.setCurveStartPoint += setCurveP1;
					pcurinfo.setCurveEndPoint += setCurveP2;
					pcurinfo.curveParamsCancelled += curveParamsCancelled;
					pcurinfo.Show();
					break;
				case SELECTEDCONTROL.SELECTED_CONTROL_PATHSTRATEGIC_CURVE_SETTING:
					pPathSetting.Children.Clear();
					setRectanlge(pPathSetting, pcurinfo.startpos, Colors.Red);
					setRectanlge(pPathSetting, pcurinfo.endpos, Colors.Blue);
					setArrow(pPathSetting, pcurinfo.endpos, pcurinfo.curveParam.enddir, Colors.Blue);
					setArrow(pPathSetting, pcurinfo.startpos, pcurinfo.curveParam.startdir, Colors.Red);
					CreateRobotPathPlan curvesetting = new CreateRobotPathPlan();
					curvesetting.CurvePathPlan( pcurinfo.curveParam);
					pPathSetting.Children.Add(drawLineVidual3D(pPathSetting, curvesetting.CoordinationXY_curveplan, Colors.Yellow));
					break;
				case SELECTEDCONTROL.SELECTED_CONTROL_PATHSTRATEGIC_CURVE_SETTING_APPLIED:
					pPathSetting.Children.Clear();
					setRectanlge(pPathLayer, pcurinfo.startpos, Colors.Red);
					setRectanlge(pPathLayer, pcurinfo.endpos, Colors.Blue);
					setArrow(pPathLayer, pcurinfo.endpos, pcurinfo.curveParam.enddir, Colors.Blue);
					setArrow(pPathLayer, pcurinfo.startpos, pcurinfo.curveParam.startdir, Colors.Red);
					CreateRobotPathPlan curveApplied = new CreateRobotPathPlan();
					curveApplied.CurvePathPlan(pcurinfo.curveParam);
					LinesVisual3D curveVisual3D = drawLineVidual3D(pPathLayer, curveApplied.CoordinationXY_curveplan, Colors.Yellow);
					curveVisual3D.SetName(pcurinfo.Name);
					pcurinfo.curveParam.curveVisual3D = curveVisual3D;
					pPathLayer.Children.Add(curveVisual3D);
					setCurveParamsList.Add(pcurinfo);
					selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_NORMAL;

					break;
				case SELECTEDCONTROL.SELECTED_CONTROL_PATHSTRATEGIC_CURVE_SETTING_CANCLLED:
					pPathSetting.Children.Clear();
					pcurinfo = null;
					selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_NORMAL;
					break;
			}

		}

		List<Position> CoordinationXY = new List<Position>();
		public double retrieveAngleTwoPoints(Point3D p1, Point3D p2) // angle between two points
		{
			double xDiff = p2.X - p1.X;
			double yDiff = p2.Y - p1.Y;
			return Math.Atan2(yDiff, xDiff);
		}
		public void calNumpage()
		{

			Stream myStream = null;
			string line;
			CoordinationXY.Clear();
			System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				using (System.IO.StreamReader file = new System.IO.StreamReader(System.IO.Path.GetFullPath(openFileDialog1.FileName)))
				{
					while ((line = file.ReadLine()) != null)
					{

						string[] separators = { "{", ",", "}" };
						string[] words = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
						//Console.WriteLine(words);
						//Console.Write(Convert.ToDouble(words[0]) / 10.0 + "" + Convert.ToDouble(words[1]) / 10.0 + "" + Convert.ToDouble(words[2]) + "" + Convert.ToDouble(words[3]));
						CoordinationXY.Add(new Position() { X = Convert.ToDouble(words[0]) * 10, Y = Convert.ToDouble(words[1]) * 10 });

					}
				}
			}


		}

		public void setRectanlge(ModelVisual3D pLayer, System.Windows.Point p, Color c)
		{
			RectangleVisual3D pRect = new RectangleVisual3D();
			pRect.Fill = new SolidColorBrush(c);
			pRect.Width = GlobalVariables.ConvertUnitLengthtoMeter(20);
			pRect.Length = GlobalVariables.ConvertUnitLengthtoMeter(20);
			pRect.Origin = new Point3D(p.X, p.Y, 0);
			pLayer.Children.Add(pRect);
		}
		public void setArrow(ModelVisual3D pLayer, System.Windows.Point p1, double angle, Color c)
		{
			ArrowVisual3D parrow = new ArrowVisual3D();
			parrow.Fill = new SolidColorBrush(c);
			parrow.Point1 = new Point3D(p1.X, p1.Y, 0);
			parrow.Point2 = new Point3D(p1.X + 10 * Math.Cos(angle), p1.Y + 10 * Math.Sin(angle), 0);
			pLayer.Children.Add(parrow);
		}

		public LinesVisual3D drawLineVidual3D(ModelVisual3D pLayer, List<Position> line, Color c)
		{
			Point3DCollection pointcollection__straighline = new Point3DCollection();
			for (int i = 0; i < line.Count; i++)
			{
				pointcollection__straighline.Add(new Point3D(line[i].X, line[i].Y, 0));
			}

			LinesVisual3D pline = new LinesVisual3D();
			pline.Points = pointcollection__straighline;
			pline.Thickness = 2;
			pline.Color = Colors.Yellow;
			return pline;
		}
		public void drawLineVidual3DEditting(ModelVisual3D pLayer, List<Position> line, LinesVisual3D pline)
		{
			Point3DCollection pointcollection__straighline = new Point3DCollection();
			for (int i = 0; i < line.Count; i++)
			{
				pointcollection__straighline.Add(new Point3D(line[i].X, line[i].Y, 0));
			}
			pline.Points = pointcollection__straighline;
			pline.Thickness = 2;
			pline.Color = Colors.Yellow;
		}

		void getLineP1()
		{
			statectrl_mousedown = STATECTRL_MOUSEDOWN.STATECTRL_PATHSTRATEGIC_LINE_P1;
		}
		void getLineP2()
		{
			statectrl_mousedown = STATECTRL_MOUSEDOWN.STATECTRL_PATHSTRATEGIC_LINE_P2;
		}
		void setLineP1()
		{
			statectrl_mousedown = STATECTRL_MOUSEDOWN.STATECTRL_PATHSTRATEGIC_LINE_P1;
		}
		void setLineP2()
		{
			statectrl_mousedown = STATECTRL_MOUSEDOWN.STATECTRL_PATHSTRATEGIC_LINE_P2;
		}
		private void loadChangedLineParams(LineParams param)
		{
			selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_PATHSTRATEGIC_LINE_SETTING;
			selectModes(null);
		}
		void getCurveP1()
		{
			statectrl_mousedown = STATECTRL_MOUSEDOWN.STATECTRL_PATHSTRATEGIC_CURVE_P1;
		}
		void getCurveP2()
		{
			statectrl_mousedown = STATECTRL_MOUSEDOWN.STATECTRL_PATHSTRATEGIC_CURVE_P2;
		}
		void setCurveP1()
		{
			statectrl_mousedown = STATECTRL_MOUSEDOWN.STATECTRL_PATHSTRATEGIC_CURVE_P1;
		}
		void setCurveP2()
		{
			statectrl_mousedown = STATECTRL_MOUSEDOWN.STATECTRL_PATHSTRATEGIC_CURVE_P2;
		}
		private void loadChangedCurveParams(CurveParams param)
		{
			//GlobalVariables.PathStrategicLocation.pcurparam = param;
			selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_PATHSTRATEGIC_CURVE_SETTING;
			selectModes(null);
		}
		private void lineParamsCancelled()
		{
			selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_PATHSTRATEGIC_LINE_SETTING_CANCLLED;
			selectModes(null);
		}
		private void curveParamsCancelled()
		{
			selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_PATHSTRATEGIC_CURVE_SETTING_CANCLLED;
			selectModes(null);
		}
		private void changedLineParamsFinhed()
		{
			selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_PATHSTRATEGIC_LINE_SETTING_APPLIED;
			selectModes(null);
		}
		private void changedCurveParamsFinhed()
		{
			selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_PATHSTRATEGIC_CURVE_SETTING_APPLIED;
			selectModes(null);
		}
		private void selectedControlItems(int mode)
		{

		}
		private void setcontrols(string tag, string message)
		{
			if (tag == "TAG-GRID")
			{
				setControlproperties(SETMAPPROPERTIES.SET_PROPERTIES_GRID, message);
			}
			else if (tag == "TAG-MAP")
			{
				setControlproperties(SETMAPPROPERTIES.SET_PROPERTIES_MAP, message);
			}
			else if (tag == "TAG-ROBOT")
			{
				setControlproperties(SETMAPPROPERTIES.SET_PROPERTIES_ROBOT, message);
			}
			else if (tag == "TAG-INFORMATION")
			{
				setControlproperties(SETMAPPROPERTIES.SET_PROPERTIES_INFORMATION, message);
			}
		}
		public void setControlproperties(SETMAPPROPERTIES mode, string message)
		{
			switch (mode)
			{
				case SETMAPPROPERTIES.SET_PROPERTIES_GRID:
					Dispatcher.Invoke((Action)delegate
					{
						try
						{
							string[] data = message.Split('%');
							viewPort3d.Width = Convert.ToDouble(data[0]);
							viewPort3d.Length = Convert.ToDouble(data[1]);
							viewPort3d.MinorDistance = Convert.ToDouble(data[2]);
							viewPort3d.MajorDistance = Convert.ToDouble(data[3]);
							var color = (Color)ColorConverter.ConvertFromString(data[4]);
							MainView3D.Background = new SolidColorBrush(color);
							viewPort3d.Thickness = Convert.ToDouble(data[5]);
							string[] normalVector = data[6].Split(',');
						}
						catch { }
					});
					break;
				case SETMAPPROPERTIES.SET_PROPERTIES_MAP:
					Dispatcher.Invoke((Action)delegate
					{
						MapLayer.Children.Clear();
						pmodelcontrol.selsettingMap(MapLayer, message);
					});

					break;
				case SETMAPPROPERTIES.SET_PROPERTIES_ROBOT:
					Dispatcher.Invoke((Action)delegate
					{
						string[] data = message.Split('%');
						if (Convert.ToInt32(data[1]) == 0)
						{
							pmodelcontrol.createRobot(RobotLayer, Convert.ToInt32(data[0]));
						}
						else if (Convert.ToInt32(data[1]) == 1)
						{
							RobotLayer.Children.Clear();
							pmodelcontrol.createRobot(RobotLayer, Convert.ToInt32(data[0]));
						}
					});
					break;
				case SETMAPPROPERTIES.SET_PROPERTIES_INFORMATION:
					/*   Dispatcher.Invoke((Action)delegate
					   {
						  richtxt_information.Document.Blocks.Clear();
						  richtxt_information.AppendText(message);
						  richtxt_information.Height = richtxt_information.Document.LineHeight;
					   });*/
					break;
			}

		}
		private void psetting_map_MouseDown(object sender, MouseButtonEventArgs e)
		{

		}
		Boolean flagselected = false;
		private void MainView3D_MouseDown(object sender, MouseButtonEventArgs e)
		{
			Point mousedown = e.GetPosition(viewPort3d.GetViewport3D());
			HitTestResult result = VisualTreeHelper.HitTest(viewPort3d.GetViewport3D(), mousedown);
			RayMeshGeometry3DHitTestResult mesh_rsult = result as RayMeshGeometry3DHitTestResult;
			if (mesh_rsult != null)
			{

				switch (statectrl_mousedown)
				{
					case STATECTRL_MOUSEDOWN.STATECTRL_NORMAL:
						break;
					case STATECTRL_MOUSEDOWN.STATECTRL_ESTIMATE_P1:
						statectrl_mousemove = STATECTRL_MOUSEMOVE.STATECTRL_MOVE_ESTIMATE;
						statectrl_mousedown = STATECTRL_MOUSEDOWN.STATECTRL_ESTIMATE_P2;
						selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_ESTIMATE_GETPOINT1;
						selectModes(mesh_rsult);

						break;
					case STATECTRL_MOUSEDOWN.STATECTRL_ESTIMATE_P2:
						{
							selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_NORMAL;
							statectrl_mousedown = STATECTRL_MOUSEDOWN.STATECTRL_NORMAL;
							statectrl_mousemove = STATECTRL_MOUSEMOVE.STATECTRL_MOVE_NORMAL;
							selectModes(null);
							//GlobalVariables.FLAG_ESTIMATE = false;
							// update new location and robot rotation
							pmodelcontrol.updateRobotstates(0, GlobalVariables.ROBOT_ESTIMATED_NEWLOCATION, GlobalVariables.ROBOT_ESTIMATED_ANGLE);
							double[] lo = { GlobalVariables.ConvertUnitLengthtoMeter(GlobalVariables.ROBOT_ESTIMATED_NEWLOCATION.X), GlobalVariables.ConvertUnitLengthtoMeter(GlobalVariables.ROBOT_ESTIMATED_NEWLOCATION.Y), GlobalVariables.ROBOT_ESTIMATED_ANGLE };

							Console.WriteLine(lo[0] + " " + lo[1] + " " + lo[2]);
							if (pconnectrobot != null)
							{
								if (pconnectrobot.isconnected)
								{
									//  byte []cmd=CommandSet.CreateFrameCMD(10,CommandSet.CLIENT_REQUESTED_NAVIGATION_ESTIMPOS,lo,CommandSet.DATALENGTH_9,CommandSet.AMOUNTBYTE_3,CommandSet.DATATYPE_2);
									// pconnectrobot.sendpackage(cmd);
								}
							}
						}
						break;
					case STATECTRL_MOUSEDOWN.STATECTRL_NAVIGATION_P1:
						statectrl_mousemove = STATECTRL_MOUSEMOVE.STATECTRL_MOVE_NAVIGATION;
						statectrl_mousedown = STATECTRL_MOUSEDOWN.STATECTRL_NAVIGATION_P2;
						selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_NAVIGATION_GETPOINT1;
						pNavigationLayer.Children.Clear();
						selectModes(mesh_rsult);
						break;
					case STATECTRL_MOUSEDOWN.STATECTRL_NAVIGATION_P2:
						{
							selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_NORMAL;
							statectrl_mousedown = STATECTRL_MOUSEDOWN.STATECTRL_NORMAL;
							statectrl_mousemove = STATECTRL_MOUSEMOVE.STATECTRL_MOVE_NORMAL;
							selectModes(null);
							//MessageBox.Show(GlobalVariables.P1_NAGVIGATION_X + " / " + GlobalVariables.P1_NAGVIGATION_Y + " / " + GlobalVariables.ROBOT_NAVIGATION_ANGLE);
							// update new location and robot rotation
							//pmodelcontrol.updateRobotstates(0, GlobalVariables.ROBOT_NAVIGATION_NEWLOCATION, GlobalVariables.ROBOT_NAVIGATION_ANGLE);
							double[] lo = { GlobalVariables.ConvertUnitLengthtoMeter(GlobalVariables.P1_NAGVIGATION_X), GlobalVariables.ConvertUnitLengthtoMeter(GlobalVariables.P1_NAGVIGATION_Y), GlobalVariables.ROBOT_NAVIGATION_ANGLE };
							ArrowVisual3D pnav = new ArrowVisual3D();

							pnav.Fill = new SolidColorBrush(Colors.Gold);
							pnav.Point1 = new Point3D(GlobalVariables.P1_NAGVIGATION_X, GlobalVariables.P1_NAGVIGATION_Y, 0);
							pnav.Point2 = new Point3D(GlobalVariables.P2_NAGVIGATION_X, GlobalVariables.P2_NAGVIGATION_Y, 0);
							pNavigationLayer.Children.Add(pnav);
							Console.WriteLine(lo[0] + " " + lo[1] + " " + lo[2]);
							if (pconnectrobot != null)
							{
								if (pconnectrobot.isconnected)
								{

									//  byte[] cmd = CommandSet.CreateFrameCMD(10, CommandSet.CLIENT_REQUESTED_NAVIGATION_SETGOALPOS, lo, CommandSet.DATALENGTH_9, CommandSet.AMOUNTBYTE_3, CommandSet.DATATYPE_2);
									//  pconnectrobot.sendpackage(cmd);
								}
							}
						}
						break;
					case STATECTRL_MOUSEDOWN.STATECTRL_MEASUREMENT_P1:
						statectrl_mousemove = STATECTRL_MOUSEMOVE.STATECTRL_MOVE_MEASUREMENT;
						statectrl_mousedown = STATECTRL_MOUSEDOWN.STATECTRL_MEASUREMENT_P2;
						selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_MEASURE_GETPOINT1;
						selectModes(mesh_rsult);
						break;
					case STATECTRL_MOUSEDOWN.STATECTRL_MEASUREMENT_P2:
						selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_NORMAL;
						statectrl_mousedown = STATECTRL_MOUSEDOWN.STATECTRL_NORMAL;
						statectrl_mousemove = STATECTRL_MOUSEMOVE.STATECTRL_MOVE_NORMAL;
						selectModes(null);
						break;
					case STATECTRL_MOUSEDOWN.STATECTRL_PATHSTRATEGIC_CURVE_P1:
						//MessageBox.Show("STATECTRL_PATHSTRATEGIC_P1");
						//statectrl_mousemove = STATECTRL_MOUSEMOVE.STATECTRL_MOVE_PATHSTRATEGIC;
						//statectrl_mousedown = STATECTRL_MOUSEDOWN.STATECTRL_PATHSTRATEGIC_CURVE_P2;
						selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_PATHSTRATEGIC_CURVE_GETPOINT1;
						selectModes(mesh_rsult);
						statectrl_mousedown = STATECTRL_MOUSEDOWN.STATECTRL_NORMAL;
						break;
					case STATECTRL_MOUSEDOWN.STATECTRL_PATHSTRATEGIC_CURVE_P2:
						selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_PATHSTRATEGIC_CURVE_GETPOINT2;
						selectModes(mesh_rsult);
						statectrl_mousedown = STATECTRL_MOUSEDOWN.STATECTRL_NORMAL;
						//MessageBox.Show("STATECTRL_PATHSTRATEGIC_P2");
						/*selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_NORMAL;
						statectrl_mousedown = STATECTRL_MOUSEDOWN.STATECTRL_NORMAL;
						statectrl_mousemove = STATECTRL_MOUSEMOVE.STATECTRL_MOVE_NORMAL;
						selectModes(null);*/
						break;

					case STATECTRL_MOUSEDOWN.STATECTRL_PATHSTRATEGIC_LINE_P1:
						//MessageBox.Show("STATECTRL_PATHSTRATEGIC_P1");
						statectrl_mousemove = STATECTRL_MOUSEMOVE.STATECTRL_MOVE_PATHSTRATEGIC;
						statectrl_mousedown = STATECTRL_MOUSEDOWN.STATECTRL_PATHSTRATEGIC_LINE_P2;
						selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_PATHSTRATEGIC_LINE_GETPOINT1;
						selectModes(mesh_rsult);
						break;
					case STATECTRL_MOUSEDOWN.STATECTRL_PATHSTRATEGIC_LINE_P2:
						selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_PATHSTRATEGIC_LINE_GETPOINT2;
						selectModes(mesh_rsult);
						selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_NORMAL;
						statectrl_mousedown = STATECTRL_MOUSEDOWN.STATECTRL_NORMAL;
						//MessageBox.Show("STATECTRL_PATHSTRATEGIC_P2");
						/*selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_NORMAL;
						statectrl_mousedown = STATECTRL_MOUSEDOWN.STATECTRL_NORMAL;
						statectrl_mousemove = STATECTRL_MOUSEMOVE.STATECTRL_MOVE_NORMAL;
						selectModes(null);*/
						break;
					case STATECTRL_MOUSEDOWN.STATECTRL_PATHSTRATEGIC_EDITTING:
						String Nameobj = mesh_rsult.VisualHit.GetName();
						if (Nameobj!="")
						{
							foreach (SetLineParams p in setLineParamsList)
							{
								if (p.findObject(Nameobj))
								{
									p.Show();
								}
							}
							foreach (SetCurveParams p in setCurveParamsList)
							{
								if (p.findObject(Nameobj))
								{
									p.Show();
								}
							}
						}
						break;



				}

			}
			 /*MessageBox.Show(""+ mesh_rsult.VisualHit.GetName());
                    int lenList = pmodelcontrol.Robotlist.Count;
                   while (lenList-->0)
                    {
                      if(pmodelcontrol.Robotlist[lenList].ROBOTNAME== mesh_rsult.VisualHit.GetName())
                        {
                        
                            pmodelcontrol.selectedpresentRobot3D = pmodelcontrol.Robotlist[lenList];
                            flagselected = true;
                        }

                    
                    }*/
		}

		private void MainView3D_MouseMove(object sender, MouseEventArgs e)
		{
			Point mousedown = e.GetPosition(viewPort3d.GetViewport3D());
			// txt_moveMouseXY.Text = "MVXY: " + mousedown.X.ToString("0.00") + " " + mousedown.Y.ToString("0.00")+ " ";
			//  txt_moveMouse_pointY.Text ="MVY: "+ mousedown.Y.ToString("0.00");
			HitTestResult result = VisualTreeHelper.HitTest(viewPort3d.GetViewport3D(), mousedown);
			RayMeshGeometry3DHitTestResult mesh_rsult = result as RayMeshGeometry3DHitTestResult;
			try
			{
				txt_movePointer.Text = "X:" + GlobalVariables.ConvertUnitLengthtoMeter(mesh_rsult.PointHit.X).ToString("0.00") + " / Y:" + GlobalVariables.ConvertUnitLengthtoMeter(mesh_rsult.PointHit.Y).ToString("0.00");
			}
			catch { }
			if (mesh_rsult != null)
			{
				switch (statectrl_mousemove)
				{
					case STATECTRL_MOUSEMOVE.STATECTRL_MOVE_NORMAL:
						break;
					case STATECTRL_MOUSEMOVE.STATECTRL_MOVE_ESTIMATE:
						selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_ESTIMATE_GETPOINT2;
						selectModes(mesh_rsult);
						break;
					case STATECTRL_MOUSEMOVE.STATECTRL_MOVE_NAVIGATION:
						selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_NAVIGATION_GETPOINT2;
						selectModes(mesh_rsult);
						break;
					case STATECTRL_MOUSEMOVE.STATECTRL_MOVE_MEASUREMENT:
						selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_MEASURE_GETPOINT2;
						selectModes(mesh_rsult);
						break;
					case STATECTRL_MOUSEMOVE.STATECTRL_MOVE_PATHSTRATEGIC:
						//selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_PATHSTRATEGIC_GETPOINT2;
						//selectModes(mesh_rsult);
						break;
				}
			
			}
		}

		private void MainView3D_MouseWheel(object sender, MouseWheelEventArgs e)
		{

		}
		private void MainView3D_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
		{
			txt_moveMouse_scaleLength.Text = "Scale: " + (viewPort3d.Width / MainView3D.Camera.LookDirection.Length).ToString("0,00"); ;

			Console.WriteLine(MainView3D.CameraController.CameraPosition.X + " " + MainView3D.CameraController.CameraPosition.Y + " " + MainView3D.CameraController.CameraPosition.Z);
		}

		private void btn_estimatePos_Click(object sender, RoutedEventArgs e)
		{
			statectrl_mousedown = STATECTRL_MOUSEDOWN.STATECTRL_ESTIMATE_P1;
			//GlobalVariables.FLAG_ESTIMATE = true;
			/*if (pconnectrobot != null)
			{
				if (pconnectrobot.isconnected)
				{

					//  byte []cmd=CommandSet.CreateFrameCMD(10,CommandSet.CLIENT_REQUESTED_NAVIGATION_ESTIMPOS,lo,CommandSet.DATALENGTH_9,CommandSet.AMOUNTBYTE_3,CommandSet.DATATYPE_2);
					pconnectrobot.sendpackage(CommandSet.CommandPackage_Estimate(-10.2, -1.4, 0));
				}
			}*/
			//  selectedControlItems(GlobalVariables.SELECTED_CONTROL_ESTIMATE);
		}

		private void btn_measure_Click(object sender, RoutedEventArgs e)
		{
			statectrl_mousedown = STATECTRL_MOUSEDOWN.STATECTRL_MEASUREMENT_P1;
			//GlobalVariables.FLAG_MEASURE = true;
			//selectedControlItems(GlobalVariables.SELECTED_CONTROL_MEASURE);
		}

		private void btn_selectmap_Click(object sender, RoutedEventArgs e)
		{

			//selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_NORMAL;
			//selectModes(null);


			/*ModelVisual3D layer = new ModelVisual3D();
			CreatePallet temp = new CreatePallet();
			temp.updatePos(0, 0,3, 90);
			pPalletLayer.Children.Add(temp.contentlayer);*/

			//selectedControlItems(GlobalVariables.SELECTED_CONTROL_NORMAL);
			//MainView3D.Camera.LookDirection = new Vector3D(-178.740200965393, -214.488241158472, -178.740200965393);
			//OrthographicCamera myOCamera = new OrthographicCamera(new Point3D(0, 0, -1000), new Vector3D(0, 0, 100), new Vector3D(0, 1, 0), 3);
			//  MainView3D.Camera = myOCamera;
			///  MainView3D.Camera.Position = new System.Windows.Media.Media3D.Point3D(MainView3D.Camera.Position.X,MainView3D.Camera.Position.Y,50);

			//

			//MessageBox.Show("ddddddd");

		}
		private void theBorder_selectmap_MouseMove(object sender, MouseEventArgs e)
		{

		}

		private void btn_setting_MouseMove(object sender, MouseEventArgs e)
		{

		}
		Stack<Node> Path;
		public ConnectBridge pconnectrobot = null;
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			/*MessageBox.Show(System.IO.Directory.GetCurrentDirectory());
            MapNode p = new MapNode();
            Path = AStar.Find(p.matrix[10,10],p.matrix[1,1]);
            Point3DCollection pt = new Point3DCollection();
            PathFigureCollection pathnew = new PathFigureCollection();
            foreach(Node index in Path)
            {
                pt.Add(new Point3D(index.Position.X, index.Position.Y, 0));
            }
            LinesVisual3D pline = new LinesVisual3D();
            pline.Color = Colors.Red;
            pline.Thickness = 2;
            pline.Points = pt;
            MapLayer.Children.Add(pline);*/

			//  pconnect.getdata += getdata;




			/*
            LinesVisual3D pline = new LinesVisual3D();
            Point3DCollection points = new Point3DCollection();
            points.Add(new Point3D(GlobalVariables.ConvertMetertoUnitLength(11), GlobalVariables.ConvertMetertoUnitLength(2.53), 0));
            points.Add(new Point3D(GlobalVariables.ConvertMetertoUnitLength(11), GlobalVariables.ConvertMetertoUnitLength(-10), 0));
            pline.Points = points;
            pline.Color = Colors.Red;
            viewPort3d.Children.Add(pline);*/
			/*byte []data=CommandSet.CreateFrameCMD_Navigation(10,21,1234.5,4567.8);
            for(int i=0;i<data.Length;i++)
            {
                Console.Write(" "+data[i]);
            }
             Console.WriteLine(" ");*/

		}
		int Count = 0;
		void run()
		{
			while (true)
			{
				if (pconnectrobot != null)
				{
					pconnectrobot.sendpackage(CommandSet.CommandPackage(CommandSet.CLIENT_REQUESTED_CMD_NAVIGATION_AMCLPOS_INF,0,"robot"));
				}
				Thread.Sleep(300);
			}

		}
		private void getdata(String data)
		{
			Console.WriteLine(data);
			Dispatcher.Invoke((Action)(() =>
			{
				try
				{
					dynamic stuff = JObject.Parse(data);
					double posX = Convert.ToDouble(stuff.CurrentPos.X);
					double posY = Convert.ToDouble(stuff.CurrentPos.Y);
					double posThetaZ = Convert.ToDouble(stuff.CurrentPos.Z);
					double posThetaW = Convert.ToDouble(stuff.CurrentPos.W);
					double posTheta = 2 * Math.Atan2(posThetaZ, posThetaW);
					double batteryinfo = Convert.ToDouble(stuff.BatteryInfo);
					int workingtimes = stuff.ProcedureTimes;
					txt_moveMouseXY.Text = "Location: " + posX.ToString("0.00") + " / " + posY.ToString("0.00") + " ";
					txt_proceduretime.Text = "Procedure: " + workingtimes;
					txt_battery.Text = "Battery: " + batteryinfo.ToString("0.00") + "%";
					pmodelcontrol.Robotlist[0].updatePos(new Point3D(GlobalVariables.ConvertMetertoUnitLength(posX), GlobalVariables.ConvertMetertoUnitLength(posY), 0), posTheta * 180 / Math.PI);
				}
				catch { }
			}));
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{


		}

		private void btn_joystick_Click(object sender, RoutedEventArgs e)
		{
			Form1 pform = new Form1();
			pform.Show();
			pform.getdatagridview += getdatagridview;
		}

		private void btn_navigation_Click(object sender, RoutedEventArgs e)
		{
			statectrl_mousedown = STATECTRL_MOUSEDOWN.STATECTRL_NAVIGATION_P1;
			//GlobalVariables.FLAG_NAGVIGATION = true;
		}

		private void btn_connect_Click(object sender, RoutedEventArgs e)
		{
			if (pconnectrobot != null)
			{
				ControlTemplate ct = btn_connect.Template;
				Image btnImage = (Image)ct.FindName("btn_connect_image", btn_connect);
				btnImage.Source = new BitmapImage(new Uri("E:\\Seldat project 2017\\RobotSV_1922017\\RobotSV\\RobotSV\\RobotSV\\Media\\disconnect.png", UriKind.RelativeOrAbsolute));

				pconnectrobot.close();
				pconnectrobot = null;
				//  pconnectrobot.getdata -= getdata;
				//  pconnectrobot.connectionevent -= connectionevent;

			}
			else
			{
				ControlTemplate ct = btn_connect.Template;
				Image btnImage = (Image)ct.FindName("btn_connect_image", btn_connect);
				btnImage.Source = new BitmapImage(new Uri("E:\\Seldat project 2017\\RobotSV_1922017\\RobotSV\\RobotSV\\RobotSV\\Media\\connect.png", UriKind.RelativeOrAbsolute));
				if (pconnectrobot != null)
				{
					pconnectrobot = null;
				}
				pconnectrobot = new ConnectBridge();
				pconnectrobot.Connect();

				pconnectrobot.getdata += getdata;
				//  pconnectrobot.connectionevent += connectionevent;
			}
		}
		public void connectionevent(bool cnt)
		{
			if (!cnt)
			{
				ControlTemplate ct = btn_connect.Template;
				Image btnImage = (Image)ct.FindName("btn_connect_image", btn_connect);
				btnImage.Source = new BitmapImage(new Uri("E:\\Seldat project 2017\\RobotSV_1922017\\RobotSV\\RobotSV\\RobotSV\\Media\\disconnect.png", UriKind.RelativeOrAbsolute));

			}
			else
			{
				ControlTemplate ct = btn_connect.Template;
				Image btnImage = (Image)ct.FindName("btn_connect_image", btn_connect);
				btnImage.Source = new BitmapImage(new Uri("E:\\Seldat project 2017\\RobotSV_1922017\\RobotSV\\RobotSV\\RobotSV\\Media\\connect.png", UriKind.RelativeOrAbsolute));

			}
		}
		private void btn_toA_Click(object sender, RoutedEventArgs e)
		{
			/* PointsVisual3D pv = new PointsVisual3D();
			 Point3DCollection pc = new Point3DCollection();
			 LinesVisual3D path = new HelixToolkit.Wpf.LinesVisual3D();
			 path.Thickness = 5;
			 for (int i = 0; i < 100;i++ )
			 {
				 pc.Add(new Point3D(i,i*10.0,0));
			 }

			 pv.Color = Colors.Red;
			// pv.Points = path;
			 path.Points = pc;
			 MainView3D.Children.Add(path);

			 */
			//process();
			//GlobalVariables.PROCESS_FLAG = true;
			/*double[] lo = { -GlobalVariables.ConvertUnitLengthtoMeter(54.7209882741001), -GlobalVariables.ConvertUnitLengthtoMeter(55.7946101722127), 0 };
            ArrowVisual3D pnav = new ArrowVisual3D();
            pnav.Fill = new SolidColorBrush(Colors.Gold);
            pnav.Point1 = new Point3D(-54.7209882741001, -55.7946101722127, 0);
            pnav.Point2 = new Point3D(-54.7209882741001+10, -55.7946101722127, 0);
            pNavigationLayer.Children.Add(pnav);
            Console.WriteLine(lo[0] + " " + lo[1] + " " + lo[2]);
            if (pconnectrobot != null)
            {
                if (pconnectrobot.isconnected)
                {

                    byte[] cmd = CommandSet.CreateFrameCMD(10, CommandSet.CLIENT_REQUESTED_NAVIGATION_SETGOALPOS, lo, CommandSet.DATALENGTH_9, CommandSet.AMOUNTBYTE_3, CommandSet.DATATYPE_2);
                    pconnectrobot.sendpackage(cmd);
                }
            }*/
		}



		private void btn_C_Click(object sender, RoutedEventArgs e)
		{

			
		}

		private void btn_toCD_Click(object sender, RoutedEventArgs e)
		{
			if (pconnectrobot != null)
			{
				if (pconnectrobot.isconnected)
				{

					// byte[] cmd = CommandSet.CreateFrameCMD(10, CommandSet.CLIENT_REQUESTED_NAVIGATION_SETGOALPOS, lo, CommandSet.DATALENGTH_9, CommandSet.AMOUNTBYTE_3, CommandSet.DATATYPE_2);
					//pconnectrobot.sendpackage(Encoding.ASCII.GetBytes(CommandSet.JsonPallet()));
				}
			}
			/* double[] lo = { GlobalVariables.ConvertUnitLengthtoMeter(GlobalVariables.POINTB_X), GlobalVariables.ConvertUnitLengthtoMeter(GlobalVariables.POINTB_Y), GlobalVariables.POINTB_Theta };
			 ArrowVisual3D pnav = new ArrowVisual3D();
			 pnav.Fill = new SolidColorBrush(Colors.LightSeaGreen);
			 pnav.Point1 = new Point3D(GlobalVariables.POINTB_X, GlobalVariables.POINTB_Y, 0);
			 pnav.Point2 = new Point3D(GlobalVariables.POINTB_X + 50, GlobalVariables.POINTB_Y, 0);
			 pNavigationLayer.Children.Add(pnav);
			 Console.WriteLine(lo[0] + " " + lo[1] + " " + lo[2]);
			 if (pconnectrobot != null)
			 {
				 if (pconnectrobot.isconnected)
				 {

					// byte[] cmd = CommandSet.CreateFrameCMD(10, CommandSet.CLIENT_REQUESTED_NAVIGATION_SETGOALPOS, lo, CommandSet.DATALENGTH_9, CommandSet.AMOUNTBYTE_3, CommandSet.DATATYPE_2);
				   //  pconnectrobot.sendpackage(cmd);
				 }
			 }*/

		}

		private void btn_startline_Click(object sender, RoutedEventArgs e)
		{
			if (pconnectrobot != null)
			{
				if (pconnectrobot.isconnected)
				{
					double[] lo = { 0.0 };
					// byte[] cmd = CommandSet.CreateFrameCMD(10, CommandSet.CLIENT_REQUESTED_LINEDETECTION_RUN, lo, CommandSet.DATALENGTH_1, CommandSet.AMOUNTBYTE_1, CommandSet.DATATYPE_1);
					// pconnectrobot.sendpackage(cmd);
				}
			}
		}

		private void btn_stopline_Click(object sender, RoutedEventArgs e)
		{

			/*
            if (pconnectrobot != null)
            {
                if (pconnectrobot.isconnected)
                {
                    double[] lo = { 0.0 };
                   // byte[] cmd = CommandSet.CreateFrameCMD(10, CommandSet.CLIENT_REQUESTED_LINEDETECTION_STOP, lo, CommandSet.DATALENGTH_1, CommandSet.AMOUNTBYTE_1, CommandSet.DATATYPE_1);
                   // pconnectrobot.sendpackage(cmd);
                }
            }*/
		}
		void getdatagridview(System.Windows.Forms.DataGridView datagridview)
		{
			if (pconnectrobot != null)
			{
				pconnectrobot.sendpackage(CommandSet.PalletService("robot", 1306, datagridview));
			}
		}
		private void sendLocation(double[] pos, double angle)
		{
			double[] lo = { GlobalVariables.ConvertUnitLengthtoMeter(pos[0]), GlobalVariables.ConvertUnitLengthtoMeter(pos[1]), angle };
			/*ArrowVisual3D pnav = new ArrowVisual3D();
            pnav.Fill = new SolidColorBrush(Colors.Red);
            pnav.Point1 = new Point3D(pos[0], pos[1], 0);
            pnav.Point2 = new Point3D(pos[0] + 50, pos[1], 0);
            pNavigationLayer.Children.Add(pnav);*/
			if (pconnectrobot != null)
			{
				if (pconnectrobot.isconnected)
				{

					// byte[] cmd = CommandSet.CreateFrameCMD(10, CommandSet.CLIENT_REQUESTED_NAVIGATION_SETGOALPOS, lo, CommandSet.DATALENGTH_9, CommandSet.AMOUNTBYTE_3, CommandSet.DATATYPE_2);
					//   pconnectrobot.sendpackage(cmd);
				}
			}

		}

		private void process()
		{
			switch (GlobalVariables.PROCESS_ROBOT)
			{
				case GlobalVariables.PROCESS_START_READY:
					Console.WriteLine("PROCESS_START_DETECTLINE_UP");
					GlobalVariables.PROCESS_ROBOT = GlobalVariables.PROCESS_START_GOTO_A_POINT;
					break;
				case GlobalVariables.PROCESS_START_GOTO_A_POINT:
					Console.WriteLine(".PROCESS_START_GOTO_A_POINT");
					double[] loA = { GlobalVariables.POINTA_X, GlobalVariables.POINTA_Y };
					sendLocation(loA, GlobalVariables.POINTA_Theta);
					GlobalVariables.PROCESS_ROBOT = GlobalVariables.PROCESS_WAIT_GOTO_A_POINT;
					Console.WriteLine("PROCESS_WAIT_GOTO_A_POINT");
					break;
				case GlobalVariables.PROCESS_WAIT_GOTO_A_POINT:
					//Console.WriteLine("PROCESS_WAIT_GOTO_A_POINT");
					// waiting 
					break;
				case GlobalVariables.PROCESS_FINISHED_GOTO_A_POINT:
					Console.WriteLine("PROCESS_FINISHED_GOTO_A_POINT");

					//select
					if (!GlobalVariables.PROCESS_FLAG_PALLET)
						GlobalVariables.PROCESS_ROBOT = GlobalVariables.PROCESS_START_DETECTLINE_UP;
					else
						GlobalVariables.PROCESS_ROBOT = GlobalVariables.PROCESS_START_DETECTLINE_DOWN;
					break;
				case GlobalVariables.PROCESS_START_DETECTLINE_UP:
					Console.WriteLine("PROCESS_START_DETECTLINE_UP");
					GlobalVariables.PROCESS_FLAG_PALLET = true;
					if (pconnectrobot != null)
					{
						if (pconnectrobot.isconnected)
						{
							double[] lo1 = { 0.0 };
							//    byte[] cmd = CommandSet.CreateFrameCMD(10, CommandSet.CLIENT_REQUESTED_LINEDETECTION_UPPALLET, lo1, CommandSet.DATALENGTH_1, CommandSet.AMOUNTBYTE_1, CommandSet.DATATYPE_1);
							// pconnectrobot.sendpackage(cmd);
						}
					}
					GlobalVariables.PROCESS_ROBOT = GlobalVariables.PROCESS_WAIT_DETECTLINE_UP;
					Console.WriteLine("PROCESS_WAIT_DETECTLINE_UP");

					break;
				case GlobalVariables.PROCESS_WAIT_DETECTLINE_UP:
					//
					// waiting 
					break;
				case GlobalVariables.PROCESS_END_DETECTLINE_UP:
					Console.WriteLine("PROCESS_END_DETECTLINE_UP");
					GlobalVariables.PROCESS_ROBOT = GlobalVariables.PROCESS_START_GOTO_B_POINT;
					break;
				case GlobalVariables.PROCESS_START_GOTO_B_POINT:
					Console.WriteLine("PROCESS_START_GOTO_B_POINT");
					double[] loB = { GlobalVariables.POINTB_X, GlobalVariables.POINTB_Y };
					sendLocation(loB, GlobalVariables.POINTB_Theta);
					GlobalVariables.PROCESS_ROBOT = GlobalVariables.PROCESS_WAIT_GOTO_B_POINT;
					Console.WriteLine("PROCESS_WAIT_GOTO_B_POINT");
					break;
				case GlobalVariables.PROCESS_WAIT_GOTO_B_POINT:

					// waiting 
					break;
				case GlobalVariables.PROCESS_FINISHED_GOTO_B_POINT:
					Console.WriteLine("PROCESS_FINISHED_GOTO_B_POINT");
					GlobalVariables.PROCESS_ROBOT = GlobalVariables.PROCESS_START_GOTO_A_POINT;
					break;
				case GlobalVariables.PROCESS_START_DETECTLINE_DOWN:
					Console.WriteLine("PROCESS_START_DETECTLINE_DOWN");
					GlobalVariables.PROCESS_FLAG_PALLET = false;
					if (pconnectrobot != null)
					{
						if (pconnectrobot.isconnected)
						{
							double[] lo1 = { 0.0 };
							// byte[] cmd = CommandSet.CreateFrameCMD(10, CommandSet.CLIENT_REQUESTED_LINEDETECTION_DOWNPALLET, lo1, CommandSet.DATALENGTH_1, CommandSet.AMOUNTBYTE_1, CommandSet.DATATYPE_1);
							// pconnectrobot.sendpackage(cmd);
						}
					}
					GlobalVariables.PROCESS_ROBOT = GlobalVariables.PROCESS_WAIT_DETECTLINE_DOWN;
					Console.WriteLine("PROCESS_WAIT_DETECTLINE_DOWN");
					break;
				case GlobalVariables.PROCESS_WAIT_DETECTLINE_DOWN:

					// waiting 
					break;
				case GlobalVariables.PROCESS_END_DETECTLINE_DOWN:
					Console.WriteLine("PROCESS_END_DETECTLINE_DOWN");
					GlobalVariables.PROCESS_ROBOT = GlobalVariables.PROCESS_START_GOTO_B_POINT;
					break;
			}
		}
		bool flag_3dmode = false;
		/*public void settingrobot23d(int robotindex, int zaxis)
		{

			// Robotlist[robotindex].updateheadingdirection(angle);
			try
			{
				if (zaxis == 0)
				{
					robotagent.robotInfo.robot3DModel.ScaledRobot(GlobalVariables.ROBOT_SCALED, GlobalVariables.ROBOT_SCALED, 0);
				}
				else if (zaxis == 1)
				{
					robotagent.robotInfo.robot3DModel.ScaledRobot(GlobalVariables.ROBOT_SCALED, GlobalVariables.ROBOT_SCALED, GlobalVariables.ROBOT_SCALED);
				}
			}
			catch
			{ }
		}*/
		private void btn_32dclick(object sender, RoutedEventArgs e)
		{

		/*
			if (!flag_3dmode)
			{
				//MainView3D.IsRotationEnabled = true;
				settingrobot23d(0, 1);

				// MainView3D.DefaultCamera = new PerspectiveCamera();
				//MainView3D.DefaultCamera.Position = new Point3D(0, 0, 10);//1000

			}
			else
			{
				settingrobot23d(0, 0);
				//   MainView3D.IsRotationEnabled = false;
			}
			flag_3dmode = !flag_3dmode;*/
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			if (p == null)
			{
				p = new Thread(run);
				p.Start();
			}
		}

		private void Button_Click_3(object sender, RoutedEventArgs e)
		{
		}

		private void MainView3D_Loaded(object sender, RoutedEventArgs e)
		{

		}

		private void btn_zoom_Click(object sender, RoutedEventArgs e)
		{
			/*	CreateRobotPathPlan pathplan = new CreateRobotPathPlan();
				pathplan.straightPathPlan(new System.Windows.Point(-10.9, -1.8), new System.Windows.Point(4.60036, -1.75073));
				pathplan.CurvePathPlan(new System.Windows.Point(-10.9, -1.8),1.57, new System.Windows.Point(-8.7, 0.25));

				for (int i = 0; i < pathplan.CoordinationXY_straigthplan.Count; i++)
				{

					PointsVisual3D pp = new PointsVisual3D();
					pp.Points.Add(new Point3D(GlobalVariables.ConvertMetertoUnitLength(pathplan.CoordinationXY_straigthplan[i].X), GlobalVariables.ConvertMetertoUnitLength(pathplan.CoordinationXY_straigthplan[i].Y), 0));
					pp.Color = Colors.Yellow;
					pp.Size = 3;
					pPathFinderLayer.Children.Add(pp);
				}
				for (int i = 0; i < pathplan.CoordinationXY_curveplan.Count; i++)
				{

					PointsVisual3D pp = new PointsVisual3D();
					pp.Points.Add(new Point3D(GlobalVariables.ConvertMetertoUnitLength(pathplan.CoordinationXY_curveplan[i].X), GlobalVariables.ConvertMetertoUnitLength(pathplan.CoordinationXY_curveplan[i].Y), 0));
					pp.Color = Colors.Yellow;
					pp.Size = 3;
					pPathFinderLayer.Children.Add(pp);
				}*/
			MainView3D.ZoomExtents(10);
		}

		private void Btn_resetpallet_Click(object sender, RoutedEventArgs e)
		{
			//pmodelcontrol.createpalletobj(pPalletLayer);
			saveImage();
		}

		private void btn_sel_LINE_Click(object sender, RoutedEventArgs e)
		{
			statectrl_mousedown = STATECTRL_MOUSEDOWN.STATECTRL_PATHSTRATEGIC_LINE_P1;
		}

		private void btn_sel_curveline_Click(object sender, RoutedEventArgs e)
		{
			selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_PATHSTRATEGIC_CURVE_OPENFORMSETTING;
			selectModes(null);
		}

		void InsertPointLoaded(System.Windows.Point sp, System.Windows.Point ed, SELECTEDCONTROL mode)
		{
			selectedctrlmode = mode;
			selectModes(null);
		}

		private void btn_sel_line_Click_1(object sender, RoutedEventArgs e)
		{
			selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_PATHSTRATEGIC_LINE_OPENFORMSETTING;
			selectModes(null);
		}
		private void saveImage()
		{
			System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{

				FileStream fs = new FileStream("E:\\MyTest.tif", FileMode.Create);
				RenderTargetBitmap bmp = new RenderTargetBitmap((int)MainView3D.ActualWidth, (int)MainView3D.ActualHeight, 1 / 96, 1 / 96, PixelFormats.Pbgra32);
				bmp.Render(MainView3D);
				BitmapEncoder encoder = new TiffBitmapEncoder();
				encoder.Frames.Add(BitmapFrame.Create(bmp));
				encoder.Save(fs);
				fs.Close();
			
			}
					
		}

		private void btn_savedpath_Click(object sender, RoutedEventArgs e)
		{
			ExportPaths.savedata(setCurveParamsList, setLineParamsList);
		}

		private void btn_loadpaths_Click(object sender, RoutedEventArgs e)
		{
				if (importPaths != null)
				{
					importPaths = null;
				}

				importPaths = new ImportPaths();
				
				importPaths.importLines += importLines;
				importPaths.importCurves += importCurve;
				if (importPaths.loadFileModel())
				{
					setLineParamsList.Clear();
					setCurveParamsList.Clear();
					importPaths.loadPathSystem();
				}

		}
		private void importLines(SetLineParams _plineinfo)
		{
			pPathSetting.Children.Clear();

			if (plineinfo != null)
				plineinfo = null;
			plineinfo = _plineinfo;
			selectedctrlmode =SELECTEDCONTROL.SELECTED_CONTROL_PATHSTRATEGIC_LINE_SETTING_APPLIED;
			selectModes(null);
		}
		private void importCurve(SetCurveParams _pcurinfo)
		{

			if (pcurinfo != null)
				pcurinfo = _pcurinfo;
			pcurinfo = _pcurinfo;
			selectedctrlmode = SELECTEDCONTROL.SELECTED_CONTROL_PATHSTRATEGIC_CURVE_SETTING_APPLIED;
			selectModes(null);
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (pconnectrobot != null)
				pconnectrobot.close();
		}

		private void btn_editpaths_Click(object sender, RoutedEventArgs e)
		{
			statectrl_mousedown = STATECTRL_MOUSEDOWN.STATECTRL_PATHSTRATEGIC_EDITTING;
		}

		private void btn_grouppaths_Click(object sender, RoutedEventArgs e)
		{
			GroupPaths grouppath = new GroupPaths();
			grouppath.Show();
		}
	}
}
