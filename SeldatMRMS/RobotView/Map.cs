
// lin convert pgm to jpg https://www.online-convert.com/result/52c893db-c765-4731-8375-f1c0a26e2079
using HelixToolkit.Wpf;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Drawing;
using System.IO;
using OpenCvSharp;


namespace SeldatMRMS.RobotView
{
    class Map
    {
        public ModelVisual3D pModelMap;
        public Point3D pointBorder1, pointBorder2, pointBorder3, pointBorder4;
        public System.Windows.Point pointMap1, pointMap2, pointMap3, pointMap4;
        public String pgmMapPath;
        
        public Map(String _pgmPath)
        {
           pgmMapPath = _pgmPath;
            pModelMap = new ModelVisual3D();
            //setpointsBorderMap(new Point3D(-800, -800, 0), new Point3D(800, -800, 0), new Point3D(800, 800, 0), new Point3D(-800, 800, 0));
           // setpointMap(new Point(-800, -800), new Point(800, -800), new Point(800, 800), new Point(-800, 800));
           /*
            var mb = new MeshBuilder(false, true);
            IList<Point3D> pnts = new List<Point3D>();
            pnts.Add(new Point3D(-800, -800, 0));
            pnts.Add(new Point3D(800, -800, 0));
            pnts.Add(new Point3D(800, 800, 0));
            pnts.Add(new Point3D(-800, 800, 0));
            mb.AddPolygon(pnts);
            var mesh = mb.ToMesh(false);

            PointCollection pntCol = new PointCollection();
            pntCol.Add(new System.Windows.Point(-800, -800));
            pntCol.Add(new System.Windows.Point(800, -800));    //Tile image height/width is 204
            pntCol.Add(new System.Windows.Point(800, 800));
            pntCol.Add(new System.Windows.Point(-800, 800));
            mesh.TextureCoordinates = pntCol;
            */

            
            
        }

        public MeshGeometry3D setBorderMap()
        {
            var mb = new MeshBuilder(false, true);
            IList<Point3D> pnts = new List<Point3D>();
          //  pnts.Add(new Point3D(-800, -800, 0));
          //  pnts.Add(new Point3D(800, -800, 0));
           // pnts.Add(new Point3D(800, 800, 0));
          //  pnts.Add(new Point3D(-800, 800, 0));
            pnts.Add(new Point3D(pointBorder1.X, pointBorder1.Y, pointBorder1.Z));
            pnts.Add(new Point3D(pointBorder2.X, pointBorder2.Y, pointBorder2.Z));
            pnts.Add(new Point3D(pointBorder3.X, pointBorder3.Y, pointBorder3.Z));
            pnts.Add(new Point3D(pointBorder4.X, pointBorder4.Y, pointBorder4.Z));
            mb.AddPolygon(pnts);
            var mesh = mb.ToMesh(false);
            return mesh;
        }
        public void setpointsBorderMap(Point3D p1, Point3D p2, Point3D p3, Point3D p4)
        {
     
            pointBorder1=p1;
            pointBorder2=p2;
            pointBorder3=p3;
            pointBorder4=p4;
        }
        public void setpointMap(System.Windows.Point p1,System.Windows.Point p2,System.Windows.Point p3,System.Windows.Point p4)
        {
            pointMap1 = p1;
            pointMap2 = p2;
            pointMap3 = p3;
            pointMap4 = p4;

        }
        public PointCollection setMapCollection()
        {
            PointCollection pntCol = new PointCollection();
            pntCol.Add(new System.Windows.Point(pointMap1.X, pointMap1.Y));
            pntCol.Add(new System.Windows.Point(pointMap2.X, pointMap2.Y));    //Tile image height/width is 204
            pntCol.Add(new System.Windows.Point(pointMap3.X, pointMap3.Y));
            pntCol.Add(new System.Windows.Point(pointMap4.X, pointMap4.Y));
           // mesh.TextureCoordinates = pntCol;
            return pntCol;
        }
      private Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        {
            // BitmapImage bitmapImage = new BitmapImage(new Uri("../Images/test.png", UriKind.Relative));

            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);

                return new  System.Drawing.Bitmap(bitmap);
            }
        }
        public BitmapImage ToBitmapImage(Bitmap bitmap)
        {
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }
        public void setMap()
        {
          //  try
            {
                var mesh = setBorderMap();
                mesh.TextureCoordinates = setMapCollection();
                ImageBrush brush = new ImageBrush();
                //  brush.ImageSource = new BitmapImage(new Uri(pgmMapPath, UriKind.Absolute));
                BitmapImage bi = new BitmapImage(new Uri(pgmMapPath, UriKind.Absolute)); ;

              var grayBitmapSource = new FormatConvertedBitmap();
                grayBitmapSource.BeginInit();
                grayBitmapSource.Source = bi;
                grayBitmapSource.DestinationFormat = PixelFormats.Gray32Float;
             
                grayBitmapSource.EndInit();

              
                IplImage canny = BitmapConverter.ToIplImage(BitmapImage2Bitmap(bi));
                IplImage img=new IplImage();
                Cv.Threshold(canny, canny,15,255, ThresholdType.BinaryInv);
                IntPtr Dynstorage = CvInvoke.cvCreateMemStorage(0);
                IntPtr Dyncontour = new IntPtr();
                var contours = new List<IntPtr>();
            //    Cv.FindContours(canny,contours,0,1);
           //     CvInvoke.cvFindContours(canny,Dynstorage,ref Dyncontour,8,ContourRetrieval.List,ContourChain.ApproxNone);
              
 
                Bitmap pp = BitmapConverter.ToBitmap(canny);
                brush.ImageSource = bi;// ToBitmapImage(pp);

                brush.TileMode = TileMode.None;
                brush.ViewportUnits = BrushMappingMode.Absolute;
                brush.ViewboxUnits = BrushMappingMode.Absolute;
                brush.Stretch = Stretch.None;
                brush.AlignmentX = AlignmentX.Left;
                brush.AlignmentY = AlignmentY.Top;
                RotateTransform pr=new RotateTransform();

                //pr.CenterX=100;
               // pr.CenterX=100;
                // brush.Transform = new MatrixTransform(-1, 0, 0, 1.0d, -1.0d, -1.0d);
                brush.Transform = new MatrixTransform(1,0, 0, -1.0d, 0, 0);
              
              //  brush.RelativeTransform = pr;
                double largesize = bi.PixelWidth <= bi.PixelHeight ? bi.PixelWidth : bi.PixelHeight;
                brush.Viewport = new Rect(-GlobalVariables.ConvertMetertoUnitLength(54.8), GlobalVariables.ConvertMetertoUnitLength(15) - largesize, bi.PixelWidth, bi.PixelHeight);
                DiffuseMaterial mat = new DiffuseMaterial(brush);
                GeometryModel3D gModel3D = new GeometryModel3D { Geometry = mesh, Material = mat };
                pModelMap.Content = gModel3D;
            }
            //catch
            {
            //    MessageBox.Show("Error in loading Map");
            }
        }

        
    }
}
