using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Custom
{
    public class RequestAndParameters
    {
        public IReadOnlyList<Parameter> Parameters { get; set; }
        public Request Request { get; set; }
    }
}
