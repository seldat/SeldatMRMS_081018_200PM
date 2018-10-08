using System;
using System.Collections.Generic;
using System.IO;

namespace SeldatMRMS.RobotView
{
    public class Position
	{
		public double X;
		public double Y;
		public double Z;
		public double W;
	}
	public class StraigthLocation
	{

		public System.Windows.Point startpoint;
		public System.Windows.Point endpoint;
		public double dir;
		public StraigthLocation() { }

	}
	public class CurveLocation
	{
		public CurveLocation() { }
		public System.Windows.Point startpoint;
		public System.Windows.Point endpoint;
		public CurveParams param;
	}

	class CreateRobotPathPlan
	{
		public List<Position> CoordinationXY_lineplan = new List<Position>();
		public List<Position> Orientations_lineplan = new List<Position>();

		public List<Position> CoordinationXY_curveplan = new List<Position>();
		public List<Position> Orientations_curveplan = new List<Position>();
		public StraigthLocation pStraigthLocation = new StraigthLocation();
		public CurveLocation pCurveLocation = new CurveLocation();

		public double unitdistance_straight = 1; // 1dm
		public CreateRobotPathPlan() { }
		public void linePathPlan(LineParams lineParams)
		{
			unitdistance_straight = lineParams.unitstep;
			pStraigthLocation.startpoint = lineParams.startpoint;
			pStraigthLocation.endpoint = lineParams.endpoint;

			double pointA_X = lineParams.endpoint.X;
			double pointA_Y = lineParams.endpoint.Y;
			double currentX = lineParams.startpoint.X;
			double currentY = lineParams.startpoint.Y;

			double th = 0;
			double x_vec = 0.0;
			double y_vec = 0.0;
			th = Math.Atan2((pointA_Y - currentY), (pointA_X - currentX));
			if (th > Math.PI)
				th = th - 2 * Math.PI;
			else if (th < -Math.PI)
				th = th + 2 * Math.PI;
			double x = 0.0, y = 0.0, z = 0.0, w = 0.0;
			z = Math.Sin(th / 2);
			w = Math.Cos(th / 2);
			CoordinationXY_lineplan.Add(new Position() { X = currentX, Y = currentY, Z = z, W = w });
			while (Math.Abs(currentX - pointA_X) >= 1 || Math.Abs(currentY - pointA_Y) >= 1)
			{

				x_vec = unitdistance_straight * Math.Cos(th);
				y_vec = unitdistance_straight * Math.Sin(th);

				x = currentX + x_vec;
				y = currentY + y_vec;
				z = Math.Sin(th / 2);
				w = Math.Cos(th / 2);

				CoordinationXY_lineplan.Add(new Position() { X = x, Y = y, Z = z, W = w });
				currentX = currentX + x_vec;
				currentY = currentY + y_vec;
			}

			x = pointA_X;
			y = pointA_Y;
			z =  Math.Sin(lineParams.enddir/2);
			w = Math.Cos(lineParams.enddir/2);

			CoordinationXY_lineplan.Add(new Position() { X = x, Y = y, Z = z, W = w });


		}


		public void saveStraigthLine()
		{
			System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				using (StreamWriter sw = File.CreateText(System.IO.Path.GetFullPath(saveFileDialog.FileName)))
				{
					sw.WriteLine("// X, Y, Z, W");
					for (int i = 0; i < CoordinationXY_lineplan.Count; i++)
					{
						String text = "{";
						text += CoordinationXY_lineplan[i].X / 10.0 + ""; // 10 : cm to m
						text += "," + CoordinationXY_lineplan[i].Y / 10.0;
						text += "," + CoordinationXY_lineplan[i].Z;
						text += "," + CoordinationXY_lineplan[i].W;
						text += "},";
						sw.WriteLine(text);
					}
				}

			}
		}

		public String TextLine()
		{
			String text = "";
			for (int i = 0; i < CoordinationXY_lineplan.Count; i++)
			{
				text += "{";
				text += CoordinationXY_lineplan[i].X / 10.0 + ""; // 10 : cm to m
				text += "," + CoordinationXY_lineplan[i].Y / 10.0;
				text += "," + CoordinationXY_lineplan[i].Z;
				text += "," + CoordinationXY_lineplan[i].W;
				text += "},\n";
			}
			return text;
		}
		public void saveCurveLine()
		{

			System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				using (StreamWriter sw = File.CreateText(System.IO.Path.GetFullPath(saveFileDialog.FileName)))
				{

					sw.WriteLine("// X, Y, Z, W");
					for (int i = 0; i < CoordinationXY_curveplan.Count; i++)
					{
						String text = "{";
						text += CoordinationXY_curveplan[i].X / 10.0 + ""; // 10 : cm to m
						text += "," + CoordinationXY_curveplan[i].Y / 10.0;
						text += "," + CoordinationXY_curveplan[i].Z;
						text += "," + CoordinationXY_curveplan[i].W;
						text += "},";
						sw.WriteLine(text);
					}
				}

			}
		}
		public String TextCurveLine()
		{
			String text = "";
			for (int i = 0; i < CoordinationXY_curveplan.Count; i++)
			{
				text += "{";
				text += CoordinationXY_curveplan[i].X / 10.0 + ""; // 10 : cm to m
				text += "," + CoordinationXY_curveplan[i].Y / 10.0;
				text += "," + CoordinationXY_curveplan[i].Z;
				text += "," + CoordinationXY_curveplan[i].W;
				text += "},\n";
			}
			return text;
		}
		public void CurvePathPlan(CurveParams param)
		{
			pCurveLocation.startpoint = param.startpoint;
			pCurveLocation.endpoint = param.endpoint;

			pCurveLocation.param = param;

			double unitdistance_curve = param.dv;
			double unitdistance_rot = param.dw;
			double pointA_X = param.endpoint.X;
			double pointA_Y = param.endpoint.Y;
			//double pointA_X =15;
			//double pointA_Y = 15;
			double th = 0;
			double x_vec = 0.0;
			double y_vec = 0.0;

			int i = 0;

			double currentX = param.startpoint.X;
			double currentY = param.startpoint.Y;
			//double currentX =0;
			//double currentY =0;
			double currentTh = param.startdir;
			double x = 0.0, y = 0.0, z = 0.0, w = 0.0;
			int count = 0;

			while (Math.Abs(currentX - pointA_X) >= 3 || Math.Abs(currentY - pointA_Y) >= 3)
			{
				if (count++ > 100)
					break;
				//Console.WriteLine(""+ currentX+ " / " + currentY+ " / "+ currentTh + " coS(0.1) = " + Math.Cos(0.1));
				x_vec = unitdistance_curve * Math.Cos(currentTh + unitdistance_rot * 0.5);
				y_vec = unitdistance_curve * Math.Sin(currentTh + unitdistance_rot * 0.5);
				th = Math.Atan2(y_vec, x_vec);

				if (th > Math.PI)
					th = th - 2 * Math.PI;
				else if (th < -Math.PI)
					th = th + 2 * Math.PI;

				x = currentX + x_vec;
				y = currentY + y_vec;
				z = Math.Sin(th / 2);
				w = Math.Cos(th / 2);

				CoordinationXY_curveplan.Add(new Position() { X = x, Y = y, Z = z, W = w });
				i++;

				currentX = x;
				currentY = y;
				currentTh = currentTh + unitdistance_rot;

			}

			CoordinationXY_curveplan.Add(new Position() { X = pointA_X, Y = pointA_Y, Z =  Math.Sin(param.enddir/2), W = Math.Cos(param.enddir/2) });
		}
	}
}
