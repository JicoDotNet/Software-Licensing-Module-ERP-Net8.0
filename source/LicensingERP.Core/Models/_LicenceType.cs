using LicensingERP.Logic.DTO.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicensingERP.Models
{
    public class _LicenceType
    {
        public IReadOnlyList<LicenceType> licenceTypes { get; set; }
        public LicenceType licenceType { get; set; }
    }
}
