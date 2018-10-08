using SeldatMRMS.Management;
using SeldatMRMS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using SeldatMRMS.RobotView;
using SeldatMRMS.Management.TrafficManager;
using SeldatMRMS.Management.FormManager;
using System.Net;

namespace SeldatMRMS
{


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Point startPoint;
        private Point originalPoint;
        private double slidingScale;
        private bool MouseMove;


        public string MyImageSource
        {
            get;
            set;
        }
        List<HalfPoint> halfpoint = new List<HalfPoint>();
        //public Interface RegistrationAgent.interfacePointer;
        public TasksManagement ptaskManager;
        public enum PATHCHECKED
        {
            PATH_CHECKED_DIRECT,
            PATH_CHECKED_BEZIER,
        }
        public enum HALFPOINTCHECKED
        {
            HALFPOINT_CHECKED,
            HALFPOINT_CHECKED_CHECKIN,
            HALFPOINT_CHECKED_CHECKOUT,
        }
        public PATHCHECKED pathchecked = PATHCHECKED.PATH_CHECKED_DIRECT;
        public HALFPOINTCHECKED halfpointchecked = HALFPOINTCHECKED.HALFPOINT_CHECKED;
        public enum STATECTRL_MOUSEDOWN
        {
            STATECTRL_MOUSEDOWN_NORMAL,
            STATECTRL_ADD_HALFPOINT,
            STATECTRL_ADD_CHECKINPOINT,
            STATECTRL_ADD_CHECKOUTPOINT,
            STATECTRL_ADD_STATION_CHARGER,
            STATECTRL_ADD_STATION_READY,
            STATECTRL_ADD_STATION_CHECKIN,
            STATECTRL_ADD_STATION_CHECKOUT,
            STATECTRL_ADD_STATION_DOCKINGAREA,
            STATECTRL_ADD_STATION_PUTAWAYAREA,
            STATECTRL_ADD_STATION_MIXEDAREA,
            STATECTRL_GET_PATH_STARTPOINT,
            STATECTRL_GET_PATH_ENDPOINT,
            STATECTRL_GET_OBJECT,
            STATECTRL_KEEP_IN_OBJECT,
            STATECTRL_GET_OUT_OBJECT,
            STATECTRL_REMOVE_OBJECT,
        }
        public enum STATECTRL_MOUSEMOVE
        {
            STATECTRL_MOVE_NORMAL,
            STATECTRL_MOVE_HALFPOINT,
            STATECTRL_MOVE_CHECKINPOINT,
            STATECTRL_MOVE_CHECKOUTPOINT,
            STATECTRL_MOVE_PATH_DIRECT,
            STATECTRL_MOVE_PATH,
            STATECTRL_MOVE_STATION,
            STATECTRL_MOVE_CHARGER,
            STATECTRL_MOVE_READY,
            STATECTRL_MOVE_CHECKIN,
            STATECTRL_MOVE_CHECKOUT,
            STATECTRL_SLIDE_PATH,
            STATECTRL_SLIDE_OBJECT,

        }
        public STATECTRL_MOUSEDOWN valstatectrl_md = STATECTRL_MOUSEDOWN.STATECTRL_MOUSEDOWN_NORMAL;
        public STATECTRL_MOUSEMOVE valstatectrl_mm;
        public RobotView3D probot3dmap;

        public MainWindow()
        {
            InitializeComponent();
            slidingScale = 1;
            MouseMove = false;
            string howtogeek = "TRUNGTRAN";
            /*IPAddress[] addresslist = Dns.GetHostAddresses(howtogeek);

			foreach (IPAddress theaddress in addresslist)
			{
				Console.WriteLine(theaddress.ToString());
			}*/
            RegistrationAgent.mainWindowPointer = this;
            RegistrationAgent.interfacePointer = new Interface(this);
            ptaskManager = new TasksManagement();
            RegistrationAgent.interfacePointer.addANewRobotAgent += ptaskManager.addANewRobotAgent;
            RegistrationAgent.interfacePointer.updateRobotAgentProperties += ptaskManager.UpdateRobotAgentProperties;
            MyImageSource = "C:\\Users\\luat.tran\\source\\repos\\SeldatMRMS\\SeldatMRMS\\Resources\\select_op.png";
            //LogRegistration.consoleForm.Show();
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
            SignIn signInForm = new SignIn();
            signInForm.Show();
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Normal_mode();
            }
        }

        public void LogConsole(String txt,string logName)
        {
            try
            {
                Task.Run(() =>

                   Dispatcher.Invoke((Action)(() =>
                   {
                       switch (logName)
                       {
                           case "logOrder":
                               {
                                   logOrder.AppendText(txt);
                                   logOrder.AppendText("\u2028");
                                   if (autoScroll_Checkbox.IsChecked == true)
                                   {
                                       logOrder.ScrollToEnd();
                                   }
                                   break;
                               }
                           case "logRobot":
                               {
                                   logRobot.AppendText(txt);
                                   logRobot.AppendText("\u2028");
                                   if (autoScroll_Checkbox.IsChecked == true)
                                   {
                                       logRobot.ScrollToEnd();
                                   }
                                   break;
                               }
                           case "logStation":
                               {
                                   logStation.AppendText(txt);
                                   logStation.AppendText("\u2028");
                                   if (autoScroll_Checkbox.IsChecked == true)
                                   {
                                       logStation.ScrollToEnd();
                                   }
                                   break;
                               }
                           case "errorConsole":
                               {
                                   errorConsole.AppendText(txt);
                                   errorConsole.AppendText("\u2028");
                                   if (autoScroll_Checkbox.IsChecked == true)
                                   {
                                       errorConsole.ScrollToEnd();
                                   }
                                   break;
                               }
                           case "warningConsole":
                               {
                                   warningConsole.AppendText(txt);
                                   warningConsole.AppendText("\u2028");
                                   if (autoScroll_Checkbox.IsChecked == true)
                                   {
                                       warningConsole.ScrollToEnd();
                                   }
                                   break;
                               }
                           default:
                               {
                                   break;
                               }
                       }
                   }))

               );
            }
            catch { }
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //statectrl_md(e);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // flag_halfpoint =true;
        }

        private void map_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var mouseWasDownOn = e.Source as FrameworkElement;
            if (mouseWasDownOn != null)
            {
                string elementName = mouseWasDownOn.Name;
                if (elementName != "")
                {

                    HalfPoint ptemp_halfpoint = RegistrationAgent.interfacePointer.findobjecthalfpoint(elementName);
                    PathModel ptemp_pathmodel = RegistrationAgent.interfacePointer.findobjecthalfpath(elementName);
                    StationModel ptemp_station = RegistrationAgent.interfacePointer.findobjectstation(elementName);
                    ChargerModel ptemp_charger = RegistrationAgent.interfacePointer.findobjectcharger(elementName);
                    ReadyModel ptemp_ready = RegistrationAgent.interfacePointer.findobjectready(elementName);
                    CheckinModel ptemp_checkin = RegistrationAgent.interfacePointer.findobjectcheckin(elementName);
                    CheckoutModel ptemp_checkout = RegistrationAgent.interfacePointer.findobjectcheckout(elementName);
                    RobotModel ptemp_rm = RegistrationAgent.interfacePointer.findRobotModel(elementName);
                    Point ep = e.GetPosition(map);

                    if (ptemp_station != null)
                    {
                        //MessageBox.Show("get "+ ptemp_station.properties.NameID);
                        RegistrationAgent.interfacePointer.SetObjectStation(ptemp_station);
                        showContextMenuStation(ptemp_station);
                    }
                    else if (ptemp_charger != null)
                    {
                        showContextMenuCharger(ptemp_charger);
                        RegistrationAgent.interfacePointer.SetObjectCharger(ptemp_charger);
                    }
                    else if (ptemp_ready != null)
                    {
                        showContextMenuReady(ptemp_ready);
                        RegistrationAgent.interfacePointer.SetObjectReady(ptemp_ready);
                    }
                    else if (ptemp_checkin != null)
                    {
                        showContextMenuCheckin(ptemp_checkin);
                        RegistrationAgent.interfacePointer.SetObjectCheckin(ptemp_checkin);
                    }
                    else if (ptemp_checkout != null)
                    {
                        showContextMenuCheckout(ptemp_checkout);
                        RegistrationAgent.interfacePointer.SetObjectCheckout(ptemp_checkout);
                    }
                    else if (ptemp_rm != null)
                    {
                        showContextMenuRobotinStore();
                    }

                }
            }

        }

        public void showContextMenuStation(StationModel ps)
        {
            ContextMenu cm = this.FindResource("TYPE-CANVAS_STATION") as ContextMenu;
            cm.IsOpen = true;
        }
        public void showContextMenuCharger(ChargerModel ps)
        {
            ContextMenu cm = this.FindResource("TYPE-CANVAS_CHARGER") as ContextMenu;
            cm.IsOpen = true;
        }
        public void showContextMenuReady(ReadyModel ps)
        {
            ContextMenu cm = this.FindResource("TYPE-CANVAS_READY") as ContextMenu;
            cm.IsOpen = true;
        }
        public void showContextMenuCheckin(CheckinModel ps)
        {
            ContextMenu cm = this.FindResource("TYPE-CANVAS_CHECKIN") as ContextMenu;
            cm.IsOpen = true;
        }
        public void showContextMenuCheckout(CheckoutModel ps)
        {
            ContextMenu cm = this.FindResource("TYPE-CANVAS_CHECKOUT") as ContextMenu;
            cm.IsOpen = true;
        }
        public void showContextMenuRobotinStore()
        {
            ContextMenu cm = this.FindResource("TYPE-CANVAS_ROBOTSTORE") as ContextMenu;
            cm.IsOpen = true;
            if (cm.Items.Count > 0)
            {
                cm.Items.Clear();

            }
            for (int index = 0; index < RegistrationAgent.robotAgentRegisteredList.Count; index++)
            {
                RobotAgent pr = RegistrationAgent.robotAgentRegisteredList.ElementAt(index).Value;
                MenuItem menuItem = new MenuItem();
                menuItem.Header = pr.NameID;
                cm.Items.Add(menuItem);
                menuItem.Click += Menu_Click;

            }
        }
        void Menu_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            RobotAgent pr = RegistrationAgent.robotAgentRegisteredList[menuItem.Header + ""];
            RobotControl robotControl = new RobotControl(pr);
            robotControl.ShowDialog();
            //here comes your code
        }

        public void showContextMenuRobot(RobotAgent pr)
        {
            ContextMenu cm = this.FindResource("TYPE-CANVAS_ROBOT") as ContextMenu;
            cm.IsOpen = true;
        }

        private void callcanvas_editStation_Click(object sender, RoutedEventArgs e)
        {
            RegistrationAgent.interfacePointer.modeEditStation();
        }
        private void callcanvas_editCharger_Click(object sender, RoutedEventArgs e)
        {
            RegistrationAgent.interfacePointer.modeEditCharger();
        }
        private void callcanvas_editReady_Click(object sender, RoutedEventArgs e)
        {
            RegistrationAgent.interfacePointer.modeEditReady();
        }
        private void callcanvas_editCheckin_Click(object sender, RoutedEventArgs e)
        {
            RegistrationAgent.interfacePointer.modeEditCheckin();
        }
        private void callcanvas_editCheckout_Click(object sender, RoutedEventArgs e)
        {
            RegistrationAgent.interfacePointer.modeEditCheckout();
        }

        private void callcanvas_viewStation_Click(object sender, RoutedEventArgs e)
        {
            RegistrationAgent.interfacePointer.modeViewStation();
        }

        private void callcanvas_propRobot_Click(object sender, RoutedEventArgs e)
        {
            RegistrationAgent.interfacePointer.modeEditStation();
        }

        private void callcanvas_controlRobot_Click(object sender, RoutedEventArgs e)
        {
            //RegistrationAgent.interfacePointer.modeViewStation();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {



        }
        private Canvas DrawArrow(Point StartPoint, Point EndPoint, Color myColor)
        {
            System.Windows.Shapes.Line _Line = new System.Windows.Shapes.Line();
            System.Windows.Shapes.Line Head = new System.Windows.Shapes.Line();

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
                    d = 1;
                }
                else
                {
                    Head.X1 = EndPoint.X + 1;
                    Head.X2 = EndPoint.X;
                    d = -1;
                }
                Head.Y1 = getArrowYByX(d, StartPoint, EndPoint);
                Head.Y2 = EndPoint.Y;
            }

            Head.StrokeEndLineCap = PenLineCap.Triangle;
            Head.StrokeThickness = 10;
            Head.Stroke = new SolidColorBrush(myColor);
            Canvas myCv = new Canvas();

            //myCv.Children.Add(_Line);
            myCv.Children.Add(Head);

            return myCv;
        }
        double getArrowYByX(double d, Point pStart, Point pEnd)
        {
            return pStart.Y + (pEnd.X - pStart.X - d) * (pEnd.Y - pStart.Y) / (pEnd.X - pStart.X);
        }

        PathModel pp;
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
        int nep = 100;
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {


        }


        void statectrl_md(MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                EditObject();
            }
            Point pp = e.GetPosition(map);
            var mouseWasDownOn = e.Source as FrameworkElement;
            switch (valstatectrl_md)
            {
                case STATECTRL_MOUSEDOWN.STATECTRL_KEEP_IN_OBJECT:
                    if (mouseWasDownOn != null)
                    {
                        string elementName = mouseWasDownOn.Name;
                        if (elementName != "")
                        {
                            //MessageBox.Show("dds" + elementName);
                            HalfPoint ptemp_halfpoint = RegistrationAgent.interfacePointer.findobjecthalfpoint(elementName);
                            PathModel ptemp_pathmodel = RegistrationAgent.interfacePointer.findobjecthalfpath(elementName);
                            StationModel ptemp_station = RegistrationAgent.interfacePointer.findobjectstation(elementName);
                            ChargerModel ptemp_charger = RegistrationAgent.interfacePointer.findobjectcharger(elementName);
                            ReadyModel ptemp_ready = RegistrationAgent.interfacePointer.findobjectready(elementName);
                            CheckinModel ptemp_checkin = RegistrationAgent.interfacePointer.findobjectcheckin(elementName);
                            CheckoutModel ptemp_checkout = RegistrationAgent.interfacePointer.findobjectcheckout(elementName);
                            if (ptemp_halfpoint != null)
                            {
                                RegistrationAgent.interfacePointer.SetObjectPoint(ptemp_halfpoint);
                                valstatectrl_mm = STATECTRL_MOUSEMOVE.STATECTRL_MOVE_HALFPOINT;
                                valstatectrl_md = STATECTRL_MOUSEDOWN.STATECTRL_GET_OUT_OBJECT;
                            }
                            else if (ptemp_pathmodel != null)
                            {
                                RegistrationAgent.interfacePointer.SetObjectPath(ptemp_pathmodel);
                            }
                            else if (ptemp_station != null)
                            {
                                RegistrationAgent.interfacePointer.SetObjectStation(ptemp_station);
                                valstatectrl_mm = STATECTRL_MOUSEMOVE.STATECTRL_MOVE_STATION;
                                valstatectrl_md = STATECTRL_MOUSEDOWN.STATECTRL_GET_OUT_OBJECT;
                            }
                            else if (ptemp_charger != null)
                            {
                                RegistrationAgent.interfacePointer.SetObjectCharger(ptemp_charger);
                                valstatectrl_mm = STATECTRL_MOUSEMOVE.STATECTRL_MOVE_CHARGER;
                                valstatectrl_md = STATECTRL_MOUSEDOWN.STATECTRL_GET_OUT_OBJECT;
                            }
                            else if (ptemp_ready != null)
                            {
                                RegistrationAgent.interfacePointer.SetObjectReady(ptemp_ready);
                                valstatectrl_mm = STATECTRL_MOUSEMOVE.STATECTRL_MOVE_READY;
                                valstatectrl_md = STATECTRL_MOUSEDOWN.STATECTRL_GET_OUT_OBJECT;
                            }
                            else if (ptemp_checkin != null)
                            {
                                RegistrationAgent.interfacePointer.SetObjectCheckin(ptemp_checkin);
                                valstatectrl_mm = STATECTRL_MOUSEMOVE.STATECTRL_MOVE_CHECKIN;
                                valstatectrl_md = STATECTRL_MOUSEDOWN.STATECTRL_GET_OUT_OBJECT;
                            }
                            else if (ptemp_checkout != null)
                            {
                                RegistrationAgent.interfacePointer.SetObjectCheckout(ptemp_checkout);
                                valstatectrl_mm = STATECTRL_MOUSEMOVE.STATECTRL_MOVE_CHECKOUT;
                                valstatectrl_md = STATECTRL_MOUSEDOWN.STATECTRL_GET_OUT_OBJECT;
                            }

                        }
                    }
                    break;
                case STATECTRL_MOUSEDOWN.STATECTRL_REMOVE_OBJECT:
                    if (mouseWasDownOn != null)
                    {
                        string elementName = mouseWasDownOn.Name;
                        if (elementName != "")
                        {
                            //MessageBox.Show("dds" + elementName);
                            HalfPoint ptemp_halfpoint = RegistrationAgent.interfacePointer.findobjecthalfpoint(elementName);
                            PathModel ptemp_pathmodel = RegistrationAgent.interfacePointer.findobjecthalfpath(elementName);
                            StationModel ptemp_station = RegistrationAgent.interfacePointer.findobjectstation(elementName);
                            ChargerModel ptemp_charger = RegistrationAgent.interfacePointer.findobjectcharger(elementName);
                            ReadyModel ptemp_ready = RegistrationAgent.interfacePointer.findobjectready(elementName);
                            CheckinModel ptemp_checkin = RegistrationAgent.interfacePointer.findobjectcheckin(elementName);
                            CheckoutModel ptemp_checkout = RegistrationAgent.interfacePointer.findobjectcheckout(elementName);
                            if (ptemp_halfpoint != null)
                            {
                                RegistrationAgent.interfacePointer.removeobject_Halfpoint(ptemp_halfpoint);
                                ptemp_halfpoint = null;
                            }
                            else if (ptemp_pathmodel != null)
                            {
                                RegistrationAgent.interfacePointer.removeobject_paths(ptemp_pathmodel);
                                ptemp_pathmodel = null;
                            }
                            else if (ptemp_station != null)
                            {
                                RegistrationAgent.interfacePointer.removeobject_station(ptemp_station);
                                ptemp_station = null;
                            }
                            else if (ptemp_charger != null)
                            {
                                RegistrationAgent.interfacePointer.removeobject_charger(ptemp_charger);
                                ptemp_charger = null;
                            }
                            else if (ptemp_ready != null)
                            {
                                RegistrationAgent.interfacePointer.removeobject_ready(ptemp_ready);
                                ptemp_ready = null;
                            }
                            else if (ptemp_checkin != null)
                            {
                                RegistrationAgent.interfacePointer.removeobject_checkin(ptemp_checkin);
                                ptemp_checkin = null;
                            }
                            else if (ptemp_checkout != null)
                            {
                                RegistrationAgent.interfacePointer.removeobject_checkout(ptemp_checkout);
                                ptemp_checkout = null;
                            }

                        }
                    }

                    break;
                case STATECTRL_MOUSEDOWN.STATECTRL_GET_OUT_OBJECT:
                    Select_mode();
                    break;
                case STATECTRL_MOUSEDOWN.STATECTRL_ADD_HALFPOINT:
                    RegistrationAgent.interfacePointer.STATESETTING = Interface.STATE_INTERFACE.INTERFACE_SETING_HALFPOINT;
                    Point ep = e.GetPosition(map);
                    RegistrationAgent.interfacePointer.Interfacecontrols(RegistrationAgent.interfacePointer.STATESETTING, ep, 0);
                    break;
                case STATECTRL_MOUSEDOWN.STATECTRL_ADD_CHECKINPOINT:
                    {
                        RegistrationAgent.interfacePointer.STATESETTING = Interface.STATE_INTERFACE.INTERFACE_SETING_CHECKINPOINT;
                        Point epci = e.GetPosition(map);
                        RegistrationAgent.interfacePointer.Interfacecontrols(RegistrationAgent.interfacePointer.STATESETTING, epci, 0);
                    }
                    break;
                case STATECTRL_MOUSEDOWN.STATECTRL_ADD_CHECKOUTPOINT:
                    RegistrationAgent.interfacePointer.STATESETTING = Interface.STATE_INTERFACE.INTERFACE_SETING_CHECKOUTPOINT;
                    Point epco = e.GetPosition(map);
                    RegistrationAgent.interfacePointer.Interfacecontrols(RegistrationAgent.interfacePointer.STATESETTING, epco, 0);
                    break;
                case STATECTRL_MOUSEDOWN.STATECTRL_ADD_STATION_CHARGER:
                    RegistrationAgent.interfacePointer.Interfacecontrols(Interface.STATE_INTERFACE.INTERFACE_ADD_STATION_CHARGER, pp, 0);
                    break;
                case STATECTRL_MOUSEDOWN.STATECTRL_ADD_STATION_READY:
                    RegistrationAgent.interfacePointer.Interfacecontrols(Interface.STATE_INTERFACE.INTERFACE_ADD_STATION_READY, pp, 0);
                    break;
                case STATECTRL_MOUSEDOWN.STATECTRL_ADD_STATION_CHECKIN:
                    RegistrationAgent.interfacePointer.Interfacecontrols(Interface.STATE_INTERFACE.INTERFACE_ADD_STATION_CHECKIN, pp, 0);
                    break;
                case STATECTRL_MOUSEDOWN.STATECTRL_ADD_STATION_CHECKOUT:
                    RegistrationAgent.interfacePointer.Interfacecontrols(Interface.STATE_INTERFACE.INTERFACE_ADD_STATION_CHECKOUT, pp, 0);
                    break;
                case STATECTRL_MOUSEDOWN.STATECTRL_ADD_STATION_DOCKINGAREA:
                    RegistrationAgent.interfacePointer.Interfacecontrols(Interface.STATE_INTERFACE.INTERFACE_ADD_STATION_DOCKING, pp, 0);
                    break;
                case STATECTRL_MOUSEDOWN.STATECTRL_ADD_STATION_PUTAWAYAREA:
                    RegistrationAgent.interfacePointer.Interfacecontrols(Interface.STATE_INTERFACE.INTERFACE_ADD_STATION_PUTAWAY, pp, 0);
                    break;
                case STATECTRL_MOUSEDOWN.STATECTRL_ADD_STATION_MIXEDAREA:
                    RegistrationAgent.interfacePointer.Interfacecontrols(Interface.STATE_INTERFACE.INTERFACE_ADD_STATION_MIXED, pp, 0);
                    break;
                case STATECTRL_MOUSEDOWN.STATECTRL_GET_PATH_STARTPOINT:
                    if (mouseWasDownOn != null)
                    {
                        string elementName = mouseWasDownOn.Name;
                        if (elementName != "")
                        {
                            HalfPoint thp_sp = RegistrationAgent.interfacePointer.findobjecthalfpoint(elementName);

                            StationModel tst_sp = RegistrationAgent.interfacePointer.findobjectstation(elementName);
                            if (thp_sp != null)
                            {

                                valstatectrl_md = STATECTRL_MOUSEDOWN.STATECTRL_GET_PATH_ENDPOINT;
                                valstatectrl_mm = STATECTRL_MOUSEMOVE.STATECTRL_SLIDE_PATH;
                                RegistrationAgent.interfacePointer.Interfacecontrols(RegistrationAgent.interfacePointer.STATESETTING, pp, 0);
                                RegistrationAgent.interfacePointer.SetObjectPath_StartPoint(thp_sp);


                            }
                            else if (tst_sp != null)
                            {

                                valstatectrl_md = STATECTRL_MOUSEDOWN.STATECTRL_GET_PATH_ENDPOINT;
                                valstatectrl_mm = STATECTRL_MOUSEMOVE.STATECTRL_SLIDE_PATH;
                                RegistrationAgent.interfacePointer.Interfacecontrols(RegistrationAgent.interfacePointer.STATESETTING, pp, 0);
                                RegistrationAgent.interfacePointer.SetObjectPath_StartPoint(tst_sp);
                            }

                        }
                    }

                    break;
                case STATECTRL_MOUSEDOWN.STATECTRL_GET_PATH_ENDPOINT:
                    if (mouseWasDownOn != null)
                    {
                        string elementName = mouseWasDownOn.Name;
                        if (elementName != "")
                        {
                            HalfPoint thp_ep = RegistrationAgent.interfacePointer.findobjecthalfpoint(elementName);
                            StationModel tst_ep = RegistrationAgent.interfacePointer.findobjectstation(elementName);
                            if (thp_ep != null)
                            {
                                RegistrationAgent.interfacePointer.SetObjectPath_EndPoint(thp_ep);
                                if (pathchecked == PATHCHECKED.PATH_CHECKED_BEZIER)
                                {
                                    RegistrationAgent.interfacePointer.STATESETTING = Interface.STATE_INTERFACE.INTERFACE_GET_ENDPOINT_BEZIERSEGMENT;
                                }
                                else if (pathchecked == PATHCHECKED.PATH_CHECKED_DIRECT)
                                {
                                    RegistrationAgent.interfacePointer.STATESETTING = Interface.STATE_INTERFACE.INTERFACE_GET_ENDPOINT_DIRECT;
                                }
                                RegistrationAgent.interfacePointer.Interfacecontrols(RegistrationAgent.interfacePointer.STATESETTING, pp, 0);
                                if (pathchecked == PATHCHECKED.PATH_CHECKED_BEZIER)
                                {
                                    RegistrationAgent.interfacePointer.STATESETTING = Interface.STATE_INTERFACE.INTERFACE_GET_STARTPOINT_BEZIERSEGMENT;
                                }
                                else if (pathchecked == PATHCHECKED.PATH_CHECKED_DIRECT)
                                {
                                    RegistrationAgent.interfacePointer.STATESETTING = Interface.STATE_INTERFACE.INTERFACE_GET_STARTPOINT_DIRECT;
                                }

                                valstatectrl_md = STATECTRL_MOUSEDOWN.STATECTRL_GET_PATH_STARTPOINT;
                                valstatectrl_mm = STATECTRL_MOUSEMOVE.STATECTRL_MOVE_NORMAL;

                            }
                            else if (tst_ep != null)
                            {
                                RegistrationAgent.interfacePointer.SetObjectPath_EndPoint(tst_ep);
                                if (pathchecked == PATHCHECKED.PATH_CHECKED_BEZIER)
                                {
                                    RegistrationAgent.interfacePointer.STATESETTING = Interface.STATE_INTERFACE.INTERFACE_GET_ENDPOINT_BEZIERSEGMENT;
                                }
                                else if (pathchecked == PATHCHECKED.PATH_CHECKED_DIRECT)
                                {
                                    RegistrationAgent.interfacePointer.STATESETTING = Interface.STATE_INTERFACE.INTERFACE_GET_ENDPOINT_DIRECT;

                                }
                                RegistrationAgent.interfacePointer.Interfacecontrols(RegistrationAgent.interfacePointer.STATESETTING, pp, 0);
                                if (pathchecked == PATHCHECKED.PATH_CHECKED_BEZIER)
                                {
                                    RegistrationAgent.interfacePointer.STATESETTING = Interface.STATE_INTERFACE.INTERFACE_GET_STARTPOINT_BEZIERSEGMENT;
                                }
                                else if (pathchecked == PATHCHECKED.PATH_CHECKED_DIRECT)
                                {
                                    RegistrationAgent.interfacePointer.STATESETTING = Interface.STATE_INTERFACE.INTERFACE_GET_STARTPOINT_DIRECT;
                                }
                                valstatectrl_md = STATECTRL_MOUSEDOWN.STATECTRL_GET_PATH_STARTPOINT;
                                valstatectrl_mm = STATECTRL_MOUSEMOVE.STATECTRL_MOVE_NORMAL;

                            }

                        }
                    }

                    break;
            }
        }

        void statectrl_mm(MouseEventArgs e)
        {
            Point pp = e.GetPosition(map);
            var mouseWasDownOn = e.Source as FrameworkElement;
            txt_location.Text = "X:" + pp.X + " | " + " Y:" + pp.Y;
            switch (valstatectrl_mm)
            {
                case STATECTRL_MOUSEMOVE.STATECTRL_SLIDE_OBJECT:
                    if (mouseWasDownOn != null)
                    {
                        string elementName = mouseWasDownOn.Name;
                        if (elementName != "")
                        {
                            //MessageBox.Show("dds" + elementName);
                            if (RegistrationAgent.interfacePointer.findobjecthalfpoint(elementName) != null)
                            {
                                Console.WriteLine("Point " + elementName);
                            }
                            else if (RegistrationAgent.interfacePointer.findobjecthalfpath(elementName) != null)
                            {
                                Console.WriteLine("Path " + elementName);
                            }
                            else if (RegistrationAgent.interfacePointer.findobjectstation(elementName) != null)
                            {

                            }
                            else if (RegistrationAgent.interfacePointer.findobjectcharger(elementName) != null)
                            {

                            }
                            else if (RegistrationAgent.interfacePointer.findobjectready(elementName) != null)
                            {

                            }
                            else if (RegistrationAgent.interfacePointer.findobjectcheckin(elementName) != null)
                            {

                            }
                            else if (RegistrationAgent.interfacePointer.findobjectcheckout(elementName) != null)
                            {

                            }

                        }
                    }
                    break;
                case STATECTRL_MOUSEMOVE.STATECTRL_MOVE_HALFPOINT:
                    RegistrationAgent.interfacePointer.STATESETTING = Interface.STATE_INTERFACE.INTERFACE_MOVE_HALFPOINT;
                    RegistrationAgent.interfacePointer.Interfacecontrols(RegistrationAgent.interfacePointer.STATESETTING, pp, 0);
                    break;
                case STATECTRL_MOUSEMOVE.STATECTRL_MOVE_STATION:
                    RegistrationAgent.interfacePointer.STATESETTING = Interface.STATE_INTERFACE.INTERFACE_MOVE_STATION;
                    RegistrationAgent.interfacePointer.Interfacecontrols(RegistrationAgent.interfacePointer.STATESETTING, pp, 0);
                    break;
                case STATECTRL_MOUSEMOVE.STATECTRL_MOVE_CHARGER:
                    RegistrationAgent.interfacePointer.STATESETTING = Interface.STATE_INTERFACE.INTERFACE_MOVE_CHARGER;
                    RegistrationAgent.interfacePointer.Interfacecontrols(RegistrationAgent.interfacePointer.STATESETTING, pp, 0);
                    break;
                case STATECTRL_MOUSEMOVE.STATECTRL_MOVE_READY:
                    RegistrationAgent.interfacePointer.STATESETTING = Interface.STATE_INTERFACE.INTERFACE_MOVE_READY;
                    RegistrationAgent.interfacePointer.Interfacecontrols(RegistrationAgent.interfacePointer.STATESETTING, pp, 0);
                    break;
                case STATECTRL_MOUSEMOVE.STATECTRL_MOVE_CHECKIN:
                    RegistrationAgent.interfacePointer.STATESETTING = Interface.STATE_INTERFACE.INTERFACE_MOVE_CHECKIN;
                    RegistrationAgent.interfacePointer.Interfacecontrols(RegistrationAgent.interfacePointer.STATESETTING, pp, 0);
                    break;
                case STATECTRL_MOUSEMOVE.STATECTRL_MOVE_CHECKOUT:
                    RegistrationAgent.interfacePointer.STATESETTING = Interface.STATE_INTERFACE.INTERFACE_MOVE_CHECKOUT;
                    RegistrationAgent.interfacePointer.Interfacecontrols(RegistrationAgent.interfacePointer.STATESETTING, pp, 0);
                    break;

                case STATECTRL_MOUSEMOVE.STATECTRL_SLIDE_PATH:
                    RegistrationAgent.interfacePointer.Interfacecontrols(RegistrationAgent.interfacePointer.STATESETTING, pp, 0);
                    break;
                    /* case STATECTRL_MOUSEMOVE.STATECTRL_GET_PATH_ENDPOINT:
                         RegistrationAgent.interfacePointer.STATESETTING = Interface.STATE_INTERFACE.INTERFACE_GET_ENDPOINT;
                         valstatectrl_md = STATECTRL_MOUSEDOWN.STATECTRL_MOVE_HALFPOINT;
                         Point pp2 = e.GetPosition(map);
                         ppp = pp2;
                         RegistrationAgent.interfacePointer.Interfacecontrols(RegistrationAgent.interfacePointer.STATESETTING, pp2, 0);
                         break;
				    */
            }
        }
        public void updateRobotAgentProperties(RobotAgent pr)
        {
            RegistrationAgent.interfacePointer.updateRobotProperties(pr);
        }
        public string SourceUri
        {
            get
            {
                return Directory.GetCurrentDirectory() + "\\Resources\\load_op.png";
            }
        }


        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            //TcpServer tcpip = new TcpServer(2000);
        }

        private void btn_selecthalfpoint_Click(object sender, RoutedEventArgs e)
        {

        }



        private void trv_points_Selected(object sender, RoutedEventArgs e)
        {

            TreeViewItem tv_points = ((TreeViewItem)e.Source);
            RegistrationAgent.interfacePointer.findobjecthalfpoint_treeview(tv_points.Header.ToString());
        }

        private void trv_vehclies_Selected(object sender, RoutedEventArgs e)
        {

            TreeViewItem tv_robot = ((TreeViewItem)e.Source);
            RegistrationAgent.interfacePointer.findobjectrobot_treeview(tv_robot.Header.ToString());
        }

        private void trv_paths_Selected(object sender, RoutedEventArgs e)
        {
            TreeViewItem tv_paths = ((TreeViewItem)e.Source);
            RegistrationAgent.interfacePointer.findobjecthalfpath_treeview(tv_paths.Header.ToString());
        }

        private void trv_stations_Selected(object sender, RoutedEventArgs e)
        {
            TreeViewItem tv_station = ((TreeViewItem)e.Source);
            RegistrationAgent.interfacePointer.findobjectstation_treeview(tv_station.Header.ToString());
        }

        private void trv_charger_Selected(object sender, RoutedEventArgs e)
        {
            TreeViewItem tv_charger = ((TreeViewItem)e.Source);
            RegistrationAgent.interfacePointer.findobjectcharger_treeview(tv_charger.Header.ToString());
        }

        private void trv_ready_Selected(object sender, RoutedEventArgs e)
        {
            TreeViewItem tv_ready = ((TreeViewItem)e.Source);
            RegistrationAgent.interfacePointer.findobjectready_treeview(tv_ready.Header.ToString());
        }

        private void trv_checkin_Selected(object sender, RoutedEventArgs e)
        {
            TreeViewItem tv_checkin = ((TreeViewItem)e.Source);
            RegistrationAgent.interfacePointer.findobjectcheckin_treeview(tv_checkin.Header.ToString());
        }

        private void trv_checkout_Selected(object sender, RoutedEventArgs e)
        {
            TreeViewItem tv_checkout = ((TreeViewItem)e.Source);
            RegistrationAgent.interfacePointer.findobjectcheckout_treeview(tv_checkout.Header.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*  Station ps = new Station(map);
			  ps.setStation(10, 10);

			  pa = new HalfPoint(map);
			  pa.sethalfpoint(10,10,80,100,Colors.Aquamarine);
			  pa.setName("haha");*/

            // PathModel pp = new PathModel(map);
            //pp.drawbezierpath(new Point(10, 30), new Point(40, 80), new Point(100, 30));
        }

        private void contentmap_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void halfpointOP_Click_1(object sender, RoutedEventArgs e)
        {
            valstatectrl_md = STATECTRL_MOUSEDOWN.STATECTRL_ADD_HALFPOINT;
        }

        private void componets_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddHalfpointOP_Click(object sender, RoutedEventArgs e)
        {
            ContextMenu cm = this.FindResource("TYPE-POINTS") as ContextMenu;
            cm.PlacementTarget = sender as Button;
            cm.IsOpen = true;

            valstatectrl_md = STATECTRL_MOUSEDOWN.STATECTRL_ADD_HALFPOINT;
        }

        private void AddPath_Click(object sender, RoutedEventArgs e)
        {
            ContextMenu cm = this.FindResource("TYPE-PATHS") as ContextMenu;
            cm.PlacementTarget = sender as Button;
            cm.IsOpen = true;

        }

        private void AddStation_Click(object sender, RoutedEventArgs e)
        {
            ContextMenu cm = this.FindResource("TYPE-STATIONS") as ContextMenu;
            cm.PlacementTarget = sender as Button;
            cm.IsOpen = true;

        }

        private void Selectmode_Click(object sender, RoutedEventArgs e)
        {
            MoveToggle(false);
            Select_mode();
        }

        private void typepoints_Click(object sender, RoutedEventArgs e)
        {

        }

        private void typestations_Click(object sender, RoutedEventArgs e)
        {
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            MessageBox.Show(item.Header.ToString());
            if (item.Header.Equals("Docking Area"))
            {
                MessageBox.Show("correct");
            }
        }

        private void putaway_selected_Click(object sender, RoutedEventArgs e)
        {
            MoveToggle(false);
            valstatectrl_md = STATECTRL_MOUSEDOWN.STATECTRL_ADD_STATION_PUTAWAYAREA;
            ProgramStatus.Text = "Add Put-away Station";
        }

        private void dockingarea_selected_Click(object sender, RoutedEventArgs e)
        {
            MoveToggle(false);
            valstatectrl_md = STATECTRL_MOUSEDOWN.STATECTRL_ADD_STATION_DOCKINGAREA;
            ProgramStatus.Text = "Add Docking Station";
        }

        private void mixedarea_selected_Click(object sender, RoutedEventArgs e)
        {
            MoveToggle(false);
            valstatectrl_md = STATECTRL_MOUSEDOWN.STATECTRL_ADD_STATION_MIXEDAREA;
            ProgramStatus.Text = "Add Mixed Station";
        }

        private void batterycharge_selected_Click(object sender, RoutedEventArgs e)
        {
            MoveToggle(false);
            valstatectrl_md = STATECTRL_MOUSEDOWN.STATECTRL_ADD_STATION_CHARGER;
            ProgramStatus.Text = "Add Charger Station";
        }

        private void ready_selected_Click(object sender, RoutedEventArgs e)
        {
            MoveToggle(false);
            valstatectrl_md = STATECTRL_MOUSEDOWN.STATECTRL_ADD_STATION_READY;
            ProgramStatus.Text = "Add Ready Station";
        }

        private void checkin_selected_Click(object sender, RoutedEventArgs e)
        {
            MoveToggle(false);
            valstatectrl_md = STATECTRL_MOUSEDOWN.STATECTRL_ADD_STATION_CHECKIN;
            ProgramStatus.Text = "Add Checkin Station";
        }

        private void checkout_selected_Click(object sender, RoutedEventArgs e)
        {
            MoveToggle(false);
            valstatectrl_md = STATECTRL_MOUSEDOWN.STATECTRL_ADD_STATION_CHECKOUT;
            ProgramStatus.Text = "Add Checkout Station";
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Directory.GetCurrentDirectory() + "\\Resources\\load_op.png");
        }

        private void removeobject_Click(object sender, RoutedEventArgs e)
        {
            valstatectrl_md = STATECTRL_MOUSEDOWN.STATECTRL_REMOVE_OBJECT;
        }

        private void parent_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void map_MouseLeave(object sender, MouseEventArgs e)
        {
            txt_location.Text = "";
        }

        private void loadmodel_Click(object sender, RoutedEventArgs e)
        {
            LoadModel p = new LoadModel(RegistrationAgent.interfacePointer);
            p.LoadFileModel();
            p.ParseInfo();
        }

        private void savemodel_Click(object sender, RoutedEventArgs e)
        {
            SaveModel.savedata();
        }

        private void load3dmap_Click(object sender, RoutedEventArgs e)
        {
            probot3dmap = new RobotView3D();
            probot3dmap.Show();
            probot3dmap.loadAWareHouseMap();
        }

        private void pathdirect_Click(object sender, RoutedEventArgs e)
        {
            RegistrationAgent.interfacePointer.STATESETTING = Interface.STATE_INTERFACE.INTERFACE_GET_STARTPOINT_DIRECT;
            valstatectrl_md = STATECTRL_MOUSEDOWN.STATECTRL_GET_PATH_STARTPOINT;
            pathchecked = PATHCHECKED.PATH_CHECKED_DIRECT;
        }

        private void pathBezier_Click(object sender, RoutedEventArgs e)
        {
            RegistrationAgent.interfacePointer.STATESETTING = Interface.STATE_INTERFACE.INTERFACE_GET_STARTPOINT_BEZIERSEGMENT;
            valstatectrl_md = STATECTRL_MOUSEDOWN.STATECTRL_GET_PATH_STARTPOINT;
            pathchecked = PATHCHECKED.PATH_CHECKED_BEZIER;
        }

        private void addrobotconfig_Click(object sender, RoutedEventArgs e)
        {
            RegistrationAgent.interfacePointer.setRobotProperties();
        }



        private void updateProperties_CurrentCellChanged(object sender, EventArgs e)
        {
            /*TextBlock NameObj = updateProperties.Columns[1].GetCellContent(updateProperties.Items[0]) as TextBlock;
			if (NameObj != null)
			{
				HalfPoint ptemp_halfpoint = RegistrationAgent.interfacePointer.findobjecthalfpoint(NameObj.Text);
				PathModel ptemp_pathmodel = RegistrationAgent.interfacePointer.findobjecthalfpath(NameObj.Text);
				Station ptemp_station = RegistrationAgent.interfacePointer.findobjectstation(NameObj.Text);
				if (ptemp_halfpoint != null)
				{
					MessageBox.Show("HaftPoint");
				}
				else if (ptemp_pathmodel != null)
				{
					MessageBox.Show("Path");
				}
				else if (ptemp_station != null)
				{
					RegistrationAgent.interfacePointer.updatePropertiesObjStation(ptemp_station);
				}
			}*/
            /*	string elementName = mouseWasDownOn.Name;
				if (elementName != "")
				{
					//MessageBox.Show("dds" + elementName);
					HalfPoint ptemp_halfpoint = RegistrationAgent.interfacePointer.findobjecthalfpoint(elementName);
					PathModel ptemp_pathmodel = RegistrationAgent.interfacePointer.findobjecthalfpath(elementName);
					Station ptemp_station = RegistrationAgent.interfacePointer.findobjectstation(elementName);
					if (ptemp_halfpoint != null)
					{
						RegistrationAgent.interfacePointer.removeobject(ptemp_halfpoint);
						ptemp_halfpoint = null;
					}
					else if (ptemp_pathmodel != null)
					{

					}
					else if (ptemp_station != null)
					{

					}
				}*/

        }

        private void updateProperties_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void updateProperties_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            MessageBox.Show("");
        }

        private void EditObject()
        {

            try
            {
                TextBlock NameObj = updateProperties.Columns[1].GetCellContent(updateProperties.Items[0]) as TextBlock;
                if (NameObj != null)
                {
                    HalfPoint ptemp_halfpoint = RegistrationAgent.interfacePointer.findobjecthalfpoint_updatevalue(NameObj.Text);
                    PathModel ptemp_pathmodel = RegistrationAgent.interfacePointer.findobjecthalfpath(NameObj.Text);
                    StationModel ptemp_station = RegistrationAgent.interfacePointer.findobjectstation_updatevalue(NameObj.Text);
                    ChargerModel ptemp_charger = RegistrationAgent.interfacePointer.findobjectcharger_updatevalue(NameObj.Text);
                    ReadyModel ptemp_ready = RegistrationAgent.interfacePointer.findobjectready_updatevalue(NameObj.Text);
                    CheckinModel ptemp_checkin = RegistrationAgent.interfacePointer.findobjectcheckin_updatevalue(NameObj.Text);
                    CheckoutModel ptemp_checkout = RegistrationAgent.interfacePointer.findobjectcheckout_updatevalue(NameObj.Text);
                    if (ptemp_halfpoint != null)
                    {
                        HalfPointProperties php = new HalfPointProperties(this, ptemp_halfpoint);
                        php.Show();
                    }
                    else if (ptemp_pathmodel != null)
                    {
                        PathProperties ppf = new PathProperties(this, ptemp_pathmodel);
                        ppf.Show();
                    }
                    else if (ptemp_station != null)
                    {
                        ptemp_station.ShowDialog();

                    }
                    else if (ptemp_charger != null)
                    {
                        ptemp_charger.ShowDialog();

                    }
                    else if (ptemp_ready != null)
                    {
                        ptemp_ready.ShowDialog();

                    }
                    else if (ptemp_checkin != null)
                    {
                        ptemp_checkin.ShowDialog();

                    }
                    else if (ptemp_checkout != null)
                    {
                        ptemp_checkout.ShowDialog();

                    }
                }
            }
            catch { }
        }

        public void updatePropertiesObjStation(StationModel ps)
        {

        }

        private void datagridValue_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void DataGridTextColumn_MouseLeave(object sender, MouseEventArgs e)
        {
        }

        private void trv_paths_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void trv_vehclies_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // double click to robot object to edit
            var hit = e.OriginalSource as DependencyObject;
            while (hit != null && !(hit is TreeViewItem))
                hit = VisualTreeHelper.GetParent(hit);
            if (hit == null)
                return;
            TreeViewItem tv_robot = hit as TreeViewItem;
            string header = tv_robot.Header.ToString().Split(new[] { " --- " }, StringSplitOptions.None)[0];
            if (header != "Vehicles")
            {
                RobotAgent ptempRobotAgent = RegistrationAgent.interfacePointer.findobjectrobot_updatevalue(tv_robot.Header.ToString().Split(new string[] { " --- " }, StringSplitOptions.None)[0]);
                ptempRobotAgent.Show();
            }
        }

        private void trv_points_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var hit = e.OriginalSource as DependencyObject;
            while (hit != null && !(hit is TreeViewItem))
                hit = VisualTreeHelper.GetParent(hit);
            if (hit == null)
                return;

            TreeViewItem tv_robot = hit as TreeViewItem;
            string header = tv_robot.Header.ToString().Split(new[] { " --- " }, StringSplitOptions.None)[0];
            if (header != "Point")
            {
                HalfPoint ptemphalfpoint = RegistrationAgent.interfacePointer.findobjecthalfpoint_updatevalue(tv_robot.Header.ToString());
                HalfPointProperties php = new HalfPointProperties(this, ptemphalfpoint);
                php.Show();
            }
        }

        private void trv_stations_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var hit = e.OriginalSource as DependencyObject;
            while (hit != null && !(hit is TreeViewItem))
                hit = VisualTreeHelper.GetParent(hit);
            if (hit == null)
                return;
            TreeViewItem tv_robot = hit as TreeViewItem;
            string header = tv_robot.Header.ToString().Split(new[] { " --- " }, StringSplitOptions.None)[0];
            if (header != "Station")
            {
                StationModel ptempstation = RegistrationAgent.interfacePointer.findobjectstation_updatevalue(header);
                ptempstation.ShowDialog();
            }
        }



        private void trv_ready_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var hit = e.OriginalSource as DependencyObject;
            while (hit != null && !(hit is TreeViewItem))
                hit = VisualTreeHelper.GetParent(hit);
            if (hit == null)
                return;
            TreeViewItem tv_robot = hit as TreeViewItem;
            string header = tv_robot.Header.ToString().Split(new[] { " --- " }, StringSplitOptions.None)[0];
            if (header != "Ready")
            {
                ReadyModel ptempready = RegistrationAgent.interfacePointer.findobjectready_updatevalue(tv_robot.Header.ToString().Split(new[] { " --- " }, StringSplitOptions.None)[0]);
                ptempready.ShowDialog();
            }
        }

        private void trv_checkin_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var hit = e.OriginalSource as DependencyObject;
            while (hit != null && !(hit is TreeViewItem))
                hit = VisualTreeHelper.GetParent(hit);
            if (hit == null)
                return;
            TreeViewItem tv_robot = hit as TreeViewItem;
            string header = tv_robot.Header.ToString().Split(new[] { " --- " }, StringSplitOptions.None)[0];
            if (header != "Checkin")
            {
                CheckinModel ptempcheckin = RegistrationAgent.interfacePointer.findobjectcheckin_updatevalue(tv_robot.Header.ToString().Split(new[] { " --- " }, StringSplitOptions.None)[0]);
                ptempcheckin.ShowDialog();
            }
        }

        private void trv_checkout_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var hit = e.OriginalSource as DependencyObject;
            while (hit != null && !(hit is TreeViewItem))
                hit = VisualTreeHelper.GetParent(hit);
            if (hit == null)
                return;
            TreeViewItem tv_robot = hit as TreeViewItem;
            string header = tv_robot.Header.ToString().Split(new[] { " --- " }, StringSplitOptions.None)[0];
            if (header != "Checkout")
            {
                CheckoutModel ptempcheckout = RegistrationAgent.interfacePointer.findobjectcheckout_updatevalue(tv_robot.Header.ToString().Split(new[] { " --- " }, StringSplitOptions.None)[0]);
                ptempcheckout.ShowDialog();
            }
        }

        private void trv_charger_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var hit = e.OriginalSource as DependencyObject;
            while (hit != null && !(hit is TreeViewItem))
                hit = VisualTreeHelper.GetParent(hit);
            if (hit == null)
                return;
            TreeViewItem tv_robot = hit as TreeViewItem;
            string header = tv_robot.Header.ToString().Split(new[] { " --- " }, StringSplitOptions.None)[0];
            if (header != "Charger")
            {
                ChargerModel ptempcharger = RegistrationAgent.interfacePointer.findobjectcharger_updatevalue(tv_robot.Header.ToString().Split(new[] { " --- " }, StringSplitOptions.None)[0]);
                ptempcharger.ShowDialog();
            }
        }


        

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (probot3dmap != null)
            {
                probot3dmap.pconnectrobot.close();
            }
            System.Windows.Forms.DialogResult pwarming = System.Windows.Forms.MessageBox.Show("Save changes to the following items ?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning);
            if (pwarming == System.Windows.Forms.DialogResult.Yes)
            {
                SaveModel.savedata();
            }
            else if (pwarming == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
        }

        private void ipscan_Click(object sender, RoutedEventArgs e)
        {
            IpScanner pp = new IpScanner();
            pp.Show();
        }

        private void setting_Click(object sender, RoutedEventArgs e)
        {

            ptaskManager.Show();
        }


        private void checkinpoint_Click(object sender, RoutedEventArgs e)
        {

            valstatectrl_md = STATECTRL_MOUSEDOWN.STATECTRL_ADD_CHECKINPOINT;
        }

        private void checkoutpoint_Click(object sender, RoutedEventArgs e)
        {

            valstatectrl_md = STATECTRL_MOUSEDOWN.STATECTRL_ADD_CHECKOUTPOINT;
        }

        private void halfpoint_Click(object sender, RoutedEventArgs e)
        {
            valstatectrl_md = STATECTRL_MOUSEDOWN.STATECTRL_ADD_HALFPOINT;

        }

        private void oderManager_Click(object sender, RoutedEventArgs e)
        {
            //CreateAreaAgent pcreateAreaAgent = new CreateAreaAgent();
            //pcreateAreaAgent.Show();
        }

        private void iprun_Click(object sender, RoutedEventArgs e)
        {
            TrafficForm ptf = new TrafficForm();
            ptf.Show();
        }

        private void groupbox_Click(object sender, RoutedEventArgs e)
        {
            RegistrationAgent.groupModelPointer.Show();
        }

        private void loadtask_Click(object sender, RoutedEventArgs e)
        {
            //TaskRegistration p = new TaskRegistration(RegistrationAgent.interfacePointer);
            //p.Show();
        }

        private void btn_group_Click(object sender, RoutedEventArgs e)
        {
            GroupPathModels groupPathModel = new GroupPathModels();
            groupPathModel.Show();
        }

        private void autoScrollLog_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void clearLog_Clicked(object sender, RoutedEventArgs e)
        {
            TabItem ti = tabControl_main.SelectedItem as TabItem;
            if (ti.Header.Equals("Log Order"))
            {
                logOrder.Document.Blocks.Clear();
            }
            else if (ti.Header.Equals("Log Robot"))
            {
                logRobot.Document.Blocks.Clear();
            }
            else if (ti.Header.Equals("Log Station"))
            {
                logStation.Document.Blocks.Clear();
            }
            else if (ti.Header.Equals("Error"))
            {
                errorConsole.Document.Blocks.Clear();
            }
            else if (ti.Header.Equals("Warning"))
            {
                warningConsole.Document.Blocks.Clear();
            }
        }

        private void clipBorder_MouseWheel(object sender, MouseWheelEventArgs e)
        {

            //double zoomDirection = e.Delta > 0 ? 1 : -1;
            //slidingScale = 0.1 * zoomDirection;
            ////LogConsole(zoomDirection + "-     slidingScale:" + slidingScale + "-      ScaleX:" + canvasScaleTransform.ScaleX + "-      ScaleY:" + canvasScaleTransform.ScaleY);
            //if (((canvasScaleTransform.ScaleY + slidingScale) >= 0.4) && ((canvasScaleTransform.ScaleY + slidingScale) <= 2))
            //{
            //canvasScaleTransform.ScaleX = canvasScaleTransform.ScaleY += slidingScale;
            //}
            ////LogConsole(zoomDirection + "--slidingScale: " + slidingScale + "--ScaleX: " + canvasScaleTransform.ScaleX + "--ScaleY: " + canvasScaleTransform.ScaleY);
        }

        private void map_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var mouseWasDownOn = e.Source as FrameworkElement;
            if (e.Source.ToString() == "System.Windows.Controls.Canvas")
            {
                map.CaptureMouse();
                startPoint = e.GetPosition(clipBorder);
                originalPoint = new Point(canvasTranslateTransform.X, canvasTranslateTransform.Y);
            }
            statectrl_md(e);
        }

        private void map_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            map.ReleaseMouseCapture();
        }
        private void map_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseMove)
            {
                if (!map.IsMouseCaptured) return;
                //RobotStore

                Vector moveVector = startPoint - e.GetPosition(clipBorder);
                //canvasTranslateTransform.X = originalPoint.X - moveVector.X;
                //canvasTranslateTransform.Y = originalPoint.Y - moveVector.Y;
                //LogConsole((originalPoint.X - moveVector.X).ToString());
                //LogConsole((originalPoint.Y - moveVector.Y).ToString());
                double xCoor = originalPoint.X - moveVector.X;
                double yCoor = originalPoint.Y - moveVector.Y;
                //canvasTranslateTransform.X = originalPoint.X - moveVector.X;
                //canvasTranslateTransform.Y = originalPoint.Y - moveVector.Y;
                double verticalLimimit = ((map.Height - clipBorder.ActualHeight) / 2) + 20;
                double horizontalLimit = ((map.Width - clipBorder.ActualWidth) / 2) + 20;
                if (((xCoor < horizontalLimit) && (xCoor > -horizontalLimit)))
                {
                    canvasTranslateTransform.X = originalPoint.X - moveVector.X;
                    //canvasTranslateTransform.Y = originalPoint.Y - moveVector.Y;
                }
                else
                {
                    if (originalPoint.X > horizontalLimit)
                    {
                        canvasTranslateTransform.X = horizontalLimit;
                    }
                    if (originalPoint.X < -horizontalLimit)
                    {
                        canvasTranslateTransform.X = horizontalLimit;
                    }
                }
                if (((yCoor < verticalLimimit) && (yCoor > -verticalLimimit)))
                {
                    //canvasTranslateTransform.X = originalPoint.X - moveVector.X;
                    canvasTranslateTransform.Y = originalPoint.Y - moveVector.Y;
                }
                else
                {
                    if (originalPoint.Y > verticalLimimit)
                    {
                        canvasTranslateTransform.Y = verticalLimimit;
                    }
                    if (originalPoint.Y < -verticalLimimit)
                    {
                        canvasTranslateTransform.Y = verticalLimimit;
                    }
                }



            }

            //LogConsole("StartPoint: " + startPoint + "--MoveVector: " + moveVector + "--Canvas:" + canvasTranslateTransform.X.ToString() + ":" + canvasTranslateTransform.Y.ToString() + "--Original:" + originalPoint.X.ToString() + ":" + originalPoint.Y.ToString());
            if (!MouseMove)
            {
                statectrl_mm(e);
            }
        }

        private void AddPutAway_Click(object sender, RoutedEventArgs e)
        {

        }


        private void move_click(object sender, RoutedEventArgs e)
        {
            Normal_mode();
            MouseMove = !MouseMove;
            MoveToggle(MouseMove);
        }


        void MoveToggle(bool move)
        {

            MouseMove = move;
            if (MouseMove)
            {
                var uriSource = new Uri("pack://siteoforigin:,,,/Resources/phat_handclose.png");
                moveHand.Source = new BitmapImage(uriSource);
                ProgramStatus.Text = "Map move";
            }
            else
            {
                var uriSource = new Uri("pack://siteoforigin:,,,/Resources/phat_handopen.png");
                moveHand.Source = new BitmapImage(uriSource);

            }
        }

        public void Select_mode()
        {
            valstatectrl_mm = STATECTRL_MOUSEMOVE.STATECTRL_SLIDE_OBJECT;
            valstatectrl_md = STATECTRL_MOUSEDOWN.STATECTRL_KEEP_IN_OBJECT;
            ProgramStatus.Text = "Ready";
        }

        public void Normal_mode()
        {
            valstatectrl_mm = STATECTRL_MOUSEMOVE.STATECTRL_MOVE_NORMAL;
            valstatectrl_md = STATECTRL_MOUSEDOWN.STATECTRL_MOUSEDOWN_NORMAL;
            ProgramStatus.Text = "Ready";
        }



        private void SelectedClick(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            //TreeViewItem selectedItem = mTreeView.SelectedItem as TreeViewItem;
            //ContextMenu contextMenu = new ContextMenu();

            //MenuItem menuItem = new MenuItem { Header = "Insert" };
            //menuItem.Click += OptionClick;

            //if (selectedItem.Focus())
            //{
            //    if (selectedItem.Header == null)
            //        return;

            //    switch (selectedItem.Header.ToString())
            //    {
            //        case "Vehicles":
            //            selectedItem.ContextMenu = contextMenu;
            //            contextMenu.Items.Add(new MenuItem().Header = "Edit");
            //            contextMenu.Items.Add(new MenuItem().Header = "View");
            //            contextMenu.Items.Add(new MenuItem().Header = "Properties");
            //            contextMenu.Items.Add(menuItem);
            //            break;

            //        case "Path":
            //            selectedItem.ContextMenu = contextMenu;
            //            contextMenu.Items.Add(new MenuItem().Header = "Edit");
            //            contextMenu.Items.Add(new MenuItem().Header = "View");
            //            contextMenu.Items.Add(new MenuItem().Header = "Properties");
            //            break;

            //        case "Point":
            //            selectedItem.ContextMenu = contextMenu;
            //            contextMenu.Items.Add(new MenuItem().Header = "Edit");
            //            contextMenu.Items.Add(new MenuItem().Header = "View");
            //            contextMenu.Items.Add(new MenuItem().Header = "Properties");
            //            break;

            //        case "Station":
            //            selectedItem.ContextMenu = contextMenu;
            //            contextMenu.Items.Add(new MenuItem().Header = "Edit");
            //            contextMenu.Items.Add(new MenuItem().Header = "View");
            //            contextMenu.Items.Add(new MenuItem().Header = "Properties");
            //            break;
            //        default:
            //            selectedItem.ContextMenu = contextMenu;
            //            selectedItem.ContextMenu.Visibility = Visibility.Hidden;
            //            break;
            //    }
            //}
        }

        void OptionClick(object sender, RoutedEventArgs e)
        {
            //Code 5
        }

        private void trv_highway_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void trv_highway_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void higwayadd_Click(object sender, RoutedEventArgs e)
        {
            RegistrationAgent.interfacePointer.addHighWay();
        }


        private void treeviewmenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Properties_selected_Click(object sender, RoutedEventArgs e)
        {
            TreeViewItem tempTrv = mTreeView.SelectedItem as TreeViewItem;
            string header = tempTrv.Header.ToString().Split(new[] { " --- " }, StringSplitOptions.None)[0];
            switch (header.Substring(0, 3))
            {
                case "PAW":
                    {
                        StationModel ptempstation = RegistrationAgent.interfacePointer.findobjectstation_updatevalue(header);
                        if (ptempstation != null)
                        {
                            ptempstation.ShowDialog();
                        }
                        break;
                    }
                case "DCK":
                    {
                        StationModel ptempstation = RegistrationAgent.interfacePointer.findobjectstation_updatevalue(header);
                        if (ptempstation != null)
                        {
                            ptempstation.ShowDialog();
                        }
                        break;
                    }
                case "MIX":
                    {
                        StationModel ptempstation = RegistrationAgent.interfacePointer.findobjectstation_updatevalue(header);
                        if (ptempstation != null)
                        {
                            ptempstation.ShowDialog();
                        }
                        break;
                    }
                case "CKI":
                    {
                        CheckinModel ptempstation = RegistrationAgent.interfacePointer.findobjectcheckin(header);
                        if (ptempstation != null)
                        {
                            ptempstation.ShowDialog();
                        }
                        break;
                    }
                case "CKO":
                    {
                        CheckoutModel ptempstation = RegistrationAgent.interfacePointer.findobjectcheckout(header);
                        if (ptempstation != null)
                        {
                            ptempstation.ShowDialog();
                        }
                        break;
                    }
                case "RDY":
                    {
                        ReadyModel ptempstation = RegistrationAgent.interfacePointer.findobjectready(header);
                        if (ptempstation != null)
                        {
                            ptempstation.ShowDialog();
                        }
                        break;
                    }
                case "CHG":
                    {
                        ChargerModel ptempstation = RegistrationAgent.interfacePointer.findobjectcharger(header);
                        if (ptempstation != null)
                        {
                            ptempstation.ShowDialog();
                        }
                        break;
                    }
                case "RBO":
                    {
                        RobotAgent ptempstation = RegistrationAgent.interfacePointer.findobjectrobot_treeview(header);
                        if (ptempstation != null)
                        {
                            ptempstation.ShowDialog();
                        }
                        break;
                    }
                case "HPA":
                    {
                        PathModel ptempstation = RegistrationAgent.interfacePointer.findobjecthalfpath_treeview(header);
                        if (ptempstation != null)
                        {
                            //ptempstation.ShowDialog();
                        }
                        break;
                    }

                default:
                    {
                        break;
                    }
            }



        }

        private void Control_selected_Click(object sender, RoutedEventArgs e)
        {
            TreeViewItem tempTrv = mTreeView.SelectedItem as TreeViewItem;
            string header = tempTrv.Header.ToString().Split(new[] { " --- " }, StringSplitOptions.None)[0];
            switch (header.Substring(0, 3))
            {
                case "RBO":
                    {
                        RobotAgent pr = RegistrationAgent.robotAgentRegisteredList[header];
                        RobotControl robotControl = new RobotControl(pr);
                        robotControl.ShowDialog();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void Delete_selected_Click(object sender, RoutedEventArgs e)
        {
            TreeViewItem tempTrv = mTreeView.SelectedItem as TreeViewItem;
            string header = tempTrv.Header.ToString().Split(new[] { " --- " }, StringSplitOptions.None)[0];
            switch (header.Substring(0, 3))
            {
                case "PAW":
                    {
                        StationModel ptemp = RegistrationAgent.interfacePointer.findobjectstation_updatevalue(header);
                        if (ptemp != null)
                        {
                            RegistrationAgent.interfacePointer.removeobject_station(ptemp);
                            ptemp = null;
                            trv_stations.Items.Remove(mTreeView.SelectedItem);
                        }
                        break;
                    }
                case "DCK":
                    {
                        StationModel ptemp = RegistrationAgent.interfacePointer.findobjectstation_updatevalue(header);
                        if (ptemp != null)
                        {
                            RegistrationAgent.interfacePointer.removeobject_station(ptemp);
                            ptemp = null;
                            trv_stations.Items.Remove(mTreeView.SelectedItem);
                        }
                        break;
                    }
                case "MIX":
                    {
                        StationModel ptemp = RegistrationAgent.interfacePointer.findobjectstation_updatevalue(header);
                        if (ptemp != null)
                        {
                            RegistrationAgent.interfacePointer.removeobject_station(ptemp);
                            ptemp = null;
                            trv_stations.Items.Remove(mTreeView.SelectedItem);
                        }
                        break;
                    }
                case "CKI":
                    {
                        CheckinModel ptemp = RegistrationAgent.interfacePointer.findobjectcheckin(header);
                        if (ptemp != null)
                        {
                            RegistrationAgent.interfacePointer.removeobject_checkin(ptemp);
                            ptemp = null;
                            mTreeView.Items.Remove(mTreeView.SelectedItem);
                        }
                        break;
                    }
                case "CKO":
                    {
                        CheckoutModel ptemp = RegistrationAgent.interfacePointer.findobjectcheckout(header);
                        if (ptemp != null)
                        {
                            RegistrationAgent.interfacePointer.removeobject_checkout(ptemp);
                            ptemp = null;
                            mTreeView.Items.Remove(mTreeView.SelectedItem);
                        }
                        break;
                    }
                case "RDY":
                    {
                        ReadyModel ptemp = RegistrationAgent.interfacePointer.findobjectready(header);
                        if (ptemp != null)
                        {
                            RegistrationAgent.interfacePointer.removeobject_ready(ptemp);
                            ptemp = null;
                            mTreeView.Items.Remove(mTreeView.SelectedItem);
                        }
                        break;
                    }
                case "CHG":
                    {
                        ChargerModel ptemp = RegistrationAgent.interfacePointer.findobjectcharger(header);
                        if (ptemp != null)
                        {
                            RegistrationAgent.interfacePointer.removeobject_charger(ptemp);
                            ptemp = null;
                            mTreeView.Items.Remove(mTreeView.SelectedItem);
                        }
                        break;
                    }
                case "RBO":
                    {
                        RobotAgent ptemp = RegistrationAgent.interfacePointer.findobjectrobot_treeview(header);
                        if (ptemp != null)
                        {
                            RegistrationAgent.interfacePointer.removeobject_robotagent(ptemp);
                            ptemp = null;
                            mTreeView.Items.Remove(mTreeView.SelectedItem);
                        }
                        break;
                    }
                case "PAH":
                    {
                        //PathModel ptemp = RegistrationAgent.interfacePointer.findobjecthalfpath_treeview(header);
                        //if (ptemp != null)
                        //{
                        //    RegistrationAgent.interfacePointer.removeobject_Halfpoint(ptemp);
                        //    ptemp = null;
                        //    mTreeView.Items.Remove(mTreeView.SelectedItem);
                        //}
                        break;
                    }
                case "HPO":
                    {
                        //PathModel ptemp = RegistrationAgent.interfacePointer.findobjecthalfpath_treeview(header);
                        //if (ptemp != null)
                        //{
                        //    RegistrationAgent.interfacePointer.removeobject_Halfpoint(ptemp);
                        //    ptemp = null;
                        //    mTreeView.Items.Remove(mTreeView.SelectedItem);
                        //}
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
        }

        

        private void trv_items_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var hit = e.OriginalSource as DependencyObject;
            while (hit != null && !(hit is TreeViewItem))
                hit = VisualTreeHelper.GetParent(hit);
            if (hit == null)
                return;
            TreeViewItem tv_station = hit as TreeViewItem;
            string header = tv_station.Header.ToString().Split(new[] { " --- " }, StringSplitOptions.None)[0];
            if (!header.Equals("Vehicles") &&
                !header.Equals("Path") &&
                !header.Equals("HighWay") &&
                !header.Equals("Point") &&
                !header.Equals("Station") &&
                !header.Equals("Charger") &&
                !header.Equals("Ready") &&
                !header.Equals("Checkin") &&
                !header.Equals("Checkout"))
            {
                //MessageBox.Show(tv_station.Header.ToString());
                tv_station.IsSelected = true;
                ContextMenu cm = this.FindResource("TREEVIEW-MENU") as ContextMenu;
                cm.PlacementTarget = sender as TreeViewItem;
                cm.IsOpen = true;
            }
        }

        private void Dynamic_menu_option_enable(object sender, ContextMenuEventArgs e)
        {
            TreeViewItem tempTrv = mTreeView.SelectedItem as TreeViewItem;
            string header = tempTrv.Header.ToString().Split(new[] { " --- " }, StringSplitOptions.None)[0];
            if (header.Substring(0, 3).Equals("RBO"))
            {
                ((sender as ContextMenu).Items[0] as MenuItem).IsEnabled = true;
                return;
            }

            if (header.Substring(0, 3).Equals("PAW") || 
                header.Substring(0, 3).Equals("DCK") || 
                header.Substring(0, 3).Equals("MIX") || 
                header.Substring(0, 3).Equals("CKI") || 
                header.Substring(0, 3).Equals("CKO") || 
                header.Substring(0, 3).Equals("RDY") || 
                header.Substring(0, 3).Equals("CHG"))
            {
                ((sender as ContextMenu).Items[0] as MenuItem).IsEnabled = false;
            }

        }

        private void statistic_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string howtogeek = "[n/a]";
                IPAddress[] addresslist = Dns.GetHostAddresses(howtogeek);

                foreach (IPAddress theaddress in addresslist)
                {
                    Console.WriteLine(theaddress.ToString());
                }
            }
            catch { }
        }
    }


    public class User
    {
        public String Attribude { get; set; }

        public string Value { get; set; }

    }

}
