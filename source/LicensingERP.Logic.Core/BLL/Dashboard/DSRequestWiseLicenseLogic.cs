using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.DashboardClass;
using LicensingERP.Logic.DTO.SP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LicensingERP.Logic.BLL.Dashboard
{
    public class DSRequestWiseLicenseLogic : DashboardLogic
    {
        public DSRequestWiseLicenseLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public List<RequestWiseLicense> GetGraphData()
        {
            return GetDashboardValue(new DashboardParam { p_QueryType = "REQUESTWISELICENSE" }).Tables[0].ToList<RequestWiseLicense>();
        }
    }
}
