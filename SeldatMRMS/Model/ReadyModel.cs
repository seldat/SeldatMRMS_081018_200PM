using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SeldatMRMS.Model
{
    public partial class ReadyModel : Form
    {

        public struct ReadyCtrl
        {
            public int numRobotInside;
            public int numRobotfilled;
        }
        
        public ReadyModel(MainWindow content, String type)
        {
            InitializeComponent();
            props.area = "0";
            this.content = content;
            connectedPath_head = new List<PathModel>();
            flag_headtail = new List<FLAGPOINTDEFINED>();
            img = new Image();
            String m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            bmp = new BitmapImage(new Uri(m_exePath + "//Resources//phat_ready.png"));
            props.TypeName = type;
            img.Source = this.bmp;
            plabel.Width = 50;
            setColorLabel(Colors.Red);
            this.content.map.Children.Add(plabel);
            lineInfo = new LineInfo();
        }

        private void Ready_Load(object sender, EventArgs e)
        {
            dgvProperties_setting();
        }

        void dgvProperties_setting()
        {
            dGV_properties.Rows.Clear();
            dGV_properties.Rows.Add("Name", props.NameID);
            dGV_properties.Rows.Add("Label", props.label);
            dGV_properties.Rows.Add("Area", "0");
        }

        public void setReadyNAME(String name)
        {
            dGV_properties.Rows[0].Cells[1].Value = name;
        }
        public String getReadyNAME()
        {
            return (dGV_properties.Rows[0].Cells[1].Value != null) ? (String)dGV_properties.Rows[0].Cells[1].Value : "";
        }

        public void setReadyLB(String lb)
        {
            dGV_properties.Rows[1].Cells[1].Value = lb;
        }
        public String getReadyLB()
        {
            return (dGV_properties.Rows[1].Cells[1].Value != null) ? (String)dGV_properties.Rows[1].Cells[1].Value : "";
        }


        

        public void setReadyArea(String port)
        {
            dGV_properties.Rows[2].Cells[1].Value = port;
        }
        public String getReadyArea()
        {
            return (dGV_properties.Rows[2].Cells[1].Value != null) ? (String)dGV_properties.Rows[2].Cells[1].Value : "";
        }

        public struct Properties
        {
            public int port;
            public int idnum;
            public double X, Y;
            public string area;
            public String label;
            public String NameKey;
            public String NameID;
            public String addressIP;
            public double realX, realY;
            public double X_model, Y_model;
            public Point location;
            public String TypeName;
        }

        public enum FLAGPOINTDEFINED
        {
            FLAGPOINT_SET_STARTPOINT,
            FLAGPOINT_SET_ENDPOINT
        }
        MainWindow content;

        public const int TYPE_STATION_CHARGE = 100;
        public const int TYPE_STATION_PICKUP = 101;
        public const int TYPE_STATION_PICKDOWN = 102;
        public double Width, Height;
        public Properties props;
        public TextBlock plabel = new TextBlock();
        public CheckInPoint checkInPoint;
        public CheckOutPoint checkOutPoint;
        public LineInfo lineInfo;
        private List<PathModel> connectedPath_head;
        private List<FLAGPOINTDEFINED> flag_headtail;
        BitmapImage bmp;
        Image img;

        public void setReady(double x, double y)
        {

            props.X = x;
            props.Y = y;
            img.Width = 50;
            img.Height = 50;
            img.SetValue(Canvas.LeftProperty, x);
            img.SetValue(Canvas.TopProperty, y);
            TranslateTransform ptrans = new TranslateTransform();
            ptrans.X = -25;
            ptrans.Y = -25;
            img.RenderTransform = ptrans;
            setLabel(props.label);
            this.content.map.Children.Add(img);
            props.NameKey = props.NameID + " --- " + props.label;

        }
        public void setnewpos(double x, double y)
        {
            props.X = x;
            props.Y = y;
            img.SetValue(Canvas.LeftProperty, x);
            img.SetValue(Canvas.TopProperty, y);
            TranslateTransform ptrans = new TranslateTransform();
            ptrans.X = -25;
            ptrans.Y = -25;
            img.RenderTransform = ptrans;
            plabel.SetValue(Canvas.LeftProperty, props.X - 15);
            plabel.SetValue(Canvas.TopProperty, props.Y - 40);
            setLabel(props.label);
        }
        public void ondraw()
        {
            this.content.map.Children.Add(img);
        }
        public void setText(String text)
        {
            props.label = text;
            props.NameKey = props.NameID + " --- " + props.label;
        }
        public void setLabel(String label)
        {

            props.label = label;

            plabel.Text = label;

            plabel.Foreground = new SolidColorBrush(Colors.White);
            plabel.SetValue(Canvas.LeftProperty, props.X);
            plabel.SetValue(Canvas.TopProperty, props.Y - 40);
            plabel.TextAlignment = System.Windows.TextAlignment.Center;
            TranslateTransform ptrans = new TranslateTransform();
            ptrans.X = -plabel.Width / 2;
            ptrans.Y = -10;
            plabel.RenderTransform = ptrans;
            props.NameKey = props.NameID + " --- " + props.label;
        }
        public void setColorLabel(Color color)
        {
            // green is connected
            // red is disdconnected
            plabel.Background = new SolidColorBrush(color);
        }
        public void Getpath(PathModel pathmodel, FLAGPOINTDEFINED fp)
        {
            if (pathmodel != null)
            {
                connectedPath_head.Add(pathmodel);
                flag_headtail.Add(fp);
            }
        }
        public void setlabelcolor(Color pcl)
        {
            plabel.Foreground = new SolidColorBrush(pcl);
        }
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
                            if (connectedPath_head[index].properties.PathType == PathModel.PATH_TYPE_DIRECT)
                            {
                                connectedPath_head[index].drawdirectpath(new System.Windows.Point(props.X, props.Y), connectedPath_head[index].endpos);
                            }
                            else if (connectedPath_head[index].properties.PathType == PathModel.PATH_TYPE_BEZIERSEGMENT)
                            {
                                connectedPath_head[index].drawbezierpath(new System.Windows.Point(props.X, props.Y), connectedPath_head[index].middlepos, connectedPath_head[index].endpos);
                            }
                            else if (connectedPath_head[index].properties.PathType == PathModel.PATH_TYPE_LINK)
                            {
                                connectedPath_head[index].drawdirectpath(new System.Windows.Point(props.X, props.Y), connectedPath_head[index].endpos);
                            }
                        }
                        if (flag_headtail[index] == FLAGPOINTDEFINED.FLAGPOINT_SET_ENDPOINT)
                        {
                            if (connectedPath_head[index].properties.PathType == PathModel.PATH_TYPE_DIRECT)
                            {
                                connectedPath_head[index].drawdirectpath(connectedPath_head[index].startpos, new System.Windows.Point(props.X, props.Y));
                            }
                            else if (connectedPath_head[index].properties.PathType == PathModel.PATH_TYPE_BEZIERSEGMENT)
                            {
                                connectedPath_head[index].drawbezierpath(connectedPath_head[index].startpos, connectedPath_head[index].middlepos, new System.Windows.Point(props.X, props.Y));
                            }
                            else if (connectedPath_head[index].properties.PathType == PathModel.PATH_TYPE_LINK)
                            {
                                connectedPath_head[index].drawdirectpath(connectedPath_head[index].startpos, new System.Windows.Point(props.X, props.Y));
                            }
                        }
                    }

                }
            }

        }
        public bool FindName(String name)
        {
            if (name.Equals(props.NameID))
                return true;
            else
                return false;
        }
        //public void setid(int id)
        //{
        //    properties.idnum = id;
        //}
        public void setName(String name)
        {
            props.NameID = name;
            img.Name = name;
            //checkInPoint.properties.key = "CIA-"+name;
            //checkOutPoint.properties.key = "COA-"+name;
        }
        public void removeobject()
        {
            if (img != null)
            {
                this.content.map.Children.Remove(img);
                this.content.map.Children.Remove(plabel);

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
            if (img != null)
            {
                this.content.map.Children.Remove(img);
                this.content.map.Children.Remove(plabel);
            }
        }
        public JObject createJsonstring()
        {
            dynamic product = new JObject();
            product.Name = props.NameID;
            product.Label = props.label;
            product.Type = props.TypeName;
            product.posX = props.X;
            product.posY = props.Y;
            return product;

        }

        public bool Connection()
        {
            //properties.rosSocket = new RosSocket("ws://" + properties.camparam_temp.agentIP + ":" + properties.camparam_temp.agentPORT);
            //if (!properties.rosSocket.webSocket.IsAlive)
            //{
            //    return false;
            //}
            //int subscription_id = properties.rosSocket.Subscribe("/pallet_status_" + properties.camparam_temp.agentID, "std_msgs/String", subscriptionHandler);
            return true;
        }

        public bool Connect()
        {
            //if (!Connection())
            //{
            //    RegistrationAgent.mainWindowPointer.LogConsole("Can not connect to " + properties.TypeName + " Agent!");
            //    return false;
            //}
            //properties.camparam = properties.camparam_temp;
            //RegistrationAgent.mainWindowPointer.LogConsole(properties.TypeName + " Agent Connected!");
            return true;
        }

        private void Ready_Shown(object sender, EventArgs e)
        {
            setReadyNAME(this.props.NameID);
            setReadyLB(this.props.label);
            //txt_station_length.Text = this.properties.LengthValue.ToString();
            //txt_station_cost.Text = this.properties.CostValue.ToString();
            //txt_station_xmodel.Text = properties.X_model.ToString();
            //txt_station_ymodel.Text = properties.Y_model.ToString();
            //setID(properties.camparam.agentID);
            //setIP(properties.camparam.agentIP);
            //setPORT(properties.camparam.agentPORT);
            //setArea(properties.camparam.areaID);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            // MessageBox.Show( dGV_properties.Rows[4].Cells[1].Value+"");
            this.Hide();
        }

        private void btn_lineInfo_Click(object sender, EventArgs e)
        {
            lineInfo.ShowDialog();
        }

        private void dGV_properties_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ReadyModel_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            props.NameID = getReadyNAME();
            props.label = getReadyLB();
            //properties.LengthValue = Double.Parse(txt_station_length.Text);
            //properties.CostValue = Double.Parse(txt_station_cost.Text);
            //properties.X_model = Double.Parse(txt_station_xmodel.Text);
            ////properties.Y_model = Double.Parse(txt_station_ymodel.Text);
            //properties.camparam.agentID = getID();
            //properties.camparam.agentIP = getIP();
            //properties.camparam.agentPORT = getPORT();
            //properties.camparam.areaID = getArea();
        }

    }
}
