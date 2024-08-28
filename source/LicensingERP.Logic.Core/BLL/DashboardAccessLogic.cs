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
            mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, CommandType.StoredProcedure);
            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_QueryType", "FORUSER"),
                new nameValuePair("p_UserTypeId", UserTypeId)
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetDashboardForUser, nameValuePairs).ToList<DTO.Class.Dashboard>();
        }

        public List<DTO.Class.Dashboard> DashboardList()
        {
            return GetDashboardValue(new DashboardParam { p_QueryType = "DASHBOARDLIST" })
                .Tables[0].ToList<DTO.Class.Dashboard>();
        }
        public DTO.Class.Dashboard DashboardList(int Id)
        {
            MySqlDbAccess mySqlDBAccess = new MySqlDbAccess(CommonObj.ConnectionString, System.Data.CommandType.StoredProcedure);
            nameValuePairs nameValuePairs = new nameValuePairs
            {
                new nameValuePair("p_QueryType","ONE"),
                new nameValuePair("p_ClientId", 0),
                new nameValuePair("p_Id",Id)
            };
            return mySqlDBAccess.GetData(StoreProcedure.GetDashboard, nameValuePairs).ToList<DTO.Class.Dashboard>().FirstOrDefault();
        }
            
    }
}
