using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.DashboardClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicensingERP.Models
{
    public class DSClientWiseLicense
    {
        public List<LicenceType> LicenceTypes { get; set; }
        public List<ClientWiseLicenseRequest> ClientWiseLicenseRequests { get; set; }
    }
}
