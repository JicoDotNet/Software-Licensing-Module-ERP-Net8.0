using LicensingERP.Logic.DTO.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicensingERP.Models
{
    public class RequestProceed
    {
        public RequisitionRequest LicenseRequest { get; set; }
        public List<WfState> WfStates { get; set; }
        public List<RequestAcknowledgement> RequestAcknowledgements { get; set; }
    }
}
