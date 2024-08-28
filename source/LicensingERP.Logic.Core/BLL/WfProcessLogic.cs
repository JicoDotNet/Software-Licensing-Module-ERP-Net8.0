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
    public class WfProcessLogic:ConnectionString
    {
        public WfProcessLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public int Insert(WfProcess wfProcess)
        {
            MySqlDbAccess DAobj = new MySqlDbAccess(CommonObj.ConnectionString);

            NameValuePairs nvp = new NameValuePairs();
            nvp.Add(new NameValuePair("p_Id", 0));
            nvp.Add(new NameValuePair("p_ProcessName", wfProcess.ProcessName));
            nvp.Add(new NameValuePair("p_ProcessCode", wfProcess.ProcessCode));
            nvp.Add(new NameValuePair("p_IsInitial", wfProcess.IsInitial));
            nvp.Add(new NameValuePair("p_IsEnd", wfProcess.IsEnd));
            nvp.Add(new NameValuePair("p_Description", wfProcess.Description));
            nvp.Add(new NameValuePair("p_LicenceTypeId", wfProcess.LicenceTypeId));
            nvp.Add(new NameValuePair("p_IsActive", true));
            nvp.Add(new NameValuePair("p_SessionId", CommonObj.SessionId));
            nvp.Add(new NameValuePair("p_QueryType", "INSERT"));

            return Convert.ToInt32(DAobj.InsertUpdateDeleteReturnObject(StoreProcedure.SetWFProcess, nvp, "Out_Param"));
        }

        public List<WfProcessLicence> GetWfProcess()
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);
            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_QueryType", "ALL"),
                new NameValuePair("p_Id", 0)
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetWFProcess, NameValuePairs).ToList<WfProcessLicence>();
        }
        public WfProcess GetIdByWFProcess(int Id)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);
            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_QueryType", "ONE"),
                 new NameValuePair("p_Id", Id)
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetWFProcess, NameValuePairs).ToList<WfProcess>().FirstOrDefault();
        }
    }
}
