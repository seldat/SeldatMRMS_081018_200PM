using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SeldatMRMS.Model
{
    public class ParkPoint : Shape
    {
        public double X, Y;
        public String label;
        public String NameObj, NameEllipse;
        private Ellipse pellipse;
        private Canvas content;

        protected override Geometry DefiningGeometry => throw new NotImplementedException();

        public ParkPoint(Canvas content)
        {
            pellipse = new Ellipse();
            this.content = content;
        }
        public Object pointer()
        {
            return this;
        }
        public void sethalfpoint(double w, double h, double posx, double posy, Color cc)
        {
            pellipse.Width = w;
            pellipse.Height = h;
            pellipse.Fill = new SolidColorBrush(cc);
            setPos(posx, posy);
            content.Children.Add(pellipse);
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
            this.label = label;
            pellipse.Name = "haha";
        }
        public void setName(String name)
        {
            NameObj = name;
            pellipse.Name = name;
        }
        public bool FindName(String name)
        {
            if (name.Equals(NameObj))
                return true;
            else
                return false;
        }
        public void setPos(double x, double y)
        {
            X = x;
            Y = y;
            if (pellipse != null)
            {
                pellipse.SetValue(Canvas.LeftProperty, X);
                pellipse.SetValue(Canvas.TopProperty, Y);
            }
        }
        public void remove()
        {
            if (pellipse != null)
            {
                this.content.Children.Remove(pellipse);
            }
        }
    }
}
