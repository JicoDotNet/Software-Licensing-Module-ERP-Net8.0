using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.DashboardClass;
using LicensingERP.Logic.DTO.SP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LicensingERP.Logic.BLL.Dashboard
{
    public class DSApprovalPendingLogic : DashboardLogic
    {
        public DSApprovalPendingLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public List<ProductWiseLicense> GetGraphData()
        {
            List<ProductWiseLicense> objs = new List<ProductWiseLicense>();

            objs = GetDashboardValue(new DashboardParam { p_QueryType = "ApprovalPending" })
                .Tables[0].ToList<ProductWiseLicense>();

            return objs;
        }
    }
}
