using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.DashboardClass
{
    public class ProductWiseLicense
    {
        public string ProductName { get; set; }
        public string UserTypeName { get; set; }
        public long LicenceCount { get; set; }
    }
}
