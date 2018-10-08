using SeldatMRMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeldatMRMS.Management.OrderManager
{
    public class Area
    {
        String area = "null";


        int dockAllow = 9999;
        int putAllow = 9999;
        int mixedAllow = 9999;


        public SortedDictionary<String, StationModel> dockingStations = null; //<Docking-"stationNameID">,<Agent>
        public SortedDictionary<String, StationModel> putAwayStations = null; //<PutAway-"stationNameID">,<Agent>
        public SortedDictionary<String, StationModel> mixedStations = null; //<PutAway-"stationNameID">,<Agent>


        public SortedDictionary<String, OrderLineInfo> DOCKING_LINE_LIST = null; //<stationID-Line>,<Info>
        public SortedDictionary<String, OrderLineInfo> PUTAWAY_LINE_LIST = null; //<stationID-Line>,<Info>

        public Area(String AreaID)
        {
            this.area = AreaID;
            DOCKING_LINE_LIST = new SortedDictionary<String, OrderLineInfo>();
            PUTAWAY_LINE_LIST = new SortedDictionary<String, OrderLineInfo>();
            dockingStations = new SortedDictionary<String, StationModel>(); // <>
            putAwayStations = new SortedDictionary<String, StationModel>();
            mixedStations = new SortedDictionary<String, StationModel>();
        }

        public class OrderLineInfo
        {
            public int line;
            public bool valid;
            public bool ordered;
            public string stationNameID;
            public bool removable;
            public int orderedPallets;
            public List<int> palletList;
            public string palletWarningKey;
            public OrderLineInfo()
            {
                stationNameID = "-1";
                line = -1;
                orderedPallets = -1;
                palletList = new List<int>();
                ordered = false;
                removable = false;
                valid = true;
                palletWarningKey = "-1";
            }
            public bool GetPallet(List<int> temp)
            {
                string messLog = "";
                if (orderedPallets < (palletList.Count - 1))
                {
                    temp.Add(palletList[orderedPallets]);
                    orderedPallets++;
                    if (ordered == false)
                    {
                        ordered = true;
                        for (int i = 0; i < palletList.Count(); i++)
                        {
                            messLog = messLog + "[" + palletList[i] + "]";
                        }
                        messLog = "Pallet " + stationNameID + "-" + line + "-" + messLog + " is ordered.";
                    }
                    RegistrationAgent.mainWindowPointer.LogConsole(messLog, "logStation");
                    return true;
                }
                else if (orderedPallets == (palletList.Count - 1))
                {
                    temp.Add(palletList[orderedPallets]);
                    orderedPallets++;
                    if (ordered == false)
                    {
                        ordered = true;
                    }
                    removable = true;
                    messLog = "Line " + stationNameID + "-" + line + " is ready to remove.";
                    RegistrationAgent.mainWindowPointer.LogConsole(messLog, "logStation");
                    return true;
                }
                removable = true;
                messLog = "Line " + stationNameID + "-" + line + " is ready to remove.";
                RegistrationAgent.mainWindowPointer.LogConsole(messLog, "logStation");
                return false;
            }
        }

        public string GetDockingLine()
        {
            if (DOCKING_LINE_LIST.Count != 0)
            {
                for (int listLineDockingIndex = 0; listLineDockingIndex < DOCKING_LINE_LIST.Count; listLineDockingIndex++)
                {
                    string pendingListLineDockingKey = DOCKING_LINE_LIST.ElementAt(listLineDockingIndex).Key;
                    if ((DOCKING_LINE_LIST[pendingListLineDockingKey].ordered == false) && (DOCKING_LINE_LIST[pendingListLineDockingKey].valid == true))
                    {
                        return pendingListLineDockingKey;
                    }
                }
            }
            return "none";
        }

        public string GetPutAwayLine()
        {
            if (PUTAWAY_LINE_LIST.Count != 0)
            {
                for (int listLinePutAwayIndex = 0; listLinePutAwayIndex < PUTAWAY_LINE_LIST.Count; listLinePutAwayIndex++)
                {
                    string pendingListLinePutAwayKey = PUTAWAY_LINE_LIST.ElementAt(listLinePutAwayIndex).Key;
                    if ((PUTAWAY_LINE_LIST[pendingListLinePutAwayKey].ordered == false) && (PUTAWAY_LINE_LIST[pendingListLinePutAwayKey].valid == true))
                    {
                        return pendingListLinePutAwayKey;
                    }
                }
            }
            return "none";
        }

        public string GetMixedLine(bool isDocking)
        {
            if (isDocking)
            {
                if (DOCKING_LINE_LIST.Count != 0)
                {
                    for (int listLineDockingIndex = 0; listLineDockingIndex < DOCKING_LINE_LIST.Count; listLineDockingIndex++)
                    {
                        string pendingListLineDockingKey = DOCKING_LINE_LIST.ElementAt(listLineDockingIndex).Key;
                        if ((DOCKING_LINE_LIST[pendingListLineDockingKey].ordered == false) && (DOCKING_LINE_LIST[pendingListLineDockingKey].valid == true))
                        {
                            return pendingListLineDockingKey;
                        }
                    }
                }
            }
            else
            {
                if (PUTAWAY_LINE_LIST.Count != 0)
                {
                    for (int listLinePutAwayIndex = 0; listLinePutAwayIndex < PUTAWAY_LINE_LIST.Count; listLinePutAwayIndex++)
                    {
                        string pendingListLinePutAwayKey = PUTAWAY_LINE_LIST.ElementAt(listLinePutAwayIndex).Key;
                        if ((PUTAWAY_LINE_LIST[pendingListLinePutAwayKey].ordered == false) && (PUTAWAY_LINE_LIST[pendingListLinePutAwayKey].valid == true))
                        {
                            return pendingListLinePutAwayKey;
                        }
                    }
                }
            }
            return "none";
        }

        public bool CheckPalletInDockingArea()
        {
            if (DOCKING_LINE_LIST.Count != 0)
            {
                return true;
            }

            return false;
        }

        public bool AddDocking(StationModel station)
        {
            if (CheckDockingID(station.props.id.ToString()) == true) // There is available slot in this Area
            {
                dockingStations.Add("Docking-" + station.props.NameID, station);
                RegistrationAgent.mainWindowPointer.LogConsole("Created " + station.props.NameID + " Station.", "logStation");
                return true;
            }
            RegistrationAgent.mainWindowPointer.LogConsole("Can not create Docking Station.", "logStation");
            return false;
        }
        
        public bool AddPutAway(StationModel station)
        {
            if (CheckPutAwayID(station.props.id.ToString()) == true) // There is available slot in this Area
            {
                putAwayStations.Add("PutAway-" + station.props.NameID, station);
                RegistrationAgent.mainWindowPointer.LogConsole("Created " + station.props.NameID + " Station.", "logStation");
                return true;
            }
            RegistrationAgent.mainWindowPointer.LogConsole("Can not create Put-Away Station!", "logStation");
            return false;
        }
        
        public bool AddMixed(StationModel station)
        {
            if (CheckMixedID(station.props.id.ToString()) == true) // There is available slot in this Area
            {
                mixedStations.Add("Mixed-" + station.props.NameID, station);
                RegistrationAgent.mainWindowPointer.LogConsole("Created " + station.props.NameID + " Station.", "logStation");
                return true;
            }
            RegistrationAgent.mainWindowPointer.LogConsole("Can not create Mixed Station!", "logStation");
            return false;
        }
        
        private bool CheckDockingID(String stationNameID)
        {
            if (dockingStations.Count < dockAllow)
            {
                if (dockingStations.ContainsKey("Docking-" + stationNameID) == false)
                {
                    return true;
                    // We can use this Agent as Docking Agent for this Area
                }
            }
            // This Agent is already a Docking or Docking slot is fulled
            return false;
        }

        private bool CheckPutAwayID(String stationNameID)
        {
            if (putAwayStations.Count < putAllow)
            {
                if (putAwayStations.ContainsKey("PutAway-" + stationNameID) == false)
                {
                    // We can use this Agent as Put-away Agent for this Area
                    return true;
                }
            }
            // This Agent is already a Put-away or Put-away 
            return false;
        }

        private bool CheckMixedID(String stationNameID)
        {
            if (mixedStations.Count < mixedAllow)
            {
                if (mixedStations.ContainsKey("Mixed-" + stationNameID) == false)
                {
                    // We can use this Agent as Mixed Agent for this Area
                    return true;
                }
            }
            // This Agent is already a Mixed or Put-away 
            return false;
        }

        public bool ProcessStation(string typeName, string stationNameID)
        {
            switch (typeName)
            {
                case "DOCKING":
                    {
                        ProcessDocking("Docking-" + stationNameID);
                        return true;
                    }
                case "PUTAWAY":
                    {
                        ProcessPutAway("PutAway-" + stationNameID);
                        return true;
                    }
                case "MIXED":
                    {
                        ProcessMixed("Mixed-" + stationNameID);
                        return true;
                    }
                default:
                    {
                        return false;
                    }
            }
        }

        private void ProcessDocking(string dockingDictKey)
        {
            string stationNameID = dockingDictKey.Split('-')[1];
            int NUMBER_OF_LINE = dockingStations[dockingDictKey].props.cam.numLs;
            int NUMBER_OF_PALLET_PER_LINE = dockingStations[dockingDictKey].props.cam.numPsPL;
            for (int lineIndex = 0; lineIndex < NUMBER_OF_LINE; lineIndex++) //Scan all Line
            {
                string listLineDockingKey = stationNameID + "-" + lineIndex;
                //New or Update
                if (DOCKING_LINE_LIST.ContainsKey(listLineDockingKey) == false) // ==> NEW
                {
                    OrderLineInfo dockLineInfoTemp = new OrderLineInfo
                    {
                        stationNameID = stationNameID,
                        line = lineIndex,
                        orderedPallets = 0,
                        palletList = new List<int>(),
                        ordered = false,
                        removable = false,
                        valid = true,
                        palletWarningKey = "-1"
                    };
                    for (int palletIndex = 0; palletIndex < NUMBER_OF_PALLET_PER_LINE; palletIndex++)
                    {
                        if (dockingStations[dockingDictKey].props.cam.lineArray[lineIndex.ToString()].palletArray[palletIndex.ToString()] == "yes")
                        {
                            dockLineInfoTemp.palletList.Add(palletIndex);
                            dockLineInfoTemp.valid = dockingStations[dockingDictKey].props.cam.lineArray[lineIndex.ToString()].valid;
                            dockLineInfoTemp.palletWarningKey = dockingStations[dockingDictKey].props.cam.lineArray[lineIndex.ToString()].palletWarning;
                            DOCKING_LINE_LIST.Add(listLineDockingKey, dockLineInfoTemp);
                            string addLog = "";
                            for (int i = 0; i < dockLineInfoTemp.palletList.Count(); i++)
                            {
                                addLog = addLog + "[" + dockLineInfoTemp.palletList[i] + "]";
                            }
                            addLog = "Added line DK: " + listLineDockingKey + "-" + addLog;
                            addLog = addLog + "-useable: " + dockLineInfoTemp.valid;// + "-palletWarningKey: " + dockLineInfoTemp.palletWarningKey;
                            RegistrationAgent.mainWindowPointer.LogConsole(addLog, "logStation");
                            //LogWriter.LogWrite("Area\\Area" + area, addLog, "Docking-" + listLineDockingKey);
                            break;
                        }
                    }
                }
                else // Đã tồn tại Line Docking [listLineDockingKey] ==> UPDATE
                {
                    List<int> palletList = new List<int>();
                    for (int palletIndex = 0; palletIndex < NUMBER_OF_PALLET_PER_LINE; palletIndex++)
                    {
                        if (dockingStations[dockingDictKey].props.cam.lineArray[lineIndex.ToString()].palletArray[palletIndex.ToString()] == "yes")
                        {
                            palletList.Add(palletIndex);
                            string updateLog = "";
                            for (int i = 0; i < palletList.Count(); i++)
                            {
                                updateLog = updateLog + "[" + palletList[i] + "]";
                            }
                            if ((!DOCKING_LINE_LIST[listLineDockingKey].palletList.SequenceEqual(palletList)) ||
                                (DOCKING_LINE_LIST[listLineDockingKey].valid != dockingStations[dockingDictKey].props.cam.lineArray[lineIndex.ToString()].valid) ||
                                (DOCKING_LINE_LIST[listLineDockingKey].palletWarningKey != dockingStations[dockingDictKey].props.cam.lineArray[lineIndex.ToString()].palletWarning))
                            {
                                DOCKING_LINE_LIST[listLineDockingKey].valid = dockingStations[dockingDictKey].props.cam.lineArray[lineIndex.ToString()].valid;
                                DOCKING_LINE_LIST[listLineDockingKey].palletWarningKey = dockingStations[dockingDictKey].props.cam.lineArray[lineIndex.ToString()].palletWarning;
                                DOCKING_LINE_LIST[listLineDockingKey].palletList = palletList;
                                updateLog = "Updated line DK: " + listLineDockingKey + "-" + updateLog;
                                updateLog = updateLog + "-useable: " + DOCKING_LINE_LIST[listLineDockingKey].valid;// + "-palletWarningKey: " + DOCKING_LINE_LIST[listLineDockingKey].palletWarningKey;
                                RegistrationAgent.mainWindowPointer.LogConsole(updateLog, "logStation");
                                //LogWriter.LogWrite("Area\\Area" + area, updateLog, "Docking-" + listLineDockingKey);
                            }
                            break;
                        }
                    }
                    if (palletList.Count == 0)
                    {
                        //Trống line thì xóa khỏi List Line Docking
                        string deleteLog = "";
                        deleteLog = "Deleted line DK: " + listLineDockingKey + "-" + deleteLog;
                        deleteLog = deleteLog + "-useable: " + DOCKING_LINE_LIST[listLineDockingKey].valid;// + "-palletWarningKey: " + DOCKING_LINE_LIST[listLineDockingKey].palletWarningKey;
                        RegistrationAgent.mainWindowPointer.LogConsole(deleteLog, "logStation");
                        //LogWriter.LogWrite("Area\\Area" + area, deleteLog, "Docking-" + listLineDockingKey);
                        DOCKING_LINE_LIST.Remove(listLineDockingKey);
                    }
                }
            }
        }

        private void ProcessPutAway(string putAwayDictKey)
        {
            string stationNameID = putAwayDictKey.Split('-')[1];
            int NUMBER_OF_LINE = putAwayStations[putAwayDictKey].props.cam.numLs;
            int NUMBER_OF_PALLET_PER_LINE = putAwayStations[putAwayDictKey].props.cam.numPsPL;
            for (int lineIndex = 0; lineIndex < NUMBER_OF_LINE; lineIndex++)
            {
                string listLinePutAwayKey = stationNameID + "-" + lineIndex;
                //New or Update
                if (PUTAWAY_LINE_LIST.ContainsKey(listLinePutAwayKey) == false) //NEW
                {
                    OrderLineInfo putLineInfoTemp = new OrderLineInfo
                    {
                        stationNameID = stationNameID,
                        line = lineIndex,
                        orderedPallets = 0,
                        palletList = new List<int>(),
                        ordered = false,
                        removable = false,
                        valid = true,
                        palletWarningKey = "-1"
                    };
                    for (int palletIndex = NUMBER_OF_PALLET_PER_LINE - 1; palletIndex >= 0; palletIndex--)
                    {
                        if (putAwayStations[putAwayDictKey].props.cam.lineArray[lineIndex.ToString()].palletArray[palletIndex.ToString()] == "no")
                        {
                            putLineInfoTemp.palletList.Add(palletIndex);
                        }
                        else if (putAwayStations[putAwayDictKey].props.cam.lineArray[lineIndex.ToString()].palletArray[palletIndex.ToString()] == "yes")
                        //Chỉ lấy nhũng pallet ở dưới phòng pallet được lấy đi ở đầu hàng
                        {
                            putLineInfoTemp.palletList.Clear();
                        }
                    }
                    if (putLineInfoTemp.palletList.Count > 0)
                    {
                        putLineInfoTemp.palletList.Sort((a, b) => -1 * a.CompareTo(b)); // Descending sort
                        putLineInfoTemp.palletList = putLineInfoTemp.palletList.Take(1).ToList();
                        putLineInfoTemp.valid = putAwayStations[putAwayDictKey].props.cam.lineArray[lineIndex.ToString()].valid;
                        putLineInfoTemp.palletWarningKey = putAwayStations[putAwayDictKey].props.cam.lineArray[lineIndex.ToString()].palletWarning;
                        PUTAWAY_LINE_LIST.Add(listLinePutAwayKey, putLineInfoTemp);
                        string addLog = "";
                        for (int i = 0; i < putLineInfoTemp.palletList.Count(); i++)
                        {
                            addLog = addLog + "[" + putLineInfoTemp.palletList[i] + "]";
                        }
                        addLog = "Added line PW: " + listLinePutAwayKey + "-" + addLog;
                        addLog = addLog + "-useable: " + PUTAWAY_LINE_LIST[listLinePutAwayKey].valid;// + "-palletWarningKey: " + PUTAWAY_LINE_LIST[listLinePutAwayKey].palletWarningKey;
                        RegistrationAgent.mainWindowPointer.LogConsole(addLog, "logStation");
                        //LogWriter.LogWrite("Area\\Area" + area, addLog, "PutAway-" + listLinePutAwayKey);
                    }
                }
                else //UPDATE
                {
                    List<int> palletList = new List<int>();
                    for (int palletIndex = NUMBER_OF_PALLET_PER_LINE - 1; palletIndex >= 0; palletIndex--)
                    {
                        if (putAwayStations[putAwayDictKey].props.cam.lineArray[lineIndex.ToString()].palletArray[palletIndex.ToString()] == "no")
                        {
                            palletList.Add(palletIndex);
                        }
                        else if (putAwayStations[putAwayDictKey].props.cam.lineArray[lineIndex.ToString()].palletArray[palletIndex.ToString()] == "yes")
                        //Chỉ lấy nhũng pallet ở dưới phòng pallet được lấy đi ở đầu hàng
                        {
                            palletList.Clear();
                        }
                    }
                    if (palletList.Count > 0)
                    {
                        palletList.Sort((a, b) => -1 * a.CompareTo(b)); // Descending sort
                        palletList = palletList.Take(1).ToList();
                        string updateLog = "";
                        for (int i = 0; i < palletList.Count(); i++)
                        {
                            updateLog = updateLog + "[" + palletList[i] + "]";
                        }
                        if ((!PUTAWAY_LINE_LIST[listLinePutAwayKey].palletList.SequenceEqual(palletList)) ||
                            (PUTAWAY_LINE_LIST[listLinePutAwayKey].valid != putAwayStations[putAwayDictKey].props.cam.lineArray[lineIndex.ToString()].valid) ||
                            (PUTAWAY_LINE_LIST[listLinePutAwayKey].palletWarningKey != putAwayStations[putAwayDictKey].props.cam.lineArray[lineIndex.ToString()].palletWarning))
                        {
                            PUTAWAY_LINE_LIST[listLinePutAwayKey].valid = putAwayStations[putAwayDictKey].props.cam.lineArray[lineIndex.ToString()].valid;
                            PUTAWAY_LINE_LIST[listLinePutAwayKey].palletWarningKey = putAwayStations[putAwayDictKey].props.cam.lineArray[lineIndex.ToString()].palletWarning;
                            PUTAWAY_LINE_LIST[listLinePutAwayKey].palletList = palletList;
                            updateLog = "Updated line PW: " + listLinePutAwayKey + "-" + updateLog;
                            updateLog = updateLog + "-useable: " + PUTAWAY_LINE_LIST[listLinePutAwayKey].valid;// + "-palletWarningKey: " + PUTAWAY_LINE_LIST[listLinePutAwayKey].palletWarningKey;
                            RegistrationAgent.mainWindowPointer.LogConsole(updateLog, "logStation");
                            //LogWriter.LogWrite("Area\\Area" + area, updateLog, "PutAway-" + listLinePutAwayKey);
                        }
                    }
                    else
                    {
                        string deleteLog = "";
                        deleteLog = "Deleted line PW: " + listLinePutAwayKey + "-" + deleteLog;
                        deleteLog = deleteLog + "-useable: " + PUTAWAY_LINE_LIST[listLinePutAwayKey].valid;// + "-palletWarningKey: " + PUTAWAY_LINE_LIST[listLinePutAwayKey].palletWarningKey;
                        RegistrationAgent.mainWindowPointer.LogConsole(deleteLog, "logStation");
                        //LogWriter.LogWrite("Area\\Area" + area, deleteLog, "PutAway-" + listLinePutAwayKey);
                        PUTAWAY_LINE_LIST.Remove(listLinePutAwayKey);
                        //Full roi thi xoa luon Line Putaway
                    }
                }
            }
        }
        
        private void ProcessMixed(string mixedDictKey)
        {

            string stationNameID = mixedDictKey.Split('-')[1];
            int NUMBER_OF_LINE = mixedStations[mixedDictKey].props.cam.numLs;
            int NUMBER_OF_PALLET_PER_LINE = mixedStations[mixedDictKey].props.cam.numPsPL;


            for (int lineIndex = 0; lineIndex < NUMBER_OF_LINE; lineIndex++) //Scan all Line
            {
                string listLineDockingKey = stationNameID + "-" + lineIndex;
                //New or Update
                if (DOCKING_LINE_LIST.ContainsKey(listLineDockingKey) == false) // ==> NEW
                {
                    OrderLineInfo dockLineInfoTemp = new OrderLineInfo
                    {
                        stationNameID = stationNameID,
                        line = lineIndex,
                        orderedPallets = 0,
                        palletList = new List<int>(),
                        ordered = false,
                        removable = false,
                        valid = true,
                        palletWarningKey = "-1"
                    };
                    for (int palletIndex = 0; palletIndex < NUMBER_OF_PALLET_PER_LINE; palletIndex++)
                    {
                        if (mixedStations[mixedDictKey].props.cam.lineArray[lineIndex.ToString()].palletArray[palletIndex.ToString()] == "yes")
                        {
                            dockLineInfoTemp.palletList.Add(palletIndex);
                            dockLineInfoTemp.valid = mixedStations[mixedDictKey].props.cam.lineArray[lineIndex.ToString()].valid;
                            dockLineInfoTemp.palletWarningKey = mixedStations[mixedDictKey].props.cam.lineArray[lineIndex.ToString()].palletWarning;
                            DOCKING_LINE_LIST.Add(listLineDockingKey, dockLineInfoTemp);
                            string addLog = "";
                            for (int i = 0; i < dockLineInfoTemp.palletList.Count(); i++)
                            {
                                addLog = addLog + "[" + dockLineInfoTemp.palletList[i] + "]";
                            }
                            addLog = "Added line DK: " + listLineDockingKey + "-" + addLog;
                            addLog = addLog + "-useable: " + dockLineInfoTemp.valid;// + "-palletWarningKey: " + dockLineInfoTemp.palletWarningKey;
                            RegistrationAgent.mainWindowPointer.LogConsole(addLog, "logStation");
                            //LogWriter.LogWrite("Area\\Area" + area, addLog, "Docking-" + listLineDockingKey);
                            break;
                        }
                    }
                }
                else // Đã tồn tại Line Docking [listLineDockingKey] ==> UPDATE
                {
                    List<int> palletList = new List<int>();
                    for (int palletIndex = 0; palletIndex < NUMBER_OF_PALLET_PER_LINE; palletIndex++)
                    {
                        if (mixedStations[mixedDictKey].props.cam.lineArray[lineIndex.ToString()].palletArray[palletIndex.ToString()] == "yes")
                        {
                            palletList.Add(palletIndex);
                            string updateLog = "";
                            for (int i = 0; i < palletList.Count(); i++)
                            {
                                updateLog = updateLog + "[" + palletList[i] + "]";
                            }
                            if ((!DOCKING_LINE_LIST[listLineDockingKey].palletList.SequenceEqual(palletList)) ||
                                (DOCKING_LINE_LIST[listLineDockingKey].valid != mixedStations[mixedDictKey].props.cam.lineArray[lineIndex.ToString()].valid) ||
                                (DOCKING_LINE_LIST[listLineDockingKey].palletWarningKey != mixedStations[mixedDictKey].props.cam.lineArray[lineIndex.ToString()].palletWarning))
                            {
                                DOCKING_LINE_LIST[listLineDockingKey].valid = mixedStations[mixedDictKey].props.cam.lineArray[lineIndex.ToString()].valid;
                                DOCKING_LINE_LIST[listLineDockingKey].palletWarningKey = mixedStations[mixedDictKey].props.cam.lineArray[lineIndex.ToString()].palletWarning;
                                DOCKING_LINE_LIST[listLineDockingKey].palletList = palletList;
                                updateLog = "Updated line DK: " + listLineDockingKey + "-" + updateLog;
                                updateLog = updateLog + "-useable: " + DOCKING_LINE_LIST[listLineDockingKey].valid;// + "-palletWarningKey: " + DOCKING_LINE_LIST[listLineDockingKey].palletWarningKey;
                                RegistrationAgent.mainWindowPointer.LogConsole(updateLog, "logStation");
                                //LogWriter.LogWrite("Area\\Area" + area, updateLog, "Docking-" + listLineDockingKey);
                            }
                            break;
                        }
                    }
                    if (palletList.Count == 0)
                    {
                        //Trống line thì xóa khỏi List Line Docking
                        string deleteLog = "";
                        deleteLog = "Deleted line DK: " + listLineDockingKey + "-" + deleteLog;
                        deleteLog = deleteLog + "-useable: " + DOCKING_LINE_LIST[listLineDockingKey].valid;// + "-palletWarningKey: " + DOCKING_LINE_LIST[listLineDockingKey].palletWarningKey;
                        RegistrationAgent.mainWindowPointer.LogConsole(deleteLog, "logStation");
                        //LogWriter.LogWrite("Area\\Area" + area, deleteLog, "Docking-" + listLineDockingKey);
                        DOCKING_LINE_LIST.Remove(listLineDockingKey);
                    }
                }
            }


            for (int lineIndex = 0; lineIndex < NUMBER_OF_LINE; lineIndex++)
            {
                string listLinePutAwayKey = stationNameID + "-" + lineIndex;
                //New or Update
                if (PUTAWAY_LINE_LIST.ContainsKey(listLinePutAwayKey) == false) //NEW
                {
                    OrderLineInfo putLineInfoTemp = new OrderLineInfo
                    {
                        stationNameID = stationNameID,
                        line = lineIndex,
                        orderedPallets = 0,
                        palletList = new List<int>(),
                        ordered = false,
                        removable = false,
                        valid = true,
                        palletWarningKey = "-1"
                    };
                    for (int palletIndex = NUMBER_OF_PALLET_PER_LINE - 1; palletIndex >= 0; palletIndex--)
                    {
                        if (mixedStations[mixedDictKey].props.cam.lineArray[lineIndex.ToString()].palletArray[palletIndex.ToString()] == "no")
                        {
                            putLineInfoTemp.palletList.Add(palletIndex);
                        }
                        else if (mixedStations[mixedDictKey].props.cam.lineArray[lineIndex.ToString()].palletArray[palletIndex.ToString()] == "yes")
                        //Chỉ lấy nhũng pallet ở dưới phòng pallet được lấy đi ở đầu hàng
                        {
                            putLineInfoTemp.palletList.Clear();
                        }
                    }
                    if (putLineInfoTemp.palletList.Count > 0)
                    {
                        putLineInfoTemp.palletList.Sort((a, b) => -1 * a.CompareTo(b)); // Descending sort
                        putLineInfoTemp.palletList = putLineInfoTemp.palletList.Take(1).ToList();
                        putLineInfoTemp.valid = mixedStations[mixedDictKey].props.cam.lineArray[lineIndex.ToString()].valid;
                        putLineInfoTemp.palletWarningKey = mixedStations[mixedDictKey].props.cam.lineArray[lineIndex.ToString()].palletWarning;
                        PUTAWAY_LINE_LIST.Add(listLinePutAwayKey, putLineInfoTemp);
                        string addLog = "";
                        for (int i = 0; i < putLineInfoTemp.palletList.Count(); i++)
                        {
                            addLog = addLog + "[" + putLineInfoTemp.palletList[i] + "]";
                        }
                        addLog = "Added line PW: " + listLinePutAwayKey + "-" + addLog;
                        addLog = addLog + "-useable: " + PUTAWAY_LINE_LIST[listLinePutAwayKey].valid;// + "-palletWarningKey: " + PUTAWAY_LINE_LIST[listLinePutAwayKey].palletWarningKey;
                        RegistrationAgent.mainWindowPointer.LogConsole(addLog, "logStation");
                        //LogWriter.LogWrite("Area\\Area" + area, addLog, "PutAway-" + listLinePutAwayKey);
                    }
                }
                else //UPDATE
                {
                    List<int> palletList = new List<int>();
                    for (int palletIndex = NUMBER_OF_PALLET_PER_LINE - 1; palletIndex >= 0; palletIndex--)
                    {
                        if (mixedStations[mixedDictKey].props.cam.lineArray[lineIndex.ToString()].palletArray[palletIndex.ToString()] == "no")
                        {
                            palletList.Add(palletIndex);
                        }
                        else if (mixedStations[mixedDictKey].props.cam.lineArray[lineIndex.ToString()].palletArray[palletIndex.ToString()] == "yes")
                        //Chỉ lấy nhũng pallet ở dưới phòng pallet được lấy đi ở đầu hàng
                        {
                            palletList.Clear();
                        }
                    }
                    if (palletList.Count > 0)
                    {
                        palletList.Sort((a, b) => -1 * a.CompareTo(b)); // Descending sort
                        palletList = palletList.Take(1).ToList();
                        string updateLog = "";
                        for (int i = 0; i < palletList.Count(); i++)
                        {
                            updateLog = updateLog + "[" + palletList[i] + "]";
                        }
                        if ((!PUTAWAY_LINE_LIST[listLinePutAwayKey].palletList.SequenceEqual(palletList)) ||
                            (PUTAWAY_LINE_LIST[listLinePutAwayKey].valid != mixedStations[mixedDictKey].props.cam.lineArray[lineIndex.ToString()].valid) ||
                            (PUTAWAY_LINE_LIST[listLinePutAwayKey].palletWarningKey != mixedStations[mixedDictKey].props.cam.lineArray[lineIndex.ToString()].palletWarning))
                        {
                            PUTAWAY_LINE_LIST[listLinePutAwayKey].valid = mixedStations[mixedDictKey].props.cam.lineArray[lineIndex.ToString()].valid;
                            PUTAWAY_LINE_LIST[listLinePutAwayKey].palletWarningKey = mixedStations[mixedDictKey].props.cam.lineArray[lineIndex.ToString()].palletWarning;
                            PUTAWAY_LINE_LIST[listLinePutAwayKey].palletList = palletList;
                            updateLog = "Updated line PW: " + listLinePutAwayKey + "-" + updateLog;
                            updateLog = updateLog + "-useable: " + PUTAWAY_LINE_LIST[listLinePutAwayKey].valid;// + "-palletWarningKey: " + PUTAWAY_LINE_LIST[listLinePutAwayKey].palletWarningKey;
                            RegistrationAgent.mainWindowPointer.LogConsole(updateLog, "logStation");
                            //LogWriter.LogWrite("Area\\Area" + area, updateLog, "PutAway-" + listLinePutAwayKey);
                        }
                    }
                    else
                    {
                        string deleteLog = "";
                        deleteLog = "Deleted line PW: " + listLinePutAwayKey + "-" + deleteLog;
                        deleteLog = deleteLog + "-useable: " + PUTAWAY_LINE_LIST[listLinePutAwayKey].valid;// + "-palletWarningKey: " + PUTAWAY_LINE_LIST[listLinePutAwayKey].palletWarningKey;
                        RegistrationAgent.mainWindowPointer.LogConsole(deleteLog, "logStation");
                        //LogWriter.LogWrite("Area\\Area" + area, deleteLog, "PutAway-" + listLinePutAwayKey);
                        PUTAWAY_LINE_LIST.Remove(listLinePutAwayKey);
                        //Full roi thi xoa luon Line Putaway
                    }
                }
            }
        }
        
        public List<bool> GetPalletArray(string stationNameID)
        {
            string agentDockingKey = "Docking-" + stationNameID;
            if (dockingStations.ContainsKey(agentDockingKey) == true) //Agent is Docking
            {
                return dockingStations[agentDockingKey].props.palletStatusArray;
            }
            else
            {
                string agentPutAwayKey = "PutAway-" + stationNameID;
                if (putAwayStations.ContainsKey(agentPutAwayKey) == true) //Agent is Put Away
                {
                    return putAwayStations[agentPutAwayKey].props.palletStatusArray;
                }
                else
                {
                    string agentMixedKey = "Mixed-" + stationNameID;
                    if (mixedStations.ContainsKey(agentMixedKey) == true) //Agent is Mixed
                    {
                        return mixedStations[agentMixedKey].props.palletStatusArray;
                    }
                    else
                    {
                        return new List<bool>();
                    }
                }
            }
        }
    }
}