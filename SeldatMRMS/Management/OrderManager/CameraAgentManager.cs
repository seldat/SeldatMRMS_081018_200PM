using SeldatMRMS.Model;
using System;

namespace SeldatMRMS.Management.OrderManager
{
    public class CameraAgentManager
    {

        public CameraAgentManager()
        {

        }
        public bool CreateCameraAgentD(String AreaID, StationModel cameraAgent)
        {
            //if (RegistrationAgent.areaList.ContainsKey(AreaID) == false)
            //{
            //    RegistrationAgent.areaList.Add(AreaID, new Area(AreaID));
            //    return RegistrationAgent.areaList[AreaID].AddDocking(cameraAgent);
            //}
            //else
            //{
            //    return RegistrationAgent.areaList[AreaID].AddDocking(cameraAgent);
            //}
            //cameraAgent.dataHandle += dataHandleD;
            return false;
        }

        public bool CreateCameraAgentP(String AreaID, StationModel cameraAgent)
        {
            //if (RegistrationAgent.areaList.ContainsKey(AreaID) == false)
            //{
            //    RegistrationAgent.areaList.Add(AreaID, new Area(AreaID));
            //    return RegistrationAgent.areaList[AreaID].AddPutAway(cameraAgent);
            //}
            //else
            //{
            //    return RegistrationAgent.areaList[AreaID].AddPutAway(cameraAgent);
            //}
            //cameraAgent.dataHandle += dataHandleP;
            return false;
        }

        public bool CreateCameraAgentM(String AreaID, StationModel cameraAgent)
        {
            //if (RegistrationAgent.areaList.ContainsKey(AreaID) == false)
            //{
            //    RegistrationAgent.areaList.Add(AreaID, new Area(AreaID));
            //    return RegistrationAgent.areaList[AreaID].AddMixed(cameraAgent);
            //}
            //else
            //{
            //    return RegistrationAgent.areaList[AreaID].AddMixed(cameraAgent);
            //}
            //cameraAgent.dataHandle += dataHandleM;
            return false;
        }


        public void RemoveCameraAgent(StationModel cameraAgent)
        {

        }
    }
}


