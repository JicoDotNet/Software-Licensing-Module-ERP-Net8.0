using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Class
{
    public class FollowUp : Request, IUserType, ISession, IActivity, IStatus, IIdentity, IRequestClaim
    {
        public DateTime ClaimDate { get; set; }
        public DateTime AssignDate { get; set; }

        public int ClaimUserId { get; set; }

        //public int Id { get; set; }
        //public int RequestClaimId { get; set; }
        public bool IsFollowUp { get; set; }
        public int NextUserTypeId { get; set; }

        public string FollowUpDoneBy { get; set; }

        //public DateTime TransactionDate { get; set; }
        //public string SessionId { get; set; }
    }
}
