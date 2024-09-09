using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.DashboardClass;
using LicensingERP.Logic.DTO.SP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LicensingERP.Logic.BLL.Dashboard
{
    public class DSClientWiseLicenseRequestLogic : DashboardLogic
    {
        public DSClientWiseLicenseRequestLogic(sCommonDto CommonObj) : base(CommonObj) { }

        public List<ClientWiseLicenseRequest> GetGraphData()
        {
            List<ClientWiseLicenseRequest> clientWiseLicenseRequests = new List<ClientWiseLicenseRequest>();

            clientWiseLicenseRequests = GetDashboardValue(new DashboardParam { p_QueryType = "CLIENTWISELICENSEREQUESTCLIENT" })
                .Tables[0].ToList<ClientWiseLicenseRequest>();

            for (int i = 0; i < clientWiseLicenseRequests.Count; i++)
            {
                clientWiseLicenseRequests[i].RequestWiseLicenses
                    = GetDashboardValue(new DashboardParam { p_QueryType = "CLIENTWISELICENSEREQUEST",
                    p_ClientId = clientWiseLicenseRequests[i].ClientId
                    }).Tables[0].ToList<RequestWiseLicense>(); ;
            }
            return clientWiseLicenseRequests;
        }
    }
}
