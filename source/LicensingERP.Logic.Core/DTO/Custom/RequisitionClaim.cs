using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Custom
{
  public  class RequisitionClaim : ISession, IIdentity, IStatus
    {

        public int Id { get; set; }
        public bool IsActive { get; set; }

        public int RequestId { get; set; }
        public string  RequestNo { get; set; }
        public int NextUserTypeId { get; set; }
        public int ClaimUserId { get; set; }
        public DateTime ? ClaimDate { get; set; }
        public DateTime ? AssignDate { get; set; }




        public string SessionId { get; set; }

    }
}
