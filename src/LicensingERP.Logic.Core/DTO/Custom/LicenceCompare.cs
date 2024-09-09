using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Custom
{
    public class LicenceCompare 
    {
        public string RequestNo { get; set; }
        public string ClientName { get; set; } 
        public string TypeName { get; set; }
        public string ProductName { get; set; }
        public string LicenceNo { get; set; }
        public int ClientId { get; set; }
        public int LicenceTypeId { get; set; }
        public int ProductId { get; set; }
    }
}
