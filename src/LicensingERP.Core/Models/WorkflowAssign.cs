using LicensingERP.Logic.DTO.Class;
using LicensingERP.Logic.DTO.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LicensingERP.Models
{
    public class WorkflowAssign
    {
        public IReadOnlyList<WfState> state { get; set; }
        public IReadOnlyList<UserType> userTypes { get; set; }
        public IReadOnlyList<WfProcess> wfProcesses { get; set; }
        public IReadOnlyList<WfAssign> wfAssigns { get; set; }

        public IReadOnlyList<LicenceType> licenceTypes { get; set; }
        public LicenceType licenceType { get; set; }
    }
}