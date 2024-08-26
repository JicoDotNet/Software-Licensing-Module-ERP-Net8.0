using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.DashboardClass
{
    public class RequestWiseLicense
    {
        public string TypeName { get; set; }
        public long LicenseCount { get; set; }
        public int RemainingDays { get; set; }
    }
}
