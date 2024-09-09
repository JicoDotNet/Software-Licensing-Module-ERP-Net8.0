using LicensingERP.Logic.DTO.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicensingERP.Areas.Report.Models
{
    public class UsertypeState
    {        
        public IReadOnlyList<UserType> UserTypes { get; set; }
        public IReadOnlyList<WfState> WfStates { get; set; }
    }
}
