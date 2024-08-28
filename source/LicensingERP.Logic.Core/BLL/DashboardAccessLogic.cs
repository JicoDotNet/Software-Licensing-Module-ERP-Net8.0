using LicensingERP.Logic.BLL.Dashboard;
using LicensingERP.Logic.Common;
using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.SP;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataAccess.MySql;

namespace LicensingERP.Logic.BLL
{
    public class DashboardAccessLogic : DashboardLogic
    {
        public DashboardAccessLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public List<DTO.Class.Dashboard> GetAccessPermission(int UserTypeId)
        {
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);
            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_QueryType", "FORUSER"),
                new NameValuePair("p_UserTypeId", UserTypeId)
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetDashboardForUser, NameValuePairs).ToList<DTO.Class.Dashboard>();
        }

        public List<DTO.Class.Dashboard> DashboardList()
        {
            return GetDashboardValue(new DashboardParam { p_QueryType = "DASHBOARDLIST" })
                .Tables[0].ToList<DTO.Class.Dashboard>();
        }
        public DTO.Class.Dashboard DashboardList(int Id)
        {
            MySqlDbAccess mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString);
            NameValuePairs NameValuePairs = new NameValuePairs
            {
                new NameValuePair("p_QueryType","ONE"),
                new NameValuePair("p_ClientId", 0),
                new NameValuePair("p_Id",Id)
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetDashboard, NameValuePairs).ToList<DTO.Class.Dashboard>().FirstOrDefault();
        }
            
    }
}
