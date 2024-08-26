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
    public class WfProcessAssignLogic : ConnectionString
    {
        public WfProcessAssignLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public int Insert(WfProcessAssign wfProcessAssign)
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);
            nameValuePairs nvp = new nameValuePairs
            {
                new nameValuePair("p_WFProcessId", wfProcessAssign.WFProcessId),
                new nameValuePair("p_StateId", wfProcessAssign.StateId),
                new nameValuePair("p_FromUserTypeId", wfProcessAssign.FormUserTypeId),
                new nameValuePair("p_ToUserTypeId", wfProcessAssign.ToUserTypeId),
                new nameValuePair("p_ActivityStartDate", GenericLogic.IstNow),
                new nameValuePair("p_SessionId", CommonObj.SessionId),
                new nameValuePair("p_QueryType", "INSERT")
            };

            return Convert.ToInt32(mySqlDBAccess.InsertUpdateDeleteReturnObject(StoreProcedure.SetWFProcessAssign, nvp, "Out_Param"));
        }

        public List<WfAssign> GetWfProcessAssigns()
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);
            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_QueryType", "ALL"),
                new nameValuePair("p_LicenceTypeId", 0)
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetWFProcessAssign, nameValuePairs).ToList<WfAssign>();
        }
        public List<WfAssign> GetWfProcessAssigns(int LicenceTypeId)
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);
            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_QueryType", "FORLICENSE"),
                new nameValuePair("p_LicenceTypeId", LicenceTypeId)
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetWFProcessAssign, nameValuePairs).ToList<WfAssign>();
        }
    }
}
