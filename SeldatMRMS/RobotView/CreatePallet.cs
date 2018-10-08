using HelixToolkit.Wpf;
using System;
using System.Windows;
using System.Windows.Media.Media3D;

namespace SeldatMRMS.RobotView
{
    class CreatePallet
	{
		public double Sx, Sy, Sz;
		public double m_Heading;
		public Model3D device = null;
		public ModelVisual3D device3D;
		public ModelVisual3D contentlayer;

		public CreatePallet()
		{
			device3D = new ModelVisual3D();
			device3D.Content = Display3d();
			contentlayer = new ModelVisual3D(); ;
		}
		public Point3D Location { get; set; }
		public double X
		{
			get { return this.Location.X; }
			set { this.Location = new Point3D(value, this.Y, this.Z); }
		}
		public double Y
		{
			get { return this.Location.Y; }
			set { this.Location = new Point3D(this.X, value, this.Z); }

		}
		public double Z
		{
			get { return this.Location.Z; }
			set { this.Location = new Point3D(this.X, this.Y, value); }

		}
		public void ScaledRobot(double x, double y, double z)
		{
			if (device != null)
			{
				var group = device as Model3DGroup;

				foreach (var el in group.Children)
				{
					var t = el as GeometryModel3D;
					t.Transform = new ScaleTransform3D(x, y, z);
				}
			}
		}
		int count_add = 0;
		public void updatePos(double x, double y, double z, double _angle)
		{
			//  contentlayer.Children.Remove(device3D);
			m_Heading = _angle;

			Transform3DGroup transforms = new Transform3DGroup();
			RotateTransform3D protate = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 0, 1), m_Heading));
			transforms.Children.Add(protate);
			device3D.Transform = transforms;

			this.Location = new Point3D(x, y, z);
			var matrix = device3D.Transform.Value;
			matrix.OffsetX = X;
			matrix.OffsetZ = Z;
			matrix.OffsetY = Y;
			device3D.Transform = new MatrixTransform3D(matrix);
			if (count_add== 0)
			{
				contentlayer.Children.Add(device3D);
				count_add++;
			}

		}
		private Model3D Display3d()
		{
			try
			{
				ModelImporter import = new ModelImporter();
				device = import.Load("C:\\Users\\luat.tran\\source\\repos\\SeldatMRMS\\SeldatMRMS\\RobotView\\Media\\pallet6.stl");
				device.SetName("robot");
				// get real size of robot
				Sx = device.Bounds.SizeX; // mm to m
				Sy = device.Bounds.SizeY;
				Sz = device.Bounds.SizeZ;
				ScaledRobot(GlobalVariables.ROBOT_SCALED, GlobalVariables.ROBOT_SCALED, 0.1);
			}
			catch (Exception e)
			{
				// Handle exception in case can not file 3D model
				MessageBox.Show("Exception Error : " + e.StackTrace);
			}
			return device;
		}
	}
}
