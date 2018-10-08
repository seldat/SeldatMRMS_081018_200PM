
using SeldatMRMS.Management.FormManager;
using SeldatMRMS.Model;
using SeldatMRMS.RobotView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SeldatMRMS.Management
{
    public class Interface
	{
		public MainWindow content;
		public List<HalfPoint> phalfpoint_manager;
		public RobotModel pRobotModel;

		//public List<PathModel> RegistrationAgent.pathRegistrationList;
		//public List<Station> RegistrationAgent.stationRegistrationList;
		public List<RobotAgent> pRobotAgentConfig_Manager;
		public List<TreeViewItem> ptreeviewitem_Points;
		public List<TreeViewItem> ptreeviewitem_Paths;

		public List<TreeViewItem> ptreeviewitem_Stations;
		public List<TreeViewItem> ptreeviewitem_Charger;
		public List<TreeViewItem> ptreeviewitem_Ready;
		public List<TreeViewItem> ptreeviewitem_Checkin;
		public List<TreeViewItem> ptreeviewitem_Checkout;

		public List<TreeViewItem> ptreeviewitem_robotconfig;

		public List<Shape> pshape;
		public HalfPoint tempShape_point;
		public HalfPoint tempShape_point_sP;
		public HalfPoint tempShape_point_eP;

		public StationModel tempShape_station_sP;
		public StationModel tempShape_station_eP;

        public ChargerModel tempShape_charger_sP;
		public ChargerModel tempShape_charger_eP;

        public ReadyModel tempShape_ready_sP;
		public ReadyModel tempShape_ready_eP;

        public CheckinModel tempShape_checkin_sP;
		public CheckinModel tempShape_checkin_eP;

        public CheckoutModel tempShape_checkout_sP;
		public CheckoutModel tempShape_checkout_eP;
        
		public PathModel tempShape_path;


		public StationModel tempShape_station;
		public ChargerModel tempShape_charger;
		public ReadyModel tempShape_ready;
		public CheckinModel tempShape_checkin;
		public CheckoutModel tempShape_checkout;

		public delegate void AddANewRobotAgent(RobotAgent pr);
		public AddANewRobotAgent addANewRobotAgent;
		public delegate void UpdateRobotAgentProperties(RobotAgent pr);
		public UpdateRobotAgentProperties updateRobotAgentProperties;
		public enum STATE_INTERFACE
		{
			INTERFACE_SETING_IDLE = 1000,
			INTERFACE_SETING_HALFPOINT,
			INTERFACE_SETING_CHECKINPOINT,
			INTERFACE_SETING_CHECKOUTPOINT,

			INTERFACE_EDIT_HALFPOINT,
			INTERFACE_MOVE_HALFPOINT,
			INTERFACE_REMOVE_HALFPOINT,

            INTERFACE_ADD_STATION_CHARGER,
            INTERFACE_ADD_STATION_READY,
            INTERFACE_ADD_STATION_CHECKIN,
            INTERFACE_ADD_STATION_CHECKOUT,
            INTERFACE_ADD_STATION_PUTAWAY,
            INTERFACE_ADD_STATION_DOCKING,
            INTERFACE_ADD_STATION_MIXED,

			INTERFACE_EDIT_STATION,
			INTERFACE_EDIT_CHARGER,
			INTERFACE_EDIT_READY,
			INTERFACE_EDIT_CHECKIN,
			INTERFACE_EDIT_CHECKOUT,


			INTERFACE_MOVE_STATION,
            INTERFACE_MOVE_CHARGER,
            INTERFACE_MOVE_READY,
            INTERFACE_MOVE_CHECKIN,
            INTERFACE_MOVE_CHECKOUT,


			INTERFACE_REMOVE_STATION,
            INTERFACE_REMOVE_CHARGER,
            INTERFACE_REMOVE_READY,
            INTERFACE_REMOVE_CHECKIN,
            INTERFACE_REMOVE_CHECKOUT,
            
			INTERFACE_SETTING_PATH,
			INTERFACE_EDIT_PATH,
			INTERFACE_MOVE_PATH,
			INTERFACE_REMOVE_PATH,

			INTERFACE_GET_STARTPOINT_DIRECT,
			INTERFACE_GET_ENDPOINT_DIRECT,
			INTERFACE_SLIDE_PATH_DIRECT,
			INTERFACE_GET_STARTPOINT_BEZIERSEGMENT,
			INTERFACE_GET_ENDPOINT_BEZIERSEGMENT,
			INTERFACE_SLIDE_PATH_BEZIERSEGMENT,
			INTERFACE_SETING_ROBOTCONFIG,

            INTERFACE_SETING_HIGHWAY,

        }
		public STATE_INTERFACE STATESETTING;
		public Interface(MainWindow content)
		{
			this.content = content;
			phalfpoint_manager = new List<HalfPoint>();
			RegistrationAgent.pathRegistrationList = new List<PathModel>();
			RegistrationAgent.stationRegistrationList = new List<StationModel>();
			ptreeviewitem_Points = new List<TreeViewItem>();
			ptreeviewitem_Paths = new List<TreeViewItem>();
			ptreeviewitem_Stations = new List<TreeViewItem>();
			ptreeviewitem_Ready = new List<TreeViewItem>();
			ptreeviewitem_Checkin = new List<TreeViewItem>();
			ptreeviewitem_Checkout = new List<TreeViewItem>();
			ptreeviewitem_Charger = new List<TreeViewItem>();
			ptreeviewitem_robotconfig = new List<TreeViewItem>();
			pshape = new List<Shape>();
		}

		public HalfPoint findobjecthalfpoint(string name)
		{
			bool flag_findhalfpoint = false;
			HalfPoint temphp = null;
			for (int i = 0; i < phalfpoint_manager.Count; i++)
			{
				if (phalfpoint_manager[i].FindName(name))
				{
					flag_findhalfpoint = true;
					phalfpoint_manager[i].setcolor(Colors.Blue);
					SetObjectPoint(phalfpoint_manager[i]);
					updatePropertiesInformationPoint();
					temphp = phalfpoint_manager[i];

					break;
				}
			}
			if (!flag_findhalfpoint)
			{
				for (int i = 0; i < phalfpoint_manager.Count; i++)
				{
					phalfpoint_manager[i].setcolor((Color)ColorConverter.ConvertFromString("#FFF0F0F0"));
				}
			}
			return temphp;
		}
		public RobotModel findRobotModel(String name)
		{
			RobotModel rm = null;
            try
            {
                if (pRobotModel.properties.name.Equals(name))
                {
                    rm = pRobotModel;
                }
            }
            catch
            {

            }
			return rm;
		}
        

		public HalfPoint findobjecthalfpoint_updatevalue(string name)
		{
			HalfPoint temphp = null;
			for (int i = 0; i < phalfpoint_manager.Count; i++)
			{
				if (phalfpoint_manager[i].FindName(name))
				{
					temphp = phalfpoint_manager[i];
					break;
				}
			}
			return temphp;
		}
		public HalfPoint findobjecthalfpoint_treeview(string name)
		{
			bool flag_findhalfpoint = false;
			HalfPoint temphp = null;
			for (int i = 0; i < phalfpoint_manager.Count; i++)
			{
				phalfpoint_manager[i].setcolor((Color)ColorConverter.ConvertFromString("#FFF0F0F0"));
			}
			for (int i = 0; i < phalfpoint_manager.Count; i++)
			{
				if (phalfpoint_manager[i].FindName(name))
				{
					flag_findhalfpoint = true;
					phalfpoint_manager[i].setcolor(Colors.Blue);
					SetObjectPoint(phalfpoint_manager[i]);
					updatePropertiesInformationPoint();
					temphp = phalfpoint_manager[i];
					break;
				}
			}
			return temphp;
		}
		public PathModel findobjecthalfpath(string name)
		{
			bool flag_findpath = false;
			PathModel tpm = null;
			for (int i = 0; i < RegistrationAgent.pathRegistrationList.Count; i++)
			{
				if (RegistrationAgent.pathRegistrationList[i].FindName(name))
				{
					flag_findpath = true;
					RegistrationAgent.pathRegistrationList[i].setcolor(Colors.Red);
					SetObjectPath(RegistrationAgent.pathRegistrationList[i]);
					updatePropertiesInformationPath();
					tpm = RegistrationAgent.pathRegistrationList[i];
					break;
				}
			}
			if (!flag_findpath)
			{
				for (int i = 0; i < RegistrationAgent.pathRegistrationList.Count; i++)
				{
					RegistrationAgent.pathRegistrationList[i].setcolor(Colors.Black);
				}
			}
			return tpm;
		}


		public StationModel findobjectstation_treeview(string name)
		{
			bool flag_findstation = false;
			StationModel tpm = null;
			for (int i = 0; i < RegistrationAgent.stationRegistrationList.Count; i++)
			{
				RegistrationAgent.stationRegistrationList[i].setlabelcolor(Colors.White);
			}
			for (int i = 0; i < RegistrationAgent.stationRegistrationList.Count; i++)
			{
				if (RegistrationAgent.stationRegistrationList[i].FindName(name))
				{
					flag_findstation = true;
					SetObjectStation(RegistrationAgent.stationRegistrationList[i]);
					RegistrationAgent.stationRegistrationList[i].setlabelcolor(Colors.Blue);
					updatePropertiesInformationStation();
					tpm = RegistrationAgent.stationRegistrationList[i];
					break;
				}
			}
			return tpm;
		}
		public ChargerModel findobjectcharger_treeview(string name)
		{
			bool flag_findstation = false;
			ChargerModel tpm = null;
			for (int i = 0; i < RegistrationAgent.chargerRegistrationList.Count; i++)
			{
				RegistrationAgent.chargerRegistrationList[i].setlabelcolor(Colors.White);
			}
			for (int i = 0; i < RegistrationAgent.chargerRegistrationList.Count; i++)
			{
				if (RegistrationAgent.chargerRegistrationList[i].FindName(name))
				{
					flag_findstation = true;
					SetObjectCharger(RegistrationAgent.chargerRegistrationList[i]);
					RegistrationAgent.chargerRegistrationList[i].setlabelcolor(Colors.Blue);
					updatePropertiesInformationCharger();
					tpm = RegistrationAgent.chargerRegistrationList[i];
					break;
				}
			}
			return tpm;
		}
		public ReadyModel findobjectready_treeview(string name)
		{
			bool flag_findstation = false;
			ReadyModel tpm = null;
			for (int i = 0; i < RegistrationAgent.readyRegistrationList.Count; i++)
			{
				RegistrationAgent.readyRegistrationList[i].setlabelcolor(Colors.White);
			}
			for (int i = 0; i < RegistrationAgent.readyRegistrationList.Count; i++)
			{
				if (RegistrationAgent.readyRegistrationList[i].FindName(name))
				{
					flag_findstation = true;
					SetObjectReady(RegistrationAgent.readyRegistrationList[i]);
					RegistrationAgent.readyRegistrationList[i].setlabelcolor(Colors.Blue);
					updatePropertiesInformationReady();
					tpm = RegistrationAgent.readyRegistrationList[i];
					break;
				}
			}
			return tpm;
		}

        public CheckinModel findobjectcheckin_treeview(string name)
        {
            bool flag_findstation = false;
            CheckinModel tpm = null;
            for (int i = 0; i < RegistrationAgent.checkinRegistrationList.Count; i++)
            {
                RegistrationAgent.checkinRegistrationList[i].setlabelcolor(Colors.White);
            }
            for (int i = 0; i < RegistrationAgent.checkinRegistrationList.Count; i++)
            {
                if (RegistrationAgent.checkinRegistrationList[i].FindName(name))
                {
                    flag_findstation = true;
                    SetObjectCheckin(RegistrationAgent.checkinRegistrationList[i]);
                    RegistrationAgent.checkinRegistrationList[i].setlabelcolor(Colors.Blue);
                    updatePropertiesInformationCheckin();
                    tpm = RegistrationAgent.checkinRegistrationList[i];
                    break;
                }
            }
            return tpm;
        }

        public CheckoutModel findobjectcheckout_treeview(string name)
        {
            bool flag_findstation = false;
            CheckoutModel tpm = null;
            for (int i = 0; i < RegistrationAgent.checkoutRegistrationList.Count; i++)
            {
                RegistrationAgent.checkoutRegistrationList[i].setlabelcolor(Colors.White);
            }
            for (int i = 0; i < RegistrationAgent.checkoutRegistrationList.Count; i++)
            {
                if (RegistrationAgent.checkoutRegistrationList[i].FindName(name))
                {
                    flag_findstation = true;
                    SetObjectCheckout(RegistrationAgent.checkoutRegistrationList[i]);
                    RegistrationAgent.checkoutRegistrationList[i].setlabelcolor(Colors.Blue);
                    updatePropertiesInformationCheckout();
                    tpm = RegistrationAgent.checkoutRegistrationList[i];
                    break;
                }
            }
            return tpm;
        }

        public StationModel findobjectstation(string name)
		{
			bool flag_findstation = false;
			StationModel tpm = null;
			for (int i = 0; i < RegistrationAgent.stationRegistrationList.Count; i++)
			{
				if (RegistrationAgent.stationRegistrationList[i].FindName(name))
				{
					flag_findstation = true;
					SetObjectStation(RegistrationAgent.stationRegistrationList[i]);
					RegistrationAgent.stationRegistrationList[i].setlabelcolor(Colors.Blue);
					updatePropertiesInformationStation();
					tpm = RegistrationAgent.stationRegistrationList[i];
					break;
				}
			}
			if (!flag_findstation)
			{
				for (int i = 0; i < RegistrationAgent.stationRegistrationList.Count; i++)
				{
					RegistrationAgent.stationRegistrationList[i].setlabelcolor(Colors.White);
				}
			}
			return tpm;
		}
		public ChargerModel findobjectcharger(string name)
		{
			bool flag_findcharger = false;
            ChargerModel tpm = null;
			for (int i = 0; i < RegistrationAgent.chargerRegistrationList.Count; i++)
			{
				if (RegistrationAgent.chargerRegistrationList[i].FindName(name))
				{
                    flag_findcharger = true;
					SetObjectCharger(RegistrationAgent.chargerRegistrationList[i]);
					RegistrationAgent.chargerRegistrationList[i].setlabelcolor(Colors.Blue);
					updatePropertiesInformationCharger();
					tpm = RegistrationAgent.chargerRegistrationList[i];
					break;
				}
			}
			if (!flag_findcharger)
			{
				for (int i = 0; i < RegistrationAgent.chargerRegistrationList.Count; i++)
				{
					RegistrationAgent.chargerRegistrationList[i].setlabelcolor(Colors.White);
				}
			}
			return tpm;
		}

		public ReadyModel findobjectready(string name)
		{
			bool flag_findready = false;
            ReadyModel tpm = null;
			for (int i = 0; i < RegistrationAgent.readyRegistrationList.Count; i++)
			{
				if (RegistrationAgent.readyRegistrationList[i].FindName(name))
				{
                    flag_findready = true;
					SetObjectReady(RegistrationAgent.readyRegistrationList[i]);
					RegistrationAgent.readyRegistrationList[i].setlabelcolor(Colors.Blue);
					updatePropertiesInformationReady();
					tpm = RegistrationAgent.readyRegistrationList[i];
					break;
				}
			}
			if (!flag_findready)
			{
				for (int i = 0; i < RegistrationAgent.readyRegistrationList.Count; i++)
				{
					RegistrationAgent.readyRegistrationList[i].setlabelcolor(Colors.White);
				}
			}
			return tpm;
		}

        public CheckinModel findobjectcheckin(string name)
        {
            bool flag_findcheckin = false;
            CheckinModel tpm = null;
            for (int i = 0; i < RegistrationAgent.checkinRegistrationList.Count; i++)
            {
                if (RegistrationAgent.checkinRegistrationList[i].FindName(name))
                {
                    flag_findcheckin = true;
                    SetObjectCheckin(RegistrationAgent.checkinRegistrationList[i]);
                    RegistrationAgent.checkinRegistrationList[i].setlabelcolor(Colors.Blue);
                    updatePropertiesInformationCheckin();
                    tpm = RegistrationAgent.checkinRegistrationList[i];
                    break;
                }
            }
            if (!flag_findcheckin)
            {
                for (int i = 0; i < RegistrationAgent.checkinRegistrationList.Count; i++)
                {
                    RegistrationAgent.checkinRegistrationList[i].setlabelcolor(Colors.White);
                }
            }
            return tpm;
        }

        public CheckoutModel findobjectcheckout(string name)
        {
            bool flag_findcheckout = false;
            CheckoutModel tpm = null;
            for (int i = 0; i < RegistrationAgent.checkoutRegistrationList.Count; i++)
            {
                if (RegistrationAgent.checkoutRegistrationList[i].FindName(name))
                {
                    flag_findcheckout = true;
                    SetObjectCheckout(RegistrationAgent.checkoutRegistrationList[i]);
                    RegistrationAgent.checkoutRegistrationList[i].setlabelcolor(Colors.Blue);
                    updatePropertiesInformationCheckout();
                    tpm = RegistrationAgent.checkoutRegistrationList[i];
                    break;
                }
            }
            if (!flag_findcheckout)
            {
                for (int i = 0; i < RegistrationAgent.checkoutRegistrationList.Count; i++)
                {
                    RegistrationAgent.checkoutRegistrationList[i].setlabelcolor(Colors.White);
                }
            }
            return tpm;
        }


        public StationModel findobjectstation_updatevalue(string name)
		{
			StationModel tpm = null;
			for (int i = 0; i < RegistrationAgent.stationRegistrationList.Count; i++)
			{
				if (RegistrationAgent.stationRegistrationList[i].FindName(name))
				{
					tpm = RegistrationAgent.stationRegistrationList[i];
					break;
				}
			}
			return tpm;
		}
		public ChargerModel findobjectcharger_updatevalue(string name)
		{
            ChargerModel tpm = null;
			for (int i = 0; i < RegistrationAgent.chargerRegistrationList.Count; i++)
			{
				if (RegistrationAgent.chargerRegistrationList[i].FindName(name))
				{
					tpm = RegistrationAgent.chargerRegistrationList[i];
					break;
				}
			}
			return tpm;
		}
		public ReadyModel findobjectready_updatevalue(string name)
		{
            ReadyModel tpm = null;
			for (int i = 0; i < RegistrationAgent.readyRegistrationList.Count; i++)
			{
				if (RegistrationAgent.readyRegistrationList[i].FindName(name))
				{
					tpm = RegistrationAgent.readyRegistrationList[i];
					break;
				}
			}
			return tpm;
		}

        public CheckinModel findobjectcheckin_updatevalue(string name)
        {
            CheckinModel tpm = null;
            for (int i = 0; i < RegistrationAgent.checkinRegistrationList.Count; i++)
            {
                if (RegistrationAgent.checkinRegistrationList[i].FindName(name))
                {
                    tpm = RegistrationAgent.checkinRegistrationList[i];
                    break;
                }
            }
            return tpm;
        }

        public CheckoutModel findobjectcheckout_updatevalue(string name)
        {
            CheckoutModel tpm = null;
            for (int i = 0; i < RegistrationAgent.checkoutRegistrationList.Count; i++)
            {
                if (RegistrationAgent.checkoutRegistrationList[i].FindName(name))
                {
                    tpm = RegistrationAgent.checkoutRegistrationList[i];
                    break;
                }
            }
            return tpm;
        }


        public PathModel findobjecthalfpath_treeview(string name)
		{
			bool flag_findpath = false;
			PathModel tpm = null;
			for (int i = 0; i < RegistrationAgent.pathRegistrationList.Count; i++)
			{
				RegistrationAgent.pathRegistrationList[i].setcolor(Colors.Black);
			}
			for (int i = 0; i < RegistrationAgent.pathRegistrationList.Count; i++)
			{
				if (RegistrationAgent.pathRegistrationList[i].FindName(name))
				{
					flag_findpath = true;
					RegistrationAgent.pathRegistrationList[i].setcolor(Colors.Red);
					SetObjectPath(RegistrationAgent.pathRegistrationList[i]);
					updatePropertiesInformationPath();
					tpm = RegistrationAgent.pathRegistrationList[i];
					break;
				}
			}
			return tpm;
		}
		public RobotAgent findobjectrobot_treeview(string name)
		{
			bool flag_findrobot = false;
			RobotAgent tpm = null;
			for (int i = 0; i < RegistrationAgent.robotAgentRegisteredList.Count; i++)
			{
				if (RegistrationAgent.robotAgentRegisteredList.ElementAt(i).Value.FindName(name))
				{
					flag_findrobot = true;
					tpm = RegistrationAgent.robotAgentRegisteredList.ElementAt(i).Value;
					updatePropertiesInformationrobot(tpm);
					break;
				}
			}
			return tpm;
		}
		public RobotAgent findobjectrobot_updatevalue(string name)
		{
			RobotAgent tpm = null;
			for (int i = 0; i < RegistrationAgent.robotAgentRegisteredList.Count; i++)
			{
				if (RegistrationAgent.robotAgentRegisteredList.ElementAt(i).Value.FindName(name))
				{
					tpm = RegistrationAgent.robotAgentRegisteredList.ElementAt(i).Value;
					break;
				}
			}
			return tpm;
		}



		public void Interfacecontrols(STATE_INTERFACE mode, Point pos, int Type)
		{
			switch (mode)
			{
				case STATE_INTERFACE.INTERFACE_SETING_IDLE:
					break;
				case STATE_INTERFACE.INTERFACE_SETING_HALFPOINT:
					HalfPoint temp = new HalfPoint(this.content.map);
					temp.sethalfpoint(20, 20, pos.X, pos.Y, Colors.Red);
					temp.setTextlabel("HPO" + phalfpoint_manager.Count);
					temp.setid(phalfpoint_manager.Count);
					temp.setName("HPO" + GlobalVariables.EncodeTransmissionTimestamp());
					//	pshape.Add(temp);
					updateTreeviewPoints(temp.properties.NameObj);

					phalfpoint_manager.Add(temp);
					//	temp.createJsonstring();
					break;
				case STATE_INTERFACE.INTERFACE_SETING_CHECKINPOINT:
					/*CheckInPoint tempci = new CheckInPoint(this.content.map);
					tempci.sethalfpoint(20, 20, pos.X, pos.Y, Colors.Red);
					tempci.setTextlabel("CheckIn-" + DateTime.Now.Ticks);
					tempci.setid(phalfpoint_manager.Count);
					tempci.setName("CheckIn" + DateTime.Now.Ticks);
					//	pshape.Add(temp);
					updateTreeviewPoints(tempci.NameObj);
					RegistrationModels.checkInPointlist.Add(tempci.NameObj, tempci);
					//phalfpoint_manager.Add(tempci);
					//	temp.createJsonstring();*/
					break;
				case STATE_INTERFACE.INTERFACE_SETING_CHECKOUTPOINT:
					/*CheckOutPoint tempco = new CheckOutPoint(this.content.map);
					tempco.sethalfpoint(20, 20, pos.X, pos.Y, Colors.Red);

					tempco.setTextlabel("CheckOut-" + DateTime.Now.Ticks);
					tempco.setid(phalfpoint_manager.Count);
					tempco.setName("CheckOut" + DateTime.Now.Ticks);
					//	pshape.Add(temp);
					updateTreeviewPoints(tempco.NameObj);
					RegistrationModels.checkOutPointlist.Add(tempco.NameObj, tempco);
					//	temp.createJsonstring();*/
					break;
				case STATE_INTERFACE.INTERFACE_EDIT_HALFPOINT:
					break;
				case STATE_INTERFACE.INTERFACE_MOVE_HALFPOINT:
					//this.tempShape_point.setPos(pos.X, pos.Y);
					//this.tempShape_point.updatePathfromNewPosition();
					break;
				case STATE_INTERFACE.INTERFACE_REMOVE_HALFPOINT:
					break;
				case STATE_INTERFACE.INTERFACE_SETTING_PATH:
					break;
				case STATE_INTERFACE.INTERFACE_EDIT_PATH:
					break;
				case STATE_INTERFACE.INTERFACE_REMOVE_PATH:
					break;
				case STATE_INTERFACE.INTERFACE_ADD_STATION_CHARGER:
					ChargerModel pstation_charger = null;
                    pstation_charger = new ChargerModel(this.content, "CHARGER");
                    pstation_charger.setText("CHG" + RegistrationAgent.chargerRegistrationList.Count);
                    pstation_charger.setName("CHG" + GlobalVariables.EncodeTransmissionTimestamp());
                    pstation_charger.setCharger(pos.X, pos.Y);
                    //pstation_charger.setid(RegistrationAgent.chargerRegistrationList.Count);
                    //pstation_charger.CreateChagerArea();
                    RegistrationAgent.chargerRegistrationList.Add(pstation_charger);
					updateTreeviewCharger(pstation_charger.props.NameKey);
					break;

				case STATE_INTERFACE.INTERFACE_ADD_STATION_READY:
					ReadyModel pstation_ready = null;
                    pstation_ready = new ReadyModel(this.content, "READY");
                    pstation_ready.setText("RDY" + RegistrationAgent.readyRegistrationList.Count);
                    pstation_ready.setName("RDY" + GlobalVariables.EncodeTransmissionTimestamp());
                    pstation_ready.setReady(pos.X, pos.Y);
                    //pstation_ready.setid(RegistrationAgent.readyRegistrationList.Count);
                    //pstation_ready.CreateReadyArea();
                    RegistrationAgent.readyRegistrationList.Add(pstation_ready);
					updateTreeviewReady(pstation_ready.props.NameKey);
					break;

                case STATE_INTERFACE.INTERFACE_ADD_STATION_CHECKIN:
                    CheckinModel pstation_checkin = null;
                    pstation_checkin = new CheckinModel(this.content, "CHECKIN");
                    pstation_checkin.setText("CKI" + RegistrationAgent.checkinRegistrationList.Count);
                    pstation_checkin.setName("CKI" + GlobalVariables.EncodeTransmissionTimestamp());
                    pstation_checkin.setCheckin(pos.X, pos.Y);
                    //pstation_checkin.setid(RegistrationAgent.checkinRegistrationList.Count);
                    RegistrationAgent.checkinRegistrationList.Add(pstation_checkin);
                    updateTreeviewCheckin(pstation_checkin.props.NameKey);
                    break;

                case STATE_INTERFACE.INTERFACE_ADD_STATION_CHECKOUT:
                    CheckoutModel pstation_checkout = null;
                    pstation_checkout = new CheckoutModel(this.content, "CHECKOUT");
                    pstation_checkout.setText("CKO" + RegistrationAgent.checkoutRegistrationList.Count);
                    pstation_checkout.setName("CKO" + GlobalVariables.EncodeTransmissionTimestamp());
                    pstation_checkout.setCheckout(pos.X, pos.Y);
                    //pstation_checkout.setid(RegistrationAgent.checkoutRegistrationList.Count);
                    RegistrationAgent.checkoutRegistrationList.Add(pstation_checkout);
                    updateTreeviewCheckout(pstation_checkout.props.NameKey);
                    break;

                case STATE_INTERFACE.INTERFACE_ADD_STATION_DOCKING:
					StationModel pstation_docking = null;
					pstation_docking = new StationModel(this.content, "DOCKING");
                    pstation_docking.setText("DCK" + RegistrationAgent.stationRegistrationList.Count);
                    pstation_docking.setName("DCK" + GlobalVariables.EncodeTransmissionTimestamp());
                    pstation_docking.setStation(pos.X, pos.Y);
                    //pstation_docking.setid(RegistrationAgent.stationRegistrationList.Count);
                    pstation_docking.CreateCameraAgentD();
                    RegistrationAgent.stationRegistrationList.Add(pstation_docking);
					updateTreeviewStations(pstation_docking.props.NameKey);
					break;

				case STATE_INTERFACE.INTERFACE_ADD_STATION_PUTAWAY:
					StationModel pstation_putaway = null;
					pstation_putaway = new StationModel(this.content, "PUTAWAY");
					pstation_putaway.setText("PAW" + RegistrationAgent.stationRegistrationList.Count);
					pstation_putaway.setName("PAW" + GlobalVariables.EncodeTransmissionTimestamp());
					pstation_putaway.setStation(pos.X, pos.Y);
					//pstation_putaway.setid(RegistrationAgent.stationRegistrationList.Count);
                    pstation_putaway.CreateCameraAgentP();
                    RegistrationAgent.stationRegistrationList.Add(pstation_putaway);
					updateTreeviewStations(pstation_putaway.props.NameKey);
                    break;

                case STATE_INTERFACE.INTERFACE_ADD_STATION_MIXED:
                    StationModel pstation_mixed = null;
                    pstation_mixed = new StationModel(this.content, "MIXED");
                    pstation_mixed.setText("MIX" + RegistrationAgent.stationRegistrationList.Count);
                    pstation_mixed.setName("MIX" + GlobalVariables.EncodeTransmissionTimestamp());
                    pstation_mixed.setStation(pos.X, pos.Y);
                    //pstation_mixed.setid(RegistrationAgent.stationRegistrationList.Count);
                    pstation_mixed.CreateCameraAgentM();
                    RegistrationAgent.stationRegistrationList.Add(pstation_mixed);
                    updateTreeviewStations(pstation_mixed.props.NameKey);
                    break;

				case STATE_INTERFACE.INTERFACE_EDIT_STATION:
					break;
				case STATE_INTERFACE.INTERFACE_SETING_ROBOTCONFIG:
					break;
				case STATE_INTERFACE.INTERFACE_MOVE_STATION:
					this.tempShape_station.setnewpos(pos.X, pos.Y);
					this.tempShape_station.updatePathfromNewPosition();
					break;
				case STATE_INTERFACE.INTERFACE_MOVE_CHARGER:
					this.tempShape_charger.setnewpos(pos.X, pos.Y);
					this.tempShape_charger.updatePathfromNewPosition();
					break;
				case STATE_INTERFACE.INTERFACE_MOVE_READY:
					this.tempShape_ready.setnewpos(pos.X, pos.Y);
					this.tempShape_ready.updatePathfromNewPosition();
					break;
				case STATE_INTERFACE.INTERFACE_MOVE_CHECKIN:
					this.tempShape_checkin.setnewpos(pos.X, pos.Y);
					this.tempShape_checkin.updatePathfromNewPosition();
					break;
				case STATE_INTERFACE.INTERFACE_MOVE_CHECKOUT:
					this.tempShape_checkout.setnewpos(pos.X, pos.Y);
					this.tempShape_checkout.updatePathfromNewPosition();
					break;
				case STATE_INTERFACE.INTERFACE_REMOVE_STATION:
					break;
				case STATE_INTERFACE.INTERFACE_GET_STARTPOINT_DIRECT:
					PathModel ptempPath_direct = new PathModel(this.content.map, PathModel.PATH_TYPE_DIRECT);
					ptempPath_direct.setName("Path" + RegistrationAgent.pathRegistrationList.Count);
					RegistrationAgent.pathRegistrationList.Add(ptempPath_direct);
					ptempPath_direct.drawdirectpath(pos, pos);
					ptempPath_direct.ondraw();
					STATESETTING = STATE_INTERFACE.INTERFACE_SLIDE_PATH_DIRECT;
					break;
				case STATE_INTERFACE.INTERFACE_GET_ENDPOINT_DIRECT:
					{
						Point startpoint_dir_end = new Point();
						Point endpoint_dir_end = new Point();
						if (RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.frontNodeConnected == PathModel.NODECONNECTED.FRONTNODE_CONNECTED_STATION)
						{
							startpoint_dir_end = new Point(RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.startpoint_station.props.X, RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.startpoint_station.props.Y);
						}
						else if (RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.frontNodeConnected == PathModel.NODECONNECTED.FRONTNODE_CONNECTED_HALFPOINT)

						{
							startpoint_dir_end = new Point(RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.startpoint.properties.X, RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.startpoint.properties.Y);
						}
						if (RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.backNodeConnected == PathModel.NODECONNECTED.BACKNODE_CONNECTED_STATION)
						{
							endpoint_dir_end = new Point(RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.endpoint_station.props.X, RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.endpoint_station.props.Y);
						}
						else if (RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.backNodeConnected == PathModel.NODECONNECTED.BACKNODE_CONNECTED_HALFPOINT)
						{
							endpoint_dir_end = new Point(RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.endpoint.properties.X, RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.endpoint.properties.Y);
						}
						RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].drawdirectpath(startpoint_dir_end, endpoint_dir_end);
						refreshpath();
					}
					break;
				case STATE_INTERFACE.INTERFACE_SLIDE_PATH_DIRECT:
					Point pxx = estimatedPoint(pos);
					Point startpoint_dir;
					if (RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.frontNodeConnected == PathModel.NODECONNECTED.FRONTNODE_CONNECTED_STATION || RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.backNodeConnected == PathModel.NODECONNECTED.BACKNODE_CONNECTED_STATION)
					{
						startpoint_dir = new Point(RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.startpoint_station.props.X, RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.startpoint_station.props.Y);
						RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].drawdirectpath(startpoint_dir, pxx);

					}
					else if (RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.frontNodeConnected == PathModel.NODECONNECTED.FRONTNODE_CONNECTED_HALFPOINT || RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.backNodeConnected == PathModel.NODECONNECTED.BACKNODE_CONNECTED_HALFPOINT)
					{
						startpoint_dir = new Point(RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.startpoint.properties.X, RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.startpoint.properties.Y);
						RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].drawdirectpath(startpoint_dir, pxx);

					}

					break;
				case STATE_INTERFACE.INTERFACE_GET_STARTPOINT_BEZIERSEGMENT:
					//this.content.map.Children.Remove(phalfpoint_manager[0]);
					PathModel ptempPath = new PathModel(this.content.map, PathModel.PATH_TYPE_BEZIERSEGMENT);
					ptempPath.setName("Path" + RegistrationAgent.pathRegistrationList.Count);
					RegistrationAgent.pathRegistrationList.Add(ptempPath);
					ptempPath.drawbezierpath(pos, pos, pos);
					ptempPath.ondraw();
					STATESETTING = STATE_INTERFACE.INTERFACE_SLIDE_PATH_BEZIERSEGMENT;

					//phalfpoint_manager[0].remove();
					//phalfpoint_manager[0].sethalfpoint(20, 20, phalfpoint_manager[0].X, phalfpoint_manager[0].Y, Colors.Red);

					break;
				case STATE_INTERFACE.INTERFACE_GET_ENDPOINT_BEZIERSEGMENT:
					Point startpoint_bz_end = new Point();
					Point endpoint_bz_end = new Point();
					if (RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.frontNodeConnected == PathModel.NODECONNECTED.FRONTNODE_CONNECTED_STATION)
					{
						startpoint_bz_end = new Point(RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.startpoint_station.props.X, RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.startpoint_station.props.Y);
					}
					if (RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.frontNodeConnected == PathModel.NODECONNECTED.FRONTNODE_CONNECTED_HALFPOINT)
					{
						startpoint_bz_end = new Point(RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.startpoint.properties.X, RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.startpoint.properties.Y);
					}
					if (RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.backNodeConnected == PathModel.NODECONNECTED.BACKNODE_CONNECTED_STATION)
					{
						endpoint_bz_end = new Point(RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.endpoint_station.props.X, RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.endpoint_station.props.Y);
					}
					if (RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.backNodeConnected == PathModel.NODECONNECTED.BACKNODE_CONNECTED_HALFPOINT)
					{
						endpoint_bz_end = new Point(RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.endpoint.properties.X, RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.endpoint.properties.Y);
					}
					RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].drawbezierpath(startpoint_bz_end, new Point(endpoint_bz_end.X - 40, endpoint_bz_end.Y + 100), endpoint_bz_end);
					refreshpath();
					break;
				case STATE_INTERFACE.INTERFACE_SLIDE_PATH_BEZIERSEGMENT:
					Point px = estimatedPoint(pos);
					Point startpoint_bz;
					if (RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.frontNodeConnected == PathModel.NODECONNECTED.FRONTNODE_CONNECTED_STATION || RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.backNodeConnected == PathModel.NODECONNECTED.BACKNODE_CONNECTED_STATION)
					{

						startpoint_bz = new Point(RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.startpoint_station.props.X, RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.startpoint_station.props.Y);
						RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].drawbezierpath(startpoint_bz, new Point(px.X - 40, px.Y + 100), px);

					}
					else if (RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.frontNodeConnected == PathModel.NODECONNECTED.FRONTNODE_CONNECTED_HALFPOINT || RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.backNodeConnected == PathModel.NODECONNECTED.BACKNODE_CONNECTED_HALFPOINT)

					{
						startpoint_bz = new Point(RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.startpoint.properties.X, RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.startpoint.properties.Y);
						RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].drawbezierpath(startpoint_bz, new Point(px.X - 40, px.Y + 100), px);

					}
					RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].drawdirectpath(RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].startpos, px);

					break;

			}
		}
		public Point estimatedPoint(Point px)
		{
			if (px.X > 0 && px.Y > 0)
			{
				px.X = px.X - 2;
				px.Y = px.Y - 2;
			}
			else if (px.X > 0 && px.Y < 0)
			{
				px.X = px.X - 2;
				px.Y = px.Y + 2;
			}
			else if (px.X < 0 && px.Y > 0)
			{
				px.X = px.X + 2;
				px.Y = px.Y - 2;
			}
			else if (px.X < 0 && px.Y < 0)
			{
				px.X = px.X + 2;
				px.Y = px.Y + 2;
			}
			return px;
		}
		public void settinghalfpoint()
		{

		}
		public void settingremovehalfpoint()
		{

		}
		public void setRobotProperties()
		{
			RobotAgent ptempRobotAgent = new RobotAgent();
			ptempRobotAgent.NameID = "RBO" + GlobalVariables.EncodeTransmissionTimestamp();
            ptempRobotAgent.setLabel("RBO"+ RegistrationAgent.robotAgentRegisteredList.Count);
			updateTreeviewRobotConfig(ptempRobotAgent.NameKey);
			addANewRobotAgent(ptempRobotAgent);
			RegistrationAgent.robotAgentRegisteredList.Add(ptempRobotAgent.NameID, ptempRobotAgent);
			if (pRobotModel == null)
			{
				pRobotModel = new RobotModel(content);
			}
		}

		public void updateRobotProperties(RobotAgent pr)
		{
			updateRobotAgentProperties(pr);
		}
		public void refreshpath()
		{
			updateTreeviewPaths(RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].properties.roadName);
			//RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count-1].drawdirectpath(RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].startpos,pos);
			for (int i = 0; i < RegistrationAgent.stationRegistrationList.Count; i++)
			{
				RegistrationAgent.stationRegistrationList[i].remove();
				RegistrationAgent.stationRegistrationList[i].setStation(RegistrationAgent.stationRegistrationList[i].props.X, RegistrationAgent.stationRegistrationList[i].props.Y);

			}
			for (int i = 0; i < phalfpoint_manager.Count; i++)
			{
				phalfpoint_manager[i].remove();
				phalfpoint_manager[i].sethalfpoint(20, 20, phalfpoint_manager[i].properties.X, phalfpoint_manager[i].properties.Y, Colors.Red);
			}
		}
		public void settingmovehalfpoint()
		{

		}
		public void updateDatasetting()
		{

		}


		public void SetObjectPoint(HalfPoint point)
		{
			this.tempShape_point = point;
		}
		public void SetObjectPath(PathModel path)
		{
			this.tempShape_path = path;
		}

		public void SetObjectStation(StationModel pstation)
		{
			this.tempShape_station = pstation;
		}
		public void SetObjectCharger(ChargerModel pcharger)
		{
			this.tempShape_charger = pcharger;
		}
		public void SetObjectReady(ReadyModel pready)
		{
			this.tempShape_ready = pready;
		}
		public void SetObjectCheckin(CheckinModel pcheckin)
		{
			this.tempShape_checkin = pcheckin;
		}
		public void SetObjectCheckout(CheckoutModel pcheckout)
		{
			this.tempShape_checkout = pcheckout;
		}


        public void modeEditStation()
        {
            //System.Windows.MessageBox.Show("edit");
            this.tempShape_station.Show();
        }
        public void modeEditCharger()
        {
            //System.Windows.MessageBox.Show("edit");
            this.tempShape_charger.Show();
        }
        public void modeEditReady()
        {
            //System.Windows.MessageBox.Show("edit");
            this.tempShape_ready.Show();
        }
        public void modeEditCheckin()
        {
            //System.Windows.MessageBox.Show("edit");
            this.tempShape_checkin.Show();
        }
        public void modeEditCheckout()
        {
            //System.Windows.MessageBox.Show("edit");
            this.tempShape_checkout.Show();
        }
        public void modeViewStation()
        {
            //System.Windows.MessageBox.Show("view");
            //this.tempShape_station.Show();
            //rtsp://admin:seldatinc123@192.168.0.3:754/h265/ch1/main/av_stream
            try
            {
                String url = "rtsp://admin:seldatinc123@" + tempShape_station.props.cam.ip + ":" + tempShape_station.props.cam.port + "/h265/ch1/main/av_stream";
                //System.Windows.MessageBox.Show(url);
                if (tempShape_station.props.isConnected)
                {
                    LiveViewForm liveFormStation = new LiveViewForm(url);
                    liveFormStation.setcam(tempShape_station.props.area, tempShape_station.props.cam.id.ToString());
                    liveFormStation.Show();
                }
                else
                {
                    System.Windows.MessageBox.Show("Please connect to Station!");
                }
            }
            catch { }
        }



        public void removeobject_Halfpoint(HalfPoint phalfpoint)
		{
			System.Windows.Forms.DialogResult pwarming = System.Windows.Forms.MessageBox.Show("Do you want to delete this element?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (pwarming == DialogResult.No)
			{
				return;
			}
			else if (pwarming == DialogResult.Yes)
			{
				for (int index1 = 0; index1 < phalfpoint_manager.Count; index1++)
				{
					if (phalfpoint_manager[index1].properties.NameObj.Equals(phalfpoint.properties.NameObj))
					{
						phalfpoint_manager.RemoveAt(index1);
						break;
					}
				}
				for (int index2 = 0; index2 < ptreeviewitem_Points.Count; index2++)
				{
					if (ptreeviewitem_Points[index2].Header.Equals(phalfpoint.properties.NameObj))
					{
						ptreeviewitem_Points.RemoveAt(index2);
						break;
					}
				}
				for (int index3 = 0; index3 < this.content.trv_points.Items.Count; index3++)
				{

					TreeViewItem ptemp = this.content.trv_points.Items.GetItemAt(index3) as TreeViewItem;
					if (ptemp.Header.Equals(phalfpoint.properties.NameObj))
					{
						this.content.trv_points.Items.RemoveAt(index3);
						break;
					}
				}
				//phalfpoint_manager.RemoveAt(phalfpoint.idnum);
				//ptreeviewitem_Points.RemoveAt(phalfpoint.idnum);
				//this.content.trv_points.Items.RemoveAt(phalfpoint.idnum);
				phalfpoint.removeobject();

			}

		}

		public void removeobject_station(StationModel pstation)
		{
			System.Windows.Forms.DialogResult pwarming = System.Windows.Forms.MessageBox.Show("Do you want to delete this element?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (pwarming == DialogResult.No)
			{
				return;
			}
			else if (pwarming == DialogResult.Yes)
			{

				for (int index1 = 0; index1 < RegistrationAgent.stationRegistrationList.Count; index1++)
				{
					if (RegistrationAgent.stationRegistrationList[index1].props.NameID.Equals(pstation.props.NameID))
					{
						RegistrationAgent.stationRegistrationList.RemoveAt(index1);
						break;
					}
				}
				for (int index2 = 0; index2 < ptreeviewitem_Stations.Count; index2++)
				{
					if (ptreeviewitem_Stations[index2].Header.Equals(pstation.props.NameID))
					{
						ptreeviewitem_Stations.RemoveAt(index2);
						break;
					}
				}
				for (int index3 = 0; index3 < this.content.trv_stations.Items.Count; index3++)
				{

					TreeViewItem ptemp = this.content.trv_stations.Items.GetItemAt(index3) as TreeViewItem;
					if (ptemp.Header.Equals(pstation.props.NameID))
					{
						this.content.trv_stations.Items.RemoveAt(index3);
						break;
					}
				}
				//phalfpoint_manager.RemoveAt(phalfpoint.idnum);
				//ptreeviewitem_Points.RemoveAt(phalfpoint.idnum);
				//this.content.trv_points.Items.RemoveAt(phalfpoint.idnum);
				pstation.removeobject();

			}

		}

        public void removeobject_charger(ChargerModel pcharger)
        {
            System.Windows.Forms.DialogResult pwarming = System.Windows.Forms.MessageBox.Show("Do you want to delete this element?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (pwarming == DialogResult.No)
            {
                return;
            }
            else if (pwarming == DialogResult.Yes)
            {

                for (int index1 = 0; index1 < RegistrationAgent.chargerRegistrationList.Count; index1++)
                {
                    if (RegistrationAgent.chargerRegistrationList[index1].props.NameID.Equals(pcharger.props.NameID))
                    {
                        RegistrationAgent.chargerRegistrationList.RemoveAt(index1);
                        break;
                    }
                }
                for (int index2 = 0; index2 < ptreeviewitem_Charger.Count; index2++)
                {
                    if (ptreeviewitem_Charger[index2].Header.Equals(pcharger.props.NameID))
                    {
                        ptreeviewitem_Charger.RemoveAt(index2);
                        break;
                    }
                }
                for (int index3 = 0; index3 < this.content.trv_charger.Items.Count; index3++)
                {

                    TreeViewItem ptemp = this.content.trv_charger.Items.GetItemAt(index3) as TreeViewItem;
                    if (ptemp.Header.Equals(pcharger.props.NameID))
                    {
                        this.content.trv_charger.Items.RemoveAt(index3);
                        break;
                    }
                }
                //phalfpoint_manager.RemoveAt(phalfpoint.idnum);
                //ptreeviewitem_Points.RemoveAt(phalfpoint.idnum);
                //this.content.trv_points.Items.RemoveAt(phalfpoint.idnum);
                pcharger.removeobject();

            }

        }

        public void removeobject_ready(ReadyModel pready)
        {
            System.Windows.Forms.DialogResult pwarming = System.Windows.Forms.MessageBox.Show("Do you want to delete this element?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (pwarming == DialogResult.No)
            {
                return;
            }
            else if (pwarming == DialogResult.Yes)
            {

                for (int index1 = 0; index1 < RegistrationAgent.readyRegistrationList.Count; index1++)
                {
                    if (RegistrationAgent.readyRegistrationList[index1].props.NameID.Equals(pready.props.NameID))
                    {
                        RegistrationAgent.readyRegistrationList.RemoveAt(index1);
                        break;
                    }
                }
                for (int index2 = 0; index2 < ptreeviewitem_Ready.Count; index2++)
                {
                    if (ptreeviewitem_Ready[index2].Header.Equals(pready.props.NameID))
                    {
                        ptreeviewitem_Ready.RemoveAt(index2);
                        break;
                    }
                }
                for (int index3 = 0; index3 < this.content.trv_ready.Items.Count; index3++)
                {

                    TreeViewItem ptemp = this.content.trv_ready.Items.GetItemAt(index3) as TreeViewItem;
                    if (ptemp.Header.Equals(pready.props.NameID))
                    {
                        this.content.trv_ready.Items.RemoveAt(index3);
                        break;
                    }
                }
                //phalfpoint_manager.RemoveAt(phalfpoint.idnum);
                //ptreeviewitem_Points.RemoveAt(phalfpoint.idnum);
                //this.content.trv_points.Items.RemoveAt(phalfpoint.idnum);
                pready.removeobject();

            }

        }

        public void removeobject_checkin(CheckinModel pcheckin)
        {
            System.Windows.Forms.DialogResult pwarming = System.Windows.Forms.MessageBox.Show("Do you want to delete this element?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (pwarming == DialogResult.No)
            {
                return;
            }
            else if (pwarming == DialogResult.Yes)
            {

                for (int index1 = 0; index1 < RegistrationAgent.checkinRegistrationList.Count; index1++)
                {
                    if (RegistrationAgent.checkinRegistrationList[index1].props.NameID.Equals(pcheckin.props.NameID))
                    {
                        RegistrationAgent.checkinRegistrationList.RemoveAt(index1);
                        break;
                    }
                }
                for (int index2 = 0; index2 < ptreeviewitem_Checkin.Count; index2++)
                {
                    if (ptreeviewitem_Checkin[index2].Header.Equals(pcheckin.props.NameID))
                    {
                        ptreeviewitem_Checkin.RemoveAt(index2);
                        break;
                    }
                }
                for (int index3 = 0; index3 < this.content.trv_checkin.Items.Count; index3++)
                {

                    TreeViewItem ptemp = this.content.trv_checkin.Items.GetItemAt(index3) as TreeViewItem;
                    if (ptemp.Header.Equals(pcheckin.props.NameID))
                    {
                        this.content.trv_checkin.Items.RemoveAt(index3);
                        break;
                    }
                }
                //phalfpoint_manager.RemoveAt(phalfpoint.idnum);
                //ptreeviewitem_Points.RemoveAt(phalfpoint.idnum);
                //this.content.trv_points.Items.RemoveAt(phalfpoint.idnum);
                pcheckin.removeobject();

            }

        }

        public void removeobject_checkout(CheckoutModel pcheckout)
        {
            System.Windows.Forms.DialogResult pwarming = System.Windows.Forms.MessageBox.Show("Do you want to delete this element?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (pwarming == DialogResult.No)
            {
                return;
            }
            else if (pwarming == DialogResult.Yes)
            {

                for (int index1 = 0; index1 < RegistrationAgent.checkoutRegistrationList.Count; index1++)
                {
                    if (RegistrationAgent.checkoutRegistrationList[index1].props.NameID.Equals(pcheckout.props.NameID))
                    {
                        RegistrationAgent.checkoutRegistrationList.RemoveAt(index1);
                        break;
                    }
                }
                for (int index2 = 0; index2 < ptreeviewitem_Checkout.Count; index2++)
                {
                    if (ptreeviewitem_Checkout[index2].Header.Equals(pcheckout.props.NameID))
                    {
                        ptreeviewitem_Checkout.RemoveAt(index2);
                        break;
                    }
                }
                for (int index3 = 0; index3 < this.content.trv_checkout.Items.Count; index3++)
                {

                    TreeViewItem ptemp = this.content.trv_checkout.Items.GetItemAt(index3) as TreeViewItem;
                    if (ptemp.Header.Equals(pcheckout.props.NameID))
                    {
                        this.content.trv_checkout.Items.RemoveAt(index3);
                        break;
                    }
                }
                //phalfpoint_manager.RemoveAt(phalfpoint.idnum);
                //ptreeviewitem_Points.RemoveAt(phalfpoint.idnum);
                //this.content.trv_points.Items.RemoveAt(phalfpoint.idnum);
                pcheckout.removeobject();

            }

        }


        public void removeobject_robotagent(RobotAgent robotAgent)
		{
			System.Windows.Forms.DialogResult pwarming = System.Windows.Forms.MessageBox.Show("Do you want to delete this element?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (pwarming == DialogResult.No)
			{
				return;
			}
			else if (pwarming == DialogResult.Yes)
			{
				for (int index1 = 0; index1 < RegistrationAgent.robotAgentRegisteredList.Count; index1++)
				{
					if (RegistrationAgent.robotAgentRegisteredList.ElementAt(index1).Value.NameID.Equals(robotAgent.NameID))
					{
						RegistrationAgent.robotAgentRegisteredList.Remove(RegistrationAgent.robotAgentRegisteredList.ElementAt(index1).Key);
						break;
					}
				}
				for (int index2 = 0; index2 < ptreeviewitem_robotconfig.Count; index2++)
				{
					if (ptreeviewitem_robotconfig[index2].Header.Equals(robotAgent.NameID))
					{
						ptreeviewitem_robotconfig.RemoveAt(index2);
						break;
					}
				}
				for (int index3 = 0; index3 < this.content.trv_vehclies.Items.Count; index3++)
				{

					TreeViewItem ptemp = this.content.trv_vehclies.Items.GetItemAt(index3) as TreeViewItem;
					if (ptemp.Header.Equals(robotAgent.NameID))
					{
						this.content.trv_vehclies.Items.RemoveAt(index3);
						break;
					}
				}

				//tempPath.remove();

			}
		}
		public void removeobject_paths(PathModel tempPath)
		{
			System.Windows.Forms.DialogResult pwarming = System.Windows.Forms.MessageBox.Show("Do you want to delete this element?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (pwarming == DialogResult.No)
			{
				return;
			}
			else if (pwarming == DialogResult.Yes)
			{
				for (int index1 = 0; index1 < RegistrationAgent.pathRegistrationList.Count; index1++)
				{
					if (RegistrationAgent.pathRegistrationList[index1].properties.roadName.Equals(tempPath.properties.roadName))
					{
						RegistrationAgent.pathRegistrationList[index1].removeHighWaytoEndPoint(tempPath.properties.roadName);
						RegistrationAgent.pathRegistrationList.RemoveAt(index1);
						break;
					}
				}
				for (int index2 = 0; index2 < ptreeviewitem_Paths.Count; index2++)
				{
					if (ptreeviewitem_Paths[index2].Header.Equals(tempPath.properties.roadName))
					{
						ptreeviewitem_Paths.RemoveAt(index2);
						break;
					}
				}
				for (int index3 = 0; index3 < this.content.trv_paths.Items.Count; index3++)
				{

					TreeViewItem ptemp = this.content.trv_paths.Items.GetItemAt(index3) as TreeViewItem;
					if (ptemp.Header.Equals(tempPath.properties.roadName))
					{
						this.content.trv_paths.Items.RemoveAt(index3);
						break;
					}
				}

				tempPath.remove();

			}
		}



		public void SetObjectPath_StartPoint(HalfPoint sP)
		{
			this.tempShape_point_sP = sP;
			sP.Getpath(RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1], HalfPoint.FLAGPOINTDEFINED.FLAGPOINT_SET_STARTPOINT);
			RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.startpoint = sP;
			RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.frontNodeConnected = PathModel.NODECONNECTED.FRONTNODE_CONNECTED_HALFPOINT;

		}
		public void SetObjectPath_EndPoint(HalfPoint eP)
		{
			this.tempShape_point_eP = eP;
			eP.Getpath(RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1], HalfPoint.FLAGPOINTDEFINED.FLAGPOINT_SET_ENDPOINT);
			RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.endpoint = eP;
			//RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].addHighWaytoEndPoint(eP);
			RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.backNodeConnected = PathModel.NODECONNECTED.BACKNODE_CONNECTED_HALFPOINT;


		}
		public void SetObjectPath_EndPoint(StationModel eP)
		{
			this.tempShape_station_eP = eP;
			eP.Getpath(RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1], StationModel.FLAGPOINTDEFINED.FLAGPOINT_SET_ENDPOINT);
			RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.endpoint_station = eP;
			RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.backNodeConnected = PathModel.NODECONNECTED.BACKNODE_CONNECTED_STATION;
		}
		public void SetObjectPath_StartPoint(StationModel sP)
		{
			this.tempShape_station_sP = sP;
			sP.Getpath(RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1], StationModel.FLAGPOINTDEFINED.FLAGPOINT_SET_STARTPOINT);
			RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.startpoint_station = sP;
			RegistrationAgent.pathRegistrationList[RegistrationAgent.pathRegistrationList.Count - 1].nodeConnected.frontNodeConnected = PathModel.NODECONNECTED.FRONTNODE_CONNECTED_STATION; ;
		}



		public void updatePropertiesInformationPoint()
		{
			List<User> users = new List<User>();
			users.Add(new User() { Attribude = "Text", Value = this.tempShape_point.properties.NameObj });
			users.Add(new User() { Attribude = "Length", Value = this.tempShape_point.properties.LengthValue + "" });
			users.Add(new User() { Attribude = "Cost", Value = this.tempShape_point.properties.CostValue + "" });
			users.Add(new User() { Attribude = "X Model (mm)", Value = this.tempShape_point.properties.X_model + "" });
			users.Add(new User() { Attribude = "Y Model (mm)", Value = this.tempShape_point.properties.Y_model + "" });
			users.Add(new User() { Attribude = "Point X location", Value = this.tempShape_point.properties.X + "" });
			users.Add(new User() { Attribude = "Point X location", Value = this.tempShape_point.properties.Y + "" });
			users.Add(new User() { Attribude = "Width", Value = this.tempShape_point.properties.Width + "" });
			users.Add(new User() { Attribude = "Height", Value = this.tempShape_point.properties.Height + "" });
			users.Add(new User() { Attribude = "Type", Value = "Half Point" });
			this.content.updateProperties.ItemsSource = users;
		}
		public void updatePropertiesInformationrobot(RobotAgent probot)
		{
			List<User> users = new List<User>();
			users.Add(new User() { Attribude = "Name", Value = probot.NameID});
			users.Add(new User() { Attribude = "Hostname", Value = probot.Hostname });
			users.Add(new User() { Attribude = "IP Address", Value = probot.IpAddress });
			users.Add(new User() { Attribude = "Port", Value = probot.Port + "" });
			users.Add(new User() { Attribude = "Critical Energy At", Value = probot.CriticalEnergyAt + "" });
			users.Add(new User() { Attribude = "Current Energy", Value = probot.CurrentEnergy + "" });
			users.Add(new User() { Attribude = "Good Energy At", Value = probot.GoodEnergyAt + "" });
			users.Add(new User() { Attribude = "Width Robot", Value = probot.WidthRobot + "" });
			users.Add(new User() { Attribude = "Length Robot", Value = probot.LengthRobot + "" });
			users.Add(new User() { Attribude = "Initial Position X", Value = probot.InitialPostion.X + "" });
			users.Add(new User() { Attribude = "Initial Position Y", Value = probot.InitialPostion.Y + "" });
			users.Add(new User() { Attribude = "Initial Heading Angle", Value = probot.InitialHeadingAngle + "" });
			users.Add(new User() { Attribude = "Current Position X", Value = probot.CurrentPosition.X + "" });
			users.Add(new User() { Attribude = "Current Position Y", Value = probot.CurrentPosition.Y + "" });
			users.Add(new User() { Attribude = "Current Heading Angle", Value = probot.CurrentHeadingAngle + "" });
			users.Add(new User() { Attribude = "AreaID", Value = "0" });

			this.content.updateProperties.ItemsSource = users;
		}
		public void updateTreeviewRobotConfig(string name)
		{
			TreeViewItem ptemptrv_robot = new TreeViewItem();
			ptemptrv_robot.Header = name;
			ptreeviewitem_robotconfig.Add(ptemptrv_robot);
			this.content.trv_vehclies.Items.Add(ptemptrv_robot);
		}
		public void updateTreeviewPoints(string name)
		{
			TreeViewItem ptemptrv_point = new TreeViewItem();
			ptemptrv_point.Header = name;
			ptreeviewitem_Points.Add(ptemptrv_point);
			this.content.trv_points.Items.Add(ptemptrv_point);
		}
		public void updateTreeviewStations(string name)
		{
			TreeViewItem ptemptrv_station = new TreeViewItem();
			ptemptrv_station.Header = name;
            //ptemptrv_station.MouseRightButtonDown += Ptemptrv_station_MouseRightButtonDown;

            ptreeviewitem_Stations.Add(ptemptrv_station);
			this.content.trv_stations.Items.Add(ptemptrv_station);
		}
		public void updateTreeviewCharger(string name)
		{
			TreeViewItem ptemptrv_charger = new TreeViewItem();
            ptemptrv_charger.Header = name;
            //ptemptrv_charger.MouseRightButtonDown += Ptemptrv_charger_MouseRightButtonDown;

            ptreeviewitem_Charger.Add(ptemptrv_charger);
			this.content.trv_charger.Items.Add(ptemptrv_charger);
		}
		public void updateTreeviewReady(string name)
		{
			TreeViewItem ptemptrv_ready = new TreeViewItem();
            ptemptrv_ready.Header = name;
            //ptemptrv_ready.MouseRightButtonDown += Ptemptrv_ready_MouseRightButtonDown;

            ptreeviewitem_Ready.Add(ptemptrv_ready);
			this.content.trv_ready.Items.Add(ptemptrv_ready);
		}
		public void updateTreeviewCheckin(string name)
		{
			TreeViewItem ptemptrv_checkin = new TreeViewItem();
            ptemptrv_checkin.Header = name;
            //ptemptrv_checkin.MouseRightButtonDown += Ptemptrv_checkin_MouseRightButtonDown;

            ptreeviewitem_Checkin.Add(ptemptrv_checkin);
			this.content.trv_checkin.Items.Add(ptemptrv_checkin);
		}
		public void updateTreeviewCheckout(string name)
		{
			TreeViewItem ptemptrv_checkout = new TreeViewItem();
            ptemptrv_checkout.Header = name;
            //ptemptrv_checkout.MouseRightButtonDown += Ptemptrv_checkout_MouseRightButtonDown;

            ptreeviewitem_Checkout.Add(ptemptrv_checkout);
			this.content.trv_checkout.Items.Add(ptemptrv_checkout);
		}


        private void Ptemptrv_station_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //var hit = e.OriginalSource as DependencyObject;
            //while (hit != null && !(hit is TreeViewItem))
            //    hit = VisualTreeHelper.GetParent(hit);
            //if (hit == null)
            //    return;
            //TreeViewItem tv_station = hit as TreeViewItem;
            //Console.WriteLine(tv_station.Name);
            System.Windows.Forms.MessageBox.Show("Nothing to do here");
        }
        private void Ptemptrv_ready_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.MessageBox.Show("Nothing to do here!");
        }
        private void Ptemptrv_checkin_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.MessageBox.Show("Nothing to do here!");
        }
        private void Ptemptrv_checkout_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.MessageBox.Show("Nothing to do here!");
        }
        private void Ptemptrv_charger_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.MessageBox.Show("Nothing to do here!");
        }



        public void updateTreeviewPaths(string name)
		{
			TreeViewItem ptemptrv_path = new TreeViewItem();
			ptemptrv_path.Header = name;
			ptreeviewitem_Paths.Add(ptemptrv_path);
			this.content.trv_paths.Items.Add(ptemptrv_path);
		}

        public void updateTreeviewHighway(string name)
        {
            TreeViewItem ptemptrv_highway = new TreeViewItem();
            ptemptrv_highway.Header = name;
            //ptreeviewitem_Paths.Add(ptemptrv_path);
            this.content.trv_highway.Items.Add(ptemptrv_highway);
        }

        public void updatePropertiesInformationPath()
		{
			//try
			{
				List<User> users = new List<User>();
				users.Add(new User() { Attribude = "Road Name", Value = this.tempShape_path.properties.roadName });
				users.Add(new User() { Attribude = "Length(mm)", Value = "450" });
				users.Add(new User() { Attribude = "Cost", Value = "1" });
				users.Add(new User() { Attribude = "Maximum Velocity(mm)", Value = "850" });
				if (this.tempShape_path.nodeConnected.startpoint != null)
					users.Add(new User() { Attribude = "Start Component", Value = "" + this.tempShape_path.nodeConnected.startpoint.properties.NameObj });
				else if (this.tempShape_path.nodeConnected.startpoint_station != null)
					users.Add(new User() { Attribude = "Start Component", Value = "" + this.tempShape_path.nodeConnected.startpoint_station.props.NameID});
				if (this.tempShape_path.nodeConnected.endpoint != null)
					users.Add(new User() { Attribude = "End Component", Value = "" + this.tempShape_path.nodeConnected.endpoint.properties.NameObj });
				else if (this.tempShape_path.nodeConnected.endpoint_station != null)
					users.Add(new User() { Attribude = "End Component", Value = "" + this.tempShape_path.nodeConnected.endpoint_station.props.NameID });
				users.Add(new User() { Attribude = "Type", Value = "Half Point" });
				this.content.updateProperties.ItemsSource = users;
			}
			this.tempShape_path.setName(this.tempShape_path.properties.roadName);
			//catch { }
		}



		public void updatePropertiesInformationStation()
		{
			List<User> users = new List<User>();
			users.Add(new User() { Attribude = "Name", Value = this.tempShape_station.props.NameID});
			users.Add(new User() { Attribude = "Length", Value = this.tempShape_station.props.lengthValue + "" });
			users.Add(new User() { Attribude = "Address", Value = this.tempShape_station.props.addressIP });
			users.Add(new User() { Attribude = "Port", Value = this.tempShape_station.props.port + "" });
			users.Add(new User() { Attribude = "Cost", Value = this.tempShape_station.props.costValue + "" });
			users.Add(new User() { Attribude = "X Model (mm)", Value = "450" });
			users.Add(new User() { Attribude = "Y Model (mm)", Value = "850" });
			users.Add(new User() { Attribude = "Point X location", Value = this.tempShape_station.props.X + "" });
			users.Add(new User() { Attribude = "Point Y location", Value = this.tempShape_station.props.Y + "" });
			users.Add(new User() { Attribude = "Station Area", Value = this.tempShape_station.props.cam.area + "" });
			users.Add(new User() { Attribude = "Station ID", Value = this.tempShape_station.props.cam.id + "" });
			users.Add(new User() { Attribude = "Station IP", Value = this.tempShape_station.props.cam.ip + "" });
			users.Add(new User() { Attribude = "Station PORT", Value = this.tempShape_station.props.cam.port + "" });
			this.content.updateProperties.ItemsSource = users;
		}
        public void updatePropertiesInformationCharger()
        {
            List<User> users = new List<User>();
            users.Add(new User() { Attribude = "Name", Value = this.tempShape_charger.props.NameID });
            users.Add(new User() { Attribude = "Length", Value = this.tempShape_charger.props.LengthValue + "" });
            users.Add(new User() { Attribude = "Address", Value = this.tempShape_charger.props.addressIP });
            users.Add(new User() { Attribude = "Port", Value = this.tempShape_charger.props.port + "" });
            users.Add(new User() { Attribude = "Cost", Value = this.tempShape_charger.props.CostValue + "" });
            users.Add(new User() { Attribude = "X Model (mm)", Value = "450" });
            users.Add(new User() { Attribude = "Y Model (mm)", Value = "850" });
            users.Add(new User() { Attribude = "Point X location", Value = this.tempShape_charger.props.X + "" });
            users.Add(new User() { Attribude = "Point Y location", Value = this.tempShape_charger.props.Y + "" });
            this.content.updateProperties.ItemsSource = users;
        }
        public void updatePropertiesInformationReady()
        {
            List<User> users = new List<User>();
            users.Add(new User() { Attribude = "Name", Value = this.tempShape_ready.props.NameID });
            users.Add(new User() { Attribude = "Address", Value = this.tempShape_ready.props.addressIP });
            users.Add(new User() { Attribude = "Port", Value = this.tempShape_ready.props.port + "" });
            users.Add(new User() { Attribude = "X Model (mm)", Value = "450" });
            users.Add(new User() { Attribude = "Y Model (mm)", Value = "850" });
            users.Add(new User() { Attribude = "Point X location", Value = this.tempShape_ready.props.X + "" });
            users.Add(new User() { Attribude = "Point Y location", Value = this.tempShape_ready.props.Y + "" });
            this.content.updateProperties.ItemsSource = users;
        }
        public void updatePropertiesInformationCheckin()
        {
            List<User> users = new List<User>();
            users.Add(new User() { Attribude = "Name", Value = this.tempShape_checkin.props.NameID });
            users.Add(new User() { Attribude = "Address", Value = this.tempShape_checkin.props.addressIP });
            users.Add(new User() { Attribude = "Port", Value = this.tempShape_checkin.props.port + "" });
            users.Add(new User() { Attribude = "X Model (mm)", Value = "450" });
            users.Add(new User() { Attribude = "Y Model (mm)", Value = "850" });
            users.Add(new User() { Attribude = "Point X location", Value = this.tempShape_checkin.props.X + "" });
            users.Add(new User() { Attribude = "Point Y location", Value = this.tempShape_checkin.props.Y + "" });
            this.content.updateProperties.ItemsSource = users;
        }
        public void updatePropertiesInformationCheckout()
        {
            List<User> users = new List<User>();
            users.Add(new User() { Attribude = "Name", Value = this.tempShape_checkout.props.NameID });
            users.Add(new User() { Attribude = "Address", Value = this.tempShape_checkout.props.addressIP });
            users.Add(new User() { Attribude = "Port", Value = this.tempShape_checkout.props.port + "" });
            users.Add(new User() { Attribude = "X Model (mm)", Value = "450" });
            users.Add(new User() { Attribude = "Y Model (mm)", Value = "850" });
            users.Add(new User() { Attribude = "Point X location", Value = this.tempShape_checkout.props.X + "" });
            users.Add(new User() { Attribude = "Point Y location", Value = this.tempShape_checkout.props.Y + "" });
            this.content.updateProperties.ItemsSource = users;
        }



        public void updatePropertiesObjStation(StationModel ps)
		{
			TextBlock NameObj = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[1]) as TextBlock;
			TextBlock length = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[2]) as TextBlock;
			TextBlock cost = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[3]) as TextBlock;
			TextBlock X_model = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[4]) as TextBlock;
			TextBlock Y_model = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[5]) as TextBlock;
			TextBlock X_location = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[6]) as TextBlock;
			TextBlock Y_location = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[7]) as TextBlock;

			//	ps.NameObj = NameObj.Text;
			ps.props.lengthValue = Convert.ToDouble(length);
			ps.props.costValue = Convert.ToDouble(cost);
			ps.props.X_model = Convert.ToDouble(X_model);
			ps.props.Y_model = Convert.ToDouble(Y_model);
			ps.props.X = Convert.ToDouble(X_location);
			ps.props.Y = Convert.ToDouble(X_location);
		}
        public void updatePropertiesObjCharger(ChargerModel ps)
        {
            TextBlock NameObj = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[1]) as TextBlock;
            TextBlock length = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[2]) as TextBlock;
            TextBlock cost = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[3]) as TextBlock;
            TextBlock X_model = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[4]) as TextBlock;
            TextBlock Y_model = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[5]) as TextBlock;
            TextBlock X_location = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[6]) as TextBlock;
            TextBlock Y_location = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[7]) as TextBlock;

            //	ps.NameObj = NameObj.Text;
            ps.props.LengthValue = Convert.ToDouble(length);
            ps.props.CostValue = Convert.ToDouble(cost);
            ps.props.X_model = Convert.ToDouble(X_model);
            ps.props.Y_model = Convert.ToDouble(Y_model);
            ps.props.X = Convert.ToDouble(X_location);
            ps.props.Y = Convert.ToDouble(X_location);
        }
        public void updatePropertiesObjReady(ReadyModel ps)
        {
            TextBlock NameObj = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[1]) as TextBlock;
            TextBlock length = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[2]) as TextBlock;
            TextBlock cost = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[3]) as TextBlock;
            TextBlock X_model = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[4]) as TextBlock;
            TextBlock Y_model = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[5]) as TextBlock;
            TextBlock X_location = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[6]) as TextBlock;
            TextBlock Y_location = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[7]) as TextBlock;

            //	ps.NameObj = NameObj.Text;

            ps.props.X_model = Convert.ToDouble(X_model);
            ps.props.Y_model = Convert.ToDouble(Y_model);
            ps.props.X = Convert.ToDouble(X_location);
            ps.props.Y = Convert.ToDouble(X_location);
        }
        public void updatePropertiesObjCheckin(CheckinModel ps)
        {
            TextBlock NameObj = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[1]) as TextBlock;
            TextBlock length = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[2]) as TextBlock;
            TextBlock cost = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[3]) as TextBlock;
            TextBlock X_model = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[4]) as TextBlock;
            TextBlock Y_model = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[5]) as TextBlock;
            TextBlock X_location = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[6]) as TextBlock;
            TextBlock Y_location = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[7]) as TextBlock;

            //	ps.NameObj = NameObj.Text;

            ps.props.X_model = Convert.ToDouble(X_model);
            ps.props.Y_model = Convert.ToDouble(Y_model);
            ps.props.X = Convert.ToDouble(X_location);
            ps.props.Y = Convert.ToDouble(X_location);
        }

        public void updatePropertiesObjCheckout(CheckoutModel ps)
        {
            TextBlock NameObj = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[1]) as TextBlock;
            TextBlock length = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[2]) as TextBlock;
            TextBlock cost = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[3]) as TextBlock;
            TextBlock X_model = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[4]) as TextBlock;
            TextBlock Y_model = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[5]) as TextBlock;
            TextBlock X_location = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[6]) as TextBlock;
            TextBlock Y_location = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[7]) as TextBlock;

            //	ps.NameObj = NameObj.Text;

            ps.props.X_model = Convert.ToDouble(X_model);
            ps.props.Y_model = Convert.ToDouble(Y_model);
            ps.props.X = Convert.ToDouble(X_location);
            ps.props.Y = Convert.ToDouble(X_location);
        }

        public void updatePropertiesObjPoint(HalfPoint ph)
		{
			TextBlock NameObj = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[0]) as TextBlock;
			TextBlock length = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[1]) as TextBlock;
			TextBlock cost = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[2]) as TextBlock;
			TextBlock X_model = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[3]) as TextBlock;
			TextBlock Y_model = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[4]) as TextBlock;
			TextBlock X_location = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[5]) as TextBlock;
			TextBlock Y_location = this.content.updateProperties.Columns[1].GetCellContent(this.content.updateProperties.Items[6]) as TextBlock;

			ph.properties.NameObj = NameObj.Text;
			ph.properties.LengthValue = Convert.ToDouble(length);
			ph.properties.CostValue = Convert.ToDouble(cost);
			ph.properties.X_model = Convert.ToDouble(X_model);
			ph.properties.Y_model = Convert.ToDouble(Y_model);
			ph.properties.X = Convert.ToDouble(X_location);
			ph.properties.Y = Convert.ToDouble(X_location);
		}

        public void addHighWay()
        {
            String name = "HWA"+GlobalVariables.EncodeTransmissionTimestamp();
            HighwayModel phighway = new HighwayModel(name);
            phighway.setText("HWA"+ RegistrationAgent.highwayRegistrationList.Count);
            updateTreeviewHighway(phighway.properties.NameKey);
            RegistrationAgent.highwayRegistrationList.Add(phighway);
        }

		//public bool StationAutoConnect (int cameraID, string cameraIP, int cameraPORT, int areaID)
		//{

		//}


		public void ClearAll()
		{
			if (RegistrationAgent.robotAgentRegisteredList.Count > 0)
				RegistrationAgent.robotAgentRegisteredList.Clear();
			if (phalfpoint_manager.Count > 0)
			{
				for (int i = 0; i < phalfpoint_manager.Count; i++)
				{
					phalfpoint_manager[i].removeobject();
					phalfpoint_manager[i] = null;
				}
				phalfpoint_manager.Clear();

			}

			if (RegistrationAgent.pathRegistrationList.Count > 0)
			{
				for (int i = 0; i < RegistrationAgent.pathRegistrationList.Count; i++)
				{
					RegistrationAgent.pathRegistrationList[i].remove();
					RegistrationAgent.pathRegistrationList[i] = null;
				}
				RegistrationAgent.pathRegistrationList.Clear();

			}
			if (RegistrationAgent.stationRegistrationList.Count > 0)
			{
				for (int i = 0; i < RegistrationAgent.stationRegistrationList.Count; i++)
				{
					RegistrationAgent.stationRegistrationList[i].remove();
					RegistrationAgent.stationRegistrationList[i] = null;
				}
				RegistrationAgent.stationRegistrationList.Clear();

			}
			if (ptreeviewitem_Points.Count > 0)
			{
				for (int i = 0; i < ptreeviewitem_Points.Count; i++)
				{
					ptreeviewitem_Points[i].Items.Clear();
					ptreeviewitem_Points[i] = null;
				}
				ptreeviewitem_Points.Clear();
				this.content.trv_points.Items.Clear();

			}
			if (ptreeviewitem_Paths.Count > 0)
			{
				for (int i = 0; i < ptreeviewitem_Paths.Count; i++)
				{
					ptreeviewitem_Paths[i].Items.Clear();
					ptreeviewitem_Paths[i] = null;
				}
				ptreeviewitem_Paths.Clear();
				this.content.trv_paths.Items.Clear();
			}
			if (ptreeviewitem_Stations.Count > 0)
			{
				for (int i = 0; i < ptreeviewitem_Stations.Count; i++)
				{
					ptreeviewitem_Stations[i].Items.Clear();
					ptreeviewitem_Stations[i] = null;
				}
				ptreeviewitem_Stations.Clear();
				this.content.trv_stations.Items.Clear();

			}
			if (ptreeviewitem_robotconfig.Count > 0)
			{
				for (int i = 0; i < ptreeviewitem_robotconfig.Count; i++)
				{
					ptreeviewitem_robotconfig[i].Items.Clear();
					ptreeviewitem_robotconfig[i] = null;
				}
				ptreeviewitem_robotconfig.Clear();
				this.content.trv_vehclies.Items.Clear();
			}
			if (tempShape_point != null)
				tempShape_point = null;
			if (tempShape_point_sP != null)
				tempShape_point_sP = null;
			if (tempShape_point_eP != null)
				tempShape_point_eP = null;
			if (tempShape_path != null)
				tempShape_path = null;
			if (tempShape_station != null)
				tempShape_station = null;
			if (tempShape_charger != null)
                tempShape_charger = null;
			if (tempShape_ready != null)
                tempShape_ready = null;
			if (tempShape_checkin != null)
                tempShape_checkin = null;
			if (tempShape_checkout != null)
                tempShape_checkout = null;
			/*public List<PathModel> RegistrationAgent.pathRegistrationList;
			public List<Station> RegistrationAgent.stationRegistrationList;
			public List<TreeViewItem> ptreeviewitem_Points;
			public List<TreeViewItem> ptreeviewitem_Paths;
			public List<TreeViewItem> ptreeviewitem_Stations;
			public List<Shape> pshape;
			public HalfPoint tempShape_point;
			public HalfPoint tempShape_point_sP;
			public HalfPoint tempShape_point_eP;

			public Station tempShape_station_sP;
			public Station tempShape_station_eP;
			public PathModel tempShape_path;
			public Station tempShape_station;*/
		}
	}
}
