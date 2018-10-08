// https://blog.csdn.net/ZhangRelay/article/details/79008366
// roslaunch rosbridge_server rosbridge_websocket.launch
using Newtonsoft.Json.Linq;
using SeldatMRMS.Communication;
using SeldatMRMS.Management.OrderManager;
using SeldatMRMS.Management.RobotManagent;
using SeldatMRMS.Management.TrafficManager;
using SeldatMRMS.Model;
using SeldatMRMS.RobotView;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace SeldatMRMS.Management
{
    public class RobotAgent
    {

        public String IpAddress = "192.168.0.1";
        public String Hostname = "RobotID";
        public String NameObj;
        public long Port = 9000;
        public double CriticalEnergyAt = 23.9;
        public double CurrentEnergy = 0.0;
        public double GoodEnergyAt = 0.0;
        public double WidthRobot = 0.0;
        public double LengthRobot = 0.0;
        public Point CurrentPosition;
        public Point InitialPostion;
        public double CurrentHeadingAngle = 0;
        public double InitialHeadingAngle = 0;
        public Point NextPoint;
        public double HeadingAngle = 0;
        public String StateEnergy;
        public int AreaID;
        public bool FindName(String name)
        {
            if (name.Equals(NameObj))
                return true;
            else
                return false;
        }
        public enum Version
        {
            ROBOT_V1_CODE = 2018001,
            ROBOT_V2_CODE = 2018002,
            ROBOT_V3_CODE = 2018003,
        }
        public class RobotInfo
        {
            public RobotInfo() { }
            public String statusconnection;
            public bool connected = false;
            public String robotName;
            public String robotID;
            public String robotVersion;
            public double batteryPercentage;
            public double procedureTimes;
            public Robot3D robot3DModel;
            public Point3D loc;
            public Point3D mapLocation;
            public double heading;
            public int id;
            public int idRobotAgentRegisterList;
            public int workingStatus;
            public String atRoadName = "";
            public bool alive = false;
            public int posInGridView;

        }

        public class OrderElement
        {
            public String number { get; set; }
            public String dateTime { get; set; }
            public String checkinDocking { get; set; }
            public String checkoutDocking { get; set; }
            public String checkinPutAway { get; set; }
            public String checkoutPutAway { get; set; }
        }
        public struct OrderInfo
        {
            public string agentID;
            public string lineIndex;
            public string palletIndex;
            public bool isOrdered;
            public List<OrderElement> orderElementList;
            public String[] finishCheckInDockingStore;
            public String[] finishLineDockingStore;
            public String finishPalletDockingStore;

            public String[] finishCheckinPutAwayStore;
            public String[] finishLinePutAwayStore;
            public String finishPalletPutAwayStore;

        }

        public struct StatusFlag
        {
            public bool flagProcess; // co process =false va at ReadyArea =true tiep tục mot quy trinh moi
            public bool atReadyArea;
            public bool flagGoBack;
            public bool flagCharge;
        }
        public struct ParamsRosSocket
        {
            public int publication_RobotInfo;
            public int publication_RobotParams;
            public int publication_ServerRobotCtrl;
            public int publication_CtrlRobotHardware;
            public int publication_DriveRobot;
            public int publication_BatteryRegister;
            public int publication_EmergencyRobot;
            public int publication_CtrlRobotDriving;
            public int publication_gotoPalletArea;
            public int publication_serverRobotGotToLineDockingArea;
            public int publication_serverRobotGotToPalletDockingArea;
            public int publication_serverRobotGotToLinePutAwayArea;
            public int publication_serverRobotGotToPalletPutAwayArea;
            public int publication_responsedStandPosInsideReadyArea;
            public int publication_serverRobotGotToCheckInDockingArea;
            public int publication_serverRobotGotToCheckInPutAwayArea;
            public int publication_serverRobotGotToFrontReadyArea;
            public int publication_serverResetErrorDetectLine;
            public int publication_checkAliveTimeOut;
            public int publication_serverRobotGotToChargeArea;
            public int publication_serverRequestRobotDetectLine;
            public int publication_linedetectionctrl;
        }
        public bool findHostName(String hostname)
        {
            if (hostname.Equals(robotInfo.robotName))
            {
                return true;
            }
            return false;
        }
        public void setFlag()
        {
            statusFlag.flagProcess = false;
            statusFlag.flagCharge = false;
            statusFlag.atReadyArea = false;
        }
        //	public ChargerAgentLoop chargeAgent;
        public RobotInfo robotInfo;
        public RobotView3D probot3dmap;
        public StatusFlag statusFlag;
        public System.Timers.Timer timerInterruptRequestRobotParamTimeOut;
        public System.Windows.Forms.Timer timerInterruptCheckAliveTimeOut;
        public System.Windows.Forms.Timer timerInterruptConnectionRosSocket;
        public delegate void UpdateLocationToRobot3D(RobotAgent r, Point3D loc, double angle);
        public UpdateLocationToRobot3D updateLocationToRobot3D;
        public delegate void AddRobot3DModelToView(ModelVisual3D robot3D);
        public AddRobot3DModelToView addRobot3DModelToView;
        public delegate void UpdateRobotInfoToTaskManager(RobotInfo robotInfo);
        public UpdateRobotInfoToTaskManager updateRobotInfoToTaskManager;
        public delegate void UpdateStatusRobotToReadyArea(String name, int status);
        public UpdateStatusRobotToReadyArea updateStatusRobotToReadyArea;
        public delegate void RequestRobotLocationInReadyArea(Object obj);
        public RequestRobotLocationInReadyArea requestRobotLocationInReadyArea;
        private RosSocket rosSocket;
        public ParamsRosSocket paramsRosSocket;
        public Orders orderTask;
        public ReadyArea readyArea;
        public OrderInfo orderInfo;
        public RobotAgent()
        {
            robotInfo = new RobotInfo();
            rosSocket = new RosSocket();
            timerInterruptCheckAliveTimeOut = new System.Windows.Forms.Timer();
            timerInterruptConnectionRosSocket = new System.Windows.Forms.Timer();
            timerInterruptCheckAliveTimeOut.Interval = 500;
            timerInterruptConnectionRosSocket.Interval = 1000;
            timerInterruptConnectionRosSocket.Tick += new EventHandler(ConnectionRosSocket);
            timerInterruptCheckAliveTimeOut.Tick += new EventHandler(checkAliveTimeOut);
            timerInterruptCheckAliveTimeOut.Start();
            timerInterruptConnectionRosSocket.Stop();

            checkRobotVersion("");
            robotInfo.alive = false;
            setFlag();

        }

        public void setIpAddress(String ipAddress)
        {
            rosSocket.ipAddress = "ws://" + this.IpAddress + ":9090";
        }
        public void checkAliveTimeOut(Object sender, EventArgs e)
        {
            if (rosSocket != null)
            {
                if (!rosSocket.isConnected)
                {
                    timerInterruptCheckAliveTimeOut.Stop();
                    timerInterruptConnectionRosSocket.Start();

                }
                else
                {
                    dynamic product = new JObject();
                    product.count = GlobalVariables.EncodeTransmissionTimestamp();
                    StandardString messages = new StandardString();
                    messages.data = product.ToString();
                    rosSocket.Publish(paramsRosSocket.publication_checkAliveTimeOut, messages);
                }
            }

        }
        public void ConnectionRosSocket(Object sender, EventArgs e)
        {
                    rosSocket.connect();
                    if (rosSocket.isConnected)
                    {
                        timerInterruptCheckAliveTimeOut.Start();
                        timerInterruptConnectionRosSocket.Stop();
                        createRosTerms();
                    }

        }

        public void addOrderTask(Orders orderTask, ReadyArea readyArea)
        {
            this.orderTask = orderTask;
            this.readyArea = readyArea;
        }
        public void setRobotView3D(RobotView3D probot3dmap)
        {
            //this.probot3dmap = probot3dmap;
        }
        public delegate void ConnectionError_CallBack(int error);
        public ConnectionError_CallBack connectionError;
        public delegate void DataResponse(String text);
        public DataResponse dataResponse;

        public void setPosInGidView(int pos)
        {
            robotInfo.posInGridView = pos;
        }
        public int getPosInGidView(int pos)
        {
            return robotInfo.posInGridView;
        }
        public void zoneCheckerHandler(Communication.Message message) // request order to go docking line or putaway line
        {
            StandardString standardString = (StandardString)message;
            String road = standardString.data;
            dynamic stuff = JObject.Parse(road);
            robotInfo.atRoadName = (String)stuff.zone;
            //robotInfo.atRoadName = road;
            Console.WriteLine(robotInfo.atRoadName);
            switch (robotInfo.atRoadName)
            {
                case CommandSetsToRobotAgent.ZONE_HANDLER_INSIDEREADY:
                    statusFlag.atReadyArea = true;
                    break;
                case CommandSetsToRobotAgent.ZONE_HANDLER_CHECKOUT_DOCKING:
                    try
                    {
                        this.orderTask.ReleaseDockingOrder(this.AreaID.ToString(), this.orderInfo.agentID, this.orderInfo.lineIndex, this.orderInfo.palletIndex);
                    }
                    catch
                    {
                        Console.WriteLine("Error call ReleaseDockingOrder");
                    }
                    break;
                case CommandSetsToRobotAgent.ZONE_HANDLER_CHECKOUT_PUTAWAY:
                    try
                    {
                        this.orderTask.ReleasePutAwayOrder(this.AreaID.ToString(), this.orderInfo.agentID, this.orderInfo.lineIndex, this.orderInfo.palletIndex);
                    }
                    catch
                    {
                        Console.WriteLine("Error call ReleasePutAwayOrder");
                    }
                    break;
            }
        }
        public void robotOrderedGotoDockingArea(String textOrdered)
        {
            StandardString messages = new StandardString();
            messages.data = textOrdered;
            rosSocket.Publish(paramsRosSocket.publication_serverRobotGotToLineDockingArea, messages);
        }
        public void robotOrderedGotoPutAwayArea(String textOrdered)
        {
            StandardString messages = new StandardString();
            messages.data = textOrdered;
            rosSocket.Publish(paramsRosSocket.publication_serverRobotGotToLinePutAwayArea, messages);
        }
        public void setRobot3Dmodel(String model)
        {
            RegistrationAgent.robotview3dPointer.setRobotAgenttoLayer(this, model);
        }
        public void close()
        {
            if (this.rosSocket != null)
            {
                this.rosSocket.close();
                //this.rosSocket = null;
            }
        }

        public void createRosTerms()
        {

            int subscription_robotInfo = rosSocket.Subscribe("/amcl_pose", "geometry_msgs/PoseWithCovarianceStamped", robotInfoHandler);
            paramsRosSocket.publication_RobotInfo = rosSocket.Advertise("/serverRobotInfoCallBack", "std_msgs/String");
            int subscription_robotParams = rosSocket.Subscribe("/robotParams", "std_msgs/String", robotParamsHandler);
            paramsRosSocket.publication_RobotParams = rosSocket.Advertise("/serverRobotParamsCallBack", "std_msgs/String");
            int subscription_ctrlRobotHardwareStatus = rosSocket.Subscribe("/ctrlRobotHardwareStatusResponse", "std_msgs/String", ctrlRobotHardwareStatusHandler);
            paramsRosSocket.publication_CtrlRobotHardware = rosSocket.Advertise("/serverCtrlRobotHardwareCallBack", "std_msgs/String");
            int subscription_DriveRobotStatus = rosSocket.Subscribe("/driveRobotStatusResponse", "std_msgs/String", driveRobotStatusHandler);
            paramsRosSocket.publication_DriveRobot = rosSocket.Advertise("/serverDriveRobotCallBack", "std_msgs/String");
            int subscription_batteryRegister = rosSocket.Subscribe("/batteryRegisterResponse", "std_msgs/String", batteryRegisterHandler);
            paramsRosSocket.publication_BatteryRegister = rosSocket.Advertise("/serverBatteryRegisterCallBack", "std_msgs/String");
            int subscription_emergencyRobot = rosSocket.Subscribe("/emergencyRobotResponse", "std_msgs/String", emergencyRobotHandler);
            paramsRosSocket.publication_EmergencyRobot = rosSocket.Advertise("/serverEmergencyRobotCallBack", "std_msgs/String");

            int subscription_batteryvol = rosSocket.Subscribe("/battery_vol", "std_msgs/Float32", batteryVolHandler);
            //
            paramsRosSocket.publication_gotoPalletArea = rosSocket.Advertise("servergotoPalletAreaCallBack", "std_msgs/String");
            // Directly publish to control robot
            paramsRosSocket.publication_CtrlRobotDriving = rosSocket.Advertise("/ctrlRobotDriving", "std_msgs/Int32");

            // publish docking area location
            paramsRosSocket.publication_serverRobotGotToLineDockingArea = rosSocket.Advertise("/serverRobotGotToLineDockingArea", "std_msgs/String");
            paramsRosSocket.publication_serverRobotGotToPalletDockingArea = rosSocket.Advertise("/serverRobotGotToPalletDockingArea", "std_msgs/String");

            paramsRosSocket.publication_serverRobotGotToCheckInDockingArea = rosSocket.Advertise("/serverRobotGotToCheckInDockingArea", "std_msgs/String");
            // publish putaway area location
            paramsRosSocket.publication_serverRobotGotToLinePutAwayArea = rosSocket.Advertise("/serverRobotGotToLinePutAwayArea", "std_msgs/String");
            paramsRosSocket.publication_serverRobotGotToPalletPutAwayArea = rosSocket.Advertise("/serverRobotGotToPalletPutAwayArea", "std_msgs/String");

            paramsRosSocket.publication_serverRobotGotToCheckInPutAwayArea = rosSocket.Advertise("/serverRobotGotToCheckInPutAwayArea", "std_msgs/String");

            paramsRosSocket.publication_serverRobotGotToFrontReadyArea = rosSocket.Advertise("/serverRobotGotToFrontReadyArea", "std_msgs/String");
            paramsRosSocket.publication_serverRobotGotToChargeArea = rosSocket.Advertise("/serverRobotGotToChargeArea", "std_msgs/String");
            int subscription_requestPutAwayArea = rosSocket.Subscribe("/requestPutAwayArea", "std_msgs/String", requestPutAwayAreaHandler);
            // subcribe Zone Checker
            int subscription_zoneChecker = rosSocket.Subscribe("/zoneChecker", "std_msgs/String", zoneCheckerHandler);
            int subscription_finishedStates = rosSocket.Subscribe("/finishedStates", "std_msgs/Int32", finishedStatesHandler);
            // int subscription_test = rosSocket.Subscribe("/pallet_status_4", "std_msgs/String", testHandler);
            int subscription_robotStatus = rosSocket.Subscribe("/robotStatus", "std_msgs/Int32", robotStatusHandler);
            int subscription_readyAreaPos = rosSocket.Subscribe("/requestReadyAreaPos", "std_msgs/Int32", readyAreaPosHandler);
            paramsRosSocket.publication_responsedStandPosInsideReadyArea = rosSocket.Advertise("/responsedStandPosInsideReadyArea", "std_msgs/String");
            paramsRosSocket.publication_serverResetErrorDetectLine = rosSocket.Advertise("/serverResetErrorDetectLine", "std_msgs/Int32");
            paramsRosSocket.publication_checkAliveTimeOut = rosSocket.Advertise("/checkAliveTimeOut", "std_msgs/String");
            paramsRosSocket.publication_serverRequestRobotDetectLine = rosSocket.Advertise("/serverRequestRobotDetectLine", "std_msgs/String");
            paramsRosSocket.publication_linedetectionctrl = rosSocket.Advertise("/linedetectionctrl", "std_msgs/Int32");
            robotInfo.alive = true;
        }
        public void requestParams()
        {
            StandardString messages = new StandardString();
            messages.data = CommandSetsToRobotAgent.CommandPackage(CommandSetsToRobotAgent.SERVER_CALLBACK_CMD_ROBOTPARAM, 0);
            rosSocket.Publish(paramsRosSocket.publication_RobotParams, messages);
            robotInfo.alive = true;
        }

        public void ctrlRobotDriving(int speed)
        {
            try
            {
                Console.WriteLine(this.NameObj + "/ " + speed);
                // 0: Stop; 100: Normal; value: speed
                StandardInt32 messages = new StandardInt32();
                messages.data = speed;
                rosSocket.Publish(paramsRosSocket.publication_CtrlRobotDriving, messages);
            }
            catch { }

        }
        public void closeRosSocket()
        {
            try
            {
                this.rosSocket.close();
                robotInfo.alive = false;
                timerInterruptRequestRobotParamTimeOut.Stop();
            }
            catch { }
        }
        public void serverRequestRobotDetectLine(String cmd)
        {
            if (rosSocket != null)
            {
                StandardString messages = new StandardString();
                messages.data = cmd;
                rosSocket.Publish(paramsRosSocket.publication_serverRequestRobotDetectLine, messages);
            }
        }

        public void stopCharge()
        {
            if (rosSocket != null)
            {
                StandardInt32 messages = new StandardInt32();
                messages.data = 1201;
                rosSocket.Publish(paramsRosSocket.publication_linedetectionctrl, messages);
            }

        }

        private void batteryVolHandler(Communication.Message message)
        {
            StandardFloat32 standardFloat32 = (StandardFloat32)message;
            robotInfo.batteryPercentage = (double)standardFloat32.data;
            if(robotInfo.batteryPercentage<=CriticalEnergyAt)
            {
                statusFlag.flagCharge = true;
            }
        }
        private void finishedStatesHandler(Communication.Message message)
        {
            StandardInt32 standardInt32 = (StandardInt32)message;
            processFinishStates(standardInt32.data);

        }
        public void resetDetectLine(int error)
        {
            StandardInt32 messages = new StandardInt32();
            messages.data = error;
            rosSocket.Publish(paramsRosSocket.publication_serverResetErrorDetectLine, messages);
        }
        public void timeOutRecallProcessing(int state, long milisecond)
        {
            Task.Run(() => {
                RegistrationAgent.mainWindowPointer.LogConsole(state.ToString() + "-----------------------Timeout");
                Stopwatch sw = new Stopwatch();
                sw.Start();
                while (true)
                {
                    if (sw.ElapsedMilliseconds > milisecond) { break; }
                }
                processFinishStates(state);
            });

        }
        public void processFinishStates(int states)
        {
            // RegistrationAgent.mainWindowPointer.LogConsole("STATE " + states);
            switch (states)
            {
                case CommandSetsToRobotAgent.STATE_FINISH_PALLETUP:// hoan thanh docking
                    {
                        // go to check in putaway
                        RegistrationAgent.mainWindowPointer.LogConsole("STATE_FINISH_PALLETUP" + states);
                        // go to check in docking or Front Ready Area
                        String msg = DataTranformation.jsoncheckinPutAwayCoordinations(0);

                        RegistrationAgent.mainWindowPointer.LogConsole(msg);
                        sendPackageStringType(paramsRosSocket.publication_serverRobotGotToCheckInPutAwayArea, msg);
                    }
                    break;
                case CommandSetsToRobotAgent.STATE_FINISH_PALLETDOWN:
                    {
                        if (statusFlag.flagCharge)
                        {
                            String msg = DataTranformation.jsonFrontReadyAreaCoordinations(0);
                            RegistrationAgent.mainWindowPointer.LogConsole("ROBOT NEED CHARGE !!");
                            sendPackageStringType(paramsRosSocket.publication_serverRobotGotToChargeArea, msg);
                            return;
                        }
                        // go to check in docking or Front Ready Area
                        RegistrationAgent.mainWindowPointer.LogConsole("STATE_FINISH_PALLETDOWN" + states);
                        bool checkOrder = RegistrationAgent.areaList[this.AreaID.ToString()].CheckPalletInDockingArea();
                        RegistrationAgent.mainWindowPointer.LogConsole("Flag check order: " + checkOrder);
                        if (checkOrder)
                        {
                            String msg = DataTranformation.jsoncheckinDockingCoordinations(0);
                            RegistrationAgent.mainWindowPointer.LogConsole(msg);
                            sendPackageStringType(paramsRosSocket.publication_serverRobotGotToCheckInDockingArea, msg);
                        }
                        else
                        {
                            String msg = DataTranformation.jsonFrontReadyAreaCoordinations(0);
                            RegistrationAgent.mainWindowPointer.LogConsole(msg);
                            sendPackageStringType(paramsRosSocket.publication_serverRobotGotToFrontReadyArea, msg);


                        }
                    }
                    break;
                case CommandSetsToRobotAgent.STATE_FINISH_GOTOLINE_READYAREA:
                    {
                        statusFlag.flagProcess = false;
                       /* RegistrationAgent.mainWindowPointer.LogConsole("STATE_FINISH_GOTOLINE_CHARGINGSTATION " + states);
                        String msg = this.readyArea.requestRobotStandInSideReadyArea();
                        RegistrationAgent.mainWindowPointer.LogConsole(msg);
                        sendPackageStringType(paramsRosSocket.publication_responsedStandPosInsideReadyArea, msg);*/
                    }
                    break;
                case CommandSetsToRobotAgent.STATE_FINISH_GOTO_CHECKINDOCKING:
                    {
                        try
                        {
                            RegistrationAgent.mainWindowPointer.LogConsole("STATE_FINISH_GOTO_CHECKINDOCKING " + states);
                            String[] cmddk = this.orderTask.RequestDockingOrderLine(this.AreaID, NameObj);
                            if (cmddk == null)
                            {
                                timeOutRecallProcessing(CommandSetsToRobotAgent.STATE_FINISH_GOTO_CHECKINDOCKING, 3000);
                                return;
                            }

                            // orderInfo.finishCheckInDockingStore = cmddk;
                            orderInfo.agentID = cmddk[1];
                            orderInfo.lineIndex = cmddk[2];
                            //orderInfo.palletIndex = cmddk[3];
                            RegistrationAgent.mainWindowPointer.LogConsole(cmddk[0]);
                            if (cmddk[0].Length > 0)
                            {
                                sendPackageStringType(paramsRosSocket.publication_serverRobotGotToLineDockingArea, cmddk[0]);
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Jump Again!");
                        }
                    }
                    break;
                case CommandSetsToRobotAgent.STATE_FINISH_GOTO_CHECKINPUTAWAY:
                    {
                        try
                        {
                            RegistrationAgent.mainWindowPointer.LogConsole("STATE_FINISH_GOTO_CHECKINPUTAWAY " + states);
                            String[] cmdpw = this.orderTask.RequestPutAwayOrderLine(this.AreaID, NameObj);
                            if (cmdpw == null)
                            {
                                timeOutRecallProcessing(CommandSetsToRobotAgent.STATE_FINISH_GOTO_CHECKINPUTAWAY, 3000);
                                return;
                            }
                            // orderInfo.finishCheckinPutAwayStore = cmdpw;
                            orderInfo.agentID = cmdpw[1];
                            orderInfo.lineIndex = cmdpw[2];
                            //orderInfo.palletIndex = cmdpw[3];
                            RegistrationAgent.mainWindowPointer.LogConsole(cmdpw[0]);
                            if (cmdpw[0].Length > 0)
                            {
                                sendPackageStringType(paramsRosSocket.publication_serverRobotGotToLinePutAwayArea, cmdpw[0]);
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Jump Again!");
                        }
                    }
                    break;
                case CommandSetsToRobotAgent.STATE_FINISH_GOTO_LINEPUTAWAY:
                    {
                        try
                        {
                            RegistrationAgent.mainWindowPointer.LogConsole("STATE_FINISH_GOTO_LINEPUTAWAY " + states);
                            String[] cmdpw = this.orderTask.RequestPutAwayOrderPallet(this.AreaID, NameObj, orderInfo.agentID, orderInfo.lineIndex);
                            if (cmdpw == null)
                            {
                                timeOutRecallProcessing(CommandSetsToRobotAgent.STATE_FINISH_GOTO_LINEPUTAWAY, 3000);
                                return;
                            }
                            // orderInfo.finishLinePutAwayStore = cmdpw;
                            orderInfo.agentID = cmdpw[1];
                            orderInfo.lineIndex = cmdpw[2];
                            orderInfo.palletIndex = cmdpw[3];
                            RegistrationAgent.mainWindowPointer.LogConsole(cmdpw[0]);
                            if (cmdpw[0].Length > 0)
                            {
                                sendPackageStringType(paramsRosSocket.publication_serverRobotGotToPalletPutAwayArea, cmdpw[0]);
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Jump Again!");
                        }
                    }
                    break;
                case CommandSetsToRobotAgent.STATE_FINISH_GOTO_LINEDOCKING:
                    {
                        try
                        {
                            RegistrationAgent.mainWindowPointer.LogConsole("STATE_FINISH_GOTO_LINEDOCKING " + states);
                            String[] cmddk = this.orderTask.RequestDockingOrderPallet(this.AreaID, NameObj, orderInfo.agentID, orderInfo.lineIndex);
                            if (cmddk == null)
                            {
                                timeOutRecallProcessing(CommandSetsToRobotAgent.STATE_FINISH_GOTO_LINEDOCKING, 3000);
                                return;
                            }
                            //  orderInfo.finishLineDockingStore = cmddk;
                            orderInfo.agentID = cmddk[1];
                            orderInfo.lineIndex = cmddk[2];
                            orderInfo.palletIndex = cmddk[3];
                            RegistrationAgent.mainWindowPointer.LogConsole(cmddk[0]);
                            if (cmddk[0].Length > 0)
                            {
                                sendPackageStringType(paramsRosSocket.publication_serverRobotGotToPalletDockingArea, cmddk[0]);
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Jump Again!");
                        }
                    }

                    break;
                case CommandSetsToRobotAgent.STATE_FINISH_DETECTLINE_TO_READYAREA:
                    // reset flagGoback
                    RegistrationAgent.mainWindowPointer.LogConsole("STATE_FINISH_DETECTLINE_TO_CHARGINGSTATION" + states);
                    break;
                case CommandSetsToRobotAgent.STATE_SELFDRIVING_WAIT_PALLETUP:
                    // do pallet nhap nhay truoc vi tri pallet set
                    {
                        //bool stop = RegistrationAgent.areaList[this.AreaID.ToString()].robotStopDK(orderInfo.agentID, orderInfo.lineIndex, orderInfo.palletIndex);
                        //if (stop)
                        //{
                        //    // RegistrationAgent.mainWindowPointer.LogConsole("Robot Stop");
                        //}
                    }
                    break;
                case CommandSetsToRobotAgent.STATE_SELFDRIVING_WAIT_PALLETDOWN:
                    // do pallet nhap nhay truoc vi tri pallet set
                    {
                        //bool stop = RegistrationAgent.areaList[this.AreaID.ToString()].robotStopPW(orderInfo.agentID, orderInfo.lineIndex, orderInfo.palletIndex);
                        //if (stop)
                        //{
                        //    // RegistrationAgent.mainWindowPointer.LogConsole("Robot Stop");
                        //}
                    }
                    break;
                case CommandSetsToRobotAgent.STATE_SELFDRIVING_REQUEST_CHARGEBATTERY:
                    statusFlag.flagCharge = true;
                    break;
                case CommandSetsToRobotAgent.STATE_SELFDRIVING_FINISH_BATTERYCHARGING:
                    // finish charge
                   /* {
                        bool checkOrder = RegistrationAgent.areaList[this.AreaID.ToString()].CheckPalletInDockingArea();
                        if (checkOrder)
                        {
                            String msg = DataTranformation.jsoncheckinDockingCoordinations(0);
                            RegistrationAgent.mainWindowPointer.LogConsole(msg);
                            sendPackageStringType(paramsRosSocket.publication_serverRobotGotToCheckInDockingArea, msg);

                        }
                        statusFlag.flagCharge = false;
                    }*/
                    statusFlag.flagCharge = false;
                    statusFlag.flagProcess = false; // khi vị trí battery va ready cung vị trí 
                    break;


            }
        }


        public void requestRobotGotoCheckInDocking()
        {
            /* RegistrationAgent.mainWindowPointer.LogConsole("Go Check In");
             if (!statusFlag.flagCharge)
             {
               //  System.Windows.Forms.MessageBox.Show("ok");
                 String msg = DataTranformation.jsoncheckinDockingCoordinations(0);
                 RegistrationAgent.mainWindowPointer.LogConsole(msg);
                 sendPackageStringType(paramsRosSocket.publication_serverRobotGotToCheckInDockingArea, msg);
             }*/
        }
        public void sendPackageStringType(int connect, String msg)
        {
            StandardString messages = new StandardString();
            messages.data = msg;
            rosSocket.Publish(connect, messages);
        }
        private void readyAreaPosHandler(Communication.Message message)
        {
            StandardInt32 standardString = (StandardInt32)message;
            Int32 data = standardString.data;
            requestRobotLocationInReadyArea(this);
        }
        public void responseLocationReadyArea(String msg)
        {
        }
        private void requestPutAwayAreaHandler(Communication.Message message)
        {
        }
        private void robotInfoHandler(Communication.Message message)
        {
            GeometryPoseWithCovarianceStamped standardString = (GeometryPoseWithCovarianceStamped)message;
            updateRobotInfo(standardString.pose);
        }
        private void testHandler(Communication.Message message)
        {
            StandardString standardString = (StandardString)message;
            System.Windows.MessageBox.Show(standardString.data);
        }
        int cnt = 0;
        private void robotParamsHandler(Communication.Message message)
        {
            StandardString standardString = (StandardString)message;
            checkRobotVersion(standardString.data);
            robotInfo.alive = true;
        }
        private void ctrlRobotHardwareStatusHandler(Communication.Message message)
        {
            StandardString standardString = (StandardString)message;
            string row = standardString.data;
        }
        private void driveRobotStatusHandler(Communication.Message message)
        {
        }
        private void batteryRegisterHandler(Communication.Message message)
        {
        }
        private void emergencyRobotHandler(Communication.Message message)
        {
        }
        public void sendPackageGoToPalletArea(String mgs)
        {
            StandardString messages = new StandardString();
            messages.data = mgs;
            rosSocket.Publish(paramsRosSocket.publication_gotoPalletArea, messages);
        }
        /*public void sendPackageGoToDockingLine(String mgs)
		{
			StandardString messages = new StandardString();
			messages.data = mgs;
			rosSocket.Publish(paramsRosSocket.publication_serverRobotGotToLineDockingArea, messages);
		}
		public void sendPackageGoToPutAwayLine(String mgs)
		{
			StandardString messages = new StandardString();
			messages.data = mgs;
			rosSocket.Publish(paramsRosSocket.publication_serverRobotGotToLinePutAwayArea, messages);
		}*/
        public void robotStatusHandler(Communication.Message message)
        {
            StandardInt32 standardInt32 = (StandardInt32)message;
            robotInfo.workingStatus = standardInt32.data;
            updateStatusRobotToReadyArea(NameObj, robotInfo.workingStatus);
        }
        public void updateRobotLocation(Point3D loc, double heading)
        {
            RegistrationAgent.robotview3dPointer.updatePos(this, loc, heading);
        }
        public void updateRobotInfo(GeometryPoseWithCovariance data)
        {
            double posX = (double)data.pose.position.x;
            double posY = (double)data.pose.position.y;
            double posThetaZ = (double)data.pose.orientation.z;
            double posThetaW = (double)data.pose.orientation.w;
            double posTheta = (double)2 * Math.Atan2(posThetaZ, posThetaW);
            robotInfo.loc = new Point3D(posX, posY, 0);
            robotInfo.mapLocation = new Point3D(GlobalVariables.ConvertMetertoUnitLength(posX), GlobalVariables.ConvertMetertoUnitLength(posY), 0);
            robotInfo.heading = posTheta * 180 / Math.PI;
            updateRobotLocation(robotInfo.mapLocation, robotInfo.heading);
        }
        public bool checkRobotVersion(String msg)
        {
            RegistrationAgent.mainWindowPointer.LogConsole("robot version");
            long version = (Int64)Version.ROBOT_V1_CODE;
            if (version == (Int64)Version.ROBOT_V1_CODE)
            {
                setRobot3Dmodel(GlobalVariables.getPathRobot3DModel());
                updateRobotLocation(new Point3D(GlobalVariables.ConvertMetertoUnitLength(0), GlobalVariables.ConvertMetertoUnitLength(0), 0), 0);
            }
            else if (version == (Int64)Version.ROBOT_V2_CODE)
            {
                setRobot3Dmodel(GlobalVariables.getPathRobot3DModel());
                updateRobotLocation(new Point3D(GlobalVariables.ConvertMetertoUnitLength(0), GlobalVariables.ConvertMetertoUnitLength(10), 0), 0);
            }
            else
                return false;
            return true;
        }
        public JObject createJsonstring()
        {
            dynamic product = new JObject();
            product.IpAddress = IpAddress;
            product.Hostname = Hostname;
            product.NameObj = NameObj;
            product.Port = Port;
            product.CriticalEnergyAt = CriticalEnergyAt;
            product.GoodEnergyAt = GoodEnergyAt;
            product.WidthRobot = WidthRobot;
            product.LengthRobot = LengthRobot;

            product.InitialPosX = InitialPostion.X;
            product.InitialPosY = InitialPostion.Y;
            product.InitialHeadingAngle = InitialHeadingAngle;
            //Console.WriteLine(product);
            return product;

        }

    }
}
