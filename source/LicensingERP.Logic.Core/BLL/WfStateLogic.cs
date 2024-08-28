using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
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
    public class WfStateLogic : ConnectionString
    {
        public WfStateLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public List<WfState> GetWfState()
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);
            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_UserTypeId", null),
                new NameValuePair("p_LicenceTypeId", null),
                new NameValuePair("p_OueryType", "ALL")
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetWfState, NameValuePairs).ToList<WfState>();
        }

        public List<WfState> GetWfState(int UserTypeId, int LicenceTypeId, bool ForFirstRequisition)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);
            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_UserTypeId", UserTypeId),
                new NameValuePair("p_LicenceTypeId", LicenceTypeId),
                new NameValuePair("p_OueryType", ForFirstRequisition? "FORWFFIRST" : "FORWFNEXT")
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetWfState, NameValuePairs).ToList<WfState>();
        }
    }
}
