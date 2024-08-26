using LicensingERP.Logic.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LicensingERP.Logic.DTO.Class
{
  public  class RequestRestrict: IRequestRestrict, ISession, IActivity, IIdentity, IStatus
    {
        public int RequestId { get; set; }
        public string RequestNo { get; set; }
        public string RestrictTo { get; set; }
        public string RestrictVal { get; set; }

        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string CreatedBy { get; set; }
        public string SessionId { get; set; }
        public bool IsActive { get; set; }
    }
}
