using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.SP;
using DataAccess.MySQL.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LicensingERP.Logic.BLL.Dashboard
{
    public class DashboardLogic : ConnectionString
    {
        public DashboardLogic(sCommonDto CommonObj) : base(CommonObj) { }

        protected DataSet GetDashboardValue(DashboardParam dashboardParam)
        {
            mySqlDBAccess = new MySqlDBAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);
            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_QueryType", dashboardParam.p_QueryType),
                new nameValuePair("p_ClientId", dashboardParam.p_ClientId),
                new nameValuePair("p_Id",0)
            };
            return mySqlDBAccess.GetDataSet(StoreProcedure.GetDashboard, nameValuePairs);
        }
    }
}
