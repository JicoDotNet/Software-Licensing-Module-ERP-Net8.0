using LicensingERP.Logic.DTO.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicensingERP.Models
{
    public class _Parameter
    {
        public IReadOnlyList<Parameter> parameters { get; set; }
        public Parameter parameter { get; set; }
    }
}
