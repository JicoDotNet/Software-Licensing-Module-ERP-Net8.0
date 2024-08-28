using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.SP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DataAccess.MySql;

namespace LicensingERP.Logic.BLL.Dashboard
{
    public class DashboardLogic : ConnectionString
    {
        public DashboardLogic(sCommonDto CommonObj) : base(CommonObj) { }

        protected DataSet GetDashboardValue(DashboardParam dashboardParam)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);
            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_QueryType", dashboardParam.p_QueryType),
                new NameValuePair("p_ClientId", dashboardParam.p_ClientId),
                new NameValuePair("p_Id",0)
            };
            return mySqlDBAccess.GetDataSet(StoreProcedure.GetDashboard, NameValuePairs);
        }
    }
}
