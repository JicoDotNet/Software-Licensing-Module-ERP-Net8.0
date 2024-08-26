using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.DashboardClass;
using LicensingERP.Logic.DTO.SP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LicensingERP.Logic.BLL.Dashboard
{
    public class DSGroupWiseUserLogic: DashboardLogic
    {
        public DSGroupWiseUserLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public List<GroupWiseUser> GetGraphData()
        {
            return GetDashboardValue(new DashboardParam { p_QueryType = "GROUPWISEUSER" }).Tables[0].ToList<GroupWiseUser>();          
        }
    }
}
