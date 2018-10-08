
using SeldatMRMS.Management.RobotManagent;
using SeldatMRMS.Management.TrafficManager;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeldatMRMS.Management.OrderManager
{
    public class Orders
    {
        public delegate void RequestToReadyArea(String msg);
        public RequestToReadyArea requestToReadyArea;
        public void addReadyAreaDepends(ReadyArea readyArea)
        {
            //readyArea.onRequestANewOrder += RequestOrder;
            //readyArea.onFinishAnOrder += OrderFinished;
        }


        public String[] RequestDockingOrderLine(int area, string robotID)
        {
            RegistrationAgent.mainWindowPointer.LogConsole("In RequestDockingOrderLine", "logOrder");
            String[] data = null;
            try
            {
                string areaID = area.ToString();
                string listLineDockingKey = RegistrationAgent.areaList[areaID].GetDockingLine();
                if (listLineDockingKey != "none")
                {
                    int agentID = Int32.Parse(listLineDockingKey.Split('-')[0]);
                    int lposdk = Int32.Parse(listLineDockingKey.Split('-')[1]);
                    if (RegistrationAgent.areaList[areaID].DOCKING_LINE_LIST.ContainsKey(listLineDockingKey))
                    {
                        data = new String[3];
                        data[0] = DataTranformation.jsonDockingLine(area, agentID, lposdk);
                        data[1] = agentID.ToString();
                        data[2] = lposdk.ToString();
                        RegistrationAgent.mainWindowPointer.LogConsole("GET DOCKING:" + agentID + "-" + lposdk, "logOrder");
                        return data;
                    }
                    RegistrationAgent.mainWindowPointer.LogConsole("No-listlinedocking-" + listLineDockingKey, "logOrder");
                }
                RegistrationAgent.mainWindowPointer.LogConsole("In RequestDockingOrderLine-no list line docking key-" + listLineDockingKey, "logOrder");
            }
            catch
            {
                RegistrationAgent.mainWindowPointer.LogConsole("Error when RequestDockingOrderLine: Area:" + area + "-Robot:" + robotID, "logOrder");
            }
            RegistrationAgent.mainWindowPointer.LogConsole("Last RequestDockingOrderLine", "logOrder");
            return data;
        }

        public String[] RequestDockingOrderPallet(int area, string robotID, string agentID, string line)
        {
            RegistrationAgent.mainWindowPointer.LogConsole("In RequestDockingOrderPallet", "logOrder");
            String[] data = null;
            try
            {
                string areaID = area.ToString();
                List<int> palletnumsdk = new List<int>();
                if (RegistrationAgent.areaList[areaID].DOCKING_LINE_LIST.ContainsKey(agentID + "-" + line) &&
                   RegistrationAgent.areaList[areaID].DOCKING_LINE_LIST[agentID + "-" + line].GetPallet(palletnumsdk))
                {
                    data = new String[4];
                    data[0] = DataTranformation.jsonDockingPallet(area, Int32.Parse(agentID), Int32.Parse(line), palletnumsdk.First());
                    data[1] = agentID.ToString();
                    data[2] = line.ToString();
                    data[3] = palletnumsdk.First().ToString();
                    RegistrationAgent.mainWindowPointer.LogConsole("DOCKING :" + data[1] + "-" + data[2] + "-" + data[3], "logOrder");
                    return data;
                }
                RegistrationAgent.mainWindowPointer.LogConsole("Error when RequestDockingOrderPallet1: Area:" + area + "-Robot:" + robotID + "-agentID:" + agentID + "-line:" + line, "logOrder");
            }
            catch
            {
                RegistrationAgent.mainWindowPointer.LogConsole("Error when RequestDockingOrderPallet2: Area:" + area + "-Robot:" + robotID + "-agentID:" + agentID + "-line:" + line, "logOrder");
            }
            return data;
        }

        public String[] RequestPutAwayOrderLine(int area, string robotID)
        {
            RegistrationAgent.mainWindowPointer.LogConsole("In RequestPutAwayOrderLine", "logOrder");
            String[] data = null;
            try
            {
                string areaID = area.ToString();
                string listLinePutAwayKey = RegistrationAgent.areaList[areaID].GetPutAwayLine();
                if (listLinePutAwayKey != "none")
                {
                    int agentID = Int32.Parse(listLinePutAwayKey.Split('-')[0]);
                    int lpospw = Int32.Parse(listLinePutAwayKey.Split('-')[1]);
                    if (RegistrationAgent.areaList[areaID].PUTAWAY_LINE_LIST.ContainsKey(listLinePutAwayKey))
                    {
                        data = new String[3];
                        data[0] = DataTranformation.jsonPutAwayLine(area, agentID, lpospw);
                        data[1] = agentID.ToString();
                        data[2] = lpospw.ToString();
                        RegistrationAgent.mainWindowPointer.LogConsole("PUT PUTAWAY:" + agentID + "-" + lpospw, "logOrder");
                        return data;
                    }
                    RegistrationAgent.mainWindowPointer.LogConsole("No-listlineputaway-" + listLinePutAwayKey, "logOrder");
                }
                RegistrationAgent.mainWindowPointer.LogConsole("In RequestPutAwayOrderLine-no list line docking key-" + listLinePutAwayKey, "logOrder");
            }
            catch
            {
                RegistrationAgent.mainWindowPointer.LogConsole("Error when RequestPutAwayOrderLine: Area:" + area + "-Robot:" + robotID, "logOrder");
            }
            RegistrationAgent.mainWindowPointer.LogConsole("Last RequestPutAwayOrderLine", "logOrder");
            return data;
        }


        public String[] RequestPutAwayOrderPallet(int area, string robotID, string agentID, string line)
        {
            RegistrationAgent.mainWindowPointer.LogConsole("In RequestPutAwayOrderPallet", "logOrder");
            String[] data = null;
            try
            {
                string areaID = area.ToString();
                List<int> palletnumspw = new List<int>();
                if (RegistrationAgent.areaList[areaID].PUTAWAY_LINE_LIST.ContainsKey(agentID + "-" + line) &&
                   RegistrationAgent.areaList[areaID].PUTAWAY_LINE_LIST[agentID + "-" + line].GetPallet(palletnumspw))
                {
                    data = new String[4];
                    data[0] = DataTranformation.jsonPutAwayPallet(area, Convert.ToInt32(agentID), Convert.ToInt32(line), palletnumspw.First());
                    data[1] = agentID.ToString();
                    data[2] = line.ToString();
                    data[3] = palletnumspw.First().ToString();
                    RegistrationAgent.mainWindowPointer.LogConsole("PUT PUTAWAY:" + data[1] + "-" + data[2] + "-" + data[3], "logOrder");
                    return data;
                }
                RegistrationAgent.mainWindowPointer.LogConsole("Error when RequestPutAwayOrderPallet1: Area:" + area + "-Robot:" + robotID + "-agentID:" + agentID + "-line:" + line, "logOrder");
            }
            catch
            {
                RegistrationAgent.mainWindowPointer.LogConsole("Error when RequestPutAwayOrderPallet2: Area:" + area + "-Robot:" + robotID + "-agentID:" + agentID + "-line:" + line, "logOrder");
            }
            return data;
        }

        public bool ReleaseDockingOrder(string areaID, string dockingAgentID, string lineOrdered, string palletIndex)
        {
            Console.WriteLine("Call Docking Remove");
            if (RegistrationAgent.areaList.ContainsKey(areaID))
            {
                if (RegistrationAgent.areaList[areaID].DOCKING_LINE_LIST.ContainsKey(dockingAgentID + "-" + lineOrdered))
                {
                    RegistrationAgent.areaList[areaID].DOCKING_LINE_LIST.Remove(dockingAgentID + "-" + lineOrdered);
                    string messLog = "Removed Docking Order: " + dockingAgentID + "-" + lineOrdered + "-" + palletIndex;
                    RegistrationAgent.mainWindowPointer.LogConsole(messLog, "logOrder");
                    LogWriter.LogWrite("Area\\Area" + 0, messLog, "Docking-" + dockingAgentID + "-" + lineOrdered);
                    return true;
                }
                RegistrationAgent.mainWindowPointer.LogConsole("There is no Docking agent: " + dockingAgentID, "logOrder");
                return false;
            }
            RegistrationAgent.mainWindowPointer.LogConsole("There is no area: " + areaID, "logOrder");
            return false;
        }

        public bool ReleasePutAwayOrder(string areaID, string putAwayAgentID, string lineOrdered, string palletIndex)
        {
            Console.WriteLine("Call PutAway Remove");
            if (RegistrationAgent.areaList.ContainsKey(areaID))
            {
                if (RegistrationAgent.areaList[areaID].PUTAWAY_LINE_LIST.ContainsKey(putAwayAgentID + "-" + lineOrdered))
                {
                    RegistrationAgent.areaList[areaID].PUTAWAY_LINE_LIST.Remove(putAwayAgentID + "-" + lineOrdered);
                    string messLog = "Removed Put-Away Order: " + putAwayAgentID + "-" + lineOrdered + "-" + palletIndex;
                    RegistrationAgent.mainWindowPointer.LogConsole(messLog, "logOrder");
                    LogWriter.LogWrite("Area\\Area" + 0, messLog, "PutAway-" + putAwayAgentID + "-" + lineOrdered);
                    return true;
                }
                RegistrationAgent.mainWindowPointer.LogConsole("There is no Put-Away agent: " + putAwayAgentID, "logOrder");
                return false;
            }
            RegistrationAgent.mainWindowPointer.LogConsole("There is no area: " + areaID, "logOrder");
            return false;
        }

    }
}
