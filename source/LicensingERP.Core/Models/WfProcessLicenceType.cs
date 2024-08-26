using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicensingERP.Models
{
    public class WfProcessLicenceType
    {
        public IReadOnlyList<WfProcessLicence> wfprocess { get; set; }
        public IReadOnlyList<LicenceType> licenceType { get; set; }
    }
}
