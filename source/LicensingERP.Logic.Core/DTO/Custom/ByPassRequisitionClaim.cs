using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Custom
{
   public class ByPassRequisitionClaim
    {
        public string BUserGroupName { get; set; }
        public string BUserName { get; set; }
        public int BUserId { get; set; }
        public int BNextUserTypeId { get; set; }
    }
}
