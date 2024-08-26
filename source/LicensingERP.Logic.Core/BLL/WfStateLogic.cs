using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
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
    public class WfStateLogic : ConnectionString
    {
        public WfStateLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public List<WfState> GetWfState()
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);
            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_UserTypeId", null),
                new nameValuePair("p_LicenceTypeId", null),
                new nameValuePair("p_OueryType", "ALL")
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetWfState, nameValuePairs).ToList<WfState>();
        }

        public List<WfState> GetWfState(int UserTypeId, int LicenceTypeId, bool ForFirstRequisition)
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);
            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_UserTypeId", UserTypeId),
                new nameValuePair("p_LicenceTypeId", LicenceTypeId),
                new nameValuePair("p_OueryType", ForFirstRequisition? "FORWFFIRST" : "FORWFNEXT")
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetWfState, nameValuePairs).ToList<WfState>();
        }
    }
}
