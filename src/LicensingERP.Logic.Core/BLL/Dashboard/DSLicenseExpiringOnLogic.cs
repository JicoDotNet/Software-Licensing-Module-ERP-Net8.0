using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.DashboardClass;
using LicensingERP.Logic.DTO.SP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LicensingERP.Logic.BLL.Dashboard
{
    public class DSLicenseExpiringOnLogic : DashboardLogic
    {
        public DSLicenseExpiringOnLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public List<RequestWiseLicense> GetGraphData()
        {
            List<RequestWiseLicense> objs = new List<RequestWiseLicense>();

            objs = GetDashboardValue(new DashboardParam { p_QueryType = "LicenseExpiringOn" })
                .Tables[0].ToList<RequestWiseLicense>();

            return objs;
        }
    }
}
