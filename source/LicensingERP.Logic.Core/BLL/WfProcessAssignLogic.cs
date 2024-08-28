using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.Custom;
using LicensingERP.Logic.DTO.SP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.MySql;

namespace LicensingERP.Logic.BLL
{
    public class WfProcessAssignLogic : ConnectionString
    {
        public WfProcessAssignLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public int Insert(WfProcessAssign wfProcessAssign)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);
            NameValuePairs nvp = new NameValuePairs
            {
                new NameValuePair("p_WFProcessId", wfProcessAssign.WFProcessId),
                new NameValuePair("p_StateId", wfProcessAssign.StateId),
                new NameValuePair("p_FromUserTypeId", wfProcessAssign.FormUserTypeId),
                new NameValuePair("p_ToUserTypeId", wfProcessAssign.ToUserTypeId),
                new NameValuePair("p_ActivityStartDate", GenericLogic.IstNow),
                new NameValuePair("p_SessionId", CommonObj.SessionId),
                new NameValuePair("p_QueryType", "INSERT")
            };

            return Convert.ToInt32(mySqlDBAccess.InsertUpdateDeleteReturnObject(StoreProcedure.SetWFProcessAssign, nvp, "Out_Param"));
        }

        public List<WfAssign> GetWfProcessAssigns()
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);
            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_QueryType", "ALL"),
                new NameValuePair("p_LicenceTypeId", 0)
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetWFProcessAssign, NameValuePairs).ToList<WfAssign>();
        }
        public List<WfAssign> GetWfProcessAssigns(int LicenceTypeId)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);
            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_QueryType", "FORLICENSE"),
                new NameValuePair("p_LicenceTypeId", LicenceTypeId)
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetWFProcessAssign, NameValuePairs).ToList<WfAssign>();
        }
    }
}
