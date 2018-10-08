using Newtonsoft.Json.Linq;
using SeldatMRMS.Communication;
using SeldatMRMS.Management;
using SeldatMRMS.Management.OrderManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SeldatMRMS.Model
{
    public partial class StationModel : Form
    {

        public struct StationCtrl
        {
            public int numRobotInside;
            public int numRobotfilled;
        }

        public class Camera
        {
            public Camera()
            {
                area = "-1";
                id = "-1";
                numLs = -1;
                numPsPL = -1;
                lineArray = new SortedDictionary<String, LineInfo>(); // <lineID>,<Line>
                valid = false;
            }
            public string area;
            public string id;
            public string ip;
            public string port;
            public int numLs;
            public int numPsPL;
            public SortedDictionary<String, LineInfo> lineArray; // <lineID>,<Line>
            public bool valid;
        }

        public class LineInfo
        {
            public LineInfo()
            {
                valid = true;
                palletWarning = "none";
                palletArray = new SortedDictionary<string, string>();
            }
            public bool valid;
            public string palletWarning;
            public SortedDictionary<String, String> palletArray;// <palletID>,<yes/no>
        }

        public struct Properties
        {
            public int port;
            public int id;
            public double X, Y;
            public String type;
            public string area;
            public String label;
            public String NameKey;
            public String NameID;
            public String typeName;
            public double costValue;
            public String addressIP;
            public bool isConnected;
            public double lengthValue;
            public double Xcenter, Ycenter;
            public double X_model, Y_model;
            public List<bool> palletStatusArray;
            public Camera cam;
        }
        public enum FLAGPOINTDEFINED
        {
            FLAGPOINT_SET_STARTPOINT,
            FLAGPOINT_SET_ENDPOINT
        }

        public RosSocket rosSocket;
        public const int TYPE_STATION_CHARGE = 100;
        public const int TYPE_STATION_PICKUP = 101;
        public const int TYPE_STATION_PICKDOWN = 102;
        //public double Width, Height;
        public Properties props;
        public TextBlock plabel = new TextBlock();
        public CheckInPoint checkInPoint;
        public CheckOutPoint checkOutPoint;
        public Model.LineInfo lineInfo;
        private List<PathModel> connectedPath_head;
        private List<FLAGPOINTDEFINED> flag_headtail;
        BitmapImage bmp;
        Image img;


        public StationModel() { }
        public StationModel(MainWindow content, String type)
        {
            InitializeComponent();
            img = new Image();
            props.cam = new Camera();
            props.area = "0";
            props.type = type;
            props.isConnected = false;
            connectedPath_head = new List<PathModel>();
            flag_headtail = new List<FLAGPOINTDEFINED>();
            String m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            switch (type)
            {
                case "PUTAWAY":
                    {
                        bmp = new BitmapImage(new Uri(m_exePath + "//Resources//phat_putaway.png"));
                        props.typeName = "PUTAWAY";
                        break;
                    }
                case "DOCKING":
                    {
                        bmp = new BitmapImage(new Uri(m_exePath + "//Resources//phat_docking.png"));
                        props.typeName = "DOCKING";
                        break;
                    }
                case "MIXED":
                    {
                        bmp = new BitmapImage(new Uri(m_exePath + "//Resources//phat_mixed.png"));
                        props.typeName = "MIXED";
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            img.Source = this.bmp;
            plabel.Width = 50;
            setColorLabel(Colors.Red);
            RegistrationAgent.mainWindowPointer.map.Children.Add(plabel);
            lineInfo = new Model.LineInfo();
            rosSocket = new RosSocket();
            timerCheckConnection.Start();
        }

        private void Station_Load(object sender, EventArgs e)
        {
            dgvProperties_setting();
            setStationNAME(this.props.NameID);
            setStationLB(this.props.label);
            setCamId(props.cam.id);
            setCamIp(props.cam.ip);
            setCamPort(props.cam.port);
            setStationArea(props.cam.area);
            this.Text = props.typeName;
        }

        void dgvProperties_setting()
        {
            dGV_properties.Rows.Clear();

                        dGV_properties.Rows.Add("Name", props.NameID);
                        dGV_properties.Rows.Add("Label",props.label);
                        dGV_properties.Rows.Add("Camera");
                        dGV_properties.Rows[2].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                        dGV_properties.Rows.Add("ID", "0");
                        dGV_properties.Rows.Add("IP", "192.168.1.");
                        dGV_properties.Rows.Add("Port", "9090");
                        dGV_properties.Rows.Add("Area", "0");

        }

        //===========================================================================
        public void setStationNAME(String name)
        {
            dGV_properties.Rows[0].Cells[1].Value = name;
        }
        public String getStationNAME()
        {
            return (dGV_properties.Rows[0].Cells[1].Value != null) ? (String)dGV_properties.Rows[0].Cells[1].Value : "";
        }

        public void setStationLB(String lb)
        {
            dGV_properties.Rows[1].Cells[1].Value = lb;
        }
        public String getStationLB()
        {
            return (dGV_properties.Rows[1].Cells[1].Value != null) ? (String)dGV_properties.Rows[1].Cells[1].Value : "";
        }
        
        public void setCamId(String id)
        {
            dGV_properties.Rows[3].Cells[1].Value = id;
        }
        public String getCamId()
        {
            return (dGV_properties.Rows[3].Cells[1].Value != null) ? (String)dGV_properties.Rows[3].Cells[1].Value : "";
        }

        public void setCamIp(String ip)
        {
            dGV_properties.Rows[4].Cells[1].Value = ip;
        }
        public String getCamIp()
        {
            return (dGV_properties.Rows[4].Cells[1].Value != null)? (String)dGV_properties.Rows[4].Cells[1].Value:"";
        }

        public void setCamPort(String port)
        {
            dGV_properties.Rows[5].Cells[1].Value = port;
        }
        public String getCamPort()
        {
            return (dGV_properties.Rows[5].Cells[1].Value != null) ? (String)dGV_properties.Rows[5].Cells[1].Value : "";
        }

        public void setStationArea(String area)
        {
            dGV_properties.Rows[6].Cells[1].Value = area;
        }
        public String getStationArea()
        {
            return (dGV_properties.Rows[6].Cells[1].Value != null) ? (String)dGV_properties.Rows[6].Cells[1].Value : "";
        }
        //===========================================================================

        public void setStation(double x, double y)
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
            RegistrationAgent.mainWindowPointer.map.Children.Add(img);
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
            RegistrationAgent.mainWindowPointer.map.Children.Add(img);
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
        public void setName(String nameID)
        {
            props.NameID = nameID;
            img.Name = nameID;
            //checkInPoint.properties.key = "CIA-"+name;
            //checkOutPoint.properties.key = "COA-"+name;
        }
        public void removeobject()
        {
            if (img != null)
            {
                RegistrationAgent.mainWindowPointer.map.Children.Remove(img);
                RegistrationAgent.mainWindowPointer.map.Children.Remove(plabel);

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
                RegistrationAgent.mainWindowPointer.map.Children.Remove(img);
                RegistrationAgent.mainWindowPointer.map.Children.Remove(plabel);
            }
        }
        public JObject createJsonstring()
        {
            dynamic product = new JObject();
            product.Name = props.NameID;
            product.Label = props.label;
            product.Type = props.type;
            product.posX = props.X;
            product.posY = props.Y;
            product.stationID = props.cam.id;
            product.stationIP = props.cam.ip;
            product.stationPort = props.cam.port;
            product.stationArea = props.cam.area;
            product.lineInfo = lineInfo.save(props.NameKey);
            return product;
        }
        

        public void connect()
        {
          
        }

        /// <summary>
        /// Kiểm tra CAMERA này đã được dùng làm Docking hay PutAway cho Area nào chưa
        /// </summary>
        /// <param name="AgentID"></param>
        /// <returns></returns>
        private bool CheckAgentAvailable(String camID)
        {
            for (int areaIndex = 0; areaIndex < RegistrationAgent.areaList.Count; areaIndex++) //Scan All Area
            {
                if (RegistrationAgent.areaList.ContainsKey(areaIndex.ToString()))
                {
                    if (RegistrationAgent.areaList[areaIndex.ToString()].dockingStations.ContainsKey("Docking-" + props.NameID) == true)
                    {
                        //Scan Docking List
                        if (RegistrationAgent.areaList[areaIndex.ToString()].dockingStations["Docking-" + props.NameID].props.cam.id.ToString() == camID)
                        {
                            return false;
                        }
                        return true;
                    }
                    if (RegistrationAgent.areaList[areaIndex.ToString()].putAwayStations.ContainsKey("PutAway-" + props.id) == true)
                    {
                        if (RegistrationAgent.areaList[areaIndex.ToString()].putAwayStations["PutAway-" + props.NameID].props.cam.id.ToString() == camID)
                        {
                            return false;
                        }
                        return true;
                    }
                    if (RegistrationAgent.areaList[areaIndex.ToString()].mixedStations.ContainsKey("Mixed-" + props.id) == true)
                    {
                        if (RegistrationAgent.areaList[areaIndex.ToString()].mixedStations["Mixed-" + props.id].props.cam.id.ToString() == camID)
                        {
                            return false;
                        }
                        return true;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Kiểm tra đã điền hết các trường chưa
        /// </summary>
        /// <returns></returns>
        public bool CheckFullFilled()
        {
            if ((getStationArea() == "") ||
                (getCamIp().Split('.')[0] == "") ||
                (getCamIp().Split('.')[1] == "") ||
                (getCamIp().Split('.')[2] == "") ||
                (getCamIp().Split('.')[3] == "") ||
                (getCamPort() == ""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void loadStationProperties(Object _stuff)
        {
            dynamic stuff = _stuff as JObject;
            props.NameID = stuff.Name;
            props.label = stuff.Label;
            props.type = stuff.Type;
            props.X = stuff.posX;
            props.Y = stuff.posY;
            props.cam.id = stuff.stationID;
            props.cam.ip = stuff.stationIP;
            props.cam.port = stuff.stationPort;
            props.cam.area = stuff.stationArea;
        }
        public bool CreateCameraAgentD()
        {
            if (RegistrationAgent.areaList.ContainsKey(props.area) == false)
            {
                RegistrationAgent.areaList.Add(props.area, new Area(props.area));
                return RegistrationAgent.areaList[props.area].AddDocking(this);
            }
            else
            {
                return RegistrationAgent.areaList[props.area].AddDocking(this);
            }
        }

        public bool CreateCameraAgentP()
        {
            if (RegistrationAgent.areaList.ContainsKey(props.area) == false)
            {
                RegistrationAgent.areaList.Add(props.area, new Area(props.area));
                return RegistrationAgent.areaList[props.area].AddPutAway(this);
            }
            else
            {
                return RegistrationAgent.areaList[props.area].AddPutAway(this);
            }
        }
        
        public bool CreateCameraAgentM()
        {
            if (RegistrationAgent.areaList.ContainsKey(props.area) == false)
            {
                RegistrationAgent.areaList.Add(props.area, new Area(props.area));
                return RegistrationAgent.areaList[props.area].AddMixed(this);
            }
            else
            {
                return RegistrationAgent.areaList[props.area].AddMixed(this);
            }
        }


        public void ConnectToAgent()
        {
            if (CheckFullFilled() == true)
            {
                if (CheckAgentAvailable(getCamId()) == true)
                {
                    //CameraSuperviserSetting camSup;
                    Camera cam = new Camera();
                    cam.area = getStationArea();
                    cam.id = getCamId();
                    cam.ip = getCamIp();
                    cam.port = getCamPort();
                    props.cam = cam;
                }
                else
                {
                    txt_console.Text = "Agent is used";
                }
            }
            else
            {
                txt_console.Text = "Missing Field";
            }
        }

        private void connectToAgent_Click(object sender, EventArgs e)
        {
            /*if (ConnectToAgent())
            {
                setColorLabel(Colors.LimeGreen);
                properties.isConnected = true;
            }
            properties.isConnected = false;*/
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            // MessageBox.Show( dGV_properties.Rows[4].Cells[1].Value+"");
            this.Hide();
        }

        private void Station_Shown(object sender, EventArgs e)
        {
           /*( dgvProperties_setting();
            setStationNAME(this.props.NameID);
            setStationLB(this.props.label);
            setCamId(props.cam.id);
            setCamIp(props.cam.ip);
            setCamPort(props.cam.port);
            setStationArea(props.cam.area);
            this.Text = props.typeName;*/

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            props.NameID = getStationNAME();
            props.label = getStationLB();
            props.cam.id = getCamId();
            props.cam.ip = getCamIp();
            props.cam.port = getCamPort();
            props.cam.area = getStationArea();
            
        }

        private void txt_station_length_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txt_station_cost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txt_station_xmodel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txt_station_ymodel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tBAgentID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tBCamSupPORT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tBArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        


        private void btn_lineInfo_Click(object sender, EventArgs e)
        {
            lineInfo.ShowDialog();
        }

        private void timerCheckConnection_Tick(object sender, EventArgs e)
        {
            if (rosSocket != null)
            {
                if(rosSocket.webSocket != null)
                {
                    if(rosSocket.webSocket.ReadyState.ToString().Equals("Closed"))
                    {
                        rosSocket.isConnected = false;
                        setColorLabel(Colors.Red);
                        timerCheckConnection.Stop();
                        timerConnectRosSocket.Start();
                        
                    }
                    else if(rosSocket.webSocket.ReadyState.ToString().Equals("Open"))
                    {
                        setColorLabel(Colors.LimeGreen);
                        rosSocket.isConnected = true;
                    }
                    Console.WriteLine(rosSocket.webSocket.ReadyState);
                }
                else
                {
                    rosSocket.isConnected = false;
                    setColorLabel(Colors.Red);
                    timerCheckConnection.Stop();
                    timerConnectRosSocket.Start();
                    
                }
            }
            
        }

        private void dGV_properties_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dGV_properties_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ConnectToAgent();
        }

        private void timerConnectRosSocket_Tick(object sender, EventArgs e)
        {
                rosSocket.seturl("ws://" + props.cam.ip + ":" + props.cam.port);
                if (rosSocket.isConnected)
                {
                    int subscription_id = rosSocket.Subscribe("/pallet_status_" + props.cam.id, "std_msgs/String", subscriptionHandler);
                    timerConnectRosSocket.Stop();
                    timerCheckConnection.Start();
                }
                else
                {
                    rosSocket.connect();
                }
        }

        private void StationModel_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void subscriptionHandler(Communication.Message message)
        {
            StandardString standardString = (StandardString)message;
            dynamic data = JObject.Parse(standardString.data);
            int NOL = Convert.ToInt32(data.NOL);
            int NOPPL = Convert.ToInt32(data.NOPPL);
            props.cam.numLs = NOL;
            props.cam.numPsPL = NOPPL;
            props.cam.ip = data.CAMIP;
            props.cam.port = data.CAMPORT;
            props.cam.id = Convert.ToInt32(data.CAMID);
            List<bool> palletStatusArray = new List<bool>(NOL * NOPPL);

            if (props.cam.lineArray == null)
            {
                props.cam.lineArray = new SortedDictionary<String, LineInfo>();
            }
            for (int lineIndex = 0; lineIndex < NOL; lineIndex++)
            {
                String line = "L" + lineIndex;
                LineInfo lineInfo = new LineInfo();
                lineInfo.palletArray = new SortedDictionary<string, string>();
                bool first = true;
                for (int palletIndex = 0; palletIndex < NOPPL; palletIndex++)
                {
                    String pallet = "PL" + palletIndex;
                    String[] palletStatus = ((String)data[line][pallet]).Split('-');
                    lineInfo.palletArray.Add(palletIndex.ToString(), palletStatus[0]);
                    palletStatusArray.Add((palletStatus[0] == "yes") ? true : false);
                    if (!((palletStatus[1] == ("available") || palletStatus[1] == ("detected")) &&
                        (palletStatus[2] == "stable")))
                    {
                        if (first == true)
                        {
                            lineInfo.valid = false;
                            lineInfo.palletWarning = palletIndex.ToString();
                            first = false;
                        }
                    }
                }
                if (!props.cam.lineArray.ContainsKey(lineIndex.ToString()))
                {
                    //NEW
                    props.cam.lineArray.Add(lineIndex.ToString(), lineInfo);
                    props.palletStatusArray = palletStatusArray;
                    props.cam.valid = false;
                }
                else
                {
                    //UPDATE
                    props.cam.lineArray[lineIndex.ToString()].palletArray = lineInfo.palletArray;
                    props.cam.lineArray[lineIndex.ToString()].valid = lineInfo.valid;
                    if (lineInfo.palletWarning != "none")
                    {
                        props.cam.lineArray[lineIndex.ToString()].palletWarning = lineInfo.palletWarning;
                    }
                    props.palletStatusArray = palletStatusArray;
                    props.cam.valid = false;
                }
            }
            props.cam.valid = true;
            if (RegistrationAgent.areaList.Count != 0)
            {
                RegistrationAgent.areaList[props.cam.area].ProcessStation(props.typeName, props.NameID);
            }
        }
    }
}
