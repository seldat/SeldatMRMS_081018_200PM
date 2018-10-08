using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SeldatMRMS.Model
{
    public class HalfPoint
    {

        public enum FLAGPOINTDEFINED
        {
            FLAGPOINT_SET_STARTPOINT,
            FLAGPOINT_SET_ENDPOINT
        }
		public struct Properties
		{
			public double X, Y;
			public double X_model, Y_model;
			public double LengthValue, CostValue;
			public double Width, Height;
			public String label;
			public String NameObj, NameEllipse;
			public int idnum;
		}
        public FLAGPOINTDEFINED flagpointdefines;
		public Properties properties;
		public TextBlock plabel;
        private Rectangle pellipse;
        private Canvas content;
        private List<PathModel> connectedPath_head;
        private List<FLAGPOINTDEFINED> flag_headtail;

        public HalfPoint(Canvas content)
        {
            pellipse = new Rectangle();
            this.content = content;
            connectedPath_head = new List<PathModel>();
			flag_headtail = new List<FLAGPOINTDEFINED>();
		

		}
        public Object pointer()
        {
            return this;
        }
        public void sethalfpoint(double w, double h, double posx, double posy, Color cc)
        {	
            pellipse.Width = w;
            pellipse.Height = h;
			properties.Width = w;
			properties.Height = h;
            pellipse.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF0F0F0"));
			pellipse.Stroke = new SolidColorBrush(Colors.Black);
            setPos(posx, posy);
            content.Children.Add(pellipse);
        }
        public void Getpath(PathModel pathmodel,FLAGPOINTDEFINED fp)
        {
            if (pathmodel != null)
            {
                connectedPath_head.Add(pathmodel);
				flag_headtail.Add(fp);
            }
        }
		// Add traffic law to halfpoint

		

		public void updatePathfromNewPosition()
        {
            if (connectedPath_head.Count > 0)
            {
                for (int index = 0; index < connectedPath_head.Count; index++)
                {
					if (connectedPath_head[index] != null)
					{
						if (flag_headtail[index] == FLAGPOINTDEFINED.FLAGPOINT_SET_STARTPOINT)
						{
							if (connectedPath_head[index].properties.PathType== PathModel.PATH_TYPE_DIRECT)
							{
								connectedPath_head[index].drawdirectpath(new System.Windows.Point(properties.X, properties.Y), connectedPath_head[index].endpos);
							}
							else if (connectedPath_head[index].properties.PathType == PathModel.PATH_TYPE_BEZIERSEGMENT)
							{
								connectedPath_head[index].drawbezierpath(new System.Windows.Point(properties.X, properties.Y), connectedPath_head[index].middlepos, connectedPath_head[index].endpos);
							}
							else if (connectedPath_head[index].properties.PathType == PathModel.PATH_TYPE_LINK)
							{
								connectedPath_head[index].drawdirectpath(new System.Windows.Point(properties.X, properties.Y), connectedPath_head[index].endpos);
							}
						}
						if (flag_headtail[index] == FLAGPOINTDEFINED.FLAGPOINT_SET_ENDPOINT)
						{
							if (connectedPath_head[index].properties.PathType == PathModel.PATH_TYPE_DIRECT)
							{
								connectedPath_head[index].drawdirectpath(connectedPath_head[index].startpos, new System.Windows.Point(properties.X, properties.Y));
							}
							else if (connectedPath_head[index].properties.PathType == PathModel.PATH_TYPE_BEZIERSEGMENT)
							{
								connectedPath_head[index].drawbezierpath(connectedPath_head[index].startpos, connectedPath_head[index].middlepos, new System.Windows.Point(properties.X, properties.Y));
							}
							else if (connectedPath_head[index].properties.PathType == PathModel.PATH_TYPE_LINK)
							{
								connectedPath_head[index].drawdirectpath(connectedPath_head[index].startpos, new System.Windows.Point(properties.X, properties.Y));
							}
						}
					}

                }
            }

        }
        public double gethalfpointWidth()
        {
            return pellipse.Width;
        }
        public double gethalfpointHeigth()
        {
            return pellipse.Width;
        }
        public Canvas getCanavasContent()
        {
            return content;
        }
        public void setTextlabel(String label)
        {
			properties.label = label;
			if (plabel != null)
			{
				this.content.Children.Remove(plabel);
				plabel = null;
			}
			
			plabel = new TextBlock();
			plabel.Text = label;
			plabel.Width = 100;
			plabel.Background = new SolidColorBrush(Colors.Pink);
			plabel.SetValue(Canvas.LeftProperty, properties.X);
			plabel.SetValue(Canvas.TopProperty, properties.Y - 30);
			TranslateTransform ptrans = new TranslateTransform();
			ptrans.X = -plabel.Width/2;
			ptrans.Y = -10;
			plabel.RenderTransform = ptrans;

		
			plabel.TextAlignment= TextAlignment.Center;
			this.content.Children.Add(plabel);
        }
		public void setid(int id)
		{
			properties.idnum = id;
		}
        public void setName(String name)
        {
			properties.NameObj = name;
            pellipse.Name = name;
        }
		public void setcolor(Color pc)
		{
			pellipse.Fill = new SolidColorBrush(pc);
		}
        public bool FindName(String name)
        {
            if (name.Equals(properties.NameObj))
                return true;
            else
                return false;
        }
        public void setPos(double x, double y)
        {
			properties.X = x;
			properties.Y = y;
            pellipse.SetValue(Canvas.LeftProperty, properties.X);
            pellipse.SetValue(Canvas.TopProperty, properties.Y);
			TranslateTransform ptrans = new TranslateTransform();
			ptrans.X = -10;
			ptrans.Y = -10;
			pellipse.RenderTransform = ptrans;
			setTextlabel(properties.label);
		}
		public void removeobject()
		{
			if (pellipse != null)
			{
				this.content.Children.Remove(pellipse);
				this.content.Children.Remove(plabel);
				if (connectedPath_head.Count > 0)
				{
					for (int i = 0; i < connectedPath_head.Count; i++)
					{

						connectedPath_head[i].remove();
					}
				}
			}
		
		}
        public void remove()
        {
            if (pellipse != null)
            {
                this.content.Children.Remove(pellipse);
				this.content.Children.Remove(plabel);
			}
        }
		public JObject createJsonstring()
		{
			dynamic product = new JObject();
			product.Name = properties.NameObj;
			product.Label = properties.label;
			product.Width = properties.Width;
			product.Height = properties.Height;
			product.posX= properties.X;
			product.posY = properties.Y;
			return product;		
		}
    }
}
