using LicensingERP.Logic.DTO.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.DashboardClass
{
    public class ClientWiseLicenseRequest
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public List<RequestWiseLicense> RequestWiseLicenses { get; set; }
    }
}
