using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Class
{
    public class RequestStatus : Request, IRequestStatus
    {
        public bool? IsApproved { get; set; }
        public DateTime ApproveRejectDate { get; set; }
        public string Remarks { get; set; }

        public TimeSpan TurnAroundTime { get; set; }
    }
}
