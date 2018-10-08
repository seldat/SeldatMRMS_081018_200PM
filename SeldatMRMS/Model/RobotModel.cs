using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SeldatMRMS.Model
{
    public class RobotModel
    {
        public struct Properties
        {
            public Point location;
            public BitmapImage bmp;
			public System.Windows.Controls.Image img;
			public String name;
		}
		public Properties properties;
		MainWindow content;
		public RobotModel(MainWindow content)
        {
			this.content = content;
			//properties.img = new System.Windows.Controls.Image();
			//String m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			//properties.bmp = new BitmapImage(new Uri(m_exePath + "//Resources//robotstore.png"));
			//properties.img.Source = this.properties.bmp;
			//properties.img.Name = "RobotStore";
			//properties.name = "RobotStore";
			//setStation(50,50);
		}
		public void setStation(double x, double y)
		{

			properties.location.X = x;
			properties.location.Y = y;
			properties.img.Width = 50;
			properties.img.Height = 50;
			properties.img.SetValue(Canvas.LeftProperty, x);
			properties.img.SetValue(Canvas.TopProperty, y);
			TranslateTransform ptrans = new TranslateTransform();
			ptrans.X = -25;
			ptrans.Y = -25;
			properties.img.RenderTransform = ptrans;
			this.content.map.Children.Add(properties.img);


		}

        public void setPos(double x, double y)
        {

        }

		public void setnewpos(double x, double y)
		{
			properties.location.X = x;
			properties.location.Y = y;
			properties.img.Width = 50;
			properties.img.Height = 50;
			properties.img.SetValue(Canvas.LeftProperty, x);
			properties.img.SetValue(Canvas.TopProperty, y);
			TranslateTransform ptrans = new TranslateTransform();
			ptrans.X = -25;
			ptrans.Y = -25;
			properties.img.RenderTransform = ptrans;
		}
	}
}
