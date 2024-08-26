using LicensingERP.Logic.DTO.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicensingERP.Models
{
    public class LicencetypeParameter
    {
        public IReadOnlyList<Parameter> parameters { get; set; }
        public IReadOnlyList<LicenceType> licenceTypes { get; set; }
        public IReadOnlyList<ParameterOfLicence> parameterOfLicence { get; set; }
        public LicenceType licenceType { get; set; }
    }
}
