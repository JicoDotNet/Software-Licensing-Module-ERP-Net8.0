using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Custom
{
    public class WfProcessLicence: WfProcess, ILicenceType
    {
       public string TypeName { get; set; }
        public string LicenceTypeDetails { get; set; }
       public int NumberOfLicence { get; set; }
       public bool IsScalingEligible { get; set; }
    }
}
