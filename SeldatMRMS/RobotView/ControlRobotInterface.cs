using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Media3D;

namespace SeldatMRMS.RobotView
{
    class ControlRobotInterface
    {
		public const int STATE_CREATE_IDLE = 2000;
		public const int STATE_CREATE_ROBOT = 2001;
		public const int STATE_CREATE_PALLET = 2002;
		public int SET_STATE_CONTROL = STATE_CREATE_IDLE;


		public Map pModelVisualMap;
        public Robot3D selectedpresentRobot3D;
        public List<Robot3D> Robotlist = new List<Robot3D>();
		public List<CreatePallet> pPalletlist = new List<CreatePallet>();
        public ControlRobotInterface() {
        }
        public void selFocusCamera() { }
        public void selMeasure(){
       
        }
        public void selEstimate() {
        
        }
		//public void control
        public void selsettingMap(ModelVisual3D pmaplayer, String msg)
        {
            string[] data = msg.Split('%');
            if (data[0] != "")
            {
               // try
                {
                    pModelVisualMap = new Map(data[0]);
                    double BorderX = Math.Abs(Convert.ToDouble(data[1]));
                    double BorderY = Math.Abs(Convert.ToDouble(data[2]));
                    double BorderZ =Convert.ToDouble(data[3]);
                    double pointmapX = Math.Abs(Convert.ToDouble(data[4]));
                    double pointmapY = Math.Abs(Convert.ToDouble(data[5]));
                    pModelVisualMap.setpointsBorderMap(new Point3D(-BorderX, -BorderY, BorderZ), new Point3D(BorderX, -BorderY, BorderZ), new Point3D(BorderX, BorderY, BorderZ), new Point3D(-BorderX, BorderY, BorderZ));
                    pModelVisualMap.setpointMap(new Point(-pointmapX, -pointmapY), new Point(pointmapX, -pointmapY), new Point(pointmapX, pointmapY), new Point(-pointmapX, pointmapY));
                    pModelVisualMap.setMap();
                    pmaplayer.Children.Add(pModelVisualMap.pModelMap);
                }
               // catch
                {
                   // MessageBox.Show("Wrong Values");
                }
            }
            else
            {
                MessageBox.Show("Path is invalid ");
            }
            
        }
        public void createRobot(ModelVisual3D probotlayer, int num)
        {
          /* Robotlist.Clear();
            Random r= new Random();
            while(num-->0)
           {
                ModelVisual3D layer = new ModelVisual3D();
                Robot3D temp = new Robot3D("MR" + Robotlist.Count + 1, layer);
                temp.updatePos(new Point3D(0,0,0),0);
                probotlayer.Children.Add(layer);
                Robotlist.Add(temp);
           };*/
        }
        public void updateRobotstates(int robotindex, Point3D location, double angle)
        {
           
           // Robotlist[robotindex].updateheadingdirection(angle);
            try
            {
                Robotlist[robotindex].updatePos(new Point3D(location.X, location.Y, 10), angle);
            }
            catch
            {}
        }
		public void createpalletobj(ModelVisual3D ppalletlayer)
		{

				ppalletlayer.Children.Clear();
			    pPalletlist.Clear();
				CreatePallet pPallet1 = new CreatePallet();
				pPallet1.updatePos(GlobalVariables.ConvertMetertoUnitLength (11.2), GlobalVariables.ConvertMetertoUnitLength( - 1.23), 0, 180);
			    pPalletlist.Add(pPallet1);
			    ppalletlayer.Children.Add(pPallet1.contentlayer);

				CreatePallet pPallet2 = new CreatePallet();
				pPallet2.updatePos(GlobalVariables.ConvertMetertoUnitLength (12.6), GlobalVariables.ConvertMetertoUnitLength (- 1.23), 0, 180);
				pPalletlist.Add(pPallet2);
				ppalletlayer.Children.Add(pPallet2.contentlayer);

		}
        public void settingrobot23d(int robotindex,int zaxis)
        {
            
            // Robotlist[robotindex].updateheadingdirection(angle);
            try
            {
                if (zaxis == 0)
                {
                    Robotlist[robotindex].ScaledRobot(GlobalVariables.ROBOT_SCALED, GlobalVariables.ROBOT_SCALED, 0);
                }
                else if (zaxis == 1)
                {
                    Robotlist[robotindex].ScaledRobot(GlobalVariables.ROBOT_SCALED, GlobalVariables.ROBOT_SCALED, GlobalVariables.ROBOT_SCALED);
                }
            }
            catch
            { }
        }



    }
}
