using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.Custom;
using LicensingERP.Logic.DTO.SP;
using DataAccess.MySQL.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensingERP.Logic.BLL
{
    public class WfProcessLogic:ConnectionString
    {
        public WfProcessLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public int Insert(WfProcess wfProcess)
        {
            MySqlDBAccess DAobj = new MySqlDBAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);

            nameValuePairs nvp = new nameValuePairs();
            nvp.Add(new nameValuePair("p_Id", 0));
            nvp.Add(new nameValuePair("p_ProcessName", wfProcess.ProcessName));
            nvp.Add(new nameValuePair("p_ProcessCode", wfProcess.ProcessCode));
            nvp.Add(new nameValuePair("p_IsInitial", wfProcess.IsInitial));
            nvp.Add(new nameValuePair("p_IsEnd", wfProcess.IsEnd));
            nvp.Add(new nameValuePair("p_Description", wfProcess.Description));
            nvp.Add(new nameValuePair("p_LicenceTypeId", wfProcess.LicenceTypeId));
            nvp.Add(new nameValuePair("p_IsActive", true));
            nvp.Add(new nameValuePair("p_SessionId", CommonObj.SessionId));
            nvp.Add(new nameValuePair("p_QueryType", "INSERT"));

            return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetWFProcess, nvp, "Out_Param"));
        }

        public List<WfProcessLicence> GetWfProcess()
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);
            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_QueryType", "ALL"),
                new nameValuePair("p_Id", 0)
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetWFProcess, nameValuePairs).ToList<WfProcessLicence>();
        }
        public WfProcess GetIdByWFProcess(int Id)
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);
            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_QueryType", "ONE"),
                 new nameValuePair("p_Id", Id)
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetWFProcess, nameValuePairs).ToList<WfProcess>().FirstOrDefault();
        }
    }
}
