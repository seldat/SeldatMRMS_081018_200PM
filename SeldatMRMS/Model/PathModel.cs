/*
	http://longxue-canada.blogspot.com/2010/07/drawing-line-with-arrow-in-silverlight.html
	draw arrow
 */
using Newtonsoft.Json.Linq;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;


namespace SeldatMRMS.Model
{

    public class PathModel
    {
		public struct Properties
		{
			public String Nameobj;
			public String roadName;
			public int PathType;
		}
		public enum NODECONNECTED
		{
			FRONTNODE_CONNECTED_HALFPOINT,
			BACKNODE_CONNECTED_HALFPOINT,
			FRONTNODE_CONNECTED_STATION,
			BACKNODE_CONNECTED_STATION
		}

		Canvas content;
        public const int PATH_TYPE_DIRECT = 20000;
        public const int PATH_TYPE_BEZIERSEGMENT = 20001;
        public const int PATH_TYPE_LINK = 20002;
		public const int STREET1 = 5000;
		public const int STREET2 = 5001;
		public const int STREET3 = 5002;
		public const int STREET4 = 5003;

        public Path parrow;
        public System.Windows.Point startpos;
        public System.Windows.Point middlepos;
        public System.Windows.Point endpos;

		public CheckInPoint checkInPoint;
		public CheckOutPoint checkOutPoint;

		public TextBlock plabel = new TextBlock();

		/// <summary>
		///  Add connect from HalfPoit or Station
		/// </summary>
		/// 
		public struct NodeConnected
		{
			public HalfPoint startpoint;
			public HalfPoint endpoint;
			public StationModel startpoint_station;
			public StationModel endpoint_station;
			public NODECONNECTED frontNodeConnected;
			public NODECONNECTED backNodeConnected;

		}

		public NodeConnected nodeConnected;
		//public bool flag_endpoint_station = false;
		//public bool flag_startpoint_station = false;

		Ellipse pelS = new Ellipse();
		Ellipse pelE = new Ellipse();
		public Properties properties;
		System.Windows.Shapes.Line _Line = new System.Windows.Shapes.Line();
		System.Windows.Shapes.Line Head = new System.Windows.Shapes.Line();

		public PathModel(Canvas content,int PathType)
        {
            this.content = content;
            parrow = new Path();
			properties.PathType = PathType;
			_Line = new System.Windows.Shapes.Line();
			Head = new System.Windows.Shapes.Line();

		}
	
		public bool FindName(String name)
		{
			if (name.Equals(properties.roadName))
				return true;
			else
				return false;
		}
		public void setcolor(System.Windows.Media.Color pc)
		{
			parrow.Stroke = new SolidColorBrush(pc);
		}
		public void setName(String name)
        {
			properties.roadName = name;
            parrow.Name =name;
			plabel.Text = properties.roadName;
		}
	
		public void removeHighWaytoEndPoint(String roadname)
		{
			//endpoint.reomoveTrafficHalfPoint(roadname);
		}
		private void DrawArrow(System.Windows.Point StartPoint, System.Windows.Point EndPoint, System.Windows.Media.Color myColor)
		{
			_Line.X1 = StartPoint.X;
			_Line.Y1 = StartPoint.Y;
			_Line.X2 = EndPoint.X;
			_Line.Y2 = EndPoint.Y;
			_Line.StrokeThickness = 1;
			_Line.Stroke = new SolidColorBrush(myColor);
			if (EndPoint.X == StartPoint.X)
			{
				if (EndPoint.Y > StartPoint.Y)
				{
					Head.Y1 = EndPoint.Y - 1;
					Head.Y2 = EndPoint.Y;
				}
				else
				{
					Head.Y1 = EndPoint.Y + 1;
					Head.Y2 = EndPoint.Y;
				}
				Head.X1 = Head.X2 = EndPoint.X;
			}
			else
			{
				Int32 d;
				if (EndPoint.X > StartPoint.X)
				{
					Head.X1 = EndPoint.X - 1;
					Head.X2 = EndPoint.X;
					d = 10;
				}
				else
				{
					Head.X1 = EndPoint.X + 1;
					Head.X2 = EndPoint.X;
					d = -10;
				}
				Head.Y1 = getArrowYByX(d, StartPoint, EndPoint);
				Head.Y2 = EndPoint.Y;
			}

			Head.StrokeEndLineCap = PenLineCap.Triangle;
			Head.StrokeThickness = 5;
			Head.Stroke = new SolidColorBrush(myColor);
		}
		double getArrowYByX(double d, System.Windows.Point pStart, System.Windows.Point pEnd)
		{
			return pStart.Y + (pEnd.X - pStart.X - d) * (pEnd.Y - pStart.Y) / (pEnd.X - pStart.X);
		}
		public void drawdirectpath(System.Windows.Point sp, System.Windows.Point ep)
        {
            this.startpos = sp;
            this.endpos = ep;
			ep = relativePoint(ep);
			TranslateTransform ptrans = new TranslateTransform();
			ptrans.X = -3;
			ptrans.Y = -3;
			pelS.Fill = new SolidColorBrush(Colors.Red);
			pelS.Width = 6;
			pelS.Height = 6;
			pelS.SetValue(Canvas.LeftProperty, sp.X);
			pelS.SetValue(Canvas.TopProperty, sp.Y);
			pelS.RenderTransform = ptrans;
			pelE.Fill = new SolidColorBrush(Colors.Red);
			pelE.Width = 6;
			pelE.Height = 6;
			pelE.SetValue(Canvas.LeftProperty, ep.X);
			pelE.SetValue(Canvas.TopProperty, ep.Y);
			pelE.RenderTransform = ptrans;
			parrow.Stroke = new SolidColorBrush(Colors.Red);
            parrow.StrokeThickness = 2;
			GeometryGroup pgeometry = new GeometryGroup();
		 /* LineGeometry plinegeometry_up = new LineGeometry();
		   plinegeometry_up.StartPoint = new System.Windows.Point(ep.X, ep.Y);
		   plinegeometry_up.EndPoint = new System.Windows.Point(ep.X, ep.Y);*/

			LineGeometry pline = new LineGeometry();
            pline.StartPoint = sp;
            pline.EndPoint = ep;

			/* LineGeometry plinegeometry_down = new LineGeometry();
			 plinegeometry_down.StartPoint = new System.Windows.Point(ep.X, ep.Y);
			 plinegeometry_down.EndPoint = new System.Windows.Point(ep.X, ep.Y);*/
			//pgeometry.Children.Add(plinegeometry_up);
			// pgeometry.Children.Add(plinegeometry_down);

			plabel.Text = properties.roadName;
			plabel.Foreground = new SolidColorBrush(Colors.Blue);
			plabel.Width = 100;
			plabel.SetValue(Canvas.LeftProperty, (startpos.X + endpos.X) / 2);
			plabel.SetValue(Canvas.TopProperty, (startpos.Y + endpos.Y) / 2);
			TranslateTransform ptranstext = new TranslateTransform();
			ptranstext.X = -plabel.Width / 2+25;
			ptranstext.Y = -10;
			plabel.RenderTransform = ptranstext;
			plabel.TextAlignment = TextAlignment.Center;
			/*plabel = new TextBlock();
			plabel.Text = properties.roadName;
			plabel.Width = 100;
			plabel.Background = new SolidColorBrush(Colors.Pink);
			plabel.SetValue(Canvas.LeftProperty, (startpos.X+endpos.X)/2);
			plabel.SetValue(Canvas.TopProperty, (startpos.Y + endpos.Y) / 2);
			plabel.TextAlignment = TextAlignment.Center;
			this.content.Children.Add(plabel);*/

			pgeometry.Children.Add(pline);
			
			parrow.Data = pgeometry; 
        }
        public void ondraw()
        {
			try
			{
				this.content.Children.Add(parrow);
			this.content.Children.Add(Head);
			this.content.Children.Add(pelS);
			this.content.Children.Add(pelE);
		
				this.content.Children.Add(plabel);
			}
			catch { }
		}
		public System.Windows.Point relativePoint(System.Windows.Point ep)
		{
			System.Windows.Point newep=new System.Windows.Point();
			int td = 2;
			if (ep.X > 0 && ep.Y > 0)
			{
				newep.X = ep.X - td;
				newep.Y = ep.Y- td;
			}
			else if (ep.X > 0 && ep.Y < 0)
			{
				newep.X = ep.X - td;
				newep.Y = ep.Y + td;
			}
			else if (ep.X < 0 && ep.Y > 0)
			{
				newep.X = ep.X + td;
				newep.Y = ep.Y - td;
			}
			else if (ep.X < 0 && ep.Y < 0)
			{
				newep.X = ep.X + td;
				newep.Y = ep.Y + td;
			}
			return newep;
		}
        public void drawbezierpath(System.Windows.Point sp, System.Windows.Point mp, System.Windows.Point ep)
        {
            this.startpos = sp;
            this.middlepos = mp;
            this.endpos = ep;
			TranslateTransform ptrans = new TranslateTransform();
			ptrans.X = -3;
			ptrans.Y = -3;
			ep = relativePoint(ep);
			pelS.Fill = new SolidColorBrush(Colors.Red);
			pelS.Width = 6;
			pelS.Height = 6;
			pelS.SetValue(Canvas.LeftProperty, sp.X);
			pelS.SetValue(Canvas.TopProperty,sp.Y);
			pelS.RenderTransform = ptrans;
			pelE.Fill = new SolidColorBrush(Colors.Red);
			pelE.Width = 6;
			pelE.Height = 6;
			pelE.SetValue(Canvas.LeftProperty, ep.X);
			pelE.SetValue(Canvas.TopProperty, ep.Y);
			pelE.RenderTransform = ptrans;
			parrow.Stroke = new SolidColorBrush(Colors.Black);
            parrow.StrokeThickness = 2;
            PathGeometry ppathgeo = new PathGeometry();
            PathSegmentCollection ppathseg = new PathSegmentCollection();
            PathFigure ppathFig = new PathFigure();
            PathFigureCollection ppathFigCol = new PathFigureCollection();
            QuadraticBezierSegment pquad = new QuadraticBezierSegment();
            pquad.Point1 = mp;
            pquad.Point2 = ep;
            ppathseg.Add(pquad);
            ppathFig.StartPoint = sp;
            ppathFig.Segments= ppathseg;
            ppathFigCol.Add(ppathFig);
            ppathgeo.Figures = ppathFigCol;
            parrow.Data=ppathgeo;
		
			//DrawArrow(sp, ep, Colors.Red);

			//this.content.Children.Add(parrow);
			// this.content.Children.Add(parrow);
		}
        public void updatePoint(System.Windows.Point sp, System.Windows.Point mp, System.Windows.Point ep)
        {
            if(properties.PathType==PATH_TYPE_DIRECT)
            {
                drawdirectpath(sp, ep);
            }
            else if(properties.PathType == PATH_TYPE_BEZIERSEGMENT)
            {
                drawbezierpath(sp,mp,ep);
            }
        }
		public void remove()
		{
			if (parrow != null)
			{
				this.content.Children.Remove(parrow);
				this.content.Children.Remove(pelE);
				this.content.Children.Remove(pelS);
			}
		}
		public double GetY(System.Windows.Point point1, System.Windows.Point point2, float x)
		{
			var dx = point2.X - point1.X;  //This part has problem in your code
			if (dx == 0)
				return float.NaN;
			var m = (point2.Y - point1.Y) / dx;
			var b = point1.Y - (m * point1.X);

			return m * x + b;
		}
		public JObject createJsonstring()
		{
				dynamic product = new JObject();
				product.Name = properties.roadName;
				product.Type = properties.PathType;
				if (nodeConnected.frontNodeConnected == NODECONNECTED.FRONTNODE_CONNECTED_HALFPOINT)
				{
					dynamic halfpoint_start = new JObject();
					halfpoint_start.Name = nodeConnected.startpoint.properties.NameObj;
					halfpoint_start.X = nodeConnected.startpoint.properties.X;
					halfpoint_start.Y = nodeConnected.startpoint.properties.Y;
					product.startPoint = halfpoint_start;
				}
			if (nodeConnected.frontNodeConnected == NODECONNECTED.FRONTNODE_CONNECTED_STATION)
			{
					dynamic station_start = new JObject();
				    station_start.Name = nodeConnected.startpoint_station.props.NameID;
				    station_start.X = nodeConnected.startpoint_station.props.X;
				    station_start.Y = nodeConnected.startpoint_station.props.Y;
					product.startPoint = station_start;
				}

				dynamic point_middle = new JObject();
				point_middle.Name ="";
			    point_middle.X = middlepos.X;
			    point_middle.Y = middlepos.Y;

				
				product.middlepoint = point_middle;
			    if (nodeConnected.frontNodeConnected == NODECONNECTED.BACKNODE_CONNECTED_HALFPOINT)
				{
					dynamic halfpoint_end = new JObject();
					halfpoint_end.Name = nodeConnected.endpoint.properties.NameObj;
					halfpoint_end.X = nodeConnected.endpoint.properties.X;
					halfpoint_end.Y = nodeConnected.endpoint.properties.Y;
					product.endPoint = halfpoint_end;
				}
				else if(nodeConnected.frontNodeConnected == NODECONNECTED.BACKNODE_CONNECTED_STATION)
				{
					dynamic station_end = new JObject();
					station_end.Name = nodeConnected.endpoint_station.props.NameID;
					station_end.X = nodeConnected.endpoint_station.props.X;
					station_end.Y = nodeConnected.endpoint_station.props.Y;
					product.endPoint = station_end;
				}

				return product;
		}
		public void trafficControl()
		{
			
		}
	}
}
