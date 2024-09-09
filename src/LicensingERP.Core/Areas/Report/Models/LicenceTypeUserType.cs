using LicensingERP.Logic.DTO.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicensingERP.Areas.Report.Models
{
    public class LicenceTypeUserType
    {
        public IReadOnlyList<LicenceType> licenceType { get; set; }
        public IReadOnlyList<UserType> userTypes { get; set; }
    }
}
